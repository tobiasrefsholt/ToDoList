namespace ConsoleInterface.CommandMenus;

public abstract class Command(ConsoleKey key, string description)
{
    public abstract void Run();

    public void Show()
    {
        Console.WriteLine(key + " - " + description);
    }

    public bool IsKeyCorrect(ConsoleKey pressedKey)
    {
        return key == pressedKey;
    }
}