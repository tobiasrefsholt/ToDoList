using AppLogic;

namespace ConsoleInterface.CommandMenus.Commands;

public class UserLogout(ConsoleKey key, User user) : Command(key, "Logout")
{
    public override void Run()
    {
        user.Logout();
    }
}