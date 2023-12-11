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

    public void ShowAllTasks()
    {
        for (var index = 0; index < _tasks.Count; index++)
        {
            var task = _tasks[index];
            task.Show(index);
        }
    }

    public void ShowTask(int index)
    {
    }
}