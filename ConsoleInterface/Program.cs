using AppLogic;
using ConsoleInterface;

var user = new User();

while (!user.IsAuthenticated)
{
    user.ShowLoginPrompt();
    user.Authenticate();
    user.ShowAuthenticationResult();
}

var todoList = new ToDoList((int)user.UserId!);
var commands = new Commands(user, todoList);

while (user.IsAuthenticated)
{
    commands.ShowMainMenu();
}
