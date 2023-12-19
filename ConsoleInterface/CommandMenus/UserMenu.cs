using AppLogic;
using ConsoleInterface.CommandMenus.Commands;

namespace ConsoleInterface.CommandMenus;

public class UserMenu(User user) : Menu(
    [
        new UserChangePassword(ConsoleKey.D1, user),
        new UserRemoveAllData(ConsoleKey.D2, user),
        new UserLogout(ConsoleKey.D3, user)
    ], "User menu")
{
    
}