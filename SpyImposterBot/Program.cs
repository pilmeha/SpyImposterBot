using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using DotNetEnv;
using MihaZupan;

Env.Load();
var botToken = Environment.GetEnvironmentVariable("BOT_TOKEN")
    ?? throw new InvalidOperationException("BOT_TOKEN not set");

// Настройка proxy
var proxyHost = Environment.GetEnvironmentVariable("PROXY_HOST")
    ?? throw new InvalidOperationException("PROXY_HOST not set");

var proxyPort = Environment.GetEnvironmentVariable("PROXY_PORT")
    ?? throw new InvalidOperationException("PROXY_PORT not set");

var proxyUserName = Environment.GetEnvironmentVariable("PROXY_USERNAME")
    ?? throw new InvalidOperationException("PROXY_USERNAME not set");

var ProxyPassword = Environment.GetEnvironmentVariable("PROXY_PASSWORD")
    ?? throw new InvalidOperationException("PROXY_PASSWORD not set");

var proxy = new HttpToSocks5Proxy(proxyHost, int.Parse(proxyPort), proxyUserName, ProxyPassword);

var handler = new HttpClientHandler
{
    Proxy = proxy,
    UseProxy = true
};

var httpClient = new HttpClient(handler);

using var cts = new CancellationTokenSource();
//var bot = new TelegramBotClient(botToken, cancellationToken: cts.Token);
var bot = new TelegramBotClient(botToken, httpClient);
var me = await bot.GetMe();
bot.OnError += OnError;
bot.OnMessage += OnMessage;
bot.OnUpdate += OnUpdate;

Console.WriteLine($"@{me.Username} is running... Press Enter to terminate");
Console.ReadLine();
cts.Cancel(); // stop the bot

// method to handle errors in polling or in your OnMessage/OnUpdate code
async Task OnError(Exception exception, HandleErrorSource source)
{
    Console.WriteLine(exception); // just dump the exception to the console
}

// method that handle messages received by the bot:
async Task OnMessage(Message msg, UpdateType type)
{
    if (msg.Text == "/start")
    {
        await bot.SendMessage(msg.Chat, "Welcome! Pick one direction",
            replyMarkup: new InlineKeyboardButton[] { "Left", "Right" });
    }
}

// method that handle other types of updates received by the bot:
async Task OnUpdate(Update update)
{
    if (update is { CallbackQuery: { } query }) // non-null CallbackQuery
    {
        await bot.AnswerCallbackQuery(query.Id, $"You picked {query.Data}");
        await bot.SendMessage(query.Message!.Chat, $"User {query.From} clicked on {query.Data}");
    }
}
