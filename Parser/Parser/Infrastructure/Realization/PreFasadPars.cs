using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Parser.Infrastructure.Interfaces;

namespace Parser.Infrastructure.Realization
{
    internal class PreFasadPars : IPreFasadPars
    {
        public void ParsCompile()
        {
            Dictionary<string, string> PathList = new Dictionary<string, string>();

            string destinationFolder = @""; //path to destination folder 

            string folderPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"")); //path to folder

            foreach (string filePath in Directory.GetFiles(folderPath))
            {
                string fileName = Path.GetFileName(filePath);
                PathList.Add(fileName, filePath);
            }

            foreach (string sourceFilePath in PathList.Values)
            {
                Console.WriteLine($"Processing file: {sourceFilePath}");
                log.Info("File was copied to 'corruptedFiles' directory.");

                string fileName = Path.GetFileName(sourceFilePath);  // Get the file name
                string destinationFilePath = Path.Combine(destinationFolder, fileName); 

                File.Copy(sourceFilePath, destinationFilePath, overwrite: true);

                MetadataFilter metadataFilter = new MetadataFilter(sourceFilePath);

                bool filteredByMetaResault = metadataFilter.FilterByMetadata();
                if (filteredByMetaResault) 
                {
                    DBInteract dBInteract = new DBInteract(sourceFilePath);
                    dBInteract.SaveDataToSQLite(@""); //path to db
                }
                else
                {
                    log.Info($"File {sourceFilePath} is invalid."); 
                }

            }

        }
    }
}
