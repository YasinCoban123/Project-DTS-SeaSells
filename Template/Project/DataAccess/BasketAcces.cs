using Microsoft.Data.Sqlite;
using Dapper;

public class BasketAccess
{
    private SqliteConnection _connection =
        new SqliteConnection("Data Source=DataSources/project.db");

    public void AddToBasket(long userId, long productId)
    {
        string sql = "INSERT INTO Winkelwagen (UserId, ProductId) VALUES (@UserId, @ProductId)";
        _connection.Execute(sql, new { UserId = userId, ProductId = productId });
    }

    public List<WinkelwagenModel> GetBasketByUser(long userId)
    {
        string sql = "SELECT * FROM Winkelwagen WHERE UserId = @UserId";
        return _connection.Query<WinkelwagenModel>(sql, new { UserId = userId }).ToList();
    }

    public void ClearBasket(long userId)
    {
        string sql = "DELETE FROM Winkelwagen WHERE UserId = @UserId";
        _connection.Execute(sql, new { UserId = userId });
    }
}