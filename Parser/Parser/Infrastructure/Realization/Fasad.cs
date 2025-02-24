using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Infrastructure.Realization
{
    internal class Fasad 
    {
        public void Compile()
        {
            PreFasadPars pars = new PreFasadPars();
            PreFasadMail mail = new PreFasadMail();

            mail.MailCompile();
            pars.ParsCompile();
        }
    }
}
