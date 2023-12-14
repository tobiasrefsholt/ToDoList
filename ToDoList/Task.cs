namespace ToDoList;

public class Task
{
    public int UserId { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateOnly Date { get; private set; }
    public DateOnly? DueDate { get; private set; }

    public Task(int userId, string title, string description, DateOnly? dueDate = null)
    {
        UserId = userId;
        Title = title;
        Description = description;
        Date = new DateOnly();
        DueDate = dueDate;
    }
}