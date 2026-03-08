using Npgsql;

class Program
{
    static void Main()
    {
        string connectionString = "Host=145.24.237.57;Port=5432;Username=postgres;Password=Mixels123;Database=seasellsdb";

        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();

        Console.WriteLine("✅ Verbonden met database!");

        // Voeg een nieuw product toe aan winkelwagen
        string sql = "INSERT INTO winkelwagen (productnaam, aantal) VALUES (@product, @aantal)";

        using var cmd = new NpgsqlCommand(sql, connection);
        cmd.Parameters.AddWithValue("product", "Laptop");
        cmd.Parameters.AddWithValue("aantal", 2);

        int rowsAffected = cmd.ExecuteNonQuery();

        Console.WriteLine($"✅ {rowsAffected} record(s) toegevoegd!");
        UserLogin.Start();
    }
}