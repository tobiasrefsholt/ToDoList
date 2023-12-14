using AppLogic;

namespace ConsoleInterface;

public class Commands
{
    private readonly User _user;
    private readonly ToDoList _toDoList;

    public Commands(User user, ToDoList toDoList)
    {
        _user = user;
        _toDoList = toDoList;
    }

    public void ShowMainMenu()
    {
        Console.Clear();
        Console.WriteLine("Choose what to do:");
        Console.WriteLine("(1) Show today's tasks");
        Console.WriteLine("(2) Show finished tasks");
        Console.WriteLine("(3) Add task");
        Console.WriteLine("(4) Manage Account");
        Console.WriteLine("(5) Log out");
        var selected = UserInput.AskForInt();
        SelectMenuItem(selected);
    }

    private void SelectMenuItem(int selected)
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
                ShowAddTask();
                break;
            case 4:
                ShowManageAccount();
                break;
            case 5:
                _user.Logout();
                Console.Clear();
                Console.WriteLine("Successfully logged out.");
                break;
            default:
                ShowMainMenu();
                break;
        }
    }

    private void ShowTodaysTasks()
    {
        Console.Clear();
        Console.WriteLine("Todays tasks: \n");
        _toDoList.ShowTodaysTasks();
    }

    private void ShowFinishedTasks()
    {
        throw new NotImplementedException();
    }

    private void ShowAddTask()
    {
        Console.Clear();
        Console.WriteLine("Add new task:");

        var title = UserInput.AskForString("Title: ", true);
        var description = UserInput.AskForString("Description: ", false);
        var dueDate = UserInput.AskForDate("Due date", true);
        var task = new TodoTask((int)_user.UserId!, title, description, dueDate);

        if (!ShowConfirmationAddTask(task)) return;

        var database = new Database();
        database.InsertTask(task);
    }

    private static bool ShowConfirmationAddTask(TodoTask task)
    {
        return UserInput.AskForBool(
            $"Do you want to add a task with title \"{task.Title}\", description \"{task.Description}\" and due date \"{task.DueDate}\"? (Y/n)");
    }

    private void ShowManageAccount()
    {
        throw new NotImplementedException();
    }
}