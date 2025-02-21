using System.Data.SQLite;
using ExtractTextFromPage;
using Parser.Infrastructure.Interfaces;
using Parser.Infrastructure.Realization;

public class DBInteract : IDBInteract
{
    private string pdfPath;

    public DBInteract(string fullPath)
    {
        pdfPath = fullPath;
    }


    public void SaveDataToSQLite(string dbPath)
    {
        string path = pdfPath;
        ParsCollector collector = new ParsCollector(path);

        using (var connection = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
        {
            Dictionary<string, string> extracteddata = collector.CollectedText();
            connection.Open();

            using (var command = new SQLiteCommand(connection))
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS Oblycovy (id INTEGER PRIMARY KEY AUTOINCREMENT, key TEXT, value TEXT)";
                command.ExecuteNonQuery();

                foreach (var pair in extracteddata)
                {
                    command.CommandText = "INSERT OR REPLACE INTO Oblycovy (key, value) VALUES (@key, @value)";
                    command.Parameters.AddWithValue("@key", pair.Key);
                    command.Parameters.AddWithValue("@value", pair.Value);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}