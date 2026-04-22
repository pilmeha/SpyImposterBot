using SpyImposterBot.Database;
using SpyImposterBot.Enums;
using System.Text.Json;
using Telegram.Bot.Types;
using Microsoft.EntityFrameworkCore;

internal class GameService : IGameService
{
    private readonly AppDbContext _db;
    public GameService(AppDbContext db) 
    {
        _db = db;
    }

    public async Task<string> GetRandomWordAsync(int packId)
    {
        var count = await _db.Words.CountAsync(w => w.PackId == packId);
        var index = new Random().Next(count);
        return await _db.Words
            .Where(w => w.PackId == packId)
            .Skip(index)
            .Select(w => w.Value)
            .FirstAsync();
    }

    public async Task<GameSession> CreateGameAsync(int playersCount, int packId)
    {
        var word = await GetRandomWordAsync(packId);

        var rnd = new Random();
        var spyIndex = rnd.Next(playersCount);

        var players = new List<GamePlayer>();

        for (int i = 0; i < playersCount; i++)
        {
            players.Add(new GamePlayer
            {
                Role = i == spyIndex ? Role.Spy : Role.Civilian,
                Word = i == spyIndex ? null : word
            });
        }

        var state = new GameState { Players = players };

        return new GameSession
        {
            PackId = packId,
            Word = word,
            PlayersData = JsonSerializer.Serialize(state),
            CurrentPlayerIndex = 0,
            GameMode = "classic",
            Status = GameStatus.in_progress
        };
    }

    public GamePlayer GetPlayer(GameSession game)
    {
        var state = JsonSerializer.Deserialize<GameState>(game.PlayersData)!;
        return state.Players[game.CurrentPlayerIndex];
    }

    public void NextPlayer(GameSession game)
    {
        var state = JsonSerializer.Deserialize<GameState>(game.PlayersData)!;
        game.CurrentPlayerIndex++;
        if (game.CurrentPlayerIndex >= state.Players.Count)
        {
            game.Status = GameStatus.finished;
        }
    }
}
