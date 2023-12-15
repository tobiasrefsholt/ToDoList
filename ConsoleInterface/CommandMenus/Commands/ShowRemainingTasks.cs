using AppLogic;

namespace ConsoleInterface.CommandMenus.Commands;

public class ShowRemainingTasks(ConsoleKey key, User user) : Command(key, "Show Remaining Tasks")
{
    public override void Run()
    {
        Console.Clear();
        Console.WriteLine("Todays tasks: \n");
        var toDoList = new ToDoList(); 
        toDoList.FetchRemainingTasks((int)user.UserId!);
        ShowTasks(toDoList.GetTaskList());
    }

    private void ShowTasks(List<TodoTask> taskList)
    {
        for (var index = 0; index < taskList.Count; index++)
        {
            var task = taskList[index];
            Console.WriteLine($"({index}) - {task.Title} - ");
        }
    }
}