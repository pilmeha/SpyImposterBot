using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;


internal class UpdateHandler
{
    //private readonly IUserService _userService;
    //private readonly IGameService _gameService;

    //public UpdateHandler(IUserService userService, IGameService gameService)
    //{
    //    _userService = userService;
    //    _gameService = gameService;
    //}

    public async Task HandleUpdateAsync(
        ITelegramBotClient bot, 
        Update update, 
        CancellationToken ct
    )
    {
        if (update.Type == UpdateType.Message)
        {
            var msg = update.Message!;

            if (msg.Text == "/start")
            {
                //await _userService.CreateUser(msg.From!.Id, msg.From.Username);

                await bot.SendMessage(msg.Chat, "Привет! Это игра в шпиона");
            }
        }
    }

    public Task HandleErrorAsync(
        ITelegramBotClient bot,
        Exception exception,
        HandleErrorSource source,
        CancellationToken ct
    )
    {
        Console.WriteLine(exception);
        return Task.CompletedTask;
    }

    //public static implicit operator UpdateHandler(DefaultUpdateHandler v)
    //{
    //    throw new NotImplementedException();
    //}
}
