using System.Xml.Linq;
using AppLogic;
using ConsoleInterface.CommandMenus.Commands;

namespace ConsoleInterface.CommandMenus;

public class MainMenu(User currentUser) : Menu(
    [
        new ShowTodaysTasks(ConsoleKey.D1, currentUser),
        new ShowRemainingTasks(ConsoleKey.D2, currentUser),
        new ShowFinishedTasks(ConsoleKey.D3, currentUser),
        new AddTask(ConsoleKey.D4, currentUser),
        new UserSettings(ConsoleKey.D5, currentUser),
        new Exit(ConsoleKey.D6)
    ],
    "Main menu:"
)
{
    
}