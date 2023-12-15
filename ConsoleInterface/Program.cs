using AppLogic;
using ConsoleInterface;
using ConsoleInterface.CommandMenus;

var user = new User();

while (true)
{
    if (user.IsAuthenticated)
    {
        var mainMenu = new MainMenu(user);
        mainMenu.Run();
    }
    else
    {
        var loginMenu = new LoginMenu(user);
        loginMenu.Run();
    }
}