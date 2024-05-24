using System.Data;
using System.Data.SQLite;
public class DBManager
{
    private readonly string _connectionString;

    // Constructor
    public DBManager(string dbPath)
    {
        _connectionString = $"Data Source={dbPath};Version=3;";
    }

    private IDbConnection CreateConnection()
    {
        return new SQLiteConnection (_connectionString);
    }

    public void InitDatabase()
    {
        using(var conn = CreateConnection())
        {
            conn.Open();

            var cmd = conn.CreateCommand();

            cmd.CommandText = @"CREATE TABLE IF NOT EXISTS 
                                Products 
                                (
                                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                    Name TEXT NOT NULL,
                                    Price DECIMAL NOT NULL
                                )";

            cmd.ExecuteNonQuery();
        }
    }
}