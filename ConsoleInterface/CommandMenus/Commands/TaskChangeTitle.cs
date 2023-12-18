using AppLogic;

namespace ConsoleInterface.CommandMenus.Commands;

public class TaskChangeTitle(ConsoleKey key, ToDoList toDoList, TodoTask selectedTask) : Command(key, "Change Title")
{
    public override void Run()
    {
        var newTitle = UserInput.AskForString("New Title: ", true);
        selectedTask.SetTitle(newTitle);
        var showSingeTask = new ShowSingeTask(toDoList);
        showSingeTask.Run(selectedTask);
    }
}