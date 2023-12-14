using ConsoleInterface;
using ToDoList;

var user = new User();
var terminal = new TerminalView();

while (!user.IsAuthenticated)
{
    user.ShowLoginPrompt();
    user.Authenticate();
    user.ShowAuthenticationResult();
}

while (user.IsAuthenticated)
{
    terminal.ShowMainMenu(user);
}
