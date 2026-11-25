using SpyImposterBot.Migrations;
using Telegram.Bot;
using Telegram.Bot.Types;

internal class CustomWordPackCallbackHandler : ICallbackHandler
{

    private readonly IWordPackService _wordPackService;
    private readonly GameSessionStorage _gameStorage;
    private readonly WordPackCreationStorage _inputStorage;
    private readonly MessageService _msg;
    private readonly ITelegramBotClient _bot;

    public CustomWordPackCallbackHandler(
        IWordPackService wordPackService,
        GameSessionStorage gameStorage,
        WordPackCreationStorage inputStorage,
        MessageService msg,
        ITelegramBotClient bot
    )
    {
        _wordPackService = wordPackService;
        _gameStorage = gameStorage;
        _inputStorage = inputStorage;
        _msg = msg;
        _bot = bot;
    }

    public bool CanHandle(Update update)
    {
        var data = update.CallbackQuery?.Data;

        if (data == null) return false;

        return data == "customPacks"
            || data == "myPacks"
            || data == "createPack"
            || data == "backCustomPacks"
            || data == "cancelPackInput"
            || data.StartsWith("selectCustomPack_")
            || data.StartsWith("startCustomPack_")
            || data.StartsWith("editCustomPack_")
            || data.StartsWith("addWords_")
            || data.StartsWith("removeWords_")
            || data.StartsWith("renamePack_")
            || data.StartsWith("deleteCustomPack_")
            || data.StartsWith("confirmDeletePack_");
    }

    public async Task HandleAsync(Update update, CancellationToken ct)
    {
        var query = update.CallbackQuery!;
        var chatId = query.Message!.Chat.Id;
        var telegramUserId = query.From.Id;
        var data = query.Data!;

        await _bot.AnswerCallbackQuery(
            query.Id,
            cancellationToken: ct
        );

        if (data == "customPacks")
        {
            await ShowCustomPacksMenu(chatId, ct);
            return;
        }

        if (data == "myPacks")
        {
            await ShowMyPacks(chatId, telegramUserId, ct);
            return;
        }

        if (data == "createPack")
        {
            _inputStorage.Set(
                chatId, 
                telegramUserId,
                new WordPackInputState
                {
                    Action = WordPackInputAction.CreateName
                }
            );

            await _msg.SendAndReplaceMessage(
                chatId, 
                MessageText.CreatePackName, 
                ct, 
                Keyboards.CancelPackInput
            );

            return;
        }

        if (data == "cancelPackInput")
        {
            _inputStorage.Remove(chatId, telegramUserId);

            await _msg.SendAndReplaceMessage(
                chatId, 
                MessageText.PackInputCancelled, 
                ct, 
                Keyboards.CustomPacksMenu
            );
            
            return;
        }


        if (data.StartsWith("selectCustomPack_"))
        {
            var packId = GetPackId(data, "selectCustomPack_");

            await ShowPack(chatId, telegramUserId, packId, ct);
            return;
        }

        if (data.StartsWith("startCustomPack_"))
        {
            var packId = GetPackId(data, "startCustomPack_");

            var canAccess = await _wordPackService.CanAccessPackAsync(packId, telegramUserId);

            if (!canAccess)
            {
                await _msg.SendAndReplaceMessage(chatId, MessageText.PackNotFound, ct, Keyboards.CustomPacksMenu);
            
                return;
            }

            _gameStorage.SelectedPack[chatId] = packId;

            await _msg.SendAndReplaceMessage(chatId, MessageText.ChooseCountPlayers, ct, Keyboards.PlayerCount);

            return;
        }


        if (data.StartsWith("editCustomPack_"))        
        {
            var packId = GetPackId(data, "editCustomPack_");

            var pack = await _wordPackService.GetOwnedPackAsync(packId, telegramUserId);

            if (pack == null)
            {
                await ShowPackNotFound(chatId, ct);
                return;
            }

            await _msg.SendAndReplaceMessage(chatId, MessageText.EditPackMenu, ct, Keyboards.EditCustomPack(packId));
            return;
        }

        if (data.StartsWith("addWords_"))
        {
            var packId = GetPackId(data, "addWords_");

            if (!await IsOwner(packId, telegramUserId))
            {
                await ShowPackNotFound(chatId, ct);
                return;
            }

            _inputStorage.Set(
                chatId,
                telegramUserId,
                new WordPackInputState
                {
                    Action = WordPackInputAction.AddWords,
                    PackId = packId
                }
            );

            await _msg.SendAndReplaceMessage(chatId, MessageText.AddWordsPrompt, ct, Keyboards.CancelPackInput);
            return;
        }

        if (data.StartsWith("removeWords_"))
        {
            var packId = GetPackId(data, "removeWords_");

            if (!await IsOwner(packId, telegramUserId))
            {
                await ShowPackNotFound(chatId, ct);
                return;
            }

            _inputStorage.Set(
                chatId,
                telegramUserId,
                new WordPackInputState
                {
                    Action = WordPackInputAction.RemoveWords,
                    PackId = packId
                }
            );

            await _msg.SendAndReplaceMessage(chatId, MessageText.RemoveWordsPrompt, ct, Keyboards.CancelPackInput);
            return;
        }

        if (data.StartsWith("renamePack_"))
        {
            var packId = GetPackId(data, "ranamePack_");

            if (!await IsOwner(packId, telegramUserId))
            {
                await ShowPackNotFound(chatId, ct);
                return;
            }

            _inputStorage.Set(
                chatId,
                telegramUserId,
                new WordPackInputState
                {
                    Action = WordPackInputAction.Rename,
                    PackId = packId
                }
            );

            await _msg.SendAndReplaceMessage(chatId, MessageText.RenamePackPrompt, ct, Keyboards.CancelPackInput);
            return;
        }

        if (data.StartsWith("deleteCustomPack_"))
        {
            var packId = GetPackId(data, "deleteCustomPack_");

            if (!await IsOwner(packId, telegramUserId))
            {
                await ShowPackNotFound(chatId, ct);
                return;
            }

            await _msg.SendAndReplaceMessage(
                chatId,
                "Ты действительно хочешь удалить эту подборку?",
                ct,
                Keyboards.ConfirmDeletePack(packId)
            );

            return;
        }

        if (data.StartsWith("confirmDeletePack_"))
        {
            var packId = GetPackId(data, "confirmDeletePack_");

            if (!await IsOwner(packId, telegramUserId))
            {
                await ShowPackNotFound(chatId, ct);
                return;
            }

            await _wordPackService.DeletePackAsync(packId, telegramUserId);

            await _msg.SendAndReplaceMessage(chatId, MessageText.PackDeleted, ct, Keyboards.CustomPacksMenu);
            return;
        }

        if (data == "backCustomPacks")
        {
            await ShowCustomPacksMenu(chatId, ct);
        }
    }

    private async Task ShowCustomPacksMenu(long chatId, CancellationToken ct)
    {
        await _msg.SendAndReplaceMessage(chatId, MessageText.CustomPacksMenu, ct, Keyboards.CustomPacksMenu);
    }

    private async Task ShowMyPacks(long chatId, long telegramUserId, CancellationToken ct)
    {
        var packs = await _wordPackService.GetMyPacksAsync(telegramUserId);

        if (packs.Count == 0)
        {
            await _msg.SendAndReplaceMessage(chatId, MessageText.MyPacksEmpty, ct, Keyboards.CustomPacksMenu);
            return;
        }

        await _msg.SendAndReplaceMessage(chatId, "Твои подборки:", ct, Keyboards.MyPacks(packs));
    }

    private async Task ShowPack(long chatId, long telegramUserId, long packId, CancellationToken ct)
    {
        var pack = await _wordPackService.GetOwnedPackAsync(packId, telegramUserId);

        if (pack == null)
        {
            await ShowPackNotFound(chatId, ct);
            return;
        }

        var wordsCount = await _wordPackService.GetWordsCountAsync(packId);

        await _msg.SendAndReplaceMessage(chatId, MessageText.PackInfo(pack.Name, wordsCount), ct, Keyboards.CustomPackActions(packId));
    }

    private async Task<bool> IsOwner(long packId, long telegramUserId)
    {
        var pack = await _wordPackService.GetOwnedPackAsync(packId, telegramUserId);
        return pack != null;
    }

    private async Task ShowPackNotFound(long chatId, CancellationToken ct)
    {
        await _msg.SendAndReplaceMessage(chatId, MessageText.PackNotFound, ct, Keyboards.CustomPacksMenu);
    }

    private static long GetPackId(string data, string prefix)
    {
        return long.Parse(data.Substring(prefix.Length));
    }
}