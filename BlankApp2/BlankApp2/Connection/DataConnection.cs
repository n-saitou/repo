using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankApp2.Connection
{
    public class DataConnection : IDataConnection
    {
        private static readonly string _ConnectionString = 
            @"Data Source=(localdb)\ProjectsV13;Initial Catalog=WPF;Integrated Security=True;";

        private SqlConnection _sqlConnection;

        public DataConnection()
        {
            _sqlConnection = new SqlConnection(_ConnectionString);
        }

        public static void LoginToTheDatabase(string username, string password)
        {

        }

        /*
        public void Dispose()
        {
        }
        */

        public string UserName { get; set; }

        public void Connect()
        {
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _sqlConnection?.Close();
                    _sqlConnection = null;
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
