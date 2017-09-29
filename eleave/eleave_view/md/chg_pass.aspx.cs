using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eleave_c;
using System.Data;
using System.Web.Services;
using System.Text;
using System.Security.Cryptography;

namespace eleave_view.md
{
    public partial class chg_pass : System.Web.UI.Page
    {
        bus_eleave bus = new bus_eleave();
        string hashed_old, hashed;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                checklogin();
            }
        }

        protected void checklogin()
        {
            if (Session["is_login"] != null)
            {
                if (Session["is_login"].ToString() == "f")
                {
                    Response.Redirect("~/unauthorised.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        [WebMethod]
        public static int oldpchk(int userid, string oldp)
        {
            string ahashed = MD5Hash(oldp);
            bus_eleave bus = new bus_eleave();
            bus.userid = userid;
            bus.password = ahashed;
            int r = bus.oldpchk();
            return r;
        }
        public void clear()
        {
            txt_oldpwd.Text = "";
            txt_nwpwd.Text = "";
            txt_conf_nwpwd.Text = "";
        }

        protected void btncp_Click(object sender, EventArgs e)
        {
            if (txt_oldpwd.Text != "" && txt_nwpwd.Text != "" && txt_conf_nwpwd.Text != "")
            {
                if (txt_conf_nwpwd.Text.Trim().Length > 6 && txt_conf_nwpwd.Text.Trim().Length <= 10)
                {
                    hashed_old = MD5Hash(txt_oldpwd.Text.Trim());
                    hashed = MD5Hash(txt_conf_nwpwd.Text.Trim());
                    if (hashed != "" && hashed_old != "")
                    {
                        bus.userid = int.Parse(Session["user_id"].ToString());
                        bus.oldp = hashed_old;
                        bus.newp = hashed;
                        int r = bus.updatepwd();
                        if (r == 1)
                        {
                            clear();
                            clear2();
                            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success_pwd();", true);
                        }
                        else if (r == 2)
                        {
                            clear();
                            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_pwd();", true);
                        }
                        else
                        {
                            clear();
                            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_old();", true);
                        }
                    }
                    else
                    {
                        clear();
                        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_pwd();", true);
                    }
                }
                else
                {
                    clear();
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_length();", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error1();", true);
            }
        }

        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

        public void clear2()
        {
            Session.Clear();
            Session["is_login"] = "f";
        }
    }
}