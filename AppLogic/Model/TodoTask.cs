using System.Data;
using System.Data.SQLite;

namespace AppLogic;

public class TodoTask
{
    public int UserId { get; init; }
    public string Title { get; init; }
    public string Description { get; init; }
    public DateTime Date { get; init; }
    public DateTime DueDate { get; init; }
    
    public bool IsDone { get; init; }
}