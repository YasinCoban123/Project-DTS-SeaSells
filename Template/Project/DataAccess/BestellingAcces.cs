using Dapper;
using Npgsql;
using Microsoft.Extensions.Configuration;

public class BestellingAccess
{
    private readonly string _connectionString;
    private string Table = "Bestellingen";

    public BestellingAccess()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public void Write(BestellingModel bestelling)
    {
        using var _connection = new NpgsqlConnection(_connectionString);
        _connection.Open();

        string sql = $"INSERT INTO {Table} (email, password, name, price) VALUES (@Email, @Password, @Name, @Price)";
        _connection.Execute(sql, bestelling);
    }

    public void Update(BestellingModel bestelling)
    {
        using var _connection = new NpgsqlConnection(_connectionString);
        _connection.Open();

        string sql = $"UPDATE {Table} SET email = @Email, password = @Password, name = @Name, price = @Price WHERE BestellingId = @BestellingId";
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

    public List<BestellingModel> GetById(long id)
    {
        using var _connection = new NpgsqlConnection(_connectionString);
        _connection.Open();

        string sql = $"SELECT * FROM {Table} WHERE BestellingId = @Id";
        return _connection.Query<BestellingModel>(sql, new { Id = id }).ToList();
    }
}