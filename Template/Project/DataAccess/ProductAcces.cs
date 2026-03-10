using Microsoft.Data.Sqlite;

using Dapper;

public class ProductAccess
{
    private SqliteConnection _connection = new SqliteConnection($"Data Source=DataSources/project.db");

    private string Table = "Product";

    public void Write(BestellingModel bestelling)
    {
        string sql = $"INSERT INTO {Table} (email, password, name) VALUES (@Email, @Password, @Name)";
        _connection.Execute(sql, bestelling);
    }

    public void Update(AccountModel account)
    {
        string sql = $"UPDATE {Table} SET email = @Email, password = @Password, name = @Name WHERE AccountId = @AccountId";
        _connection.Execute(sql, account);
    }

    public void Delete(AccountModel account)
    {
        string sql = $"DELETE FROM {Table} WHERE UserId = @UserId";
        _connection.Execute(sql, account);
    }

    public List<ProductModel> GetAllProducts()
    {
        string sql = $"SELECT * FROM {Table}";
        return _connection.Query<ProductModel>(sql).ToList();
    }

}