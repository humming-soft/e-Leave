using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using eleave_c;
using System.Globalization;
using System.Web.Mail;

namespace eleave_view.user
{
    public partial class cancel : System.Web.UI.Page
    {
        bus_eleave bus = new bus_eleave();
        bus_eleave_HS bus2 = new bus_eleave_HS();
        string a, a1, toemail, mailbody, url = "http://uoa.hummingsoft.com.my:8065/e_leave/ target=\"_blank\"", url2 = "http://192.168.1.65/e_leave/ target=\"_blank\"";
        DateTime dt1, dt2;
        int chk;
        Boolean ret;
        CultureInfo provider = CultureInfo.InvariantCulture;
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
                if (Session["is_login"].ToString() == "t")
                {
                    fill_user_approved_leaves();

                }
                else
                {
                    Response.Redirect("~/unauthorised.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        public void fill_user_approved_leaves()
        {
            bus.userid = int.Parse(Session["user_id"].ToString());
            DataTable dt = bus.fill_user_approved_leaves();
            grd_cancel.DataSource = dt;
            grd_cancel.DataBind();
        }
        protected void fetch_mail_details_cancel()
        {
            toemail = "";
            DataTable dt = bus2.fetch_mail_details_cancel();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    toemail = toemail + dt.Rows[i]["email"].ToString();
                    toemail += (i < dt.Rows.Count - 1) ? ";" : string.Empty;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "warning();", true);
            }
        }

        protected void lnkcancel_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            GridViewRow row = lnk.NamingContainer as GridViewRow;
            int id = int.Parse(grd_cancel.DataKeys[row.RowIndex].Value.ToString());
            //string adates = row.Cells[3].Text.Trim();
            bus.lid = id;
            int r = bus.initiate_cancel();
            if (r == 1)
            {
                fetch_mail_details_cancel();
                mailbody = "<table  border='1' cellpadding='0' cellspacing='0' style='width: 750px; border-color: black;'><tr><td colspan='9'><br>&nbsp &nbspDear Sir / Madam,<br /><br />&nbsp&nbsp&nbsp&nbsp&nbspCancellation of leave has been requested by  <b>" + Session["name"].ToString() + "</b> on <b>" + DateTime.Now.ToString("dd/MM/yyyy") + ".</b> The details are as follows.<br /><br /></td></tr><tr style='font-weight: 700;'></tr><tr><td colspan='9'><br/><p></p><p> &nbsp&nbsp&nbspName:   " + Session["name"].ToString() + "</p><p>&nbsp&nbsp&nbspDepartment:   " + Session["dep"].ToString() + "</p><p>&nbsp&nbsp&nbspDesignation:   " + Session["des"].ToString() + " </p><p>&nbsp&nbsp&nbspLeave Type:   " + row.Cells[1].Text.ToString() + " </p><p>&nbsp&nbsp&nbspclick<a href=" + url2 + "> here </a>to login into the application (UOA)</p><p>&nbsp&nbsp&nbspclick<a href=" + url + "> here </a>to login into the application</p><br/></td></tr><tr></tr><td colspan='9' style='font-weight: bold' align='right'><br /><br />Regards,<br />Team e-leave</td></tr><tr><td align='center'><p style='color:blue;'> This is a system generated response. Please do not respond to this email id.</p></td></tr></table>";
                bool check = SendWebMail(toemail, "Leave Application Notification", mailbody, "", "", "info@hummingsoft.com.my");
                if (check == true)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "errormail();", true);
                }
            }
            else
            {
                fill_user_approved_leaves();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
            }
        }

        protected Boolean Isvisible(string dates)
        {
            a = dates.Trim();
            ret = false;
            string[] values = a.Split(',');
            for (int i = 0; i < values.Length; i++)
            {
                a1 = values[i].ToString();
                DateTime dt1 = DateTime.Parse(a1);
                DateTime dt2 = DateTime.Now;
                if (dt1 > dt2)
                {
                    ret = true;
                }

            }

            return ret;
        }

        protected void grd_cancel_PreRender(object sender, EventArgs e)
        {
            if (grd_cancel.Rows.Count > 0)
            {
                grd_cancel.UseAccessibleHeader = true;
                grd_cancel.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        private bool SendWebMail(string strTo, string subj, string cont, string cc, string bcc, string strfrom)
        {
            bool flg = false;
            MailMessage msg = new MailMessage();
            msg.Body = cont;
            msg.From = strfrom;
            msg.To = strTo;
            msg.Subject = subj;
            msg.Cc = cc;
            msg.Bcc = bcc;
            msg.BodyFormat = MailFormat.Html;
            try
            {
                //SmtpMail.SmtpServer = "175.143.44.165";
                //SmtpMail.SmtpServer = "192.168.1.4"; // change the ip address when hosting in server
                SmtpMail.SmtpServer = "webmail.hummingsoft.com.my";
                SmtpMail.Send(msg);
                flg = true;
            }
            catch (Exception)
            {
                flg = false;
            }
            return flg;
        }
    }
}