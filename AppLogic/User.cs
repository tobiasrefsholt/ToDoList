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
        var userId = database.GetUserId(username);
        if (userId == null) return;

        var hash = database.GetPasswordHash((int)userId);
        Username = username;
        UserId = userId;
        IsAuthenticated = !string.IsNullOrEmpty(hash) && PasswordHash.ValidatePassword(password, hash);
    }

    public void CreateUser(string username, string password)
    {
        var dbInstance = new Database();
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) return;
        var hash = PasswordHash.CreateHash(password);
        dbInstance.InsertUser(username, hash);
        Authenticate(username, password);
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
}