using Telegram.Bot.Types.ReplyMarkups;

static class Keyboards
{
    public static InlineKeyboardMarkup Show =>
        new(InlineKeyboardButton.WithCallbackData("Показать", "show"));

    public static InlineKeyboardMarkup Next =>
        new(InlineKeyboardButton.WithCallbackData("Следующий", "next"));

    public static InlineKeyboardMarkup PlayAgainMenu =>
          new(new[]
          {
            new [] { InlineKeyboardButton.WithCallbackData("Сыграть ещё раз", "playAgain") },
            new [] { InlineKeyboardButton.WithCallbackData("Вернуться к выбору темы", "goGameType") },
          });

    public static InlineKeyboardMarkup PlayerCount =>
        new(new[] 
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

    public static InlineKeyboardMarkup GameType =>
    new(new[]
    {
            new[] { InlineKeyboardButton.WithCallbackData("Классика", "pack_1") },
            new[] { InlineKeyboardButton.WithCallbackData("Мемы", "pack_2") },
            new[] { InlineKeyboardButton.WithCallbackData("Гравити Фолз", "pack_3") },
            new[] { InlineKeyboardButton.WithCallbackData("Парные слова", "pack_4") },
            new[] { InlineKeyboardButton.WithCallbackData("Подборки слов", "pack_5") },
    });

    public static ReplyKeyboardMarkup MainMenu =>
        new(new[]
        {
            new KeyboardButton[] {"Первая кнопка", "Вторая кнопка" },
            new KeyboardButton[] {"Третья кнопка" }
        })
        {
            ResizeKeyboard = true
        };
}

