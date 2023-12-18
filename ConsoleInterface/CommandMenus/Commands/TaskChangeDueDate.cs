using AppLogic;

namespace ConsoleInterface.CommandMenus.Commands;

public class TaskChangeDueDate(ConsoleKey key, ToDoList toDoList, TodoTask selectedTask) : Command(key, "Change Due Date")
{
    public override void Run()
    {
        var newDueDate = UserInput.AskForDate("Change due date: ");
        selectedTask.SetDueDate(newDueDate);
        var showSingeTask = new ShowSingeTask(toDoList);
        showSingeTask.Run(selectedTask);
    }
}