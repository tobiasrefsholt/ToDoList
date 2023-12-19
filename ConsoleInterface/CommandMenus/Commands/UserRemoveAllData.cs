using AppLogic;

namespace ConsoleInterface.CommandMenus.Commands;

public class UserRemoveAllData(ConsoleKey key, User user) : Command(key, "Delete user and remove data")
{
    public override void Run()
    {
        if (!UserInput.AskForBool("You are about to delete all your data! Continue?")) return;
        if (!user.IsAuthenticated) return;
        var toDoList = new ToDoList((int)user.UserId!);
        toDoList.RemoveTasksForUser();
        user.Delete();
        user.Logout();
    }
}