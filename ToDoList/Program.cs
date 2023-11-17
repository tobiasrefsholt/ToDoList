using ToDoList;

class Program
{
    static void Main()
    {
        var user = new User();
        user.ShowLoginPromt();
        user.AuthenticateUser();
    }
}