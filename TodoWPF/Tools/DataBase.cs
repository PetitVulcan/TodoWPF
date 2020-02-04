﻿using MySql.Data.MySqlClient;
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

        private string connectionString = "Server=mysql-todo.alwaysdata.net;User=todo_wpf;Password=*2019#JpGodet*;DataBase=todo_psyko";
        public MySqlConnection connection;
        public MySqlCommand command;
        public MySqlDataReader reader;
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
            connection = new MySqlConnection(connectionString);
        }
    }
}
