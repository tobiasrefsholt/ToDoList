using System.Data;
using System.Data.SqlClient;
using Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ToDoList;

public class User
{
    private string? _username = null;
    private string? _password = null;
    private int? _userId = null;

    public void authenticateUser()
    {
        var dbCon = Database.Instance();
        if (dbCon.IsConnect())
        {
            //suppose col0 and col1 are defined as VARCHAR in the DB
            var query = $"SELECT id FROM users WHERE username={_username} AND password={_password}";
            var cmd = new MySqlCommand(query, dbCon.Connection);
            var reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                _userId = reader.GetInt32(0);
                Console.WriteLine("User ID = " + _userId);
            }
            dbCon.Close();
        }
    }

    public void showLoginPromt()
    {
        Console.WriteLine("Please login");
        Console.Write("Username: ");
        _username = Console.ReadLine();
        Console.Write("Password: ");
        _password = Console.ReadLine();
    }
}