using System.Data;
using System.Data.SQLite;

namespace AppLogic;

public class Task
{
    public int UserId { get; init; }
    public string Title { get; init; }
    public string Description { get; init; }
    public DateTime Date { get; init; }
    public DateTime? DueDate { get; init; }

    public Task(int userId, string title, string description, DateTime? dueDate = null)
    {
        UserId = userId;
        Title = title;
        Description = description;
        Date = DateTime.Now;
        DueDate = dueDate;
    }

    public Task()
    {
    }
}