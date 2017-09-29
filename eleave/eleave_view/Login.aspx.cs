    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Web.Configuration;
using eleave_c;
using System.Text;
using System.Security.Cryptography;
using System.DirectoryServices;

namespace eleave_view
{
    public partial class Login : System.Web.UI.Page
    {
        bus_eleave bus = new bus_eleave();
        string hashed, domainName, adPath, userName, pswd, strError;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                inval.Visible = false;
            }
        }

        protected void logi_Click(object sender, EventArgs e)
        {
            if (username.Text != "" && password.Text != "")
            {
                //hashed = MD5Hash(password.Text.Trim());
                //if (hashed != "")
                //{
                //    bus.user_name = username.Text;
                //    bus.password = hashed;
                //    int res = bus.check_login();
                //    if (res == 1)
                //    {
                //        inval.Visible = false;
                //        set_sessions();

                //    }
                //    else
                //    {
                //        username.Text = "";
                //        password.Text = "";
                //        inval.Visible = true;
                //    }
                //}
                //else
                //{
                //    username.Text = "";
                //    password.Text = "";
                //    inval.Visible = true;
                //}

                /* LDAP Authentication : START */

                domainName = string.Empty;
                adPath = string.Empty;
                userName = username.Text.Trim();
                pswd = password.Text.Trim();
                strError = string.Empty;

                domainName = WebConfigurationManager.AppSettings["DirectoryPath"];
                adPath = WebConfigurationManager.AppSettings["DirectoryDomain"];

                bool a = AuthenticateUser(domainName, userName, pswd);

                if (a == true)
                {
                    inval.Visible = false;
                    set_sessions();
                }
                else
                {
                    username.Text = "";
                    password.Text = "";
                    inval.Visible = true;
                }

                /* LDAP Authentication : END */
            }
            else
            {
            }
        }

        public void set_sessions()
        {
            bus.user_name = username.Text;
            DataTable dt = bus.fetch_userdetails();
            if (dt.Rows.Count > 0)
            {
                Session["user_id"] = dt.Rows[0][0].ToString();
                Session["name"] = dt.Rows[0][1].ToString();
                Session["gender"] = dt.Rows[0][2].ToString();
                Session["doj"] = dt.Rows[0][3].ToString();
                Session["dep"] = dt.Rows[0][4].ToString();
                Session["des"] = dt.Rows[0][5].ToString();
                Session["role"] = dt.Rows[0][6].ToString();
                Session["region"]=dt.Rows[0][7].ToString();
                Session["is_login"] = "t";
                if (Session["role"].ToString() == "User")
                {
                    Response.Redirect("~/user/dash.aspx");
                }
                else if (Session["role"].ToString() == "HR")
                {
                    Response.Redirect("~/hr/hrdash.aspx");
                }
                else if (Session["role"].ToString() == "Management")
                {
                    Response.Redirect("~/md/dash.aspx");
                }
                else
                {
                    Response.Redirect("~/unauthorised.aspx");
                }
            }
            else
            {
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

      public bool AuthenticateUser(string path, string user, string pass)
      {
          DirectoryEntry de = new DirectoryEntry(path, user, pass, AuthenticationTypes.Secure);
          try
          {
              //run a search using those credentials.  
              //If it returns anything, then you're authenticated
              DirectorySearcher ds = new DirectorySearcher(de);
              ds.FindOne();
              return true;
          }
          catch
          {
              //otherwise, it will crash out so return false
              return false;
          }
      }
    }
}