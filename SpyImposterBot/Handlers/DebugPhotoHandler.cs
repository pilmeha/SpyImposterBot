
using Telegram.Bot;
using Telegram.Bot.Types;

internal class DebugPhotoHandler : ICommandHandler
{
    private readonly ITelegramBotClient _bot;

    public DebugPhotoHandler(ITelegramBotClient bot)
    {
        _bot = bot;
    }

    public bool CanHandle(Update update)
        => update.Message?.Photo != null;

    public async Task HandleAsync(Update update, CancellationToken ct)
    {
        var photo = update.Message!.Photo!.Last();

        var fileId = photo.FileId;

        await _bot.SendMessage(update.Message.Chat.Id, $"FileId:\n{fileId}", cancellationToken: ct);
    }
}

