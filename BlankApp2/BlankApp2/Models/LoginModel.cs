using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankApp2.Models
{
    public class LoginModel : IDisposable
    {
        private static readonly string _ConnectionString = 
            @"Data Source=(localdb)\ProjectsV13;Initial Catalog=WPF;Integrated Security=True;";

        private SqlConnection _sqlConnection;

        public LoginModel()
        {
            _sqlConnection = new SqlConnection(_ConnectionString);
        }

        public static void LoginToTheDatabase(string username, string password)
        {

        }

        public void Dispose()
        {
            _sqlConnection?.Close();
        }

        //void Connection()
        //{
        //    var con = new System.Data.SqlClient.SqlConnection(connectionString);
        //    con.Open();
        //    try
        //    {
        //        string sqlstr = "select * from sys.tables";
        //        var com = new System.Data.SqlClient.SqlCommand(sqlstr, con);
        //        var sdr = com.ExecuteReader();

        //        while (sdr.Read() == true)
        //        {
        //            string tableName = sdr[0] as string;
        //        }
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}


    }
}
