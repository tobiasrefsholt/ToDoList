using AppLogic;

namespace ConsoleInterface.CommandMenus.Commands;

public class ShowTodaysTasks(ConsoleKey key, User user) : Command(key, "Show today's tasks")
{
    public override void Run()
    {
        var toDoList = new ToDoList((int)user.UserId!);
        toDoList.FetchTodaysTasks();
        var tasks = toDoList.GetTaskList();
        TasksView.ViewAll(tasks, "Remaining tasks");
        var singeTask = new ShowSingeTask(toDoList);
        singeTask.Run();
    }
}