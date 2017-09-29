using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace eleave_m
{
    public class dbconnect
    {
        SqlConnection con = new SqlConnection();
        string constring = ConfigurationManager.ConnectionStrings["eleave"].ToString();

        public SqlConnection connect()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.ConnectionString = constring;
                    con.Open();
                }

            }
            catch (Exception e)
            {

            }
            return con;
        }

        public SqlConnection disconnect()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception e)
            {

            }
            return con;
        }
    }
}
