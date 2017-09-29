using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace eleave_m
{
    public class data_eleave_HS
    {
        SqlCommand cmd = new SqlCommand();
        dbconnect db = new dbconnect();
        public DataTable fetch_collegues(int userid)
        {
            try
            {
                //cmd.Connection = db.disconnect();
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fetch_collegues";
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Connection = db.connect();
                cmd.Parameters.AddWithValue("@userid", userid);
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                cmd.Connection = db.connect();
                da.SelectCommand = cmd;
                da.Fill(dt);
                return dt;
            }
            finally
            {
                db.disconnect();
            }
        }
        public DataTable fill_app_rej_hr()
        {
            try
            {
                //cmd.Connection = db.disconnect();
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fill_app_rej_hr";
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Connection = db.connect();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                cmd.Connection = db.connect();
                da.Fill(dt);
                return dt;
            }
            finally
            {
                db.disconnect();
            }
        }

        public int reject_leave(int lid)
        {
            try
            {
                //cmd.Connection = db.disconnect();
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_reject_leave_hr";
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Connection = db.connect();
                cmd.Parameters.AddWithValue("@leave_id", lid);
                SqlParameter outparam = new SqlParameter();
                outparam.ParameterName = "@flag";
                outparam.Direction = ParameterDirection.InputOutput;
                outparam.DbType = DbType.Int32;
                outparam.Value = 0;
                cmd.Parameters.Add(outparam);
                cmd.Connection = db.connect();
                cmd.ExecuteNonQuery();
                int res = int.Parse(cmd.Parameters["@flag"].Value.ToString());
                //cmd.Dispose();
                return res;
            }
            finally
            {
                db.disconnect();
            }
        }

        public int accept_leave(int lid)
        {
            try
            {
                //cmd.Connection = db.disconnect();
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_accept_leave_hr";
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Connection = db.connect();
                cmd.Parameters.AddWithValue("@lid", lid);
                SqlParameter outparam = new SqlParameter();
                outparam.ParameterName = "@flag";
                outparam.Direction = ParameterDirection.InputOutput;
                outparam.DbType = DbType.Int32;
                outparam.Value = 0;
                cmd.Parameters.Add(outparam);
                cmd.Connection = db.connect();
                cmd.ExecuteNonQuery();
                int res = int.Parse(cmd.Parameters["@flag"].Value.ToString());
                //cmd.Dispose();
                return res;
            }
            finally
            {
                db.disconnect();
            }
        }

        public int checkold(int uid)
        {
            try
            {
                //cmd.Connection = db.disconnect();
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_chk_oldpwd_hr";
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Connection = db.connect();
                cmd.Parameters.AddWithValue("@uid", uid);
                SqlParameter outparam = new SqlParameter();
                outparam.ParameterName = "@flag";
                outparam.Direction = ParameterDirection.InputOutput;
                outparam.DbType = DbType.Int32;
                outparam.Value = 0;
                cmd.Parameters.Add(outparam);
                cmd.Connection = db.connect();
                cmd.ExecuteNonQuery();
                int res = int.Parse(cmd.Parameters["@flag"].Value.ToString());
                //cmd.Dispose();
                return res;
            }
            finally
            {
                db.disconnect();
            }
        }

        public int updatepwd(int uid, string nwpwd, string cnf_nwpwd)
        {
            try
            {
                //cmd.Connection = db.disconnect();
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_update_pwd_hr";
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Connection = db.connect();
                cmd.Parameters.AddWithValue("@uid", uid);
                cmd.Parameters.AddWithValue("@nwpwd", nwpwd);
                SqlParameter outparam = new SqlParameter();
                outparam.ParameterName = "@flag";
                outparam.Direction = ParameterDirection.InputOutput;
                outparam.DbType = DbType.Int32;
                outparam.Value = 0;
                cmd.Parameters.Add(outparam);
                cmd.Connection = db.connect();
                cmd.ExecuteNonQuery();
                int res = int.Parse(cmd.Parameters["@flag"].Value.ToString());
                //cmd.Dispose();
                return res;
            }
            finally
            {
                db.disconnect();
            }
        }
        public string file_hr(int lid)
        {
            try
            {
                //cmd.Connection = db.disconnect();
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fetch_file";
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Connection = db.connect();
                cmd.Parameters.AddWithValue("@lid", lid);
                SqlParameter outparam = new SqlParameter();
                outparam.ParameterName = "@file";
                outparam.Direction = ParameterDirection.InputOutput;
                outparam.DbType = DbType.Int32;
                outparam.Value = 0;
                cmd.Parameters.Add(outparam);
                cmd.Connection = db.connect();
                cmd.ExecuteNonQuery();
                string file = cmd.Parameters["@file"].Value.ToString();
                //cmd.Dispose();
                return file;
            }
            finally
            {
                db.disconnect();
            }
        }

        public DataTable fetch_mail_details_hr()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fetch_mail_details_hr_cc";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                cmd.Connection = db.connect();
                da.Fill(dt);
                return dt;
            }
            finally
            {
                db.disconnect();
            }
        }

        public DataTable fetch_mail_details_cancel()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fetch_mail_details_cancel_hr";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                cmd.Connection = db.connect();
                da.SelectCommand = cmd;
                da.Fill(dt);
                return dt;
            }
            finally
            {
                db.disconnect();
            }
        }

        public DataTable fill_approvedleaves()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fill_approvedleaves";
                cmd.CommandType = CommandType.StoredProcedure;                
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                cmd.Connection = db.connect();
                da.SelectCommand = cmd;
                da.Fill(dt);                
                return dt;
            }
            finally
            {
                db.disconnect();
            }
        }

        public int forward_leave_appr(int lid)
        {
            try
            {                
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_forward_leave";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@lid", lid);                
                SqlParameter outparam = new SqlParameter();
                outparam.ParameterName = "@flag";
                outparam.Direction = ParameterDirection.InputOutput;
                outparam.DbType = DbType.Int32;
                outparam.Value = 0;
                cmd.Parameters.Add(outparam);
                cmd.Connection = db.connect();
                cmd.ExecuteNonQuery();
                int res = int.Parse(cmd.Parameters["@flag"].Value.ToString());
                return res;
            }
            finally
            {
                db.disconnect();
            }
        }

        public DataTable fetch_mail_details_appr()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fetch_mail_details_appr";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                cmd.Connection = db.connect();
                da.SelectCommand = cmd;
                da.Fill(dt);
                return dt;
            }
            finally
            {
                db.disconnect();
            }
        }

        public int forward_leave_rej(int lid)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_forward_leave_rej";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@lid", lid);
                SqlParameter outparam = new SqlParameter();
                outparam.ParameterName = "@flag";
                outparam.Direction = ParameterDirection.InputOutput;
                outparam.DbType = DbType.Int32;
                outparam.Value = 0;
                cmd.Parameters.Add(outparam);
                cmd.Connection = db.connect();
                cmd.ExecuteNonQuery();
                int res = int.Parse(cmd.Parameters["@flag"].Value.ToString());
                return res;
            }
            finally
            {
                db.disconnect();
            }
        }
        
    }
}
