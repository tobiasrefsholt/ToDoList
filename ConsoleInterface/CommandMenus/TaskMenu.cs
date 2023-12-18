using AppLogic;
using ConsoleInterface.CommandMenus.Commands;

namespace ConsoleInterface.CommandMenus;

public class TaskMenu(ToDoList toDoList, TodoTask selectedTask) : Menu(
[
    new TaskMarkDone(ConsoleKey.D1, toDoList, selectedTask),
    new TaskChangeTitle(ConsoleKey.D2, toDoList, selectedTask),
    new TaskChangeDescription(ConsoleKey.D3, toDoList, selectedTask),
    new TaskChangeDueDate(ConsoleKey.D4, toDoList, selectedTask),
    new TaskDelete(ConsoleKey.D5, toDoList, selectedTask)
], "Task Menu")
{
    public override void Run()
    {
        ShowCommands();
        var command = FindCommand(GetInput());
        command?.Run();
    }
}