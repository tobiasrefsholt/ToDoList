using AppLogic;

namespace ConsoleInterface.CommandMenus.Commands;

public class ShowFinishedTasks(ConsoleKey key, User user) : Command(key, "Show finished tasks")
{
    public override void Run()
    {
        var toDoList = new ToDoList((int)user.UserId!);
        toDoList.FetchFinishedTasks();
        var tasks = toDoList.GetTaskList();
        TasksView.ViewAll(tasks, "Remaining tasks");
        var singeTask = new ShowSingeTask(toDoList);
        singeTask.Run();
    }
}