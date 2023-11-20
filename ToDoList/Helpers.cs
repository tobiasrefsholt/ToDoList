namespace ToDoList;

public class Helpers
{
    public static int AskForInt()
    {
        Console.Write("Type a number: ");
        var input = Console.ReadLine();
        var result = 0;
        try
        {
            result = int.Parse(input);
        }
        catch (FormatException)
        {
            Console.WriteLine("Not a number, try again.");
            AskForInt();
        }

        return result;
    }
}