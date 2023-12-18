using AppLogic;
using ConsoleInterface.CommandMenus;

namespace ConsoleInterface;

public static class TasksView
{
    public static void Menu(List<TodoTask> tasks, string title)
    {
        Console.Clear();
        Console.WriteLine($"{title}: \n");
        ListRow(tasks);
        Console.ReadKey();
    }

    private static void ListRow(IReadOnlyList<TodoTask> taskList)
    {
        for (var index = 0; index < taskList.Count; index++)
        {
            var task = taskList[index];
            ListRow(index, task);
        }
    }

    private static void ListRow(int index, TodoTask task)
    {
        var defaultBackground = Console.BackgroundColor;
        var defaultForeground = Console.ForegroundColor;

        SetConsoleColors(task);

        Console.WriteLine($"({index}) - {task.Title} - {task.Description} - Due: {task.DueDate} - Done: {task.IsDone}");

        Console.BackgroundColor = defaultBackground;
        Console.ForegroundColor = defaultForeground;
    }

    private static void SetConsoleColors(TodoTask task)
    {
        switch (task.IsDone)
        {
            case false when task.DueDate < DateTime.Today:
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                break;
            case true:
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                break;
        }
    }
}