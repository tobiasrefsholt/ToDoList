using ToDoList;
using Task = ToDoList.Task;

namespace ConsoleInterface;

public class TerminalView
{
    public void ShowMainMenu(User user)
    {
        Console.Clear();
        Console.WriteLine("\n\nChoose what to do:");
        Console.WriteLine("(1) Show today's tasks");
        Console.WriteLine("(2) Show finished tasks");
        Console.WriteLine("(3) Add task");
        Console.WriteLine("(4) Manage Account");
        Console.WriteLine("(5) Log out");
        var selected = UserInput.AskForInt();
        SelectMenuItem(selected, user);
    }

    private void SelectMenuItem(int selected, User user)
    {
        switch (selected)
        {
            case 1:
                ShowTodaysTasks();
                break;
            case 2:
                ShowFinishedTasks();
                break;
            case 3:
                ShowAddTask(user);
                break;
            case 4:
                ShowManageAccount();
                break;
            case 5:
                user.Logout();
                Console.Clear();
                Console.WriteLine("Successfully logged out.");
                break;
            default:
                ShowMainMenu(user);
                break;
        }
    }

    private void ShowTodaysTasks()
    {
        throw new NotImplementedException();
    }

    private void ShowFinishedTasks()
    {
        throw new NotImplementedException();
    }

    private void ShowAddTask(User user)
    {
        Console.Clear();
        Console.WriteLine("Add new task:");
        
        var title = UserInput.AskForString("Title: ", true);
        var description = UserInput.AskForString("Description: ", false);
        var dueDate = UserInput.AskForDate("Due date", true);
        var task = new Task((int)user.UserId!, title, description, dueDate);

        if(!ShowConfirmationAddTask(task)) return;

        var database = new Database();
        database.InsertTask(task);
    }

    private static bool ShowConfirmationAddTask(Task task)
    {
        return UserInput.AskForBool(
            $"Do you want to add a task with title \"{task.Title}\", description \"{task.Description}\" and due date \"{task.DueDate}\"? (Y/n)");
    }

    private void ShowManageAccount()
    {
        throw new NotImplementedException();
    }
}