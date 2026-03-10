using Npgsql;
using Dapper;

public class ProductAccess
{
    private NpgsqlConnection _connection => new NpgsqlConnection(
        "Host=localhost;Port=5432;Username=postgres;Password=Mixels123;Database=postgres"
    );

    private string Table = "product";

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