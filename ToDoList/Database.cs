using System.Data.SQLite;

namespace ToDoList;

public class Database
{
    private const string ConnectionString = "Data Source=database.db;Version=3;New=True;Compress=True;";

    public Database()
    {
        InitializeTables();
    }

    private void InitializeTables()
    {
        var usersTableSql = new SQLiteCommand(
            "CREATE TABLE IF NOT EXISTS users (username VARCHAR(255), password VARCHAR(255))");
        var tasksTableSql = new SQLiteCommand(
            "CREATE TABLE IF NOT EXISTS tasks (user_id INT, title VARCHAR(255), description VARCHAR(255), date DATETIME, due_date DATETIME)");
        Insert(usersTableSql);
        Insert(tasksTableSql);
    }

    private void Insert(SQLiteCommand command)
    {
        using var c = new SQLiteConnection(ConnectionString);
        c.Open();
        command.Connection = c;
        command.ExecuteNonQuery();
    }

    private string Read(SQLiteCommand command)
    {
        using var c = new SQLiteConnection(ConnectionString);
        c.Open();
        command.Connection = c;
        using var rdr = command.ExecuteReader();
        var response = string.Empty;
        while (rdr.Read())
        {
            response = rdr.GetString(0);
            break;
        }

        return response;
    }

    private int? ReadInt(SQLiteCommand command)
    {
        using var c = new SQLiteConnection(ConnectionString);
        c.Open();
        command.Connection = c;
        using var rdr = command.ExecuteReader();
        int? response = null;
        while (rdr.Read())
        {
            response = rdr.GetInt32(0);
            break;
        }

        return response;
    }

    public void InsertUser(string username, string password)
    {
        var command = new SQLiteCommand("INSERT INTO users (username, password) VALUES (?,?)");
        command.Parameters.AddWithValue("username", username);
        command.Parameters.AddWithValue("password", password);
        Insert(command);
    }

    public void InsertTask(Task task)
    {
        var command =
            new SQLiteCommand("INSERT INTO tasks (user_id, title, description, date, due_date) VALUES (?,?,?,?,?)");
        command.Parameters.AddWithValue("user_id", task.UserId);
        command.Parameters.AddWithValue("title", task.Title);
        command.Parameters.AddWithValue("description", task.Description);
        command.Parameters.AddWithValue("date", task.Date);
        command.Parameters.AddWithValue("due_date", task.DueDate);
        Insert(command);
    }

    public int? GetIdByUsername(string username)
    {
        var command = new SQLiteCommand("SELECT rowid FROM users WHERE username LIKE @username");
        command.Parameters.AddWithValue("@username", username);
        return ReadInt(command);
    }

    public string GetPasswordHash(string username)
    {
        var command = new SQLiteCommand("SELECT password FROM users WHERE username LIKE @username");
        command.Parameters.AddWithValue("@username", username);
        return Read(command);
    }
}