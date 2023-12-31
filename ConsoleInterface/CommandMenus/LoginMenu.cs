using AppLogic;
using ConsoleInterface.CommandMenus.Commands;

namespace ConsoleInterface.CommandMenus;

public class LoginMenu(User user) : Menu(
[
    new UserLogin(ConsoleKey.D1, user),
    new UserRegister(ConsoleKey.D2, user),
    new Exit(ConsoleKey.D3)
], "Place login or register")
{
    
}