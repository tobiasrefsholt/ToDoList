using ToDoList;

class Program
{
    public static void Main()
    {
        var database = new Database();
        var user = new User();
        while (!user.IsAuthenticated)
        {
            user.ShowLoginPrompt();
            user.AuthenticateUser(database);
        }

        Pages.ShowMainMenu(user);
    }
}