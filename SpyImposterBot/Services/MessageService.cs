using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

public class MessageService
{
    private readonly ITelegramBotClient _bot;
    private readonly GameSessionStorage _storage;

    public MessageService(ITelegramBotClient bot, GameSessionStorage storage)
    {
        _bot = bot;
        _storage = storage;
    }

    public async Task SendAndReplaceMessage(long chatId, string text, CancellationToken ct, ReplyMarkup? kb = null)
    {
        if (_storage.LastMessageIds.TryGetValue(chatId, out var oldId))
        {
            try { await _bot.DeleteMessage(chatId, oldId, ct); } catch { }
        }

        var msg = await _bot.SendMessage(chatId, text, replyMarkup: kb, cancellationToken: ct);

        _storage.LastMessageIds[chatId] = msg.MessageId;
    }

    public async Task SendAndReplacePhotoMessage(long chatId, string text, string photoFileId, CancellationToken ct, ReplyMarkup? kb = null)
    {
        if (_storage.LastMessageIds.TryGetValue(chatId, out var oldId))
        {
            try { await _bot.DeleteMessage(chatId, oldId, ct); } catch { }
        }

        var msg = await _bot.SendPhoto(chatId, photoFileId, caption: text, replyMarkup: kb, cancellationToken: ct);

        _storage.LastMessageIds[chatId] = msg.MessageId;
    }
}