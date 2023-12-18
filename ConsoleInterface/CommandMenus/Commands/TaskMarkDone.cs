using AppLogic;

namespace ConsoleInterface.CommandMenus.Commands;

public class TaskMarkDone(ConsoleKey key, ToDoList toDoList, TodoTask selectedTask) : Command(key, "Mark as done")
{
    public override void Run()
    {
        var newIsDone = UserInput.AskForBool("Set as done: ");
        selectedTask.SetIsDone(newIsDone);
        var showSingeTask = new ShowSingeTask(toDoList);
        showSingeTask.Run(selectedTask);
    }
}