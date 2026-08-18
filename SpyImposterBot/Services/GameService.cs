using SpyImposterBot.Database;
using SpyImposterBot.Enums;
using System.Text.Json;
using Telegram.Bot.Types;
using Microsoft.EntityFrameworkCore;

internal class GameService : IGameService
{
    private const int PairedWordsPackId = 4;
    
    private readonly AppDbContext _db;
    public GameService(AppDbContext db) 
    {
        _db = db;
    }

    public async Task<Word> GetRandomWordAsync(int packId)
    {
        var count = await _db.Words.CountAsync(w => w.PackId == packId);

        if (count == 0)
            throw new Exception("No words in pack");

        var index = Random.Shared.Next(count);

        return await _db.Words
            .Where(w => w.PackId == packId)
            .Skip(index)
            .FirstAsync();
    }

    public async Task<GameSession> CreateGameAsync(int playersCount, int packId)
    {
        var pack = await _db.WordPacks.FindAsync((long)packId)
            ?? throw new Exception("Pack not found");

        if (packId == PairedWordsPackId)
            return await CreatePairedWordsGameAsync(playersCount, pack);
        
        return await CreateClassicGameAsync(playersCount, pack);
    }

    private async Task<GameSession> CreateClassicGameAsync(int playersCount, WordPack pack)
    {
        var wordEntity = await GetRandomWordAsync((int)pack.Id);

        var spyIndex = Random.Shared.Next(playersCount);

        var players = new List<GamePlayer>();

        for (int i = 0; i < playersCount; i++)
        {
            players.Add(new GamePlayer
            {
                Role = i == spyIndex ? Role.Spy : Role.Civilian,
                Word = i == spyIndex ? null : wordEntity.Value
            });
        }

        var state = new GameState { Players = players };

        return new GameSession
        {
            PackId = pack.Id,
            Word = wordEntity.Value,
            ImageFileId = wordEntity.ImageFileId,
            HasImages = pack.HasImage,
            PlayersData = JsonSerializer.Serialize(state),
            CurrentPlayerIndex = 0,
            Status = GameStatus.in_progress
        };
    }
    
    private async Task<GameSession> CreatePairedWordsGameAsync(int playersCount, WordPack pack)
    {
        var pairs = await _db.Words
            .Where(w =>
                w.PackId == pack.Id &&
                w.PairId != null)
            .GroupBy(w => w.PairId)
            .Where(g => g.Count() == 2)
            .Select(g => g.ToList())
            .ToListAsync();
        
        if (pairs.Count == 0)
            throw new Exception("No word pairs in pack");
        
        var pair = pairs[Random.Shared.Next(pairs.Count)];

        var commonWord = pair[0].Value;
        var differentWord = pair[1].Value;
        
        var spyIndex = Random.Shared.Next(playersCount);
        
        var players = new List<GamePlayer>();

        for (int i = 0; i < playersCount; i++)
        {
            var isSpy = i == spyIndex;
            players.Add(new GamePlayer
            {
                Role = isSpy ? Role.Spy : Role.Civilian,
                Word = isSpy ? differentWord : commonWord,
            });
        }
        // var players = CreatePairedPlayers(playersCount, commonWord.Value, differentWord.Value);
        
        var state = new GameState { Players = players };

        return new GameSession
        {
            PackId = pack.Id,
            Word = $"{commonWord} / {differentWord}",
            ImageFileId = null,
            HasImages = false,
            PlayersData = JsonSerializer.Serialize(state),
            CurrentPlayerIndex = 0,
            Status = GameStatus.in_progress
        };
    }
    
    
    public GamePlayer GetPlayer(GameSession game)
    {
        var state = JsonSerializer.Deserialize<GameState>(game.PlayersData) 
            ?? throw new Exception("Invalid game state");
        return state.Players[game.CurrentPlayerIndex];
    }

    public void NextPlayer(GameSession game)
    {
        var state = JsonSerializer.Deserialize<GameState>(game.PlayersData)
            ?? throw new Exception("Invalid game state");

        game.CurrentPlayerIndex++;

        if (game.CurrentPlayerIndex >= state.Players.Count)
            game.Status = GameStatus.finished;
        
    }
}
