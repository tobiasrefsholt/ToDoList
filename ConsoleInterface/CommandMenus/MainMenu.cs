using System.Xml.Linq;
using AppLogic;
using ConsoleInterface.CommandMenus.Commands;

namespace ConsoleInterface.CommandMenus;

public class MainMenu(User currentUser) : Menu(
    [
        new ShowRemainingTasks(ConsoleKey.D1, currentUser),
        new ShowFinishedTasks(ConsoleKey.D2, currentUser),
        new AddTask(ConsoleKey.D3, currentUser),
        new UserSettings(ConsoleKey.D4, currentUser),
        new UserLogout(ConsoleKey.D5, currentUser),
    ],
    "Main menu:"
)
{
    
}