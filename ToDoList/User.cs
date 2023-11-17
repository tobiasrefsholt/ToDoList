namespace ToDoList;

public class User
{
    private string? _username = null;
    private string? _password = null;
    public int? UserId { get; private set; }

    public void AuthenticateUser()
    {
        var dbInstance = new Database(); 
        dbInstance.CreateConnection();
        dbInstance.InitializeTables();
        if (_username != null && _password != null)
        {
            UserId = dbInstance.GetUserId(_username, _password);    
        }
        dbInstance.Close();
        if (UserId != null) return;
        Console.WriteLine("User not Found. Try again og create an account.");
    }

    public void CreateUser()
    {
        var dbInstance = new Database(); 
        dbInstance.CreateConnection();
        dbInstance.InitializeTables();
        if (_username != null && _password != null)
        {
            dbInstance.InsertUser(_username, _password);
            UserId = dbInstance.GetUserId(_username, _password);
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
}