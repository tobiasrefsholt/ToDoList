using AppLogic;
using Dapper;

namespace ConsoleInterface.CommandMenus;

public abstract class Menu(List<Command> commands, string description)
{

    public virtual void Run()
    {
        Console.Clear();
        Console.WriteLine(description);
        ShowCommands();
        var command = FindCommand(GetInput());
        command?.Run();
    }

    protected ConsoleKey GetInput()
    {
        Console.Write("Choose an option: ");
        var input = Console.ReadKey().Key;
        Console.WriteLine();
        return input;
    }

    protected void ShowCommands()
    {
        commands.ForEach(command => command.Show());
    }

    protected Command? FindCommand(ConsoleKey key)
    {
        return commands.FirstOrDefault(command => command.IsKeyCorrect(key));
    }
}