﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DolcheMilk
{
    internal class DataBase
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-S0CVP4L;Initial Catalog=MilkiBel;Integrated Security=True"); //подключение к БД

        public void openConnection() //открытие подключения
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
        }
        public void closeConnection()//закрытие подключения
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
        public SqlConnection getConnection()
        {
            return con;
        }
    }
    static class Data
    {
    }
}
