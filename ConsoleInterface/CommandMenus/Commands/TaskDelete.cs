using AppLogic;

namespace ConsoleInterface.CommandMenus.Commands;

public class TaskDelete(ConsoleKey key, ToDoList toDoList, TodoTask selectedTask) : Command(key, "Delete Task")
{
    public override void Run()
    {
        if (UserInput.AskForBool("Delete task? "))
            toDoList.DeleteTask(selectedTask);
    }
}