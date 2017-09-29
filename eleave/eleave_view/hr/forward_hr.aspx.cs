using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using eleave_c;
using System.Web.Mail;
using System.Net;

namespace eleave_view.hr
{
    public partial class forward_hr : System.Web.UI.Page
    {
        bus_eleave bus = new bus_eleave();
        bus_eleave_HS obj = new bus_eleave_HS();
        WebClient client = new WebClient();
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
                    fillleavesfr();

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

        protected void fillleavesfr()
        {
            DataTable dt = bus.fillleavesfr();
            if (dt.Rows.Count > 0)
            {
                grd_forward.DataSource = dt;
                grd_forward.DataBind();
            }
            else
            {
                grd_forward.DataSource = null;
                grd_forward.DataBind();
                btnaccept.Visible = false;
                btnreject.Visible = false;
                Panel1.Visible = false;
            }
        }

        public void fetch_mail_details()
        {
            toemail = "";
            bus.role = Session["role"].ToString();
            DataTable dtemail = bus.fetch_mail_details();
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

        protected void btnaccept_Click(object sender, EventArgs e)
        {
            f = 1;
            foreach (GridViewRow row in grd_forward.Rows)
            {
                cbox = (CheckBox)row.FindControl("chk"); //RowSelector is the id of checkbox in Grid View
                if (cbox.Checked == true)
                {
                    // Fetch request's id
                    int RequestId = Convert.ToInt32(grd_forward.DataKeys[row.RowIndex].Value);

                    // Write your approval logic here
                    bus.lid = RequestId;
                    int r = bus.forward_leave();
                    if (r == 1)
                    {
                        fetch_mail_details();
                        mailbody = "<table  border='1' cellpadding='0' cellspacing='0' style='width: 850px; border-color: black;'><tr><td colspan='9'><br>&nbsp &nbspDear Sir / Madam,<br /><br />&nbsp&nbsp&nbsp&nbsp&nbspLeave application submitted by <b>" + row.Cells[2].Text.ToString() + "</b> has been forwarded to you on <b>" + DateTime.Now.ToString("dd/MM/yyyy") + ".</b> The details are as follows.<br /><br /></td></tr><tr style='font-weight: 700;'></tr><tr><td colspan='9'><br/><p></p><p> &nbsp&nbsp&nbspName:   " + row.Cells[2].Text.ToString() + "</p><p>&nbsp&nbsp&nbspDepartment:   " + row.Cells[3].Text.ToString() + "</p><p>&nbsp&nbsp&nbspDesignation:   " + row.Cells[4].Text.ToString() + " </p><p>&nbsp&nbsp&nbspLeave Type:   " + row.Cells[5].Text.ToString() + " </p><p>&nbsp&nbsp&nbspPeriod:   " + row.Cells[7].Text.ToString() + " </p><p>&nbsp&nbsp&nbspReason:   " + row.Cells[8].Text.ToString() + " </p><p>&nbsp&nbsp&nbspclick<a href=" + url2 + "> here </a>to login into the application (UOA)</p><p>&nbsp&nbsp&nbspclick<a href=" + url + "> here </a>to login into the application</p><br/></td></tr><tr></tr><td colspan='9' style='font-weight: bold' align='right'><br /><br />Regards,<br />Team e-leave</td></tr><tr><td align='center'><p style='color:blue;'> This is a system generated response. Please do not respond to this email id.</p></td></tr></table>";
                        bool check = SendWebMail(toemail, "Leave Application Notification", mailbody, "", "", "info@hummingsoft.com.my");
                        if (check == true)
                        {
                            f = 0;
                        }
                        else
                        {
                            f = 3;
                        }
                    }
                    else
                    {
                        f = 2;
                    }

                }

            }
            if (f == 0)
            {
                fillleavesfr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
            }
            else if (f == 2)
            {
                fillleavesfr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
            }
            else if (f == 3)
            {
                fillleavesfr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "errormail();", true);
            }
            else
            {
                fillleavesfr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "warning();", true);
            }

        }

        protected void lnkforward_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            GridViewRow row = lnk.NamingContainer as GridViewRow;
            int id = int.Parse(grd_forward.DataKeys[row.RowIndex].Value.ToString());
            bus.lid = id;
            int r = bus.forward_leave();
            if (r == 1)
            {
                fetch_mail_details();
                mailbody = "<table  border='1' cellpadding='0' cellspacing='0' style='width: 850px; border-color: black;'><tr><td colspan='9'><br>&nbsp &nbspDear Sir / Madam,<br /><br />&nbsp&nbsp&nbsp&nbsp&nbspLeave application submitted by <b>" + row.Cells[2].Text.ToString() + "</b> has been forwarded to you on <b>" + DateTime.Now.ToString("dd/MM/yyyy") + ".</b> The details are as follows.<br /><br /></td></tr><tr style='font-weight: 700;'></tr><tr><td colspan='9'><br/><p></p><p> &nbsp&nbsp&nbspName:   " + row.Cells[2].Text.ToString() + "</p><p>&nbsp&nbsp&nbspDepartment:   " + row.Cells[3].Text.ToString() + "</p><p>&nbsp&nbsp&nbspDesignation:   " + row.Cells[4].Text.ToString() + " </p><p>&nbsp&nbsp&nbspLeave Type:   " + row.Cells[5].Text.ToString() + " </p><p>&nbsp&nbsp&nbspPeriod:   " + row.Cells[7].Text.ToString() + " </p><p>&nbsp&nbsp&nbspReason:   " + row.Cells[8].Text.ToString() + " </p><p>&nbsp&nbsp&nbspclick<a href=" + url2 + "> here </a>to login into the application (UOA)</p><p>&nbsp&nbsp&nbspclick<a href=" + url + "> here </a>to login into the application</p><br/></td></tr><tr></tr><td colspan='9' style='font-weight: bold' align='right'><br /><br />Regards,<br />Team e-leave</td></tr><tr><td align='center'><p style='color:blue;'> This is a system generated response. Please do not respond to this email id.</p></td></tr></table>";
                bool check = SendWebMail(toemail, "Leave Application Notification", mailbody, "", "", "info@hummingsoft.com.my");
                if (check == true)
                {
                    fillleavesfr();
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
                }
                else
                {
                    fillleavesfr();
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "errormail();", true);
                }
            }
            else
            {
                fillleavesfr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
            }

        }

        protected void lnkreject_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            GridViewRow row = lnk.NamingContainer as GridViewRow;
            string rej = ((TextBox)grd_forward.Rows[row.RowIndex].FindControl("txtrejs")).Text.Trim();
            //if (rej != "")
            //{
            int id = int.Parse(grd_forward.DataKeys[row.RowIndex].Value.ToString());
            bus.lid = id;
            bus.userid = int.Parse(Session["user_id"].ToString());
            bus.reason = rej;
            int r = bus.reject_leave();
            if (r == 1)
            {
                mailbody = "<table  border='1' cellpadding='0' cellspacing='0' style='width: 850px; border-color: black;'><tr><td colspan='9'><br>&nbsp &nbspDear " + row.Cells[2].Text.ToString() + ",<br /><br />&nbsp&nbsp&nbsp&nbsp&nbspLeave application submitted by you is <b>Rejected </b> on " + DateTime.Now.ToString("dd/MM/yyyy") + ".</b> The details are as follows.<br /><br /></td></tr><tr style='font-weight: 700;'></tr><tr><td colspan='9'><br/><p></p><p> &nbsp&nbsp&nbspName:   " + row.Cells[2].Text.ToString() + "</p><p>&nbsp&nbsp&nbspDepartment:   " + row.Cells[3].Text.ToString() + "</p><p>&nbsp&nbsp&nbspDesignation:   " + row.Cells[4].Text.ToString() + " </p><p>&nbsp&nbsp&nbspLeave Type:   " + row.Cells[5].Text.ToString() + " </p><p>&nbsp&nbsp&nbspPeriod:   " + row.Cells[7].Text.ToString() + " </p><p>&nbsp&nbsp&nbspReason:   " + row.Cells[8].Text.ToString() + " </p><p>&nbsp&nbsp&nbspclick<a href=" + url2 + "> here </a>to login into the application (UOA)</p><p>&nbsp&nbsp&nbspclick<a href=" + url + "> here </a>to login into the application</p><br/></td></tr><tr></tr><td colspan='9' style='font-weight: bold' align='right'><br /><br />Regards,<br />Team e-leave</td></tr><tr><td align='center'><p style='color:blue;'> This is a system generated response. Please do not respond to this email id.</p></td></tr></table>";
                bool check = SendWebMail(row.Cells[11].Text.ToString(), "Leave Application Notification", mailbody, "", "", "info@hummingsoft.com.my");
                if (check == true)
                {
                    fillleavesfr();
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
                }
                else
                {
                    fillleavesfr();
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "errormail();", true);
                }
            }
            else
            {
                fillleavesfr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
            }            
        }

        protected Boolean Isenable(string ltype)
        {
            if (ltype == "Medical" || ltype== "Hospitalization")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void lnk_dwn_Click(object sender, EventArgs e)
        {

            LinkButton lnkbtn = sender as LinkButton;
            GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
            string medPath = gvrow.Cells[9].Text.ToString();
            string med_path = Server.MapPath(medPath);
            Byte[] buffer = client.DownloadData(med_path);
            if (buffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", buffer.Length.ToString());
                Response.BinaryWrite(buffer);
            }
        }

        protected void grd_forward_PreRender(object sender, EventArgs e)
        {
            if (grd_forward.Rows.Count > 0)
            {
                grd_forward.UseAccessibleHeader = true;
                grd_forward.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void btnrejc_Click(object sender, EventArgs e)
        {
            f = 1;
            foreach (GridViewRow row in grd_forward.Rows)
            {
                cbox = (CheckBox)row.FindControl("chk"); //RowSelector is the id of checkbox in Grid View
                if (cbox.Checked == true)
                {
                    if (txtbreason.Text != "")
                    {
                        // Fetch request's id
                        int RequestId = Convert.ToInt32(grd_forward.DataKeys[row.RowIndex].Value);

                        // Write your approval logic here
                        bus.lid = RequestId;
                        bus.userid = int.Parse(Session["user_id"].ToString());
                        bus.reason = txtbreason.Text.Trim();
                        int r = bus.reject_leave();
                        if (r == 1)
                        {
                            mailbody = "<table  border='1' cellpadding='0' cellspacing='0' style='width: 850px; border-color: black;'><tr><td colspan='9'><br>&nbsp &nbspDear " + row.Cells[2].Text.ToString() + ",<br /><br />&nbsp&nbsp&nbsp&nbsp&nbspLeave application submitted by you is <b>Rejected </b> on " + DateTime.Now.ToString("dd/MM/yyyy") + ".</b> The details are as follows.<br /><br /></td></tr><tr style='font-weight: 700;'></tr><tr><td colspan='9'><br/><p></p><p> &nbsp&nbsp&nbspName:   " + row.Cells[2].Text.ToString() + "</p><p>&nbsp&nbsp&nbspDepartment:   " + row.Cells[3].Text.ToString() + "</p><p>&nbsp&nbsp&nbspDesignation:   " + row.Cells[4].Text.ToString() + " </p><p>&nbsp&nbsp&nbspLeave Type:   " + row.Cells[5].Text.ToString() + " </p><p>&nbsp&nbsp&nbspPeriod:   " + row.Cells[7].Text.ToString() + " </p><p>&nbsp&nbsp&nbspReason:   " + row.Cells[8].Text.ToString() + " </p><p>&nbsp&nbsp&nbspclick<a href=" + url2 + "> here </a>to login into the application (UOA)</p><p>&nbsp&nbsp&nbspclick<a href=" + url + "> here </a>to login into the application</p><br/></td></tr><tr></tr><td colspan='9' style='font-weight: bold' align='right'><br /><br />Regards,<br />Team e-leave</td></tr><tr><td align='center'><p style='color:blue;'> This is a system generated response. Please do not respond to this email id.</p></td></tr></table>";
                            bool check = SendWebMail(row.Cells[11].Text.ToString(), "Leave Application Notification", mailbody, "", "", "info@hummingsoft.com.my");
                            if (check == true)
                            {
                                f = 0;
                            }
                            else
                            {
                                f = 3;
                            }
                        }
                        else
                        {
                            f = 2;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "warning2();", true);
                    }

                }

            }
            if (f == 0)
            {
                fillleavesfr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
            }
            else if (f == 2)
            {
                fillleavesfr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
            }
            else if (f == 3)
            {
                fillleavesfr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "errormail();", true);
            }
            else
            {
                fillleavesfr();
                txtbreason.Text = "";
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
                //SmtpMail.SmtpServer = "192.168.1.4"; // change the ip address to this when hosting in server
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