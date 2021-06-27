using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeradorCodigo.WebApi.Models
{
    public class MySqlDatabase : IDisposable
    {
        public MySqlConnection Connection;

        public MySqlDatabase(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
            this.Connection.Open();
        }

        public void Dispose()
        {
            Connection.Close();
        }
    }
}
