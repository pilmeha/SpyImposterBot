using Microsoft.EntityFrameworkCore;
using SpyImposterBot.Database;

internal class WordPackService : IWordPackService
{
    private const int MaxPackNameLength = 40;
    private const int MaxWordLength = 100;
    private const int MaxWordsCount = 500;
    private const int MinWordsCount = 2;

    private readonly AppDbContext _db;
    private readonly IUserService _userService;

    public WordPackService(AppDbContext db, IUserService userService)
    {
        _db = db;
        _userService = userService;
    }

    public async Task<int> AddWordsAsync(long packId, long telegramId, IEnumerable<string> words)
    {
        var pack = await GetRequiredOwnedPackAsync(packId, telegramId);

        var newWords= NormalizeWords(words);

        var existingWords = await _db.Words
            .Where(x => x.PackId == pack.Id)
            .Select(x => x.Value)
            .ToListAsync();

        var existingSet = new HashSet<string>(existingWords, StringComparer.OrdinalIgnoreCase);
    
        var wordsToAdd = newWords
            .Where(x => existingSet.Add(x))
            .ToList();

        if (wordsToAdd.Count == 0) return 0;

        if (existingWords.Count + wordsToAdd.Count > MaxWordsCount)
        {
            throw new ArgumentException(
                $"В подборке может быть не более {MaxWordsCount} слов."
            );
        }

        var entities = wordsToAdd.Select(value => new Word
        {
            PackId = pack.Id,
            Value = value,
            PairId = null,
            ImageFileId = null
        });

        _db.Words.AddRange(entities);

        await _db.SaveChangesAsync();
        return wordsToAdd.Count();
    }

    public async Task<bool> CanAccessPackAsync(long packId, long telegramId)
    {
        var pack = await _db.WordPacks
            .FirstOrDefaultAsync(x => x.Id == packId);

        if (pack == null) return false;

        if (pack.UserId == null && pack.IsPublic) return false;

        var userId = await GetUserIdAsync(telegramId);

        return pack.UserId == userId || pack.IsPublic;
    }

    public async Task<WordPack> CreatePackAsync(long telegramId, string name, IEnumerable<string> words)
    {
        name = NormalizeName(name);

        var normalizedWords = NormalizeWords(words);

        if (normalizedWords.Count < MinWordsCount)
        {
            // Перенести в MessageText
            throw new ArgumentException(
                $"Добавиь минимум {MinWordsCount} разных слова."
            );
        }

        if (normalizedWords.Count > MaxWordsCount)
        {
            throw new ArgumentException(
                $"В подборке может быть не более {MaxWordsCount} слов."
            );
        }

        var userId = await GetUserIdAsync(telegramId);

        var pack = new WordPack
        {
            UserId = userId,
            Name = name,
            IsPublic = false,
            HasImage = false,
            SpyImageFileId = null
        };

        _db.WordPacks.Add(pack);

        await _db.SaveChangesAsync();

        var wordEntities = normalizedWords.Select(value => new Word
        {
            PackId = pack.Id,
            Value = value,
            PairId = null,
            ImageFileId = null
        });

        _db.Words.AddRange(wordEntities);

        await _db.SaveChangesAsync();

        return pack;
    }

    public async Task DeletePackAsync(long packId, long telegramId)
    {
        var pack = await GetRequiredOwnedPackAsync(packId, telegramId);

        var words = await _db.Words
            .Where(x => x.PackId == pack.Id)
            .ToListAsync();

        _db.Words.RemoveRange(words);
        _db.WordPacks.Remove(pack);

        await _db.SaveChangesAsync();
    }

    public async Task<List<WordPack>> GetMyPacksAsync(long telegramId)
    {
        var userId = await GetUserIdAsync(telegramId);

        return await _db.WordPacks
            .Where(x => x.UserId == userId)
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task<WordPack?> GetOwnedPackAsync(long packId, long telegramId)
    {
        var userId = await GetUserIdAsync(telegramId);

        return await _db.WordPacks
            .FirstOrDefaultAsync(x => x.Id == packId && x.UserId == userId);
    }

    public async Task<int> RemoveWordsAsync(long packId, long telegramId, IEnumerable<string> words)
    {
        var pack = await GetRequiredOwnedPackAsync(packId, telegramId);

        var wordsToRemove = new HashSet<string>(NormalizeWords(words), StringComparer.OrdinalIgnoreCase);
    
        var existingWords = await _db.Words
            .Where(x => x.PackId == packId)
            .ToListAsync();

        var matchedWords = existingWords
            .Where(x => wordsToRemove.Contains(x.Value))
            .ToList();

        if (existingWords.Count - matchedWords.Count < MinWordsCount)
        {
            throw new ArgumentException(
                $"В подборке должно остаться минимум {MinWordsCount} слова."
            );
        }

        if (matchedWords.Count == 0) return 0;

        await _db.SaveChangesAsync();
        return matchedWords.Count;
    }

    public async Task RenamePackAsync(long packId, long telegramId, string newName)
    {
        var pack = await GetRequiredOwnedPackAsync(packId, telegramId);

        pack.Name = NormalizeName(newName);

        await _db.SaveChangesAsync();
    }

    private async Task<long> GetUserIdAsync(long telegramId)
    {
        return await _userService.GetOrCreateUserIdAsync(telegramId, null);
    }

    private async Task<WordPack> GetRequiredOwnedPackAsync(long packId, long telegramId)
    {
        var pack = await GetOwnedPackAsync(packId, telegramId);

        if (pack == null)
        {
            throw new InvalidOperationException(
                "Подборка не найдена или к ней нету доступа."
            );
        }

        return pack;
    }

    private static string NormalizeName(string name)
    {
        name = name.Trim();

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Название не может быть пустым.");

        if (name.Length > MaxPackNameLength)
        {
            throw new ArgumentException(
                $"Название не должно превышать {MaxPackNameLength} символов."
            );
        }
        
        return name;
    }

    private static List<string> NormalizeWords(IEnumerable<string> words)
    {
        return words
            .Select(x => x.Trim())
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(x =>
            {
                if (x.Length > MaxWordLength)
                {
                    throw new ArgumentException(
                        $"Слово не должно превышать {MaxWordLength} символов: {x}"
                    );
                }

                return x;
            })
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToList();
    }

}