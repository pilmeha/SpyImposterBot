using SpyImposterBot.Database;
using SpyImposterBot.Enums;
using Telegram.Bot;
using Telegram.Bot.Types;

internal class NextHandler : ICallbackHandler
{
    private readonly IGameService _gameService;
    private readonly AppDbContext _db;
    private readonly GameSessionStorage _storage;
    private readonly ITelegramBotClient _bot;
    private readonly MessageService _msg;
    private const string NEXTMessage = "next";

    public NextHandler(IGameService gameService, AppDbContext db, GameSessionStorage storage, ITelegramBotClient bot, MessageService msg)
    {
        _gameService = gameService;
        _db = db;
        _storage = storage;
        _bot = bot;
        _msg = msg;
    }

    public bool CanHandle(Update update)
        => update.CallbackQuery?.Data == NEXTMessage;

    public async Task HandleAsync(Update update, CancellationToken ct)
    {
        var query = update.CallbackQuery!;
        var chatId = query.Message!.Chat.Id;

        if (!_storage.ActiveGames.TryGetValue(chatId, out var gameId)) return;

        var game = await _db.GameSessions.FindAsync(new object[] { gameId }, ct);
        if (game == null) return;

        _gameService.NextPlayer(game);

        await _db.SaveChangesAsync(ct);

        if (game!.Status == GameStatus.finished)
        {
            await _msg.SendAndReplaceMessage(chatId, $"Игра окончена 👾\n\nХотите сыграть ещё раз?", ct, Keyboards.PlayAgainMenu);

            return; 
        }

        await _msg.SendAndReplaceMessage(chatId, "Передайте телефон следующему игроку", ct, Keyboards.Show);
    }
}

