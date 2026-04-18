using SpyImposterBot.Database;
using SpyImposterBot.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;


class Callbacks
{
    private static readonly Dictionary<long, long> ActiveGames = new();
    private static readonly Dictionary<long, int> LastMessageIds = new();
    const string PlayersPrefix = "players_";

    IGameService gameService;
    AppDbContext db;
    ITelegramBotClient bot;
    Update update;
    CancellationToken ct;
    //CallbackQuery query;
    //long chatId;

    public Callbacks(
        IGameService gameService, 
        AppDbContext db, 
        ITelegramBotClient bot,
        Update update,
        CancellationToken ct
        //CallbackQuery query,
        //long chatId
        )
    {
        this.gameService = gameService;
        this.db = db;
        this.bot = bot;
        this.update = update;
        this.ct = ct;
        //this.query = query;
        //this.chatId = chatId;
    }

    public async void PlayersCountQueryCallback(CallbackQuery query, long chatId)
    {
        var count = int.Parse(query.Data!.AsSpan(PlayersPrefix.Length));
        //var count = int.Parse(query.Data.Replace("players_", ""));

        await bot.AnswerCallbackQuery(query.Id);

        // Создаем игру
        var game = gameService.CreateGame(count);

        db.GameSessions.Add(game);
        await db.SaveChangesAsync();

        ActiveGames[chatId] = game.Id;

        await SendAndReplaceMessage(
            bot,
            chatId,
            $"Игра создана. Игроков: {count}",
            Keyboards.Show
            );
    }

    public async void ShowPlayerFunc(CallbackQuery query, long chatId)
    {
        if (!ActiveGames.TryGetValue(chatId, out var gameId)) return;

        var game = await db.GameSessions.FindAsync(gameId);
        if (game == null) return;
        var player = gameService.GetPlayer(game);

        var text = player.Role == Role.Spy ? "Ты ШПИОН 😈" : $"Твое слово: {player.Word}";
        var playerNumber = game.CurrentPlayerIndex + 1;

        await SendAndReplaceMessage(
            bot,
            chatId,
            "Игрок " + playerNumber + "\n" + text,
            Keyboards.Next
            );
    }

    public async void NextPlayerFunc(CallbackQuery query, long chatId)
    {
        if (!ActiveGames.TryGetValue(chatId, out var gameId)) return;

        var game = await db.GameSessions.FindAsync(gameId);
        if (game == null) return;

        gameService.NextPlayer(game);

        await db.SaveChangesAsync();

        if (game!.Status == GameStatus.finished)
        {
            await SendAndReplaceMessage(
                bot,
                chatId,
                "Игра окончена 👾"
                );
            return;
        }

        await SendAndReplaceMessage(
            bot,
            chatId,
            "Передайте телефон следующему игроку",
            Keyboards.Show
            );
    }

    public async Task SendAndReplaceMessage(ITelegramBotClient bot, long chatId, string text, ReplyMarkup? keyboard = null)
    {
        if (LastMessageIds.TryGetValue(chatId, out var oldMsgId))
        {
            try
            {
                await bot.DeleteMessage(chatId, oldMsgId);
            }
            catch { }
        }

        var msg = await bot.SendMessage(chatId, text, replyMarkup: keyboard);

        LastMessageIds[chatId] = msg.MessageId;
    }
}

