using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Infrastructure.Realization
{
    internal class PreFasadPars
    {
        public void ParsCompile()
        {
            Dictionary<string, string> PathList = new Dictionary<string, string>();

            string destinationFolder = @""; // Note: This is now a folder path

            string folderPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @""));

            foreach (string filePath in Directory.GetFiles(folderPath))
            {
                string fileName = Path.GetFileName(filePath);
                PathList.Add(fileName, filePath);
            }

            // ... (your existing loop for printing KeyValuePairs)

            foreach (string sourceFilePath in PathList.Values)
            {
                Console.WriteLine($"Processing file: {sourceFilePath}");

                string fileName = Path.GetFileName(sourceFilePath);  // Get the file name
                string destinationFilePath = Path.Combine(destinationFolder, fileName); // Combine folder and file name

                File.Copy(sourceFilePath, destinationFilePath, overwrite: true); // Copy to the correct destination

                MetadataFilter metadataFilter = new MetadataFilter(sourceFilePath);

                bool filteredByMetaResault = metadataFilter.FilterByMetadata();
                if (filteredByMetaResault) // Simplified if condition
                {
                    DBInteract dBInteract = new DBInteract(sourceFilePath);
                    dBInteract.SaveDataToSQLite(@"");
                }
                else
                {
                    Console.WriteLine("File is invalid");
                }

            }
        }
    }
}