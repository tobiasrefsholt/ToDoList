using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList;

class Database
{
    private SQLiteConnection _sqliteConn;
    private SQLiteConnection _conn;

    public void CreateConnection()
    {
        if (_conn != null) return;
        // Create a new database connection:
        _conn = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;");
        // Open the connection:
        try
        {
            _conn.Open();
        }
        catch (Exception ex)
        {
            // ignored
        }
    }

    public void InitializeTables()
    {
        CreateConnection();
        const string usersTableSql = "CREATE TABLE IF NOT EXISTS users (id INT AUTO_INCREMENT, username VARCHAR(255), password VARCHAR(255))";
        const string tasksTableSql = "CREATE TABLE IF NOT EXISTS tasks (id INT AUTO_INCREMENT, user_id INT, title VARCHAR(255), description VARCHAR(255), date DATETIME, due_date DATETIME)";
        var sqliteCmd = _conn.CreateCommand();
        sqliteCmd.CommandText = usersTableSql;
        sqliteCmd.ExecuteNonQuery();
        sqliteCmd.CommandText = tasksTableSql;
        sqliteCmd.ExecuteNonQuery();
    }

    public void InsertUser(string username, string password)
    {
        CreateConnection();
        var insertSql = new SQLiteCommand("INSERT INTO users (username, password) VALUES (?,?)", _conn);
        insertSql.Parameters.AddWithValue("username", username);
        insertSql.Parameters.AddWithValue("password", password);
        insertSql.ExecuteNonQuery();
    }
    
    public void InsertTask(int userId, string title, string description, string date, string dueDate)
    {
        InsertData("INSERT INTO tasks (user_id, title, description, date, due_date) VALUES (userId, title, description, date, dueDate)");
    }

    private void InsertData(string sql)
    {
        CreateConnection();
        var sqliteCmd = _conn.CreateCommand();
        sqliteCmd.CommandText = sql;
        sqliteCmd.ExecuteNonQuery();
    }

    public int? GetUserId(string username, string password)
    {
        return ReadIntData("SELECT id FROM users WHERE username='" + username + "' AND password='" + password + "'");
    }

    private int? ReadIntData(string sql)
    {
        CreateConnection();
        var sqliteCmd = _conn.CreateCommand();
        sqliteCmd.CommandText = sql;
        var sqliteDatareader = sqliteCmd.ExecuteReader();
        while (sqliteDatareader.Read())
        {
            return sqliteDatareader.GetInt32(0);
        }
        return null;
    }

    private void ReadStringData(string sql, string table)
    {
        var sqliteCmd = _conn.CreateCommand();
        sqliteCmd.CommandText = $"SELECT * FROM {table}";

        var sqliteDatareader = sqliteCmd.ExecuteReader();
        while (sqliteDatareader.Read())
        {
            var myreader = sqliteDatareader.GetString(0);
            Console.WriteLine(myreader);
        }

        _conn.Close();
    }
    public void Close()
    {
        _conn.Close();
    }
}