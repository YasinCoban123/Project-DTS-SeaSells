using Microsoft.Data.Sqlite;
using Dapper;

public class StoreAcces
{
    private SqliteConnection _connection =
        new SqliteConnection("Data Source=DataSources/project.db");

    public List<ProductModel> GetAllProducts()
    {
        string sql = "SELECT * FROM Product";

        return _connection.Query<ProductModel>(sql).ToList();
    }

    public List<ProductModel> SearchProducts(List<string> words)
    {
        List<ProductModel> results = new List<ProductModel>();

        foreach (string word in words)
        {
            string sql = @"
            SELECT * FROM Product
            WHERE LOWER(ProductName) LIKE '%' || LOWER(@Word) || '%'
               OR LOWER(Description) LIKE '%' || LOWER(@Word) || '%'
               OR LOWER(Keywords) LIKE '%' || LOWER(@Word) || '%'";

            var found = _connection.Query<ProductModel>(sql, new { Word = word }).ToList();

            foreach (var product in found)
            {
                if (!results.Any(p => p.ProductId == product.ProductId))
                {
                    results.Add(product);
                }
            }
        }

        return results;
    }
}