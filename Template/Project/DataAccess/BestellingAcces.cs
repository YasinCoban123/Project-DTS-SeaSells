using Microsoft.Data.Sqlite;
using Dapper;

public class BestellingAccess
{
    private readonly string _connectionString;
    private string Table = "Bestellingen";

    private SqliteConnection _connection =
        new SqliteConnection("Data Source=DataSources/project.db");

    public void Write(BestellingModel bestelling)
    {
        string sql = $"INSERT INTO {Table} (email, password, name, price) VALUES (@Email, @Password, @Name, @Price)";
        _connection.Execute(sql, bestelling);
    }

    public void Update(BestellingModel bestelling)
    {

        string sql = $"UPDATE {Table} SET email = @Email, password = @Password, name = @Name, price = @Price WHERE BestellingId = @BestellingId";
        _connection.Execute(sql, bestelling);
    }

    public void Delete(BestellingModel bestelling)
    {
        string sql = $"DELETE FROM {Table} WHERE BestellingId = @BestellingId";
        _connection.Execute(sql, bestelling);
    }

    public List<BestellingModel> GetAllOrders()
    {
        string sql = $"SELECT * FROM {Table}";
        return _connection.Query<BestellingModel>(sql).ToList();
    }

    public List<BestellingModel> GetById(long id)
    {
        string sql = $"SELECT * FROM {Table} WHERE BestellingId = @Id";
        return _connection.Query<BestellingModel>(sql, new { Id = id }).ToList();
    }
}