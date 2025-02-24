using System.Data.SQLite;
using ExtractTextFromPage;
using Parser.Infrastructure.Interfaces;
using Parser.Infrastructure.Realization;
using System.Collections.Generic;
using System.Linq;

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

            string createTableSql = "CREATE TABLE IF NOT EXISTS Oblycovy (id INTEGER PRIMARY KEY AUTOINCREMENT, ";
            createTableSql += string.Join(", ", extracteddata.Keys.Select(key => $"\"{key}\" TEXT"));
            createTableSql += ")";

            using (var command = new SQLiteCommand(createTableSql, connection))
            {
                command.ExecuteNonQuery();
            }

            string insertSql = $"INSERT OR REPLACE INTO Oblycovy ({string.Join(", ", extracteddata.Keys.Select(key => $"\"{key}\""))}) VALUES ({string.Join(", ", extracteddata.Keys.Select(key => $"@{key}"))})";

            using (var command = new SQLiteCommand(insertSql, connection))
            {
                foreach (var pair in extracteddata)
                {
                    command.Parameters.AddWithValue($"@{pair.Key}", pair.Value);
                }
                command.ExecuteNonQuery();
            }
        }
    }
}