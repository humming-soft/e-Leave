using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace eleave_m
{
    public class data_eleave
    {
        SqlCommand cmd = new SqlCommand();
        dbconnect db = new dbconnect();

        public int check_login(string username, string pswd)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_checklogin";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@pswd", pswd);
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

        public DataTable fetch_userdetails(string username)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fetch_user_details";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", username);
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
        public DataTable fetch_holidays(int rid)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fetch_holidays";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@rid", rid);
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

        public DataTable fetch_holidays_cal(int rid)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fetch_holidays_cal";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@rid", rid);
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

        public DataTable fetch_holidays1(int userid)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fetch_holidays1";
                cmd.CommandType = CommandType.StoredProcedure;
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
        public DataTable fetch_holidaysma(int userid)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fetch_holidaysma";
                cmd.CommandType = CommandType.StoredProcedure;
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
        public DataTable fetch_holidays_cochin(int userid)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fetch_holidayscochin";
                cmd.CommandType = CommandType.StoredProcedure;
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

        public DataTable fetch_leaves(int userid)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fetch_leaves";
                cmd.CommandType = CommandType.StoredProcedure;
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

        public DataTable fill_grid(int userid)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fill_leaves_user";
                cmd.CommandType = CommandType.StoredProcedure;
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

        public DataTable fetch_download_leaves(int lid)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_download_approved_leaves";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@lid", lid);
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

        public DataTable fetch_details(int userid)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fetch_details";
                cmd.CommandType = CommandType.StoredProcedure;
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

        public DataTable fetch_leavetypes(int userid)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fetch_leaves_available";
                cmd.CommandType = CommandType.StoredProcedure;
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

        public DataTable fetch_period()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fetch_period";
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

        public DataTable fetch_collegues(int userid)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fetch_collegues";
                cmd.CommandType = CommandType.StoredProcedure;
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

        public int insert_med(int userid, int ltype, string dates, int period, string reason, double rdays, string jobc, string contact, string med_path)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_insert_med";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userid", userid);
                cmd.Parameters.AddWithValue("@ltype", ltype);
                cmd.Parameters.AddWithValue("@dates", dates);
                cmd.Parameters.AddWithValue("@period", period);
                cmd.Parameters.AddWithValue("@reason", reason);
                cmd.Parameters.AddWithValue("@rdays", rdays);
                cmd.Parameters.AddWithValue("@jobc", jobc);
                cmd.Parameters.AddWithValue("@contact", contact);
                cmd.Parameters.AddWithValue("@med_path", med_path);
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

        public int insert_leave(int userid, int ltype, string dates, int period, string reason, double rdays, string jobc, string contact)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_check_avail_chk";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userid", userid);
                cmd.Parameters.AddWithValue("@ltype", ltype);
                cmd.Parameters.AddWithValue("@dates", dates);
                cmd.Parameters.AddWithValue("@period", period);
                cmd.Parameters.AddWithValue("@reason", reason);
                cmd.Parameters.AddWithValue("@rdays", rdays);
                cmd.Parameters.AddWithValue("@jobc", jobc);
                cmd.Parameters.AddWithValue("@contact", contact);
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

        public int insert_oleave(int userid, int ltype, string dates, int period, string reason, double rdays, string jobc, string contact)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_insert_oleaves";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userid", userid);
                cmd.Parameters.AddWithValue("@ltype", ltype);
                cmd.Parameters.AddWithValue("@dates", dates);
                cmd.Parameters.AddWithValue("@period", period);
                cmd.Parameters.AddWithValue("@reason", reason);
                cmd.Parameters.AddWithValue("@rdays", rdays);
                cmd.Parameters.AddWithValue("@jobc", jobc);
                cmd.Parameters.AddWithValue("@contact", contact);
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

        public int cancel_leave(int lid)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_cancel_leave";
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

        public DataTable fill_user_approved_leaves(int userid)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fetch_approved_leaves";
                cmd.CommandType = CommandType.StoredProcedure;
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

        public int check_avail(int userid, int ltype, double rdays)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_check_avail";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userid", userid);
                cmd.Parameters.AddWithValue("@ltype", ltype);
                cmd.Parameters.AddWithValue("@rdays", rdays);
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

        public int initiate_cancel(int lid)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_initiate_cancel";
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

        public int upload_holidays(string event_name, DateTime event_date, string event_color)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_upload_holidays_bulk";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@event_name", event_name);
                cmd.Parameters.AddWithValue("@event_date", event_date);
                cmd.Parameters.AddWithValue("@event_color", event_color);
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

        public int upload_holidays_malaysia(string event_name, DateTime event_date, string event_color)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_upload_holidays_bulk_malaysia";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@event_name", event_name);
                cmd.Parameters.AddWithValue("@event_date", event_date);
                cmd.Parameters.AddWithValue("@event_color", event_color);
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

        public DataTable fillgender()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fillgender";
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

        public DataTable filldep()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_filldepartment";
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

        public int add_user(string name, string user_name, string email, string gender, DateTime doj, DateTime dob, int dep, int grade, int desi, int region)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_add_user";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@user_name", user_name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@doj", doj);
                cmd.Parameters.AddWithValue("@dob", dob);
                cmd.Parameters.AddWithValue("@dep", dep);
                cmd.Parameters.AddWithValue("@grade", grade);
                cmd.Parameters.AddWithValue("@desi", desi);
                cmd.Parameters.AddWithValue("@region", region);
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

        public DataTable fetchdesignation(int id)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fetchdesignation";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
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

        public DataTable fetchgrade(int id)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fetchgrade";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
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

        public DataTable fillregion()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fillregion";
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

        public DataTable fetchdisdates()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fetchdisdates";
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

        public DataTable fillusers()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fetchall_users";
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

        public int deleteuser(int id)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_deleteuser";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
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

        public DataTable fillleavesfr()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fillleavesfr";
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

        public DataTable fill_leaves_all()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_userleaves_all";
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

        public int forward_leave(int lid)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_accept_leave_hr";
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

        public int reject_leave(int lid, int userid, string reason)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_reject_leave_hr";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@lid", lid);
                cmd.Parameters.AddWithValue("@userid", userid);
                cmd.Parameters.AddWithValue("@reason", reason);
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

        public int fetchalerts()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fetchalerts";
                cmd.CommandType = CommandType.StoredProcedure;
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

        public int fetchalerts_cancel()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fetchalerts_cancel";
                cmd.CommandType = CommandType.StoredProcedure;
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

        public int updatepwd(int uid, string oldp, string newp)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_update_pwd_hr";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uid", uid);
                cmd.Parameters.AddWithValue("@oldp", oldp);
                cmd.Parameters.AddWithValue("@newp", newp);
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

        public DataTable fill_details_user(int uid)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fill_details_user";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uid", uid);
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

        public int update_profile(int uid, string add1, string add2, string mob)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_updateProfile_hr";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uid", uid);
                cmd.Parameters.AddWithValue("@add1", add1);
                cmd.Parameters.AddWithValue("@add2", add2);
                cmd.Parameters.AddWithValue("@mob", mob);
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

        public int oldpchk(int uid, string password)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_oldpchk";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uid", uid);
                cmd.Parameters.AddWithValue("@password", password);
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

        public DataTable fillleavesapr()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fill_leaves_app";
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

        public int approve_leave(int lid, int userid)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_approve_leave";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@lid", lid);
                cmd.Parameters.AddWithValue("@userid", userid);
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

        public int reject_leave_md(int lid, int userid, string reason)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_reject_leave_md";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@lid", lid);
                cmd.Parameters.AddWithValue("@userid", userid);
                cmd.Parameters.AddWithValue("@reason", reason);
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

        public DataTable fill_leaves_all_highcharts()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_userleaves_all_highcharts";
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

        public int fetchalerts_md()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fetchalerts_md";
                cmd.CommandType = CommandType.StoredProcedure;
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
        public int fetchalerts_user(int userid)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fetchalerts_user";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userid", userid);
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

        public DataTable fillcancapprl()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fillcancapprl";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cmd;
                cmd.Connection = db.connect();
                da.Fill(dt);
                return dt;
            }
            finally
            {
                db.disconnect();
            }
        }

        public int reject_can_appr(int lid)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_reject_can_appr";
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

        public int cancel_all_approved(int lid)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_cancel_all_approved";
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

        public int cancel_av_approved(int lid, string dates, double rdays)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_cancel_av_approved";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@lid", lid);
                cmd.Parameters.AddWithValue("@dates", dates);
                cmd.Parameters.AddWithValue("@rdays", rdays);
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

        public int fetchalerts_md2()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fetchalerts_md2";
                cmd.CommandType = CommandType.StoredProcedure;
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

        public void change_stat(int userid)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_change_stat";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userid", userid);
                SqlParameter outparam = new SqlParameter();
                cmd.Connection = db.connect();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                db.disconnect();
            }
        }
        public DataTable fill_details_user_edit(int uid)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fill_details_user_edit";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uid", uid);
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

        public int update_user(int id, string name, string user_name, string email, string gender, DateTime doj, int dep, int grade, int desi, int region, DateTime dob)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_update_user";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@user_name", user_name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@doj", doj);
                cmd.Parameters.AddWithValue("@dep", dep);
                cmd.Parameters.AddWithValue("@grade", grade);
                cmd.Parameters.AddWithValue("@desi", desi);
                cmd.Parameters.AddWithValue("@region", region);
                cmd.Parameters.AddWithValue("@dob", dob);
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

        public DataTable fillcflist()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fillcflist";
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

        public int checkcf()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_checkcf";
                cmd.CommandType = CommandType.StoredProcedure;
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

        public int cf()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_carryforward";
                cmd.CommandType = CommandType.StoredProcedure;
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

        public DataTable fetch_leaves_taken()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_userleaves_all_taken";
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

        public DataTable fetch_leaves_balance()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_userleaves_balance";
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

        public DataTable fill_logs()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_leaves_log";
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

        public DataTable fetch_mail_details(string role)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fetch_mail_details_hr";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@role", role);
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

        public DataTable fetch_mail_details_cancel()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fetch_mail_details_cancel";
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

        public DataTable fetch_mail_details_hr_apply(string role)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fetch_mail_details_hr_apply";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@role", role);
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
        public int checkusername(string username)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_checkusername";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", username);
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

        public int checkemail(string email)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_checkemail";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@email", email);
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
        public int checkusername_edit(string username, int id)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_checkusername_edit";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@id", id);
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

        public int checkemail_edit(string email, int id)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_checkemail_edit";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@id", id);
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

        public DataTable fill_ldetails(int lid)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fill_ldetails";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@lid", lid);
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

        public string fetch_details_edit(int id)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fetch_details_edit";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlParameter outparam = new SqlParameter();
                outparam.ParameterName = "@flag";
                outparam.Direction = ParameterDirection.InputOutput;
                outparam.DbType = DbType.String;
                outparam.Size = 600;
                outparam.Value = "";
                cmd.Parameters.Add(outparam);
                cmd.Connection = db.connect();
                cmd.ExecuteNonQuery();
                string res = cmd.Parameters["@flag"].Value.ToString();
                return res;
            }
            finally
            {
                db.disconnect();
            }
        }

        public int check_in_out(int userid, int ltype, double rdays)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_check_in_out";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userid", userid);
                cmd.Parameters.AddWithValue("@ltype", ltype);
                cmd.Parameters.AddWithValue("@rdays", rdays);
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

        public int clear_holidays()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_clear_holidays";
                cmd.CommandType = CommandType.StoredProcedure;
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

        public int clear_holidays_hs()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_clear_holidays_hs";
                cmd.CommandType = CommandType.StoredProcedure;
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

        public DataTable fill_leves_appr_all()
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "sp_fill_leves_appr_all";
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
    }
}
