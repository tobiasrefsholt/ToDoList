using System.Data;
using System.Data.SQLite;

namespace AppLogic;

public class TodoTask
{
    public int RowId { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsDone { get; set; }

    public void SetTitle(string newTitle)
    {
        Title = newTitle;
        Save();
    }

    public void SetDescription(string newDescription)
    {
        Description = newDescription;
        Save();
    }

    public void SetDueDate(DateTime newDueDate)
    {
        DueDate = newDueDate;
        Save();
    }

    public void SetIsDone(bool newIsDone)
    {
        IsDone = newIsDone;
        Save();
    }

    public void Save()
    {
        var database = new Database();
        var sqlCommand = new SQLiteCommand("UPDATE tasks SET " +
                                           "Title = @Title, " +
                                           "Description = @Description, " +
                                           "DueDate = @DueDate, " +
                                           "IsDone = @IsDone " +
                                           "WHERE rowid LIKE @RowId AND UserId LIKE @UserId");
        sqlCommand.Parameters.AddWithValue("@Title", Title);
        sqlCommand.Parameters.AddWithValue("@Description", Description);
        sqlCommand.Parameters.AddWithValue("@DueDate", DueDate);
        sqlCommand.Parameters.AddWithValue("@IsDone", IsDone);
        sqlCommand.Parameters.AddWithValue("@RowId", RowId);
        sqlCommand.Parameters.AddWithValue("@UserId", UserId);
        database.Insert(sqlCommand);
    }
}