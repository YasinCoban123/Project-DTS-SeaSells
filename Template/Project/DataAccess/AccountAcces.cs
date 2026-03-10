using Npgsql;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

public class UserAccountsAccess
{
    private readonly string _connectionString;
    private string Table = "Account";

    public UserAccountsAccess()
    {
        // Lees connection string uit appsettings.json
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public void Write(AccountModel account)
    {
        using var _connection = new NpgsqlConnection(_connectionString);
        _connection.Open();

        string sql = $"INSERT INTO {Table} (name, email, password) VALUES (@Name, @Email, @Password)";
        _connection.Execute(sql, account);
    }

    public AccountModel GetByEmail(string email)
    {
        using var _connection = new NpgsqlConnection(_connectionString);
        _connection.Open();

        string sql = $"SELECT * FROM {Table} WHERE email = @Email";
        return _connection.QueryFirstOrDefault<AccountModel>(sql, new { Email = email });
    }

    public void Update(AccountModel account)
    {
        using var _connection = new NpgsqlConnection(_connectionString);
        _connection.Open();

        string sql = $"UPDATE {Table} SET email = @Email, password = @Password, name = @Name WHERE UserId = @UserId";
        _connection.Execute(sql, account);
    }

    public void Delete(AccountModel account)
    {
        using var _connection = new NpgsqlConnection(_connectionString);
        _connection.Open();

        string sql = $"DELETE FROM {Table} WHERE UserId = @UserId";
        _connection.Execute(sql, account);
    }
}