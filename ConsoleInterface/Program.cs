using ConsoleInterface;
using ToDoList;

var database = new Database();
var user = new User();
var terminal = new TerminalView();

while (!user.IsAuthenticated)
{
    user.ShowLoginPrompt();
    user.Authenticate(database);
}

terminal.ShowMainMenu(user);