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


internal class UpdateDispatcher
{
    private readonly IEnumerable<ICommandHandler> _commandHandlers;
    private readonly IEnumerable<ICallbackHandler> _callbackHandlers;

    public UpdateDispatcher(
        IEnumerable<ICommandHandler> commandHandlers,
        IEnumerable<ICallbackHandler> callbackHandlers)
    {
        _commandHandlers = commandHandlers;
        _callbackHandlers = callbackHandlers;
    }

    public async Task DispatchAsync(Update update, CancellationToken ct)
    {
        // COMMANDS
        if (update.Message?.Text != null)
        {
            foreach (var handler in _commandHandlers)
            {
                if (handler.CanHandle(update))
                {
                    await handler.HandleAsync(update, ct);
                    return;
                }
            }
        }

        // CALLBACKS
        if (update.CallbackQuery != null)
        {
            foreach (var handler in _callbackHandlers)
            {
                if (handler.CanHandle(update))
                {
                    await handler.HandleAsync(update, ct);
                    return;
                }
            }
        }
    }


    //private readonly IGameService _gameService;
    //private readonly AppDbContext _db;

    //private readonly Dictionary<long, long> ActiveGames = new();
    //private readonly Dictionary<long, int> LastMessageIds = new();

    //public UpdateDispatcher(IGameService gameService, AppDbContext db)
    //{
    //    _gameService = gameService;
    //    _db = db;
    //}

    //public async Task HandleUpdateAsync(ITelegramBotClient bot, Update update, CancellationToken ct)
    //{
    //    // message
    //    if (update.Type == UpdateType.Message)
    //    {
    //        var msg = update.Message!;
    //        var chatId = msg.Chat.Id;

    //        // START
    //        if (msg.Text == "/start")
    //        {
    //            await bot.SendMessage(chatId, "Привет! Это игра в шпиона");
    //        }

    //        // CREATE GAME
    //        if (msg.Text == "/newgame")
    //        {
    //            await bot.SendMessage(chatId, "Выбери количество игроков!", replyMarkup: Keyboards.PlayerCount);
    //        }
    //    }

    //    // callback
    //    if (update.Type == UpdateType.CallbackQuery)
    //    {
    //        var query = update.CallbackQuery!;
    //        var chatId = query.Message!.Chat.Id;

    //        var callbacks = new Callbacks(_gameService, _db, bot, update, ct);

    //        //const string PlayersPrefix = "players_";
    //        if (query.Data!.StartsWith("players_"))
    //        {
    //            callbacks.PlayersCountQueryCallback(query, chatId);

    //        }

    //        else if (query.Data == "show")
    //        {
    //            callbacks.ShowPlayerFunc(query, chatId);
  
    //        }

    //        else if (query.Data == "next")
    //        {
    //            callbacks.NextPlayerFunc(query, chatId);
    //        }

    //    return;
    //    }
    //}

    //async Task SendAndReplaceMessage(ITelegramBotClient bot, long chatId, string text, ReplyMarkup? keyboard = null)
    //{
    //    if (LastMessageIds.TryGetValue(chatId, out var oldMsgId))
    //    {
    //        try
    //        {
    //            await bot.DeleteMessage(chatId, oldMsgId);
    //        }
    //        catch { }
    //    }

    //    var msg = await bot.SendMessage(chatId, text, replyMarkup: keyboard);

    //    LastMessageIds[chatId] = msg.MessageId;
    //}

    //public Task HandleErrorAsync(ITelegramBotClient bot, Exception exception, HandleErrorSource source, CancellationToken ct)
    //{
    //    Console.WriteLine(exception);
    //    return Task.CompletedTask;
    //}
}
