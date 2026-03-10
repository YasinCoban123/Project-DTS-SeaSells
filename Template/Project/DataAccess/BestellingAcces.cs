using Npgsql;
using Dapper;


public class BestellingAccess
{
    private NpgsqlConnection _connection = new NpgsqlConnection(
        "Host=localhost;Port=5432;Username=postgres;Password=Mixels123;Database=postgres"
    );

    private string Table = "Bestellingen";

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

}