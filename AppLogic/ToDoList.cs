using System.Data.SQLite;

namespace AppLogic;

public class ToDoList(int userId)
{
    private List<TodoTask> _tasks = [];

    public void FetchAllTasks()
    {
        FetchRemainingTasks();
        FetchFinishedTasks();
    }

    public void FetchRemainingTasks()
    {
        var database = new Database();
        _tasks = database.GetTasksForUser(userId, false);
    }
    
    public void FetchFinishedTasks()
    {
        var database = new Database();
        _tasks = database.GetTasksForUser(userId, true);
    }

    public List<TodoTask> GetTaskList()
    {
        return _tasks;
    }

    public void DeleteTask(TodoTask task)
    {
        _tasks.Remove(task);
        var database = new Database();
        var sqlCommand = new SQLiteCommand("DELETE FROM tasks WHERE rowid LIKE @RowId");
        sqlCommand.Parameters.AddWithValue("@RowId", task.RowId);
        database.Insert(sqlCommand);
    }
    
    public TodoTask GetTask(int index)
    {
        return _tasks[index];
    }
}