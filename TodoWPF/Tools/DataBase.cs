using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoWPF.Tools
{
    class DataBase
    {
        private static DataBase instance = null;
        private static object _lock = new object();

        private string connectionString = @"Data Source=(LocalDB)\CoursMCPD;Integrated Security=True";
        public SqlConnection connection;
        public SqlCommand command;
        public SqlDataReader reader;
        public static DataBase Instance
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                        instance = new DataBase();
                    return instance;
                }
            }
        }
        private DataBase()
        {
            connection = new SqlConnection(connectionString);
        }
    }
}
