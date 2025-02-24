using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Infrastructure.Realization
{
    public class PreFasadMail
    {
        public void MailCompile()
        {
            MeinMailer meinMailer = new MeinMailer();

            meinMailer.MalerMain();
        }
    }
}
