using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using eleave_c;
using System.Web.Mail;

namespace eleave_view.hr
{
    public partial class app_rej_forward_hr : System.Web.UI.Page
    {
        bus_eleave_HS obj = new bus_eleave_HS();
        int f;
        CheckBox cbox;
        public string toemail, mailbody, url = "http://uoa.hummingsoft.com.my:8065/e_leave/ target=\"_blank\"", url2 = "http://192.168.1.65/e_leave/ target=\"_blank\"";
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
                    fill_approvedleaves();
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

        protected void fill_approvedleaves()
        {
            DataTable dt = obj.fill_approvedleaves();
            if(dt.Rows.Count>0)
            {
                approved_hr.DataSource = dt;
                approved_hr.DataBind();
            }
            else
            {
                approved_hr.DataSource = null;
                approved_hr.DataBind();
            }
        }        

        protected void lnk_appr_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            GridViewRow row = lnk.NamingContainer as GridViewRow;
            int id = int.Parse(approved_hr.DataKeys[row.RowIndex].Value.ToString());
            obj.lid = id;
            int r = obj.forward_leave_appr();
            if (r == 1)
            {
                fetch_mail_details_appr();
                mailbody = "<table  border='1' cellpadding='0' cellspacing='0' style='width: 850px; border-color: black;'><tr><td colspan='9'><br>&nbsp &nbspDear Sir / Madam,<br /><br />&nbsp&nbsp&nbsp&nbsp&nbspLeave application submitted by <b>" + row.Cells[1].Text.ToString() + "</b> has been forwarded to you on <b>" + DateTime.Now.ToString("dd/MM/yyyy") + ".</b> The details are as follows.<br /><br /></td></tr><tr style='font-weight: 700;'></tr><tr><td colspan='9'><br/><p></p><p> &nbsp&nbsp&nbspName:   " + row.Cells[1].Text.ToString() + "</p><p>&nbsp&nbsp&nbspDepartment:   " + row.Cells[2].Text.ToString() + "</p><p>&nbsp&nbsp&nbspDesignation:   " + row.Cells[3].Text.ToString() + " </p><p>&nbsp&nbsp&nbspLeave Type:   " + row.Cells[4].Text.ToString() + " </p><p>&nbsp&nbsp&nbspPeriod:   " + row.Cells[6].Text.ToString() + " </p><p>&nbsp&nbsp&nbspReason:   " + row.Cells[7].Text.ToString() + " </p><p>&nbsp&nbsp&nbspclick<a href=" + url2 + "> here </a>to login into the application (UOA)</p><p>&nbsp&nbsp&nbspclick<a href=" + url + "> here </a>to login into the application</p><br/></td></tr><tr></tr><td colspan='9' style='font-weight: bold' align='right'><br /><br />Regards,<br />Team e-leave</td></tr><tr><td align='center'><p style='color:blue;'> This is a system generated response. Please do not respond to this email id.</p></td></tr></table>";
                bool check = SendWebMail(toemail, "Leave Application Notification", mailbody, "", "", "info@hummingsoft.com.my");
                if (check == true)
                {
                    fill_approvedleaves();
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
                }
                else
                {
                    fill_approvedleaves();
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "errormail();", true);
                }
            }
            else
            {
                fill_approvedleaves();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
            }
        }

        protected void lnk_reject_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            GridViewRow row = lnk.NamingContainer as GridViewRow;
            int id = int.Parse(approved_hr.DataKeys[row.RowIndex].Value.ToString());
            obj.lid = id;
            int r = obj.forward_leave_rej();
            if (r == 1)
            {
                mailbody = "<table  border='1' cellpadding='0' cellspacing='0' style='width: 850px; border-color: black;'><tr><td colspan='9'><br>&nbsp &nbspDear " + row.Cells[1].Text.ToString() + ",<br /><br />&nbsp&nbsp&nbsp&nbsp&nbspCancellation of leave submitted by you is <b>Rejected </b> on " + DateTime.Now.ToString("dd/MM/yyyy") + ".</b> The details are as follows.<br /><br /></td></tr><tr style='font-weight: 700;'></tr><tr><td colspan='9'><br/><p></p><p> &nbsp&nbsp&nbspName:   " + row.Cells[1].Text.ToString() + "</p><p>&nbsp&nbsp&nbspDepartment:   " + row.Cells[2].Text.ToString() + "</p><p>&nbsp&nbsp&nbspDesignation:   " + row.Cells[3].Text.ToString() + " </p><p>&nbsp&nbsp&nbspLeave Type:   " + row.Cells[4].Text.ToString() + " </p><p>&nbsp&nbsp&nbspPeriod:   " + row.Cells[6].Text.ToString() + " </p><p>&nbsp&nbsp&nbspReason:   " + row.Cells[7].Text.ToString() + " </p><p>&nbsp&nbsp&nbspclick<a href=" + url2 + "> here </a>to login into the application (UOA)</p><p>&nbsp&nbsp&nbspclick<a href=" + url + "> here </a>to login into the application</p><br/></td></tr><tr></tr><td colspan='9' style='font-weight: bold' align='right'><br /><br />Regards,<br />Team e-leave</td></tr><tr><td align='center'><p style='color:blue;'> This is a system generated response. Please do not respond to this email id.</p></td></tr></table>";
                bool check = SendWebMail(row.Cells[9].Text.ToString(), "Leave Application Notification", mailbody, "", "", "info@hummingsoft.com.my");
                if (check == true)
                {
                    fill_approvedleaves();
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
                }
                else
                {
                    fill_approvedleaves();
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "errormail();", true);
                }
            }
            else
            {
                fill_approvedleaves();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
            }
        }

        public void fetch_mail_details_appr()
        {
            toemail = "";
            obj.role = Session["role"].ToString();
            DataTable dtemail = obj.fetch_mail_details_appr();
            if (dtemail.Rows.Count > 0)
            {
                for (int i = 0; i < dtemail.Rows.Count; i++)
                {
                    toemail = toemail + dtemail.Rows[i]["email"].ToString();
                    toemail += (i < dtemail.Rows.Count - 1) ? ";" : string.Empty;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "warning();", true);
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
                SmtpMail.SmtpServer = "webmail.hummingsoft.com.my"; // change the ip address to this when hosting in server
                SmtpMail.Send(msg);
                flg = true;
            }
            catch (Exception)
            {
                flg = false;
            }
            return flg;
        }

        protected void approved_hr_PreRender(object sender, EventArgs e)
        {
            if (approved_hr.Rows.Count > 0)
            {
                approved_hr.UseAccessibleHeader = true;
                approved_hr.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        
    }
}