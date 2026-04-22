using System.Numerics;

internal static class MessageText
{
    // StartCommandHandler
    public const string Start = "Привет! Это игра в шпиона";

    // NewGameCommandHandler и GoGameTypeHandler
    public const string ChooseGameType = "Выбери тему:";

    // GameTypeHandler и PlayAgainHandler
    public const string ChooseCountPlayers = "Выбери количество игроков:";


    // PlayerCountHandler и PlayAgainHandler
    public static string GameCreatedWithCountPlayers(int countPlayers)
        => $"Игра создана. Игроков: {countPlayers}";

    public const string ChooseFirstGameType = "Сначала выбери тему";

    // ShowHandler
    public static string PlayerTurn(int playerNumber)
        => $"Игрок {playerNumber}";

    public static string Word(string word)
        => $"Твое слово: {word}";

    public const string Spy = "Ты ШПИОН 😈";

    // NextHandler
    public const string NextPlayer = "Передайте телефон следующему игроку";
    public const string GameFinished = "Игра окончена 👾\n\nХотите сыграть ещё раз?";
}

