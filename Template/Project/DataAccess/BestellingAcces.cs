using Dapper;
using Microsoft.Data.Sqlite;

public class BestellingAccess
{
    private SqliteConnection _connection =
        new SqliteConnection("Data Source=DataSources/project.db");
    private string Table = "Bestellingen";

    public void Write(BestellingModel bestelling)
    {
        string sql = $"INSERT INTO {Table} (UserId, ProductId) VALUES (@UserId, @ProductId)";
        _connection.Execute(sql, bestelling);
    }

    public void Delete(BestellingModel bestelling)
    {
        string sql = $"DELETE FROM {Table} WHERE Id = @Id";
        _connection.Execute(sql, bestelling);
    }

    public List<BestellingModel> GetAllOrders()
    {
        string sql = $"SELECT * FROM {Table}";
        return _connection.Query<BestellingModel>(sql).ToList();
    }

    public List<BestellingModel> GetOrdersByUser(long userId)
    {
        string sql = $"SELECT * FROM {Table} WHERE UserId = @UserId";
        return _connection.Query<BestellingModel>(sql, new { UserId = userId }).ToList();
    }
}