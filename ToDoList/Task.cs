namespace ToDoList;

public class Task
{
    public int UserId { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime Date { get; private set; }
    public DateTime? DueDate { get; private set; }

    public Task(int userId, string title, string description, DateTime? dueDate = null)
    {
        UserId = userId;
        Title = title;
        Description = description;
        Date = DateTime.Now;
        DueDate = dueDate;
    }
}