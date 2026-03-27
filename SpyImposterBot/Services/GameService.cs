using System.Text.Json;

internal class GameService : IGameService
{
    private static readonly List<string> Words = new()
    {
        "Париж", "Самолет", "Школа", "Космос", "Компьютер"
    };

    public GameSession CreateGame(int playersCount)
    {
        var rnd = new Random();

        var word = Words[rnd.Next(Words.Count)];

        var spyIndex = rnd.Next(playersCount);

        var players = new List<GamePlayer>();

        for (int i = 0; i < playersCount; i++)
        {
            if (i == spyIndex)
            {
                players.Add(new GamePlayer
                {
                    Role = "spy",
                    Word = null
                });
            }
            else
            {
                players.Add(new GamePlayer
                {
                    Role = "civilian",
                    Word = word
                });
            }
        }

        var state = new GameState { Players =  players };

        return new GameSession
        {
            PlayersData = JsonSerializer.Serialize(state),
            CurrentPlayerIndex = 0,
            GameMode = "classic",
            Status = "in_progress"
        };
    }

    public GamePlayer GetPlayer(GameSession game)
    {
        var state = JsonSerializer.Deserialize<GameState>(game.PlayersData)!;
        return state.Players[game.CurrentPlayerIndex];
    }

    public void NextPlayer(GameSession game)
    {
        var state = JsonSerializer.Deserialize<GameState>(game.PlayersData)!;
        game.CurrentPlayerIndex++;
        if (game.CurrentPlayerIndex >= state.Players.Count)
        {
            game.Status = "finished";
        }
    }
}
