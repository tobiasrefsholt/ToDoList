using System.Runtime.InteropServices.JavaScript;
using AppLogic;

namespace ConsoleInterface.CommandMenus.Commands;

public class ShowRemainingTasks(ConsoleKey key, User user) : Command(key, "Show Remaining Tasks")
{
    public override void Run()
    {
        var toDoList = new ToDoList((int)user.UserId!);
        toDoList.FetchRemainingTasks();
        TasksView.Menu(toDoList.GetTaskList(), "Remaining tasks");
    }
}