using Npgsql;
using Microsoft.Data.Sqlite;

using Dapper;
using Microsoft.Extensions.Configuration;
public class ProductAccess
{
    private readonly string _connectionString;
    private string Table = "product";

    private SqliteConnection _connection =
        new SqliteConnection("Data Source=DataSources/project.db");
    

    public void Write(ProductModel product)
    {
        string sql = $"INSERT INTO {Table} (ProductName, Description, keywords, Price) VALUES (@ProductName, @Description, @keywords, @Price)";
        _connection.Execute(sql, product);
    }

    public void Update(ProductModel product)
    {
        string sql = $"UPDATE {Table} SET ProductName = @ProductName, Description = @Description, keywords = @keywords, Price = @Price WHERE productid = @ProductId";
        _connection.Execute(sql, product);
    }

    public void Delete(ProductModel product)
    {
        string sql = $"DELETE FROM {Table} WHERE productid = @ProductId";
        _connection.Execute(sql, product);
    }

    public List<ProductModel> GetAllProducts()
    {
        string sql = $"SELECT * FROM {Table}";
        return _connection.Query<ProductModel>(sql).ToList();
    }
}