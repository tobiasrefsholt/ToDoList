using AppLogic;
using Dapper;

namespace ConsoleInterface.CommandMenus;

public abstract class Menu(List<Command> commands, string description)
{
    protected readonly string Description = description;

    public abstract void Run();

    protected ConsoleKey GetInput()
    {
        Console.WriteLine("Choose an option: ");
        return Console.ReadKey().Key;
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