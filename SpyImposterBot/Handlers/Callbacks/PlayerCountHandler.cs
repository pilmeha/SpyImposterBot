using SpyImposterBot.Database;
using Telegram.Bot;
using Telegram.Bot.Types;

internal class PlayerCountHandler : ICallbackHandler
{
    private readonly IGameService _gameService;
    private readonly AppDbContext _db;
    private readonly GameSessionStorage _storage;
    private readonly ITelegramBotClient _bot;
    private readonly MessageService _msg;

    private const string Prefix = "players_";

    public PlayerCountHandler(IGameService gameService, AppDbContext db, GameSessionStorage storage, ITelegramBotClient bot, MessageService msg)
    {
        _gameService = gameService;
        _db = db;
        _storage = storage;
        _bot = bot;
        _msg = msg;
    }

    public bool CanHandle(Update update)
        => update.CallbackQuery?.Data?.StartsWith(Prefix) == true;

    public async Task HandleAsync(Update update, CancellationToken ct)
    {
        var query = update.CallbackQuery!;
        var chatId = query.Message!.Chat.Id;

        await _bot.AnswerCallbackQuery(query.Id);

        var count = int.Parse(query.Data!.Substring(Prefix.Length));

        if (!_storage.SelectedPack.TryGetValue(chatId, out var packId))
        {
            await _msg.SendAndReplaceMessage(chatId, "Сначала выбери тему", ct, Keyboards.GameType);
            return;
        }

        var game = await _gameService.CreateGameAsync(count, (int)packId);

        _db.GameSessions.Add(game);
        await _db.SaveChangesAsync(ct);

        _storage.ActiveGames[chatId] = game.Id;

        await _msg.SendAndReplaceMessage(chatId, $"Игра создана. Игроков: {count}", ct, Keyboards.Show);
    }
}
