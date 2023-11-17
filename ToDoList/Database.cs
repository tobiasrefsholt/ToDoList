using MySql.Data;
using MySql.Data.MySqlClient;

namespace Data;

public class Database
{
    private string _server = "localhost";
    private string _databaseName = "ToDoList";
    private string _userName = "admin";
    private string _password = "";

    public MySqlConnection Connection { get; set; }

    private static Database _instance = null;

    public static Database Instance()
    {
        if (_instance == null)
            _instance = new Database();
        return _instance;
    }

    public bool IsConnect()
    {
        if (Connection == null)
        {
            if (String.IsNullOrEmpty(_databaseName))
                return false;
            string connstring = string.Format("Server={0}; database={1}; UID={2}; password={3}", _server, _databaseName,
                _userName, _password);
            Connection = new MySqlConnection(connstring);
            Connection.Open();
        }

        return true;
    }

    public void Close()
    {
        Connection.Close();
    }
}