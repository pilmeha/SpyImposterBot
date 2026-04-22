public class GameSessionStorage
{
    public Dictionary<long, long> ActiveGames { get; } = new();
    public Dictionary<long, int> LastMessageIds { get; } = new();
    public Dictionary<long, long> SelectedPack { get;  } = new();
}
