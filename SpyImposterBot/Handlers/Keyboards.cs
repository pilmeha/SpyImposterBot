using Telegram.Bot.Types.ReplyMarkups;

static class Keyboards
{
    public static InlineKeyboardMarkup Show =>
        new(InlineKeyboardButton.WithCallbackData("Показать", "show"));

    public static InlineKeyboardMarkup Next =>
        new(InlineKeyboardButton.WithCallbackData("Следующий", "next"));
}

