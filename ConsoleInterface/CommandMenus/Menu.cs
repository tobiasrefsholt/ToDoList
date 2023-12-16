using AppLogic;
using Dapper;

namespace ConsoleInterface.CommandMenus;

public abstract class Menu(List<Command> commands, string description)
{
    public void Run()
    {
        Console.Clear();
        Console.WriteLine(description);
        ShowCommands();
        var command = FindCommand(GetInput());
        command?.Run();
    }

    private ConsoleKey GetInput()
    {
        Console.Write("Choose an option: ");
        var input = Console.ReadKey().Key;
        Console.WriteLine();
        return input;
    }

    private void ShowCommands()
    {
        commands.ForEach(command => command.Show());
    }

    private Command? FindCommand(ConsoleKey key)
    {
        return commands.FirstOrDefault(command => command.IsKeyCorrect(key));
    }
}