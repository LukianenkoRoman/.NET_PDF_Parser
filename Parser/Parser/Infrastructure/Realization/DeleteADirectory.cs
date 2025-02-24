using Aspose.Email;
using Parser.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Infrastructure.Realization
{
    class DeleteADirectory
    {
        public static void Cleardirectory()
        {
            string[] filePaths = Directory.GetFiles(@"");// File directory
            foreach (string filePath in filePaths)
            File.Delete(filePath);
            log.Info("Directory has been cleared.");
        }
    }
}
