using Telegram.Bot.Types;


public interface ICallbackHandler
{
    bool CanHandle(Update update);
    Task HandleAsync(Update update, CancellationToken ct);
}

