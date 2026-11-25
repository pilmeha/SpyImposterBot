internal interface IGameService
{
    Task<GameSession> CreateGameAsync(int playersCount, int packId, long createdByTelegramId);
    GamePlayer GetPlayer(GameSession game);
    void NextPlayer(GameSession game);
}
