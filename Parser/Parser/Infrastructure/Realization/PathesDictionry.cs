using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parser.Infrastructure.Interfaces;

namespace Parser.Infrastructure.Realization
{
    public class PathesDictionary : IPathesDictionary
    {
        public Dictionary<string, string> PathList { get; set; }

        public PathesDictionary()
        {
            PathList = new Dictionary<string, string>();
        }

        public Dictionary<string, string> pathSetter()
        {
            string folderPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @""));

            try
            {
                foreach (string filePath in Directory.GetFiles(folderPath))
                {
                    string fileName = Path.GetFileName(filePath);
                    PathList.Add(fileName, filePath);
                }

                foreach (KeyValuePair<string, string> pair in PathList)
                {
                    Console.WriteLine($"Key: {pair.Key}, Value: {pair.Value}");
                }
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine($"Error: Directory not found at {folderPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return PathList;
        }
    }
}
