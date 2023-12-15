using AppLogic;

namespace ConsoleInterface.CommandMenus.Commands;

public class UserLogin(ConsoleKey key, User user) : Command(key, "Login")
{
    public override void Run()
    {
        ShowLoginPrompt();
        ShowAuthenticationResult();
    }

    private void ShowAuthenticationResult()
    {
        Console.Clear();
        if (user.IsAuthenticated)
        {
            Console.WriteLine($"Hello, {user.Username}. You're logged in!");
            return;
        }

        Console.WriteLine("Wrong username or password. Try again or create an account.");
    }

    private void ShowLoginPrompt()
    {
        Console.WriteLine("Please login");
        Console.Write("Username: ");
        var username = Console.ReadLine();
        Console.Write("Password: ");
        var password = Console.ReadLine();
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) return;
        user.Authenticate(username, password);
    }
}