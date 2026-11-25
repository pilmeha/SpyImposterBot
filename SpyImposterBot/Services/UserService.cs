using Microsoft.EntityFrameworkCore;
using SpyImposterBot.Database;

internal class UserService : IUserService
{

    private readonly AppDbContext _db;

    public UserService(AppDbContext db)
    {
        _db = db;
    }

    public async Task CreateUser(long telegramId, string? username)
    {
        await GetOrCreateUserIdAsync(telegramId, username);
    }

    public async Task<long> GetOrCreateUserIdAsync(long telegramId, string? username)
    {
        var user = await _db.Users
            .FirstOrDefaultAsync(x => x.TelegramId == telegramId);

        if (user == null)
        {
            user = new User
            {
                TelegramId = telegramId,
                Username = username
            };

            _db.Users.Add(user);
        }
        else if (user.Username != username)
        {
            user.Username = username;
        }

        await _db.SaveChangesAsync();

        return user.Id;
    }
}
