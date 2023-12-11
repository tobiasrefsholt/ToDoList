using Microsoft.VisualBasic;

namespace ToDoList;

public class ToDoList
{
    private User _user;
    private List<Task> _tasks = new();

    public ToDoList(User user)
    {
        _user = user;
    }
}