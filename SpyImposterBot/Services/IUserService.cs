public interface IUserService
{
    Task CreateUser(long telegramId, string? username);

    Task<long> GetOrCreateUserIdAsync(long telegramId, string? username);
}