using System.Diagnostics;
using AppLogic;

namespace ConsoleInterface.CommandMenus.Commands;

public class UserRegister(ConsoleKey key, User user) : Command(key, "Register")
{
    public override void Run()
    {
        Console.WriteLine("Register account");
        Console.Write("Create Username: ");
        var username = Console.ReadLine();
        Console.Write("Create Password: ");
        var password = Console.ReadLine();
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) return;
        user.CreateUser(username, password);
    }
}