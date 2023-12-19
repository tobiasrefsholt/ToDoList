using System.Data.SQLite;
using Microsoft.VisualBasic;

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
        const string sql = "SELECT rowid, UserId, Title, Description, Date, DueDate, IsDone " +
                           "FROM tasks WHERE UserId LIKE @UserId AND IsDone LIKE @IsDone ORDER BY IsDone desc, DueDate";
        var param = new { UserId = userId, IsDone = false };
        var database = new Database();
        _tasks = database.GetTaskList(sql, param);
    }

    public void FetchFinishedTasks()
    {
        const string sql = "SELECT rowid, UserId, Title, Description, Date, DueDate, IsDone " +
                           "FROM tasks WHERE UserId LIKE @UserId AND IsDone LIKE @IsDone ORDER BY IsDone desc, DueDate";
        var param = new { UserId = userId, IsDone = true };
        var database = new Database();
        _tasks = database.GetTaskList(sql, param);
    }

    public void FetchTodaysTasks()
    {
        var isoDate = DateTime.Today.ToString("yyyy-MM-dd");
        const string sql = "SELECT rowid, UserId, Title, Description, Date, DueDate, IsDone FROM tasks " +
                           "WHERE UserId LIKE @UserId AND DATE(`DueDate`) = @IsoDate " +
                           "ORDER BY IsDone desc, DueDate";
        var param = new { UserId = userId, IsoDate = isoDate };
        var database = new Database();
        _tasks = database.GetTaskList(sql, param);
    }

    public List<TodoTask> GetTaskList()
    {
        return _tasks;
    }

    public void DeleteTask(TodoTask task)
    {
        _tasks.Remove(task);
        var sqlCommand = new SQLiteCommand("DELETE FROM tasks WHERE rowid LIKE @RowId");
        sqlCommand.Parameters.AddWithValue("@RowId", task.RowId);
        var database = new Database();
        database.Insert(sqlCommand);
    }

    public TodoTask GetTask(int index)
    {
        return _tasks[index];
    }

    public void RemoveTasksForUser()
    {
        var database = new Database();
        var sqlCommand = new SQLiteCommand("DELETE FROM tasks WHERE UserId LIKE @UserId");
        sqlCommand.Parameters.AddWithValue("@UserId", userId);
        database.Insert(sqlCommand);
    }
}