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

namespace eleave_view.md
{
    public partial class app_rej : System.Web.UI.Page
    {
        bus_eleave bus = new bus_eleave();
        bus_eleave_HS bus2 = new bus_eleave_HS();
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
                    fillleavesapr();

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

        protected void fillleavesapr()
        {
            DataTable dt = bus.fillleavesapr();
            if (dt.Rows.Count > 0)
            {
                grd_app_rej.DataSource = dt;
                grd_app_rej.DataBind();
            }
            else
            {
                grd_app_rej.DataSource = null;
                grd_app_rej.DataBind();
                btnaccept.Visible = false;
                btnreject.Visible = false;
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
            string filePath = gvrow.Cells[9].Text.ToString();
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

        protected void grd_app_rej_PreRender(object sender, EventArgs e)
        {
            if (grd_app_rej.Rows.Count > 0)
            {
                grd_app_rej.UseAccessibleHeader = true;
                grd_app_rej.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void lnkforward_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            GridViewRow row = lnk.NamingContainer as GridViewRow;
            int id = int.Parse(grd_app_rej.DataKeys[row.RowIndex].Value.ToString());
            bus.lid = id;
            bus.userid = int.Parse(Session["user_id"].ToString());
            int r = bus.approve_leave();
            if (r == 1)
            {
                fetch_mail_details_hr();
                mailbody = "<table  border='1' cellpadding='0' cellspacing='0' style='width: 850px; border-color: black;'><tr><td colspan='9'><br>&nbsp &nbspDear " + row.Cells[2].Text.ToString() + ",<br /><br />&nbsp&nbsp&nbsp&nbsp&nbspLeave application submitted by you is <b>Approved </b> on " + DateTime.Now.ToString("dd/MM/yyyy") + ".</b> The details are as follows.<br /><br /></td></tr><tr style='font-weight: 700;'></tr><tr><td colspan='9'><br/><p></p><p> &nbsp&nbsp&nbspName:   " + row.Cells[2].Text.ToString() + "</p><p>&nbsp&nbsp&nbspDepartment:   " + row.Cells[3].Text.ToString() + "</p><p>&nbsp&nbsp&nbspDesignation:   " + row.Cells[4].Text.ToString() + " </p><p>&nbsp&nbsp&nbspLeave Type:   " + row.Cells[5].Text.ToString() + " </p><p>&nbsp&nbsp&nbspPeriod:   " + row.Cells[7].Text.ToString() + " </p><p>&nbsp&nbsp&nbspReason:   " + row.Cells[8].Text.ToString() + " </p><p>&nbsp&nbsp&nbspclick<a href=" + url2 + "> here </a>to login into the application (UOA)</p><p>&nbsp&nbsp&nbspclick<a href=" + url + "> here </a>to login into the application</p><br/></td></tr><tr></tr><td colspan='9' style='font-weight: bold' align='right'><br /><br />Regards,<br />Team e-leave</td></tr><tr><td align='center'><p style='color:blue;'> This is a system generated response. Please do not respond to this email id.</p></td></tr></table>";
                bool check = SendWebMail(row.Cells[11].Text.ToString(), "Leave Application Notification", mailbody, toemail, "", "info@hummingsoft.com.my");
                if (check == true)
                {
                    fillleavesapr();
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
                }
                else
                {
                    fillleavesapr();
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "warningemail();", true);
                }
            }
            else
            {
                fillleavesapr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
            }
        }

        protected void lnkreject_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            GridViewRow row = lnk.NamingContainer as GridViewRow;
            string rej = ((TextBox)grd_app_rej.Rows[row.RowIndex].FindControl("txtrejs")).Text.Trim();
            int id = int.Parse(grd_app_rej.DataKeys[row.RowIndex].Value.ToString());
            bus.lid = id;
            bus.userid = int.Parse(Session["user_id"].ToString());
            bus.reason = rej;
            int r = bus.reject_leave_md();
            if (r == 1)
            {
                mailbody = "<table  border='1' cellpadding='0' cellspacing='0' style='width: 850px; border-color: black;'><tr><td colspan='9'><br>&nbsp &nbspDear " + row.Cells[2].Text.ToString() + ",<br /><br />&nbsp&nbsp&nbsp&nbsp&nbspLeave application submitted by you is <b>Rejected </b> on " + DateTime.Now.ToString("dd/MM/yyyy") + ".</b> The details are as follows.<br /><br /></td></tr><tr style='font-weight: 700;'></tr><tr><td colspan='9'><br/><p></p><p> &nbsp&nbsp&nbspName:   " + row.Cells[2].Text.ToString() + "</p><p>&nbsp&nbsp&nbspDepartment:   " + row.Cells[3].Text.ToString() + "</p><p>&nbsp&nbsp&nbspDesignation:   " + row.Cells[4].Text.ToString() + " </p><p>&nbsp&nbsp&nbspLeave Type:   " + row.Cells[5].Text.ToString() + " </p><p>&nbsp&nbsp&nbspPeriod:   " + row.Cells[7].Text.ToString() + " </p><p>&nbsp&nbsp&nbspReason:   " + row.Cells[8].Text.ToString() + " </p><p>&nbsp&nbsp&nbspclick<a href=" + url2 + "> here </a>to login into the application (UOA)</p><p>&nbsp&nbsp&nbspclick<a href=" + url + "> here </a>to login into the application</p><br/></td></tr><tr></tr><td colspan='9' style='font-weight: bold' align='right'><br /><br />Regards,<br />Team e-leave</td></tr><tr><td align='center'><p style='color:blue;'> This is a system generated response. Please do not respond to this email id.</p></td></tr></table>";
                bool check = SendWebMail(row.Cells[11].Text.ToString(), "Leave Application Notification", mailbody, "", "", "info@hummingsoft.com.my");
                if (check == true)
                {
                    fillleavesapr();
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
                }
                else
                {
                    fillleavesapr();
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "warningemail();", true);
                }
            }
            else
            {
                fillleavesapr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
            }
        }

        protected void btnaccept_Click(object sender, EventArgs e)
        {
            f = 1;
            foreach (GridViewRow row in grd_app_rej.Rows)
            {
                cbox = (CheckBox)row.FindControl("chk"); //RowSelector is the id of checkbox in Grid View
                if (cbox.Checked == true)
                {
                    // Fetch request's id
                    int RequestId = Convert.ToInt32(grd_app_rej.DataKeys[row.RowIndex].Value);

                    // Write your approval logic here
                    bus.lid = RequestId;
                    bus.userid = int.Parse(Session["user_id"].ToString());
                    int r = bus.approve_leave();
                    if (r == 1)
                    {
                        fetch_mail_details_hr();
                        mailbody = "<table  border='1' cellpadding='0' cellspacing='0' style='width: 850px; border-color: black;'><tr><td colspan='9'><br>&nbsp &nbspDear " + row.Cells[2].Text.ToString() + ",<br /><br />&nbsp&nbsp&nbsp&nbsp&nbspLeave application submitted by you is <b>Approved </b> on " + DateTime.Now.ToString("dd/MM/yyyy") + ".</b> The details are as follows.<br /><br /></td></tr><tr style='font-weight: 700;'></tr><tr><td colspan='9'><br/><p></p><p> &nbsp&nbsp&nbspName:   " + row.Cells[2].Text.ToString() + "</p><p>&nbsp&nbsp&nbspDepartment:   " + row.Cells[3].Text.ToString() + "</p><p>&nbsp&nbsp&nbspDesignation:   " + row.Cells[4].Text.ToString() + " </p><p>&nbsp&nbsp&nbspLeave Type:   " + row.Cells[5].Text.ToString() + " </p><p>&nbsp&nbsp&nbspPeriod:   " + row.Cells[7].Text.ToString() + " </p><p>&nbsp&nbsp&nbspReason:   " + row.Cells[8].Text.ToString() + " </p><p>&nbsp&nbsp&nbspclick<a href=" + url2 + "> here </a>to login into the application (UOA)</p><p>&nbsp&nbsp&nbspclick<a href=" + url + "> here </a>to login into the application</p><br/></td></tr><tr></tr><td colspan='9' style='font-weight: bold' align='right'><br /><br />Regards,<br />Team e-leave</td></tr><tr><td align='center'><p style='color:blue;'> This is a system generated response. Please do not respond to this email id.</p></td></tr></table>";
                        bool check = SendWebMail(row.Cells[11].Text.ToString(), "Leave Application Notification", mailbody, toemail, "", "info@hummingsoft.com.my");
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
                fillleavesapr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
            }
            else if (f == 2)
            {
                fillleavesapr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
            }
            else if (f == 3)
            {
                fillleavesapr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "warningemail();", true);
            }
            else
            {
                fillleavesapr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "warning();", true);
            }
        }

        protected void btnreject_Click(object sender, EventArgs e)
        {
            //f = 1;
            //foreach (GridViewRow row in grd_app_rej.Rows)
            //{
            //    cbox = (CheckBox)row.FindControl("chk"); //RowSelector is the id of checkbox in Grid View
            //    if (cbox.Checked == true)
            //    {
            //        if (txtbreason.Text != "")
            //        {
            //            // Fetch request's id
            //            int RequestId = Convert.ToInt32(grd_app_rej.DataKeys[row.RowIndex].Value);

            //            // Write your approval logic here
            //            bus.lid = RequestId;
            //            bus.reason = txtbreason.Text.Trim();
            //            int r = bus.reject_leave_md();
            //            if (r == 1)
            //            {
            //                f = 0;
            //            }
            //            else
            //            {
            //                f = 2;
            //            }
            //        }
            //        else
            //        {
            //            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "warning2();", true);
            //        }

            //    }

            //}
            //if (f == 0)
            //{
            //    fillleavesapr();
            //    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
            //}
            //else if (f == 2)
            //{
            //    fillleavesapr();
            //    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
            //}
            //else
            //{
            //    fillleavesapr();
            //    txtbreason.Text = "";
            //    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "warning();", true);
            //}
        }

        protected void btnrejc_Click(object sender, EventArgs e)
        {
            f = 1;
            foreach (GridViewRow row in grd_app_rej.Rows)
            {
                cbox = (CheckBox)row.FindControl("chk"); //RowSelector is the id of checkbox in Grid View
                if (cbox.Checked == true)
                {
                    if (txtbreason.Text != "")
                    {
                        // Fetch request's id
                        int RequestId = Convert.ToInt32(grd_app_rej.DataKeys[row.RowIndex].Value);

                        // Write your approval logic here
                        bus.lid = RequestId;
                        bus.userid = int.Parse(Session["user_id"].ToString());
                        bus.reason = txtbreason.Text.Trim();
                        int r = bus.reject_leave_md();
                        if (r == 1)
                        {
                            mailbody = "<table  border='1' cellpadding='0' cellspacing='0' style='width: 850px; border-color: black;'><tr><td colspan='9'><br>&nbsp &nbspDear " + row.Cells[2].Text.ToString() + ",<br /><br />&nbsp&nbsp&nbsp&nbsp&nbspLeave application submitted by you is <b>Rejected </b> on " + DateTime.Now.ToString("dd/MM/yyyy") + ".</b>The details are as follows.<br /><br /></td></tr><tr style='font-weight: 700;'></tr><tr><td colspan='9'><br/><p></p><p> &nbsp&nbsp&nbspName:   " + row.Cells[2].Text.ToString() + "</p><p>&nbsp&nbsp&nbspDepartment:   " + row.Cells[3].Text.ToString() + "</p><p>&nbsp&nbsp&nbspDesignation:   " + row.Cells[4].Text.ToString() + " </p><p>&nbsp&nbsp&nbspLeave Type:   " + row.Cells[5].Text.ToString() + " </p><p>&nbsp&nbsp&nbspPeriod:   " + row.Cells[7].Text.ToString() + " </p><p>&nbsp&nbsp&nbspReason:   " + row.Cells[8].Text.ToString() + " </p><p>&nbsp&nbsp&nbspclick<a href=" + url2 + "> here </a>to login into the application (UOA)</p><p>&nbsp&nbsp&nbspclick<a href=" + url + "> here </a>to login into the application</p><br/></td></tr><tr></tr><td colspan='9' style='font-weight: bold' align='right'><br /><br />Regards,<br />Team e-leave</td></tr><tr><td align='center'><p style='color:blue;'> This is a system generated response. Please do not respond to this email id.</p></td></tr></table>";
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
                fillleavesapr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
            }
            else if (f == 2)
            {
                fillleavesapr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
            }
            else if( f == 3)
            {
                fillleavesapr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "warningemail();", true);
            }
            else
            {
                fillleavesapr();
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

        //Fetching HR mail address for setting the CC while accepting the mail by MD/ED
        protected void fetch_mail_details_hr()
        {
            toemail = "";
            //bus2.role = Session["role"].ToString();
            DataTable dt = bus2.fetch_mail_details_hr();
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
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "warning_fetch();", true);
            }
        }
    }
}