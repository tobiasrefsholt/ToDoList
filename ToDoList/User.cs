namespace ToDoList;

public class User
{
    private string? _username = null;
    private string? _password = null;
    public bool IsAuthenticated { get; private set; }
    public int? UserId { get; private set; }

    public void AuthenticateUser()
    {
        var dbInstance = new Database();
        dbInstance.CreateConnection();
        dbInstance.InitializeTables();
        if (_username != null && _password != null)
        {
            UserId = dbInstance.GetIdByUsername(_username);
            var hash = dbInstance.GetPasswordHash(_username);
            if (hash != null)
            {
                IsAuthenticated = PasswordHash.ValidatePassword(_password, hash);
            }
        }

        dbInstance.Close();
        Console.Clear();
        if (IsAuthenticated)
        {
            Console.WriteLine($"Hello, {_username}. You're logged in!");
            return;
        }

        Console.WriteLine("Wrong username or password. Try again og create an account.");
    }

    public void CreateUser(string? username, string? password)
    {
        var dbInstance = new Database();
        dbInstance.CreateConnection();
        dbInstance.InitializeTables();
        if (username != null && password != null)
        {
            _username = username;
            _password = PasswordHash.CreateHash(password);
            dbInstance.InsertUser(_username, _password);
            UserId = dbInstance.GetIdByUsername(_username);
        }

        dbInstance.Close();
    }

    public void ShowLoginPromt()
    {
        Console.WriteLine("Press any key to log in, or press \"C\" to create a new account.");
        string? input = Console.ReadLine();
        if (input == null || input.ToLower() != "c")
        {
            ShowLogin();
            return;
        }

        ShowRegister();
    }

    private void ShowRegister()
    {
        Console.WriteLine("Register account");
        Console.Write("Create Username: ");
        var username = Console.ReadLine();
        Console.Write("Create Password: ");
        var password = Console.ReadLine();
        if (username == null || password == null)
        {
            Console.WriteLine("Please enter a username and password");
            return;
        }

        CreateUser(username, password);
    }

    private void ShowLogin()
    {
        Console.WriteLine("Please login");
        Console.Write("Username: ");
        _username = Console.ReadLine();
        Console.Write("Password: ");
        _password = Console.ReadLine();
    }

    public void Logout()
    {
        IsAuthenticated = false;
        UserId = null;
        _username = null;
        _password = null;
    }
}