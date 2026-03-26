internal class UserService : IUserService
{
    public Task CreateUser(long telegramId, string? username)
    {
        return Task.CompletedTask;
    }
}
