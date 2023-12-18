using System.Runtime.InteropServices.JavaScript;
using AppLogic;

namespace ConsoleInterface.CommandMenus.Commands;

public class ShowRemainingTasks(ConsoleKey key, User user) : Command(key, "Show Remaining Tasks")
{
    public override void Run()
    {
        var toDoList = new ToDoList((int)user.UserId!);
        toDoList.FetchRemainingTasks();
        var tasks = toDoList.GetTaskList();
        TasksView.ViewAll(tasks, "Remaining tasks");
        var singeTask = new ShowSingeTask(toDoList);
        singeTask.Run();
    }
}