using Npgsql;
using Dapper;
using Microsoft.Extensions.Configuration;

public class BestellingAccess
{
    private readonly string _connectionString;
    private string Table = "Bestellingen";

    public BestellingAccess()
    {
        // Lees connection string uit appsettings.json
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public void Write(BestellingModel bestelling)
    {
        using var _connection = new NpgsqlConnection(_connectionString);
        _connection.Open();

        string sql = $"INSERT INTO {Table} (email, password, name) VALUES (@Email, @Password, @Name)";
        _connection.Execute(sql, bestelling);
    }

    public void Update(BestellingModel bestelling)
    {
        using var _connection = new NpgsqlConnection(_connectionString);
        _connection.Open();

        string sql = $"UPDATE {Table} SET email = @Email, password = @Password, name = @Name WHERE BestellingId = @BestellingId";
        _connection.Execute(sql, bestelling);
    }

    public void Delete(BestellingModel bestelling)
    {
        using var _connection = new NpgsqlConnection(_connectionString);
        _connection.Open();

        string sql = $"DELETE FROM {Table} WHERE BestellingId = @BestellingId";
        _connection.Execute(sql, bestelling);
    }

    public List<BestellingModel> GetAllOrders()
    {
        using var _connection = new NpgsqlConnection(_connectionString);
        _connection.Open();

        string sql = $"SELECT * FROM {Table}";
        return _connection.Query<BestellingModel>(sql).ToList();
    }
}