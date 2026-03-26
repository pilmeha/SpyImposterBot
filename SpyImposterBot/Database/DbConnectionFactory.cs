using Npgsql;
using System.Data;

public interface IDbConnectionFactory
{
    IDbConnection Create();
}

internal class DbConnectionFactory : IDbConnectionFactory
{
    private readonly string _connectionString;

    public DbConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection Create() => new NpgsqlConnection(_connectionString);
}
