using Telegram.Bot.Types;

internal class WordPackInputCommandHandler : ICommandHandler
{

    private readonly WordPackCreationStorage _storage;
    private readonly IWordPackService _wordPackService;
    private readonly MessageService _msg;

    public WordPackInputCommandHandler(
        WordPackCreationStorage storage,
        IWordPackService wordPackService,
        MessageService msg)
    {
        _storage = storage;
        _wordPackService = wordPackService;
        _msg = msg;
    }

    public bool CanHandle(Update update)
    {
        var message = update.Message;

        if (message?.Text == null || message.From == null)
            return false;

        return _storage.TryGet(message.Chat.Id, message.From.Id, out _);
    }

    public async Task HandleAsync(Update update, CancellationToken ct)
    {
        var message = update.Message;

        if (message?.Text == null || message.From == null)
            return;

        var chatId = message.Chat.Id;
        var telegramUserId = message.From.Id;
        var text = message.Text.Trim();

        if (!_storage.TryGet(chatId, telegramUserId, out var state))
            return;

        if (text == "/cancel")
        {
            _storage.Remove(chatId, telegramUserId);

            await _msg.SendAndReplaceMessage(
                chatId,
                MessageText.PackInputCancelled,
                ct,
                Keyboards.CustomPacksMenu);

            return;
        }    

        switch (state.Action)
        {
            case WordPackInputAction.CreateName:
                await HandleCreateName(chatId, telegramUserId, text, ct);
                break;

            case WordPackInputAction.CreateWords:
                await HandleCreateWords(
                    chatId,
                    telegramUserId,
                    state,
                    text,
                    ct);
                break;

            case WordPackInputAction.AddWords:
                await HandleAddWords(
                    chatId,
                    telegramUserId,
                    state,
                    text,
                    ct);
                break;

            case WordPackInputAction.RemoveWords:
                await HandleRemoveWords(
                    chatId,
                    telegramUserId,
                    state,
                    text,
                    ct);
                break;

            case WordPackInputAction.Rename:
                await HandleRename(
                    chatId,
                    telegramUserId,
                    state,
                    text,
                    ct);
                break;
        }
    }

    private async Task HandleCreateName(
        long chatId,
        long telegramUserId,
        string name,
        CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length > 40)
        {
            await _msg.SendAndReplaceMessage(
                chatId,
                "Название должно содержать от 1 до 40 символов.",
                ct,
                Keyboards.CancelPackInput);

            return;
        }

        _storage.Set(
            chatId,
            telegramUserId,
            new WordPackInputState
            {
                Action = WordPackInputAction.CreateWords,
                PackName = name
            });

        await _msg.SendAndReplaceMessage(
            chatId,
            MessageText.CreatePackWords,
            ct,
            Keyboards.CancelPackInput);
    }

    private async Task HandleCreateWords(
        long chatId,
        long telegramUserId,
        WordPackInputState state,
        string text,
        CancellationToken ct)
    {
        var words = ParseWords(text);

        try
        {
            var pack = await _wordPackService.CreatePackAsync(
                telegramUserId,
                state.PackName!,
                words);

            _storage.Remove(chatId, telegramUserId);

            await _msg.SendAndReplaceMessage(
                chatId,
                $"{MessageText.PackCreated}\n\n" +
                MessageText.PackInfo(
                    pack.Name,
                    words.Count),
                ct,
                Keyboards.CustomPackActions(pack.Id));
        }
        catch (ArgumentException ex)
        {
            await _msg.SendAndReplaceMessage(
                chatId,
                ex.Message,
                ct,
                Keyboards.CancelPackInput);
        }
    }

    private async Task HandleAddWords(
        long chatId,
        long telegramUserId,
        WordPackInputState state,
        string text,
        CancellationToken ct)
    {
        var words = ParseWords(text);

        try
        {
            var count = await _wordPackService.AddWordsAsync(
                state.PackId!.Value,
                telegramUserId,
                words);

            _storage.Remove(chatId, telegramUserId);

            var total = await _wordPackService.GetWordsCountAsync(
                state.PackId.Value);

            await _msg.SendAndReplaceMessage(
                chatId,
                $"{MessageText.WordsAdded(count)}\n" +
                $"Всего слов: {total}",
                ct,
                Keyboards.EditCustomPack(state.PackId.Value));
        }
        catch (ArgumentException ex)
        {
            await _msg.SendAndReplaceMessage(
                chatId,
                ex.Message,
                ct,
                Keyboards.CancelPackInput);
        }
    }

    private async Task HandleRemoveWords(
        long chatId,
        long telegramUserId,
        WordPackInputState state,
        string text,
        CancellationToken ct)
    {
        var words = ParseWords(text);

        try
        {
            var count = await _wordPackService.RemoveWordsAsync(
                state.PackId!.Value,
                telegramUserId,
                words);

            _storage.Remove(chatId, telegramUserId);

            var total = await _wordPackService.GetWordsCountAsync(
                state.PackId.Value);

            await _msg.SendAndReplaceMessage(
                chatId,
                $"{MessageText.WordsRemoved(count)}\n" +
                $"Осталось слов: {total}",
                ct,
                Keyboards.EditCustomPack(state.PackId.Value));
        }
        catch (ArgumentException ex)
        {
            await _msg.SendAndReplaceMessage(
                chatId,
                ex.Message,
                ct,
                Keyboards.CancelPackInput);
        }
    }

    private async Task HandleRename(
        long chatId,
        long telegramUserId,
        WordPackInputState state,
        string text,
        CancellationToken ct)
    {
        try
        {
            await _wordPackService.RenamePackAsync(
                state.PackId!.Value,
                telegramUserId,
                text);

            _storage.Remove(chatId, telegramUserId);

            await _msg.SendAndReplaceMessage(
                chatId,
                "Название подборки изменено.",
                ct,
                Keyboards.CustomPackActions(state.PackId.Value));
        }
        catch (ArgumentException ex)
        {
            await _msg.SendAndReplaceMessage(
                chatId,
                ex.Message,
                ct,
                Keyboards.CancelPackInput);
        }
    }

    private static List<string> ParseWords(string text)
    {
        return text
            .Split(
                new[] { '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.Trim())
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .ToList();
    }
}