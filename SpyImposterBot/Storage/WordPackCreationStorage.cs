using System.Collections.Concurrent;

internal enum WordPackInputAction
{
    CreateName,
    CreateWords,
    AddWords,
    RemoveWords,
    Rename
}

internal class WordPackInputState
{
    public WordPackInputAction Action { get; set; }
    public long? PackId { get; set; }
    public string? PackName { get; set; }
}

internal class WordPackCreationStorage
{
    private readonly ConcurrentDictionary<(long ChatId, long UserId), WordPackInputState> _states = new();

    public void Set(long chatId, long userId, WordPackInputState state)
    {
        _states[(chatId, userId)] = state;
    }

    public bool TryGet(long chatId, long userId, out WordPackInputState state)
    {
        return _states.TryGetValue((chatId, userId), out state!);
    }

    public void Remove(long chatId, long userId)
    {
        _states.TryRemove((chatId, userId), out _);
    }
}