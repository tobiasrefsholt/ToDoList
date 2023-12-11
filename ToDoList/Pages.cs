namespace ToDoList;

public class Pages
{
    public static void ShowMainMenu(User user)
    {
        Console.WriteLine("\n\nChoose what to do:");
        Console.WriteLine("(1) Show today's tasks");
        Console.WriteLine("(2) Show finished tasks");
        Console.WriteLine("(3) Add task");
        Console.WriteLine("(4) Manage Account");
        Console.WriteLine("(5) Log out");
        var selected = Helpers.AskForInt();
        SelectMenuItem(selected, user);
    }

    private static void SelectMenuItem(int selected, User user)
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
                Program.Main();
                break;
            default:
                ShowMainMenu(user);
                break;
        }
    }

    private static void ShowTodaysTasks()
    {
        throw new NotImplementedException();
    }

    private static void ShowFinishedTasks()
    {
        throw new NotImplementedException();
    }

    private static void ShowAddTask(User user)
    {
        Console.Clear();
        Console.WriteLine("Add task:");
        var title = Helpers.AskForString("Title: ", true);
        var description = Helpers.AskForString("Description: ", false);
        var dueDateInput = Helpers.AskForString("Due date (yyyy-mm-dd)", false);
        DateTime? dueDate = (dueDateInput.Length == 10) ? Convert.ToDateTime(dueDateInput) : null;
        Console.WriteLine(
            $"Do you want to add a task with title \"{title}\", description \"{description}\" and due date \"{dueDate}\"?");
        var addTask = Helpers.AskForBool("Continue?");
        if (!addTask || user.UserId == null) return;
        var db = new Database();
        db.InsertTask(new Task(user.UserId.Value, title, description, dueDate));
    }

    private static void ShowManageAccount()
    {
        throw new NotImplementedException();
    }
}