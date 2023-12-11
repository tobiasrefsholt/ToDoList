namespace ToDoList;

public class Task
{
    public int UserId { get; }
    public string Title { get; }
    public string Description { get; }
    public DateTime Date { get; }
    public DateTime? DueDate { get; }

    public Task(int userId, string title, string description, DateTime? dueDate = null)
    {
        UserId = userId;
        Title = title;
        Description = description;
        Date = DateTime.Now;
        DueDate = dueDate;
    }

    public void Show(string label = "")
    {
        Console.WriteLine(label + Title + " " + DueDate);
    }

    public void Show(int index)
    {
        Show($"({index}) - ");
    }
}