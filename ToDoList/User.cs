namespace ToDoList;

public class User
{
    private string? _username;
    private string? _password;
    public bool IsAuthenticated { get; private set; }
    public int? UserId { get; private set; }

    public void AuthenticateUser(Database database)
    {
        if (_username != null && _password != null)
        {
            UserId = database.GetIdByUsername(_username);
            var hash = database.GetPasswordHash(_username);
            IsAuthenticated = PasswordHash.ValidatePassword(_password, hash);
        }

        Console.Clear();
        if (IsAuthenticated)
        {
            Console.WriteLine($"Hello, {_username}. You're logged in!");
            return;
        }

        Console.WriteLine("Wrong username or password. Try again og create an account.");
    }

    private void CreateUser()
    {
        var dbInstance = new Database();
        if (_username == null || _password == null) return;
        var hash = PasswordHash.CreateHash(_password);
        dbInstance.InsertUser(_username, hash);
        UserId = dbInstance.GetIdByUsername(_username);
    }

    public void ShowLoginPrompt()
    {
        Console.WriteLine("Press any key to log in, or press \"C\" to create a new account.");
        var input = Console.ReadKey().KeyChar;
        if (input != 'c' && input != 'C')
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
        _username = Console.ReadLine();
        Console.Write("Create Password: ");
        _password = Console.ReadLine();
        if (_username == null || _password == null)
        {
            Console.WriteLine("Please enter a username and password");
            return;
        }

        CreateUser();
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