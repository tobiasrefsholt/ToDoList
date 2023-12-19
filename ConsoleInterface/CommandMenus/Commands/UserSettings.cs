using AppLogic;

namespace ConsoleInterface.CommandMenus.Commands;

public class UserSettings(ConsoleKey key, User user) : Command(key, "User settings")
{
    public override void Run()
    {
        var userMenu = new UserMenu(user);
        userMenu.Run();
    }
}