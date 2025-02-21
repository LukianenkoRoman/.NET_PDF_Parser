using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Infrastructure.Interfaces
{
    public interface IPathesDictionary
    {
        public Dictionary<string, string> PathList { get; set; }
        public Dictionary<string, string> pathSetter();

    }
}
