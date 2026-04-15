internal interface IGameService
{
    GameSession CreateGame(int playersCount);
    GamePlayer GetPlayer(GameSession game);
    void NextPlayer(GameSession game);
}
