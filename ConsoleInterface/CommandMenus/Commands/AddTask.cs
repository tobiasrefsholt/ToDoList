using AppLogic;

namespace ConsoleInterface.CommandMenus.Commands;

public class AddTask(ConsoleKey key, User user) : Command(key, "Add task")
{
    public override void Run()
    {
        Console.Clear();
        Console.WriteLine("Add new task:");

        var task = NewTaskPrompt();

        if (!ShowConfirmationAddTask(task)) return;

        var database = new Database();
        database.InsertTask(task);
    }

    private TodoTask NewTaskPrompt()
    {
        var title = UserInput.AskForString("Title: ", true);
        var description = UserInput.AskForString("Description: ", false);
        var dueDate = UserInput.AskForDate("Due date", true);
        var task = new TodoTask()
        {
            UserId = (int)user.UserId!,
            Title = title,
            Description = description,
            DueDate = dueDate,
            IsDone = false
        };
        return task;
    }

    private static bool ShowConfirmationAddTask(TodoTask task)
    {
        return UserInput.AskForBool(
            $"Do you want to add a task with title \"{task.Title}\", description \"{task.Description}\" and due date \"{task.DueDate}\"? (Y/n)");
    }
}