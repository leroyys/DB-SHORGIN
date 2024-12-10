using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace muscnt
{
    internal class Connection
    {
        private static Connection _instance;
        private SQLiteConnection _connection;

        private Connection()
        {
            _connection = new SQLiteConnection("Data Source=C:\\Users\\andri\\Desktop\\КУРСОВАЯ МЦ\\dbmc.db");
            _connection.Open();
        }

        public static Connection GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Connection();
            }
            return _instance;
        }

        public SQLiteConnection GetConnection()
        {
            return _connection;
        }

        public void CloseConnection()
        {
            if (_connection != null)
            {
                _connection.Close();
            }
        }
    }
}
