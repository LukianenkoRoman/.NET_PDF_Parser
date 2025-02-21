using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Aspose.Email.Clients.Imap;
using Aspose.Email.Clients;
using Aspose.Email;
using Aspose.Email.Mime;
using Parser.Infrastructure.Interfaces;

namespace Parser.Infrastructure.Realization
{
    public class MaileClient : IMaileClient
    {
        public void DownloadAttachments(string email, string password, string downloadFolder)
        {
            try
            {
                log.Info("Starting to connect to the IMAP server...");

                using (ImapClient client = new ImapClient("imap.gmail.com", 993, email, password, SecurityOptions.Auto))
                {
                    log.Info("Connection successful. Opening the 'Inbox' folder.");

                    client.SelectFolder(ImapFolderInfo.InBox);
                    ImapQueryBuilder builder = new ImapQueryBuilder();
                    builder.HasNoFlags(ImapMessageFlags.IsRead); 

                    ImapMessageInfoCollection messages = client.ListMessages(builder.GetQuery());

                    log.Info($"Found {messages.Count} emails.");

                    foreach (var msgInfo in messages)
                    {
                        Aspose.Email.MailMessage msg = client.FetchMessage(msgInfo.UniqueId);

                        foreach (var attachment in msg.Attachments)
                        {
                            if (attachment.Name.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
                            {
                                string filePath = Path.Combine(downloadFolder, attachment.Name);

                                using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                                {
                                    attachment.ContentStream.CopyTo(fileStream);
                                }

                                log.Info($"The file {attachment.Name} has been downloaded to {filePath}");
                            }
                        }
                    }
                }

                log.Info("File upload is complete.");
            }
            catch (Exception ex)
            {
                log.Error($"Error while downloading files: {ex.Message}");
            }
        }
    }
}
