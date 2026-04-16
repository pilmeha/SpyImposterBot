using System;
using System.Collections.Generic;
using System.Text;
using SpyImposterBot.Database;
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

    public UpdateHandler(IGameService gameService, AppDbContext db)
    {
        _gameService = gameService;
        _db = db;
    }

    public async Task HandleUpdateAsync(
        ITelegramBotClient bot, 
        Update update, 
        CancellationToken ct
    )
    {
        // message
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

            var keyboardPlayerCount = new InlineKeyboardMarkup(new[]
            {
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("3", "players_3"),
                    InlineKeyboardButton.WithCallbackData("4", "players_4"),
                    InlineKeyboardButton.WithCallbackData("5", "players_5"),
                    InlineKeyboardButton.WithCallbackData("6", "players_6"),
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("7", "players_7"),
                    InlineKeyboardButton.WithCallbackData("8", "players_8"),
                    InlineKeyboardButton.WithCallbackData("9", "players_9"),
                    InlineKeyboardButton.WithCallbackData("10", "players_10"),
                },
            });

            var keyboarGameType = new InlineKeyboardMarkup(
                new[]
                {
                    new InlineKeyboardButton[] { "Классика" },
                    new InlineKeyboardButton[] { "Мемы" },
                    new InlineKeyboardButton[] { "Грави Фолз" },
                    new InlineKeyboardButton[] { "Парные слова" },
                    new InlineKeyboardButton[] { "Подборки слов" },
                }
            );

            var keyboardShow = new InlineKeyboardButton("Показать", "show");
            var keyboardNext = new InlineKeyboardButton("Следующий", "next");


            // START
            if (msg.Text == "/start")
            {
                await bot.SendMessage(chatId, "Привет! Это игра в шпиона");
            }

            // CREATE GAME
            if (msg.Text == "/newgame")
            {
                await bot.SendMessage(chatId, "Выбери количество игроков!", replyMarkup: keyboardPlayerCount);
            }

            // SHOW WORD
            if (msg.Text == "/show")
            {
                if (!ActiveGames.TryGetValue(chatId, out var gameId)) return;

                var game = await _db.GameSessions.FindAsync(gameId);
                if (game == null) return;
                var player = _gameService.GetPlayer(game);

                var text = player.Role == "spy" ? "Ты ШПИОН 😈" : $"Твое слово: {player.Word}";

                await bot.SendMessage(chatId, "Игрок n\n" + text, replyMarkup: keyboardNext);
                //await bot.SendMessage(chatId, "Игрок n\n" + text + "\n\n/next");

            }

            // NEXT PLAYER
            if (msg.Text == "/next")
            {
                if (!ActiveGames.TryGetValue(chatId, out var gameId)) return;

                var game = await _db.GameSessions.FindAsync(gameId);
                if (game == null) return;

                _gameService.NextPlayer(game);

                await _db.SaveChangesAsync();

                if (game!.Status == "finished")
                {
                    await bot.SendMessage(chatId, "Игра окончена 👾");
                    return;
                }

                await bot.SendMessage(chatId, "Передайте телефон следующему игроку", replyMarkup: keyboardShow);
                //await bot.SendMessage(chatId, "Передайте телефон следующему игроку\n\n/show");
            }
        }

        // callback
        if (update.Type == UpdateType.CallbackQuery)
        {
            var keyboardShow = new InlineKeyboardButton("Показать", "show");
            var keyboardNext = new InlineKeyboardButton("Следующий", "next");

            var query = update.CallbackQuery!;
            var chatId = query.Message!.Chat.Id;

            if (query.Data!.StartsWith("players_"))
            {
                var count = int.Parse(query.Data.Replace("players_", ""));

                await bot.AnswerCallbackQuery(query.Id);

                // Создаем игру
                var game = _gameService.CreateGame(count);

                _db.GameSessions.Add(game);
                await _db.SaveChangesAsync();

                ActiveGames[chatId] = game.Id;

                await bot.SendMessage(chatId, $"Игра создана. Игроков: {count}", replyMarkup: keyboardShow);
                //await bot.SendMessage(chatId, $"Игра создана. Игроков: {count}\nНажмите /show");
            }

            if (query.Data!.StartsWith("show"))
            {
                if (!ActiveGames.TryGetValue(chatId, out var gameId)) return;

                var game = await _db.GameSessions.FindAsync(gameId);
                if (game == null) return;
                var player = _gameService.GetPlayer(game);

                var text = player.Role == "spy" ? "Ты ШПИОН 😈" : $"Твое слово: {player.Word}";

                await bot.SendMessage(chatId, "Игрок n\n" + text, replyMarkup: keyboardNext);
            }

            if (query.Data!.StartsWith("next"))
            {
                if (!ActiveGames.TryGetValue(chatId, out var gameId)) return;

                var game = await _db.GameSessions.FindAsync(gameId);
                if (game == null) return;

                _gameService.NextPlayer(game);

                await _db.SaveChangesAsync();

                if (game!.Status == "finished")
                {
                    await bot.SendMessage(chatId, "Игра окончена 👾");
                    return;
                }

                await bot.SendMessage(chatId, "Передайте телефон следующему игроку", replyMarkup: keyboardShow);
            }

            return;
        }
    }

    public Task HandleErrorAsync(ITelegramBotClient bot, Exception exception, HandleErrorSource source, CancellationToken ct)
    {
        Console.WriteLine(exception);
        return Task.CompletedTask;
    }
}
