using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Infrastructure.Interfaces
{
    internal interface IDBInteract
    {
        public void SaveDataToSQLite(string dbPath);
    }
}
