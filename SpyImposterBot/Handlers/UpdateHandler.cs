using System;
using System.Collections.Generic;
using System.Text;
using SpyImposterBot.Database;
using SpyImposterBot.Enums;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;


internal class UpdateHandler
{
    private readonly IGameService _gameService;
    private readonly AppDbContext _db;

    private static readonly Dictionary<long, long> ActiveGames = new();
    private static readonly Dictionary<long, int> LastMessageIds = new();

    public UpdateHandler(IGameService gameService, AppDbContext db)
    {
        _gameService = gameService;
        _db = db;
    }

    public async Task HandleUpdateAsync(ITelegramBotClient bot, Update update, CancellationToken ct)
    {
        // message
        if (update.Type == UpdateType.Message)
        {
            var msg = update.Message!;
            var chatId = msg.Chat.Id;

            // START
            if (msg.Text == "/start")
            {
                await bot.SendMessage(chatId, "Привет! Это игра в шпиона");
            }

            // CREATE GAME
            if (msg.Text == "/newgame")
            {
                await bot.SendMessage(chatId, "Выбери количество игроков!", replyMarkup: Keyboards.PlayerCount);
            }
        }

        // callback
        if (update.Type == UpdateType.CallbackQuery)
        {
            var query = update.CallbackQuery!;
            var chatId = query.Message!.Chat.Id;

            var callbacks = new Callbacks(_gameService, _db, bot, update, ct);

            //const string PlayersPrefix = "players_";
            if (query.Data!.StartsWith("players_"))
            {
                callbacks.PlayersCountQueryCallback(query, chatId);
                //var count = int.Parse(query.Data!.AsSpan(PlayersPrefix.Length));
                ////var count = int.Parse(query.Data.Replace("players_", ""));

                //await bot.AnswerCallbackQuery(query.Id);

                //// Создаем игру
                //var game = _gameService.CreateGame(count);

                //_db.GameSessions.Add(game);
                //await _db.SaveChangesAsync();

                //ActiveGames[chatId] = game.Id;

                //await SendAndReplaceMessage(
                //    bot,
                //    chatId,
                //    $"Игра создана. Игроков: {count}",
                //    Keyboards.Show
                //    );
            }

            else if (query.Data == "show")
            {
                callbacks.ShowPlayerFunc(query, chatId);
                //if (!ActiveGames.TryGetValue(chatId, out var gameId)) return;

                //var game = await _db.GameSessions.FindAsync(gameId);
                //if (game == null) return;
                //var player = _gameService.GetPlayer(game);

                //var text = player.Role == Role.Spy ? "Ты ШПИОН 😈" : $"Твое слово: {player.Word}";
                //var playerNumber = game.CurrentPlayerIndex + 1;

                //await SendAndReplaceMessage(
                //    bot,
                //    chatId,
                //    "Игрок " + playerNumber + "\n" + text,
                //    Keyboards.Next
                //    );
            }

            else if (query.Data == "next")
            {
                callbacks.NextPlayerFunc(query, chatId);
                //    if (!ActiveGames.TryGetValue(chatId, out var gameId)) return;

                //    var game = await _db.GameSessions.FindAsync(gameId);
                //    if (game == null) return;

                //    _gameService.NextPlayer(game);

                //    await _db.SaveChangesAsync();

                //    if (game!.Status == GameStatus.finished)
                //    {
                //        await SendAndReplaceMessage(
                //            bot,
                //            chatId,
                //            "Игра окончена 👾"
                //            );
                //        return;
                //    }

                //    await SendAndReplaceMessage(
                //        bot,
                //        chatId,
                //        "Передайте телефон следующему игроку",
                //        Keyboards.Show
                //        );
            }

        return;
        }
    }

    async Task SendAndReplaceMessage(ITelegramBotClient bot, long chatId, string text, ReplyMarkup? keyboard = null)
    {
        if (LastMessageIds.TryGetValue(chatId, out var oldMsgId))
        {
            try
            {
                await bot.DeleteMessage(chatId, oldMsgId);
            }
            catch { }
        }

        var msg = await bot.SendMessage(chatId, text, replyMarkup: keyboard);

        LastMessageIds[chatId] = msg.MessageId;
    }

    public Task HandleErrorAsync(ITelegramBotClient bot, Exception exception, HandleErrorSource source, CancellationToken ct)
    {
        Console.WriteLine(exception);
        return Task.CompletedTask;
    }
}
