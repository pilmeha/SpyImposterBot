internal interface IWordPackService
{
    Task<List<WordPack>> GetMyPacksAsync(long telegramId);

    Task<WordPack?> GetOwnedPackAsync(long packId, long telegramId);

    Task<bool> CanAccessPackAsync(long packId, long telegramId);

    Task<WordPack> CreatePackAsync(long telegramId, string name, IEnumerable<string> words);

    Task RenamePackAsync(long packId, long telegramId, string newName);

    Task<int> AddWordsAsync(long packId, long telegramId, IEnumerable<string> words);

    Task<int> RemoveWordsAsync(long packId, long telegramId, IEnumerable<string> words);

    Task DeletePackAsync(long packId, long telegramId);

    Task<int> GetWordsCountAsync(long packId);
}
