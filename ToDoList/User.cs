namespace ToDoList;

public class User
{
    public string? Username { get; private set; }
    private string? _password;
    public bool IsAuthenticated { get; private set; }
    public int? UserId { get; private set; }

    public void Authenticate()
    {
        if (Username == null || _password == null)
        {
            IsAuthenticated = false;
            return;
        }

        var database = new Database();
        UserId = database.GetIdByUsername(Username);
        var hash = database.GetPasswordHash(Username);
        IsAuthenticated = !string.IsNullOrEmpty(hash) && PasswordHash.ValidatePassword(_password, hash);
        ShowAuthenticationResult();
    }

    public void ShowAuthenticationResult()
    {
        Console.Clear();
        if (IsAuthenticated)
        {
            Console.WriteLine($"Hello, {Username}. You're logged in!");
            return;
        }

        Console.WriteLine("Wrong username or password. Try again or create an account.");
    }

    private void CreateUser()
    {
        var dbInstance = new Database();
        if (Username == null || _password == null) return;
        var hash = PasswordHash.CreateHash(_password);
        dbInstance.InsertUser(Username, hash);
        UserId = dbInstance.GetIdByUsername(Username);
        IsAuthenticated = true;
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
        Username = Console.ReadLine();
        Console.Write("Create Password: ");
        _password = Console.ReadLine();
        if (Username == null || _password == null)
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
        Username = Console.ReadLine();
        Console.Write("Password: ");
        _password = Console.ReadLine();
    }

    public void Logout()
    {
        IsAuthenticated = false;
        UserId = null;
        Username = null;
        _password = null;
    }
}