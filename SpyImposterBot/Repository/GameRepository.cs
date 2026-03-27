using Dapper;

internal class GameRepository
{
    private readonly IDbConnectionFactory _factory;
    public GameRepository(IDbConnectionFactory factory) 
    {
        _factory = factory;
    }

    public async Task<long> Create(GameSession game)
    {
        var sql = @"
            INSERT INTO game_sessions (game_mode, players_data, current_player_index, status)
            VALUES (@GameMode, @PlayersData, @CurrentPlayerIndex, @Status)
            RETURNING id;
        ";

        using var conn = _factory.Create();

        return await conn.ExecuteScalarAsync<long>(sql, game);
    }

    public async Task<GameSession?> Get(long id)
    {
        var sql = "SELECT * FROM game_sessions WHERE id = @id";

        using var conn = _factory.Create();

        return await conn.QueryFirstOrDefaultAsync<GameSession>(sql, new { id });
    }

    public async Task Update(GameSession game)
    {
        var sql = @"
            UPDATE game_sessions
            SET current_player_index = @CurrentPlayerIndex,
                status = @Status
            WHERE id = @Id;
        ";

        using var conn = _factory.Create();

        await conn.ExecuteAsync(sql, game);
    }
}
