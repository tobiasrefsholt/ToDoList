using ToDoList;

class Program
{
    static void Main()
    {
        var user = new User();
        while (user.UserId == null)
        {
            user.ShowLoginPromt();
            user.AuthenticateUser();
        }
    }
}