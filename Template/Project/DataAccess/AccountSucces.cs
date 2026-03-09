using Microsoft.Data.Sqlite;

using Dapper;


public class UserAccountsAccess
{
    private SqliteConnection _connection = new SqliteConnection($"Data Source=DataSources/project.db");

    private string Table = "Account";

    public void Write(AccountModel account)
    {
        string sql = $"INSERT INTO {Table} (email, password, name) VALUES (@Email, @Password, @Name)";
        _connection.Execute(sql, account);
    }

    public AccountModel GetByEmail(string email)
    {
        string sql = $"SELECT * FROM {Table} WHERE email = @Email";
        return _connection.QueryFirstOrDefault<AccountModel>(sql, new { Email = email });
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

}