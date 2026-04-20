using Telegram.Bot.Types;

public interface ICommandHandler
{
    bool CanHandle(Update update);
    Task HandleAsync(Update update, CancellationToken ct);
}
