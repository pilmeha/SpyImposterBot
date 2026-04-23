using Telegram.Bot.Types;

internal class UpdateDispatcher
{
    private readonly IEnumerable<ICommandHandler> _commandHandlers;
    private readonly IEnumerable<ICallbackHandler> _callbackHandlers;

    public UpdateDispatcher(
        IEnumerable<ICommandHandler> commandHandlers,
        IEnumerable<ICallbackHandler> callbackHandlers)
    {
        _commandHandlers = commandHandlers;
        _callbackHandlers = callbackHandlers;
    }

    public async Task DispatchAsync(Update update, CancellationToken ct)
    {
        // Image, file, documentc for FileImageId
        if (update.Message != null && update.Message.Text == null)
        {
            foreach (var handler in _commandHandlers)
            {
                await handler.HandleAsync(update, ct);
            }
        }

        // COMMANDS
        if (update.Message?.Text != null)
        {
            foreach (var handler in _commandHandlers)
            {
                if (handler.CanHandle(update))
                {
                    await handler.HandleAsync(update, ct);
                    return;
                }
            }
        }

        // CALLBACKS
        if (update.CallbackQuery != null)
        {
            foreach (var handler in _callbackHandlers)
            {
                if (handler.CanHandle(update))
                {
                    await handler.HandleAsync(update, ct);
                    return;
                }
            }
        }
    }
}
