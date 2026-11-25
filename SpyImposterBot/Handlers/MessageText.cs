using System.Numerics;

internal static class MessageText
{
    // StartCommandHandler
    public const string Start = "Привет! Это игра в шпиона!\nЧтобы начать нажми на /newgame";

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


    public const string CustomPacksMenu = "Пользовательские подборки:";
    public const string MyPacksEmpty = "У тебя пока нету собственных подборок. \n\nСоздай первую!";
    public const string CreatePackName = "Введи название новой подборки:";
    public const string CreatePackWords = 
        "Теперь отправь слова для подборки.\n\n" +
        "Каждое слово должно быть на отдельной строке.\n\n" +
        "Миниму - 2 слова, максимум - 500.";

    public const string PackCreated = "Подборка успешно создана!";
    public const string EditPackMenu = "Что хочешь сделать с подборкой?";
    public const string AddWordsPrompt = 
        "Отправь слова, которые хочешь добавить.\n\nКаждое слово - с новой строки.";
    public const string RemoveWordsPrompt = 
        "Отправь слова, которые хочешь удалить.\n\nКаждое слово - с новой строки.";

    public const string RenamePackPrompt = "Введи новое название подборки:";
    public const string PackDeleted = "Подборка удалена.";
    public const string PackInputCancelled = "Действие отменено.";
    public const string PackNotFound = "Подборка не найдена или к ней нет доступа.";
  
    public static string PackInfo(string name, int wordsCount) =>
        $"Подборка: {name}\nКоличество слов: {wordsCount}";
    public static string WordsAdded(int count) =>
        $"Добавлено слов: {count}";
    public static string WordsRemoved(int count) =>
        $"Удаленно слов: {count}";
}

