namespace AppLogic;

public class ToDoList
{
    private int _userId;
    private List<TodoTask> _tasks = new();

    public ToDoList(int userId)
    {
        _userId = userId;
        FetchTasks();
    }

    private void FetchTasks()
    {
        var database = new Database();
        _tasks = database.GetTasksForUser(_userId);
    }

    public void ShowTodaysTasks()
    {
        throw new NotImplementedException();
    }
}