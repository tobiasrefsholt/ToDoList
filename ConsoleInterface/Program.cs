using AppLogic;
using ConsoleInterface;

var user = new User();

while (true)
{
    if (user.IsAuthenticated)
    {
        var todoList = new ToDoList((int)user.UserId!);
        var commands = new Commands(user, todoList);
        commands.ShowMainMenu();
    }
    else
    {
        user.Logout();
        user.ShowLoginPrompt();
        user.Authenticate();
        user.ShowAuthenticationResult();
    }
}