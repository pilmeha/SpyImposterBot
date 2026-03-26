public interface IUserService
{
    Task CreateUser(long telegramId, string? username);
}