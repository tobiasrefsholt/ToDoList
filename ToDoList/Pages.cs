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
                ShowAddTask();
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
    
    public static void ShowTodaysTasks()
    {
        throw new NotImplementedException();
    }

    public static void ShowFinishedTasks()
    {
        throw new NotImplementedException();
    }

    public static void ShowAddTask()
    {
        Console.Clear();
        Console.WriteLine("Add task:");
        var title = Helpers.AskForString("Title: ", true);
        var description = Helpers.AskForString("Description: ", false);
        var dueDate = Helpers.AskForString("Due date (yyyy-mm-dd)", false);
        Console.WriteLine($"Do you want to add a task with title \"{title}\", description \"{description}\" and due date \"{dueDate}\"?");
        var addTask = Helpers.AskForBool("Continue?");
        if (!addTask) return;
    }

    public static void ShowManageAccount()
    {
        throw new NotImplementedException();
    }
}