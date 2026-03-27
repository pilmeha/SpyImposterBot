using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;


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
            var chatId = msg.Chat.Id;
            var keyboard1 = new ReplyKeyboardMarkup(
                new[]
                {
                    new KeyboardButton[] {"Первая кнопка", "Вторая кнопка" },
                    new KeyboardButton[] { "Третья кнопка " },
                }
            )
            {
                ResizeKeyboard = true
            };

            var keyboardPlayerCount = new InlineKeyboardMarkup(
                new[]
                {
                    new InlineKeyboardButton[] { "3", "4", "5", "6"},
                    new InlineKeyboardButton[] { "7", "8", "9", "10" },
                }
            );

            if (msg.Text == "/start")
            {
                //await _userService.CreateUser(msg.From!.Id, msg.From.Username);

                await bot.SendMessage(msg.Chat, "Привет! Это игра в шпиона");

                //await bot.SendMessage(msg.Chat, "Какой-то текст для 1го типа кнопок", replyMarkup: keyboard1);

                await bot.SendMessage(msg.Chat, "Выбери количество игроков!", replyMarkup: keyboardPlayerCount);
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
