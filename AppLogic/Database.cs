using System.Data.SQLite;
using System.Net.NetworkInformation;
using Dapper;

namespace AppLogic;

public class Database
{
    private readonly string _dbPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/todolist.db";
    private readonly string _connectionString;

    public Database()
    {
        _connectionString = $"Data Source={_dbPath};Version=3;New=True;Compress=True;";
        InitializeTables();
    }

    private void InitializeTables()
    {
        var usersTableSql = new SQLiteCommand();
        usersTableSql.CommandText = "CREATE TABLE IF NOT EXISTS users (username VARCHAR(255), password VARCHAR(255), UNIQUE (username))";
        var tasksTableSql = new SQLiteCommand();
        tasksTableSql.CommandText =
            "CREATE TABLE IF NOT EXISTS tasks " +
            "(UserId INT, Title VARCHAR(255), Description VARCHAR(255), Date DATETIME, DueDate DATETIME, IsDone BOOL)";
        Insert(usersTableSql);
        Insert(tasksTableSql);
    }

    public void Insert(SQLiteCommand command)
    {
        using var connection = new SQLiteConnection(_connectionString);
        connection.Open();
        command.Connection = connection;
        command.ExecuteNonQuery();
        command.Dispose();
    }

    public string ReadSingle(SQLiteCommand command)
    {
        using var connection = new SQLiteConnection(_connectionString);
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

    public int? ReadInt(SQLiteCommand command)
    {
        using var connection = new SQLiteConnection(_connectionString);
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

    public void InsertTask(TodoTask todoTask)
    {
        var command = new SQLiteCommand();
        command.CommandText =
            "INSERT INTO tasks (UserId, Title, Description, Date, DueDate, IsDone) " +
            "VALUES (@UserId, @Title, @Description, @Date, @DueDate, @IsDone)";
        command.Parameters.AddWithValue("@UserId", todoTask.UserId);
        command.Parameters.AddWithValue("@Title", todoTask.Title);
        command.Parameters.AddWithValue("@Description", todoTask.Description);
        command.Parameters.AddWithValue("@Date", todoTask.Date);
        command.Parameters.AddWithValue("@DueDate", todoTask.DueDate);
        command.Parameters.AddWithValue("@IsDone", todoTask.IsDone);
        Insert(command);
    }

    public List<TodoTask>GetTaskList(string sql, object param)
    {
        using var connection = new SQLiteConnection(_connectionString);
        return connection.Query<TodoTask>(sql, param).ToList();
    }
}