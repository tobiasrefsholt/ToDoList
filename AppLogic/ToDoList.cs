namespace AppLogic;

public class ToDoList
{
    private List<TodoTask> _tasks = new();

    public void FetchRemainingTasks(int userId)
    {
        var database = new Database();
        _tasks = database.GetTasksForUser(userId);
    }

    public List<TodoTask> GetTaskList()
    {
        throw new NotImplementedException();
    }
    
    public TodoTask GetTask(int index)
    {
        return _tasks[index];
    }
}