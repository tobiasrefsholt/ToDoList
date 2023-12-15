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
        Console.WriteLine("Choose an option: ");
        return Console.ReadKey().Key;
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