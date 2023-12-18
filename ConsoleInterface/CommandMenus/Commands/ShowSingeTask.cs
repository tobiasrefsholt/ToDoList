using AppLogic;

namespace ConsoleInterface.CommandMenus.Commands;

public class ShowSingeTask(ToDoList toDoList)
{
    private TodoTask? _selectedTask = null;

    public void Run()
    {
        SelectTask();
        if (_selectedTask == null) return;
        PrintTaskDetails();
        var taskMenu = new TaskMenu(toDoList, _selectedTask);
        taskMenu.Run();
    }

    private void PrintTaskDetails()
    {
        Console.Clear();
        Console.WriteLine("Title: " + _selectedTask.Title);
        Console.WriteLine("Description: " + _selectedTask.Description);
        Console.WriteLine("Date added: " + _selectedTask.Date);
        Console.WriteLine("Due date: " + _selectedTask.DueDate);
        Console.WriteLine("Finished: " + _selectedTask.IsDone);
        Console.WriteLine();
    }

    private void SelectTask()
    {
        var tasks = toDoList.GetTaskList();
        var index = UserInput.AskForInt(0, tasks.Count - 1);
        _selectedTask = index != null ? tasks[(int)index] : null;
    }
}