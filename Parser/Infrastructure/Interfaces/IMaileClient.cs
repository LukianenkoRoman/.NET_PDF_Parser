using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Infrastructure.Interfaces
{
    public interface IMaileClient
    {
        public void DownloadAttachments(string email, string password, string downloadFolder);
    }
}
