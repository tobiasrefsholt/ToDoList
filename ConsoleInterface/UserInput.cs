namespace ConsoleInterface;

public class UserInput
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

    public static string AskForString(string label, bool required)
    {
        Console.Write(label);
        var input = Console.ReadLine();

        if (!string.IsNullOrEmpty(input))
        {
            return input;
        }

        if (!required) return string.Empty;

        Console.WriteLine("This field is required, please enter a valid input.");
        return AskForString(label, required);
    }

    public static bool AskForBool(string label)
    {
        Console.Write(label + "(Y/n)");
        var input = Console.ReadLine();
        return string.IsNullOrEmpty(input) || input.ToLower() == "y";
    }

    public static DateTime? AskForDate(string label, bool required)
    {
        var input = AskForString(label + " (yyyy-mm-dd)", false);
        if (!required && string.IsNullOrEmpty(input)) return null;
        
        try
        {
            if (string.IsNullOrEmpty(input))
                throw new Exception("This field is required, try again!");

            return DateTime.Parse(input);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return AskForDate(label, required);
        }
    }
}