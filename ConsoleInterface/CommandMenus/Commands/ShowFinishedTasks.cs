using AppLogic;

namespace ConsoleInterface.CommandMenus.Commands;

public class ShowFinishedTasks(ConsoleKey key, User user) : Command(key, "Show finished tasks")
{
    public override void Run()
    {
        var toDoList = new ToDoList((int)user.UserId!);
        toDoList.FetchFinishedTasks();
        TasksView.Menu(toDoList.GetTaskList(), "Finished tasks");
    }
}