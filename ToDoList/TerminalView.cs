namespace ToDoList;

public class TerminalView
{
    public void ShowMainMenu(User user)
    {
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
        Console.WriteLine("Add task:");
        var title = UserInput.AskForString("Title: ", true);
        var description = UserInput.AskForString("Description: ", false);
        var dueDateInput = UserInput.AskForString("Due date (yyyy-mm-dd)", false);
        DateTime? dueDate = (dueDateInput.Length == 10) ? Convert.ToDateTime(dueDateInput) : null;
        Console.WriteLine(
            $"Do you want to add a task with title \"{title}\", description \"{description}\" and due date \"{dueDate}\"?");
        var addTask = UserInput.AskForBool("Continue?");
        if (!addTask || user.UserId == null) return;
        var db = new Database();
        db.InsertTask(new Task(user.UserId.Value, title, description, dueDate));
    }

    private void ShowManageAccount()
    {
        throw new NotImplementedException();
    }
}