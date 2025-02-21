using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parser.Infrastructure.Interfaces;
using Parser.Infrastructure.Realization;

namespace Parser.Infrastructure.Realization
{
    public class Destinator : IDestinator
    {

        public void Destinate() //class to chek files before sending to working directory or a trashbox 
        {
            MetadataFilter filter = new MetadataFilter("You are invalid");
            StreamWriter sw = new StreamWriter(@""); //txt file to chek status
            string soursFile = @""; //path to sours file
            string destinationFile = @""; //path to destination file
            string destinatorCorruptedFiles = @""; //path to destinator corrupted files

            bool resault = filter.FilterByMetadata();  
            if (resault == true) //sending files to one of folders if his data is correct or incorrect
            {
                File.Copy(soursFile, destinationFile, overwrite: true);
                sw.WriteLine("File was added to folder;");
                sw.Close();
            }
            else
            {
                File.Copy(soursFile, destinatorCorruptedFiles, overwrite: true);
                sw.WriteLine("File was deleted;"); 
                sw.Close();
            }
        }
    }
}
