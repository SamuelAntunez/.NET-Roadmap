using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace BaseDeDatos
{
    public class DB
    {
        private string _connectionString;
        protected SqlConnection _connection;

        public DB(string server, string db, string user, string password)
        {
            _connectionString = $"Data Source={server}; Initial Catalog={db};" +
                $"User ID={user};Password={password}";
        }

        public void Connect()
        {
            _connection = new SqlConnection(_connectionString);
            _connection.Open();
        }

        public void Close()
        {
            if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
            _connection.Close();
        }
    }
}
