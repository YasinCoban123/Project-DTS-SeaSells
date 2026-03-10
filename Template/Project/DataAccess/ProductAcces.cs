using Npgsql;
using Microsoft.Data.Sqlite;

using Dapper;
using Microsoft.Extensions.Configuration;
public class ProductAccess
{
    private readonly string _connectionString;
    private string Table = "product";

    public ProductAccess()
    {
        // Lees de connection string uit appsettings.json
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public void Write(ProductModel product)
    {
        using var _connection = new NpgsqlConnection(_connectionString);
        _connection.Open();
        string sql = $"INSERT INTO {Table} (ProductName, Description, keywords, Price) VALUES (@ProductName, @Description, @keywords, @Price)";
        _connection.Execute(sql, product);
    }

    public void Update(ProductModel product)
    {
        using var _connection = new NpgsqlConnection(_connectionString);
        _connection.Open();
        string sql = $"UPDATE {Table} SET ProductName = @ProductName, Description = @Description, keywords = @keywords, Price = @Price WHERE productid = @ProductId";
        _connection.Execute(sql, product);
    }

    public void Delete(ProductModel product)
    {
        using var _connection = new NpgsqlConnection(_connectionString);
        _connection.Open();
        string sql = $"DELETE FROM {Table} WHERE productid = @ProductId";
        _connection.Execute(sql, product);
    }

    public List<ProductModel> GetAllProducts()
    {
        using var _connection = new NpgsqlConnection(_connectionString);
        _connection.Open();
        string sql = $"SELECT * FROM {Table}";
        return _connection.Query<ProductModel>(sql).ToList();
    }
}