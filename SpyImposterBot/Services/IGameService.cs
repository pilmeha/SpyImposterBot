internal interface IGameService
{
    Task<GameSession> CreateGameAsync(int playersCount, int packId);
    GamePlayer GetPlayer(GameSession game);
    void NextPlayer(GameSession game);
}
