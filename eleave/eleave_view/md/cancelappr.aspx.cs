using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using eleave_c;
using System.Web.Mail;

namespace eleave_view.md
{
    public partial class cancelappr : System.Web.UI.Page
    {
        bus_eleave bus = new bus_eleave();
        bus_eleave_HS bus2 = new bus_eleave_HS();
        string idate, a, a1, output, period;
        public string toemail, mailbody, url = "http://uoa.hummingsoft.com.my:8065/e_leave/ target=\"_blank\"", url2 = "http://192.168.1.65/e_leave/ target=\"_blank\"";
        DateTime dt1, dt2;
        int chk;
        double ct;
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
                    fillcancapprl();

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

        protected void fillcancapprl()
        {
            DataTable dt = bus.fillcancapprl();
            grdcancelappr.DataSource = dt;
            grdcancelappr.DataBind();
        }

        protected void lnkapprove_Click(object sender, EventArgs e)
        {
            chk = 0;
            ct = 0;
            LinkButton lnk = sender as LinkButton;
            GridViewRow row = lnk.NamingContainer as GridViewRow;
            int id = int.Parse(grdcancelappr.DataKeys[row.RowIndex].Value.ToString());
            a = row.Cells[5].Text.ToString().Trim();
            period = row.Cells[6].Text.ToString().Trim();
            idate = row.Cells[8].Text.ToString().Trim();
            string[] values = a.Split(',');
            DataTable nc = new DataTable();
            nc.Columns.Add("Date", typeof(string));
            for (int i = 0; i < values.Length; i++)
            {
                a1 = values[i].ToString();
                dt1 = DateTime.Parse(a1);
                dt2 = DateTime.Parse(idate);
                if (dt1 < dt2)
                {
                    //can't cancel that leave
                    // get the count of the leaves, update the days requested to these days
                    nc.Rows.Add(a1);
                    ct = ct + 1;
                    chk = 1;
                }
                else
                {
                    // can cancel that leave dont do anything
                }

            }

            if (chk == 0)
            {
                // cancel all leaves
                bus.lid = id;
                int r = bus.cancel_all_approved();
                if (r == 1)
                {
                    // send email
                    fetch_mail_details_hr();
                    mailbody = "<table  border='1' cellpadding='0' cellspacing='0' style='width: 850px; border-color: black;'><tr><td colspan='9'><br>&nbsp &nbspDear " + row.Cells[1].Text.ToString() + ",<br /><br />&nbsp&nbsp&nbsp&nbsp&nbspCancellation of leave submitted by you is <b>Approved </b> on " + DateTime.Now.ToString("dd/MM/yyyy") + ".</b> The details are as follows.<br /><br /></td></tr><tr style='font-weight: 700;'></tr><tr><td colspan='9'><br/><p></p><p> &nbsp&nbsp&nbspName:   " + row.Cells[1].Text.ToString() + "</p><p>&nbsp&nbsp&nbspDepartment:   " + row.Cells[2].Text.ToString() + "</p><p>&nbsp&nbsp&nbspDesignation:   " + row.Cells[3].Text.ToString() + " </p><p>&nbsp&nbsp&nbspLeave Type:   " + row.Cells[4].Text.ToString() + " </p><p>&nbsp&nbsp&nbspPeriod:   " + row.Cells[6].Text.ToString() + " </p><p>&nbsp&nbsp&nbspReason:   " + row.Cells[7].Text.ToString() + " </p><p>&nbsp&nbsp&nbspclick<a href=" + url2 + "> here </a>to login into the application (UOA)</p><p>&nbsp&nbsp&nbspclick<a href=" + url + "> here </a>to login into the application</p><br/></td></tr><tr></tr><td colspan='9' style='font-weight: bold' align='right'><br /><br />Regards,<br />Team e-leave</td></tr><tr><td align='center'><p style='color:blue;'> This is a system generated response. Please do not respond to this email id.</p></td></tr></table>";
                    bool check = SendWebMail(row.Cells[9].Text.ToString(), "Leave Application Notification", mailbody, toemail, "", "info@hummingsoft.com.my");
                    if (check == true)
                    {
                        fillcancapprl();
                        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
                    }
                    else
                    {
                        fillcancapprl();
                        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "warningemail();", true);
                    }
                }
                else
                {
                    fillcancapprl();
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
                }
            }
            else
            {
                // cancel the leaves that are not in datatable and update the dates requested with the dates in datatable and the count

                for (int i = 0; i < nc.Rows.Count; i++)
                {
                    output = output + nc.Rows[i]["Date"].ToString();
                    output += (i < nc.Rows.Count - 1) ? "," : string.Empty;
                }

                bus.lid = id;
                bus.dates = output;
                if (period == "Full Day")
                {
                    bus.rdays = ct;
                }
                else
                {
                    bus.rdays = ct / 2;
                }
                int r = bus.cancel_av_approved();
                if (r == 1)
                {
                    // send email
                    fetch_mail_details_hr();
                    mailbody = "<table  border='1' cellpadding='0' cellspacing='0' style='width: 850px; border-color: black;'><tr><td colspan='9'><br>&nbsp &nbspDear " + row.Cells[1].Text.ToString() + ",<br /><br />&nbsp&nbsp&nbsp&nbsp&nbspCancellation of leave submitted by you is <b>Approved </b> on " + DateTime.Now.ToString("dd/MM/yyyy") + ".</b> The details are as follows.<br /><br /></td></tr><tr style='font-weight: 700;'></tr><tr><td colspan='9'><br/><p></p><p> &nbsp&nbsp&nbspName:   " + row.Cells[1].Text.ToString() + "</p><p>&nbsp&nbsp&nbspDepartment:   " + row.Cells[2].Text.ToString() + "</p><p>&nbsp&nbsp&nbspDesignation:   " + row.Cells[3].Text.ToString() + " </p><p>&nbsp&nbsp&nbspLeave Type:   " + row.Cells[4].Text.ToString() + " </p><p>&nbsp&nbsp&nbspPeriod:   " + row.Cells[6].Text.ToString() + " </p><p>&nbsp&nbsp&nbspReason:   " + row.Cells[7].Text.ToString() + " </p><p>&nbsp&nbsp&nbspclick<a href=" + url2 + "> here </a>to login into the application (UOA)</p><p>&nbsp&nbsp&nbspclick<a href=" + url + "> here </a>to login into the application</p><br/></td></tr><tr></tr><td colspan='9' style='font-weight: bold' align='right'><br /><br />Regards,<br />Team e-leave</td></tr><tr><td align='center'><p style='color:blue;'> This is a system generated response. Please do not respond to this email id.</p></td></tr></table>";
                    bool check = SendWebMail(row.Cells[9].Text.ToString(), "Leave Application Notification", mailbody, toemail, "", "info@hummingsoft.com.my");
                    if (check == true)
                    {
                        fillcancapprl();
                        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
                    }
                    else
                    {
                        fillcancapprl();
                        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "warningemail();", true);
                    }
                }
                else
                {
                    fillcancapprl();
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
                }
            }
        }

        protected void lnkreject_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            GridViewRow row = lnk.NamingContainer as GridViewRow;
            int id = int.Parse(grdcancelappr.DataKeys[row.RowIndex].Value.ToString());
            bus.lid = id;
            int r = bus.reject_can_appr();
            if (r == 1)
            {
                // send email
                mailbody = "<table  border='1' cellpadding='0' cellspacing='0' style='width: 850px; border-color: black;'><tr><td colspan='9'><br>&nbsp &nbspDear " + row.Cells[1].Text.ToString() + ",<br /><br />&nbsp&nbsp&nbsp&nbsp&nbspCancellation of leave submitted by you is <b>Rejected </b> on " + DateTime.Now.ToString("dd/MM/yyyy") + ".</b> The details are as follows.<br /><br /></td></tr><tr style='font-weight: 700;'></tr><tr><td colspan='9'><br/><p></p><p> &nbsp&nbsp&nbspName:   " + row.Cells[1].Text.ToString() + "</p><p>&nbsp&nbsp&nbspDepartment:   " + row.Cells[2].Text.ToString() + "</p><p>&nbsp&nbsp&nbspDesignation:   " + row.Cells[3].Text.ToString() + " </p><p>&nbsp&nbsp&nbspLeave Type:   " + row.Cells[4].Text.ToString() + " </p><p>&nbsp&nbsp&nbspPeriod:   " + row.Cells[6].Text.ToString() + " </p><p>&nbsp&nbsp&nbspReason:   " + row.Cells[7].Text.ToString() + " </p><p>&nbsp&nbsp&nbspclick<a href=" + url2 + "> here </a>to login into the application (UOA)</p><p>&nbsp&nbsp&nbspclick<a href=" + url + "> here </a>to login into the application</p><br/></td></tr><tr></tr><td colspan='9' style='font-weight: bold' align='right'><br /><br />Regards,<br />Team e-leave</td></tr><tr><td align='center'><p style='color:blue;'> This is a system generated response. Please do not respond to this email id.</p></td></tr></table>";
                bool check = SendWebMail(row.Cells[9].Text.ToString(), "Leave Application Notification", mailbody, "", "", "info@hummingsoft.com.my");
                if (check == true)
                {
                    fillcancapprl();
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
                }
                else
                {
                    fillcancapprl();
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "warningemail();", true);
                }
            }
            else
            {
                fillcancapprl();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
            }
        }

        protected void grdcancelappr_PreRender(object sender, EventArgs e)
        {
            if (grdcancelappr.Rows.Count > 0)
            {
                grdcancelappr.UseAccessibleHeader = true;
                grdcancelappr.HeaderRow.TableSection = TableRowSection.TableHeader;
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