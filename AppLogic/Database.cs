using System.Data.SQLite;
using Dapper;

namespace AppLogic;

public class Database
{
    private const string ConnectionString = "Data Source=database.db;Version=3;New=True;Compress=True;";

    public Database()
    {
        InitializeTables();
    }

    private void InitializeTables()
    {
        var usersTableSql = new SQLiteCommand();
        usersTableSql.CommandText = "CREATE TABLE IF NOT EXISTS users (username VARCHAR(255), password VARCHAR(255))";
        var tasksTableSql = new SQLiteCommand();
        tasksTableSql.CommandText =
            "CREATE TABLE IF NOT EXISTS tasks " +
            "(UserId INT, Title VARCHAR(255), Description VARCHAR(255), Date DATETIME, DueDate DATETIME)";
        Insert(usersTableSql);
        Insert(tasksTableSql);
    }

    private void Insert(SQLiteCommand command)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        connection.Open();
        command.Connection = connection;
        command.ExecuteNonQuery();
        command.Dispose();
    }

    private string ReadSingle(SQLiteCommand command)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        connection.Open();
        command.Connection = connection;
        using var dataReader = command.ExecuteReader();
        var response = string.Empty;
        while (dataReader.Read())
        {
            response = dataReader.GetString(0);
            break;
        }

        return response;
    }

    private int? ReadInt(SQLiteCommand command)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        connection.Open();
        command.Connection = connection;
        using var dataReader = command.ExecuteReader();
        int? response = null;
        while (dataReader.Read())
        {
            response = dataReader.GetInt32(0);
            break;
        }

        return response;
    }

    public void InsertUser(string username, string password)
    {
        var command = new SQLiteCommand();
        command.CommandText = "INSERT INTO users (username, password) VALUES (?,?)";
        command.Parameters.AddWithValue(null, username);
        command.Parameters.AddWithValue(null, password);
        Insert(command);
    }

    public void InsertTask(TodoTask todoTask)
    {
        var command = new SQLiteCommand();
        command.CommandText =
            "INSERT INTO tasks (UserId, Title, Description, Date, DueDate) " +
            "VALUES (@UserId, @Title, @Description, @Date, @DueDate)";
        command.Parameters.AddWithValue("@UserId", todoTask.UserId);
        command.Parameters.AddWithValue("@Title", todoTask.Title);
        command.Parameters.AddWithValue("@Description", todoTask.Description);
        command.Parameters.AddWithValue("@Date", todoTask.Date);
        command.Parameters.AddWithValue("@DueDate", todoTask.DueDate);
        Insert(command);
    }

    public int? GetIdByUsername(string username)
    {
        var command = new SQLiteCommand();
        command.CommandText = "SELECT rowid FROM users WHERE username LIKE @username";
        command.Parameters.AddWithValue("@username", username);
        return ReadInt(command);
    }

    public string GetPasswordHash(string username)
    {
        var command = new SQLiteCommand();
        command.CommandText = "SELECT password FROM users WHERE username LIKE @username";
        command.Parameters.AddWithValue("@username", username);
        return ReadSingle(command);
    }

    public List<TodoTask> GetTasksForUser(int userId)
    {
        const string sql = "SELECT * FROM tasks WHERE UserId LIKE @UserId";
        using var connection = new SQLiteConnection(ConnectionString);
        return connection.Query<TodoTask>(sql, new { UserId = userId }).ToList();
    }
}