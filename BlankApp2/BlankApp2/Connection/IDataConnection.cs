using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankApp2.Connection
{
    public interface IDataConnection : IDisposable
    {

        string UserName { get; set; }
        void Connect();
    }
}
