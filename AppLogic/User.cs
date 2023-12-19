using System.Data.SQLite;

namespace AppLogic;

public class User
{
    public string? Username { get; private set; }
    public bool IsAuthenticated { get; private set; }
    public int? UserId { get; private set; }

    public void Authenticate(string username, string password)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            Logout();
            return;
        }

        var database = new Database();
        var userId = GetId(username);
        if (userId == null) return;

        var hash = GetHash((int)userId);
        Username = username;
        UserId = userId;
        IsAuthenticated = !string.IsNullOrEmpty(hash) && PasswordHash.ValidatePassword(password, hash);
    }

    private string GetHash(int userId)
    {
        var command = new SQLiteCommand();
        command.CommandText = "SELECT password FROM users WHERE rowid LIKE @userId";
        command.Parameters.AddWithValue("@userId", userId);
        var database = new Database();
        return database.ReadSingle(command);
    }

    public void CreateUser(string username, string password)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) return;
        var hash = PasswordHash.CreateHash(password);
        InsertUser(username, hash);
        Authenticate(username, password);
    }

    private void InsertUser(string username, string hash)
    {
        var command = new SQLiteCommand();
        command.CommandText = "INSERT INTO users (username, password) VALUES (@Username,@Password)";
        command.Parameters.AddWithValue("@Username", username);
        command.Parameters.AddWithValue("@Password", hash);
        var database = new Database();
        database.Insert(command);
    }

    public void Logout()
    {
        IsAuthenticated = false;
        UserId = null;
        Username = null;
    }

    public void Delete()
    {
        var database = new Database();
        var sqlCommand = new SQLiteCommand("DELETE FROM users WHERE rowid LIKE @UserId");
        sqlCommand.Parameters.AddWithValue("@UserId", UserId);
        database.Insert(sqlCommand);
    }

    public void ChangePassword(string oldPassword, string newPassword)
    {
        Authenticate(Username!, oldPassword);
        if (!IsAuthenticated) return;
        SetNewPassword(newPassword);
    }

    private void SetNewPassword(string newPassword)
    {
        var hash = PasswordHash.CreateHash(newPassword);
        var database = new Database();
        var sqlCommand = new SQLiteCommand("UPDATE users SET password = @Hash WHERE rowid LIKE @UserId");
        sqlCommand.Parameters.AddWithValue("@Hash", hash);
        sqlCommand.Parameters.AddWithValue("@UserId", UserId);
        database.Insert(sqlCommand);
    }

    private int? GetId(string username)
    {
        var command = new SQLiteCommand();
        command.CommandText = "SELECT rowid FROM users WHERE username LIKE @username";
        command.Parameters.AddWithValue("@username", username);
        var database = new Database();
        return database.ReadInt(command);
    }
}