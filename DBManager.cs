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
}