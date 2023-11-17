using ToDoList;

class Program
{
    static void Main()
    {
        var user = new User();
        user.showLoginPromt();
        user.authenticateUser();
    }
}