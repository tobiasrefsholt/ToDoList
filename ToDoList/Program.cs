using ToDoList;

class Program
{
    private static void Main()
    {
        var user = new User();
        while (user.UserId == null)
        {
            user.ShowLoginPromt();
            user.AuthenticateUser();
        }

        ShowMainMenu();
    }

    private static void ShowMainMenu()
    {
        Console.WriteLine("\n\nChoose what to do:");
        Console.WriteLine("(1) Show today's tasks");
        Console.WriteLine("(2) Show finished tasks");
        Console.WriteLine("(3) Add task");
        Console.WriteLine("(4) Manage Account");
        Console.WriteLine("(5) Log out");
        var selected = AskForInt();
        Console.WriteLine($"You selected {selected}");
    }

    private static int AskForInt()
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