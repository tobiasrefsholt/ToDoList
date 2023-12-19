using AppLogic;

namespace ConsoleInterface.CommandMenus.Commands;

public class UserChangePassword(ConsoleKey key, User user) : Command(key, "Change password")
{
    public override void Run()
    {
        var oldPassword = UserInput.AskForString("Old Password: ", true);
        var newPassword = UserInput.AskForString("New password: ", true);
        user.ChangePassword(oldPassword, newPassword);
    }
}