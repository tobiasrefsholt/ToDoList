namespace ConsoleInterface.CommandMenus.Commands;

public class Exit(ConsoleKey key) : Command(key, "Exit")
{
    public override void Run()
    {
        Environment.Exit(0);
    }
}