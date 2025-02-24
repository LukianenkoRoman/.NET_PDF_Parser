using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parser.Infrastructure.Interfaces;
using PdfSharp.Snippets.Drawing;

namespace Parser.Infrastructure.Realization
{
    public class MeinMailer : IMeinMailer
    {
        public void MalerMain()
        {
            while (true)
            {

                //check_logger_config.check_logger_directory();
                Console.WriteLine("Logs recorded.(logs/app.log)");
                string downloadFolder = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @""));// File directory
                string email = "";  // Email address
                string password = "";  // Application password

                MaileClient MaileClient = new MaileClient();
                MaileClient.DownloadAttachments(email, password, downloadFolder);

                PreFasadPars preFasadPars = new PreFasadPars();
                preFasadPars.ParsCompile();
                DeleteADirectory.Cleardirectory();

                Console.WriteLine("Waiting one hour before next start...");
                Thread.Sleep(50000);//3600000
            }
        }
    }
}
