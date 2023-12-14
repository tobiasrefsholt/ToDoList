using System.Data;
using System.Data.SQLite;

namespace AppLogic;

public class TodoTask
{
    public int UserId { get; init; }
    public string Title { get; init; }
    public string Description { get; init; }
    public DateTime Date { get; init; }
    public DateTime? DueDate { get; init; }

    public TodoTask(int userId, string title, string description, DateTime? dueDate = null)
    {
        UserId = userId;
        Title = title;
        Description = description;
        Date = DateTime.Now;
        DueDate = dueDate;
    }

    public TodoTask()
    {
    }
}