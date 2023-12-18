using AppLogic;

namespace ConsoleInterface.CommandMenus.Commands;

public class TaskChangeDescription(ConsoleKey key, ToDoList toDoList, TodoTask selectedTask) : Command(key, "Change Description")
{
    public override void Run()
    {
        var newDescription = UserInput.AskForString("New Description: ", true);
        selectedTask.SetDescription(newDescription);
        var showSingeTask = new ShowSingeTask(toDoList);
        showSingeTask.Run(selectedTask);
    }
}