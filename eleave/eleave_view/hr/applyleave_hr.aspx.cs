using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eleave_c;
using System.Data;
using System.IO;
using System.Web.Services;
using System.Text.RegularExpressions;
using System.Web.Mail;

namespace eleave_view.hr
{
    public partial class applyleave_hr : System.Web.UI.Page
    {
        bus_eleave obj = new bus_eleave();
        bus_eleave_HS obj1 = new bus_eleave_HS();
        string filename, daterange, toemail, mailbody, url = "http://uoa.hummingsoft.com.my:8065/e_leave/ target=\"_blank\"", url2 = "http://192.168.1.65/e_leave/ target=\"_blank\"";
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
                    fill_lbl_hr();
                    fill_ltype_hr();
                    fill_period_hr();
                    fill_collegues_hr();
                    txtdate_hr.Attributes.Add("readonly", "readonly");
                    txtedate.Attributes.Add("readonly", "readonly");
                    txtsdate.Attributes.Add("readonly", "readonly");

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

        //To get dates. Called by Json
        [WebMethod]
        public static List<Event> disdates_hr(int userid)
        {
            List<Event> dates = new List<Event>();
            bus_eleave bus = new bus_eleave();
            //DataTable dt = bus.fetch_holidays1();
            DataTable dt2 = fetchdates(userid);
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                Event _holiday = new Event();
                _holiday.EventDate = dt2.Rows[i]["dates1"].ToString();
                dates.Add(_holiday);
            }
            return dates;
        }

        public static DataTable fetchdates(int userid)
        {
            bus_eleave bus = new bus_eleave();
            bus.userid = userid;
            DataTable dt = bus.fetch_holidays1();
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("dates1");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string[] split = dt.Rows[i]["dates"].ToString().Split(',');
                for (int j = 0; j < split.Length; j++)
                {
                    DataRow dr = dt1.NewRow();
                    dr["dates1"] = split[j];
                    dt1.Rows.Add(dr);
                }
            }
            return dt1;
        }


        protected void fetch_mail_details_hr_apply()
        {
            toemail = "";
            obj.role = Session["role"].ToString();
            DataTable dt = obj.fetch_mail_details_hr_apply();
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



        // apply leave start lots of checking done, beware while edit (Y)
        protected void btnreq_hr_Click(object sender, EventArgs e)
        {
            //string agaile = ddlltype_hr.SelectedValue.ToString();
            if (ddlltype_hr.SelectedIndex != 0) // serverside validation 
            {
                if (int.Parse(ddlltype_hr.SelectedValue.ToString()) == 2 || int.Parse(ddlltype_hr.SelectedValue.ToString()) == 8)
                {
                    if (fupload_hr.HasFile) // Medical Leave
                    {
                        if (fupload_hr.PostedFile.ContentLength < 3145728)
                        {
                            String ext = System.IO.Path.GetExtension(fupload_hr.FileName);
                            if (ext == ".pdf")
                            {
                                if (txtdate_hr.Text != "" && ddlper_hr.SelectedValue.ToString() != "" && txtreason_hr.Text != "" && ddljobc_hr.SelectedValue.ToString() != "" && txtphone_hr.Text != "")
                                {
                                    FileInfo file = new System.IO.FileInfo(fupload_hr.PostedFile.FileName);
                                    string fname = file.Name.Remove((file.Name.Length - file.Extension.Length));
                                    fname = fname + System.DateTime.Now.ToString("_dd-MM-yy_hh;mm;ss") + file.Extension; // renaming file uploads
                                    filename = Path.Combine(HttpContext.Current.Server.MapPath("~/uploads/"), fname);
                                    string filename_vir = Path.Combine("~/uploads/", fname);
                                    obj.userid = int.Parse(Session["user_id"].ToString());
                                    obj.ltype = int.Parse(ddlltype_hr.SelectedValue.ToString());
                                    obj.dates = txtdate_hr.Text.Trim();
                                    obj.period = int.Parse(ddlper_hr.SelectedValue.ToString());
                                    obj.reason = txtreason_hr.Text.Trim();
                                    obj.rdays = getcount();
                                    obj.jobc = ddljobc_hr.SelectedItem.ToString();
                                    obj.contact = txtphone_hr.Text.Trim();
                                    obj.med_path = filename_vir;
                                    int r = obj.insert_med();
                                    if (r == 1)
                                    {
                                        fupload_hr.SaveAs(filename);
                                        // send email
                                        fetch_mail_details_hr_apply();
                                        mailbody = "<table  border='1' cellpadding='0' cellspacing='0' style='width: 750px; border-color: black;'><tr><td colspan='9'><br>&nbsp &nbspDear Sir / Madam,<br /><br />&nbsp&nbsp&nbsp&nbsp&nbspLeave application has been submitted by <b>" + Session["name"].ToString() + "</b> on <b>" + DateTime.Now.ToString("dd/MM/yyyy") + ".</b> The details are as follows.<br /><br /></td></tr><tr style='font-weight: 700;'></tr><tr><td colspan='9'><br/><p></p><p> &nbsp&nbsp&nbspName:   " + Session["name"].ToString() + "</p><p>&nbsp&nbsp&nbspDepartment:   " + Session["dep"].ToString() + "</p><p>&nbsp&nbsp&nbspDesignation:   " + Session["des"].ToString() + " </p><p>&nbsp&nbsp&nbspLeave Type:   " + ddlltype_hr.SelectedItem.ToString() + " </p><p>&nbsp&nbsp&nbspPeriod:   " + ddlper_hr.SelectedItem.ToString() + " </p><p>&nbsp&nbsp&nbspReason:   " + txtreason_hr.Text.Trim() + " </p><p>&nbsp&nbsp&nbspclick<a href=" + url2 + "> here </a>to login into the application (UOA)</p><p>&nbsp&nbsp&nbspclick<a href=" + url + "> here </a>to login into the application</p><br/></td></tr><tr></tr><td colspan='9' style='font-weight: bold' align='right'><br /><br />Regards,<br />Team e-leave</td></tr><tr><td align='center'><p style='color:blue;'> This is a system generated response. Please do not respond to this email id.</p></td></tr></table>";
                                        bool check = SendWebMail(toemail, "Leave Application Notification", mailbody, "", "", "info@hummingsoft.com.my");
                                        if (check == true)
                                        {
                                            clearfeilds();
                                            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
                                        }
                                        else
                                        {
                                            clearfeilds();
                                            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "errormail();", true);
                                        }
                                    }
                                    else if (r == 2)
                                    {
                                        clearfeilds();
                                        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
                                    }
                                    else
                                    {
                                        clearfeilds1();
                                        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "errornotavail();", true);
                                    }
                                }
                                else
                                {
                                    ddlltype_hr.SelectedIndex = 0;
                                    clearfeilds();
                                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error1();", true);
                                }
                            }
                            else
                            {
                                ddlltype_hr.SelectedIndex = 0;
                                clearfeilds2();
                                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "errorpdf();", true);
                            }
                        }
                        else
                        {
                            ddlltype_hr.SelectedIndex = 0;
                            clearfeilds2();
                            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "errorpdfsize();", true);
                        }
                    }
                    else
                    {
                        ddlltype_hr.SelectedIndex = 0;
                        clearfeilds2();
                        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "errornofile();", true);
                    }
                }
                else if (int.Parse(ddlltype_hr.SelectedValue.ToString()) == 4) // Maternity Leave (Only Women)
                {
                    List<DateTime> holiday = new List<DateTime>();
                    DataTable dt2 = fetchdatesmaternity(int.Parse(Session["user_id"].ToString()));
                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        holiday.Add(DateTime.Parse(dt2.Rows[i]["dates1"].ToString()));
                    }

                    if (txtsdate.Text != "" && txtedate.Text != "" & ddlper_hr.SelectedValue.ToString() != "" && txtreason_hr.Text != "" && ddljobc_hr.SelectedValue.ToString() != "" && txtphone_hr.Text != "")
                    {
                        if (txtsdate.Text != txtedate.Text)
                        {
                            DateTime sd = DateTime.Parse(txtsdate.Text.Trim());
                            DateTime ed = DateTime.Parse(txtedate.Text.Trim());
                            DataTable rc = new DataTable();
                            rc.Columns.Add("Date", typeof(string));
                            while (sd <= ed)
                            {
                                if (holiday.Contains(sd))
                                {
                                    sd = sd.AddDays(1);
                                }
                                else
                                {
                                    //Insert into datatable && get the count
                                    rc.Rows.Add(sd.ToString("dd/MM/yyyy"));
                                    ct = ct + 1;
                                    sd = sd.AddDays(1);
                                }
                            }

                            for (int i = 0; i < rc.Rows.Count; i++)
                            {
                                daterange = daterange + rc.Rows[i]["Date"].ToString();
                                daterange += (i < rc.Rows.Count - 1) ? "," : string.Empty;
                            }

                            // from datatable get the concatenated string

                            string rdate = txtsdate.Text.Trim() + '-' + txtedate.Text.Trim();
                            obj.userid = int.Parse(Session["user_id"].ToString());
                            obj.ltype = int.Parse(ddlltype_hr.SelectedValue.ToString());
                            obj.dates = daterange;
                            obj.period = int.Parse(ddlper_hr.SelectedValue.ToString());
                            obj.reason = txtreason_hr.Text.Trim();
                            if (int.Parse(ddlper_hr.SelectedValue.ToString()) == 1)
                            {
                                obj.rdays = ct;
                            }
                            else
                            {
                                obj.rdays = ct / 2;
                            }

                            obj.jobc = ddljobc_hr.SelectedItem.ToString();
                            obj.contact = txtphone_hr.Text.Trim();
                            int r1 = obj.insert_leave();
                            if (r1 == 1)
                            {
                                // send email
                                fetch_mail_details_hr_apply();
                                mailbody = "<table  border='1' cellpadding='0' cellspacing='0' style='width: 750px; border-color: black;'><tr><td colspan='9'><br>&nbsp &nbspDear Sir / Madam,<br /><br />&nbsp&nbsp&nbsp&nbsp&nbspLeave application has been submitted by <b>" + Session["name"].ToString() + "</b> on <b>" + DateTime.Now.ToString("dd/MM/yyyy") + ".</b> The details are as follows.<br /><br /></td></tr><tr style='font-weight: 700;'></tr><tr><td colspan='9'><br/><p></p><p> &nbsp&nbsp&nbspName:   " + Session["name"].ToString() + "</p><p>&nbsp&nbsp&nbspDepartment:   " + Session["dep"].ToString() + "</p><p>&nbsp&nbsp&nbspDesignation:   " + Session["des"].ToString() + " </p><p>&nbsp&nbsp&nbspLeave Type:   " + ddlltype_hr.SelectedItem.ToString() + " </p><p>&nbsp&nbsp&nbspPeriod:   " + ddlper_hr.SelectedItem.ToString() + " </p><p>&nbsp&nbsp&nbspReason:   " + txtreason_hr.Text.Trim() + " </p><p>&nbsp&nbsp&nbspclick<a href=" + url2 + "> here </a>to login into the application (UOA)</p><p>&nbsp&nbsp&nbspclick<a href=" + url + "> here </a>to login into the application</p><br/></td></tr><tr></tr><td colspan='9' style='font-weight: bold' align='right'><br /><br />Regards,<br />Team e-leave</td></tr><tr><td align='center'><p style='color:blue;'> This is a system generated response. Please do not respond to this email id.</p></td></tr></table>";
                                bool check = SendWebMail(toemail, "Leave Application Notification", mailbody, "", "", "info@hummingsoft.com.my");
                                if (check == true)
                                {
                                    clearfeilds();
                                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
                                }
                                else
                                {
                                    clearfeilds();
                                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "errormail();", true);
                                }
                            }
                            else if( r1 == 3)
                            {
                                   clearfeilds1();
                                   ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "errornotavail();", true);
                            }
                            else if (r1 == 5)
                            {
                                clearfeilds1();
                                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "errormandatory_m();", true);
                            }
                            else
                            {
                                clearfeilds();
                                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
                            }
                        }
                        else
                        {
                            clearfeilds3();
                            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "errorsrange();", true);
                        }
                    }
                    else
                    {
                        ddlltype_hr.SelectedIndex = 0;
                        clearfeilds();
                        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error1();", true);
                    }
                }

                else if (int.Parse(ddlltype_hr.SelectedValue.ToString()) == 5 || int.Parse(ddlltype_hr.SelectedValue.ToString()) == 6 || int.Parse(ddlltype_hr.SelectedValue.ToString()) == 9) // Unpaid or Compassionate or Replcement
                {
                    if (txtdate_hr.Text != "" && ddlper_hr.SelectedIndex != 0 && txtreason_hr.Text != "" && ddljobc_hr.SelectedValue.ToString() != "" && txtphone_hr.Text != "")
                    {
                        obj.userid = int.Parse(Session["user_id"].ToString());
                        obj.ltype = int.Parse(ddlltype_hr.SelectedValue.ToString());
                        obj.dates = txtdate_hr.Text.Trim();
                        obj.period = int.Parse(ddlper_hr.SelectedValue.ToString());
                        obj.reason = txtreason_hr.Text.Trim();
                        obj.rdays = getcount();
                        obj.jobc = ddljobc_hr.SelectedItem.ToString();
                        obj.contact = txtphone_hr.Text.Trim();
                        int r1 = obj.insert_oleave();
                        if (r1 == 1)
                        {
                            // send email
                            fetch_mail_details_hr_apply();
                            mailbody = "<table  border='1' cellpadding='0' cellspacing='0' style='width: 750px; border-color: black;'><tr><td colspan='9'><br>&nbsp &nbspDear Sir / Madam,<br /><br />&nbsp&nbsp&nbsp&nbsp&nbspLeave application has been submitted by <b>" + Session["name"].ToString() + "</b> on <b>" + DateTime.Now.ToString("dd/MM/yyyy") + ".</b> The details are as follows.<br /><br /></td></tr><tr style='font-weight: 700;'></tr><tr><td colspan='9'><br/><p></p><p> &nbsp&nbsp&nbspName:   " + Session["name"].ToString() + "</p><p>&nbsp&nbsp&nbspDepartment:   " + Session["dep"].ToString() + "</p><p>&nbsp&nbsp&nbspDesignation:   " + Session["des"].ToString() + " </p><p>&nbsp&nbsp&nbspLeave Type:   " + ddlltype_hr.SelectedItem.ToString() + " </p><p>&nbsp&nbsp&nbspPeriod:   " + ddlper_hr.SelectedItem.ToString() + " </p><p>&nbsp&nbsp&nbspReason:   " + txtreason_hr.Text.Trim() + " </p><p>&nbsp&nbsp&nbspclick<a href=" + url2 + "> here </a>to login into the application (UOA)</p><p>&nbsp&nbsp&nbspclick<a href=" + url + "> here </a>to login into the application</p><br/></td></tr><tr></tr><td colspan='9' style='font-weight: bold' align='right'><br /><br />Regards,<br />Team e-leave</td></tr><tr><td align='center'><p style='color:blue;'> This is a system generated response. Please do not respond to this email id.</p></td></tr></table>";
                            bool check = SendWebMail(toemail, "Leave Application Notification", mailbody, "", "", "info@hummingsoft.com.my");
                            if (check == true)
                            {
                                clearfeilds();
                                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
                            }
                            else
                            {
                                clearfeilds();
                                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "errormail();", true);
                            }
                        }
                        else
                        {
                            clearfeilds();
                            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
                        }
                    }
                    else
                    {
                        clearfeilds();
                        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error1();", true);
                    }
                }
                else // Marriage, Annual and Paternity
                {
                    if (txtdate_hr.Text != "" && ddlper_hr.SelectedIndex != 0 && txtreason_hr.Text != "" && ddljobc_hr.SelectedValue.ToString() != "" && txtphone_hr.Text != "")
                    {
                        obj.userid = int.Parse(Session["user_id"].ToString());
                        obj.ltype = int.Parse(ddlltype_hr.SelectedValue.ToString());
                        obj.dates = txtdate_hr.Text.Trim();
                        obj.period = int.Parse(ddlper_hr.SelectedValue.ToString());
                        obj.reason = txtreason_hr.Text.Trim();
                        obj.rdays = getcount();
                        obj.jobc = ddljobc_hr.SelectedItem.ToString();
                        obj.contact = txtphone_hr.Text.Trim();

                        int r1 = obj.insert_leave(); // checking and insertion is done in one procedure
                        if (r1 == 1)
                        {
                            // send email
                            fetch_mail_details_hr_apply();
                            mailbody = "<table  border='1' cellpadding='0' cellspacing='0' style='width: 750px; border-color: black;'><tr><td colspan='9'><br>&nbsp &nbspDear Sir / Madam,<br /><br />&nbsp&nbsp&nbsp&nbsp&nbspLeave application has been submitted by <b>" + Session["name"].ToString() + "</b> on <b>" + DateTime.Now.ToString("dd/MM/yyyy") + ".</b> The details are as follows.<br /><br /></td></tr><tr style='font-weight: 700;'></tr><tr><td colspan='9'><br/><p></p><p> &nbsp&nbsp&nbspName:   " + Session["name"].ToString() + "</p><p>&nbsp&nbsp&nbspDepartment:   " + Session["dep"].ToString() + "</p><p>&nbsp&nbsp&nbspDesignation:   " + Session["des"].ToString() + " </p><p>&nbsp&nbsp&nbspLeave Type:   " + ddlltype_hr.SelectedItem.ToString() + " </p><p>&nbsp&nbsp&nbspPeriod:   " + ddlper_hr.SelectedItem.ToString() + " </p><p>&nbsp&nbsp&nbspReason:   " + txtreason_hr.Text.Trim() + " </p><p>&nbsp&nbsp&nbspclick<a href=" + url2 + "> here </a>to login into the application (UOA)</p><p>&nbsp&nbsp&nbspclick<a href=" + url + "> here </a>to login into the application</p><br/></td></tr><tr></tr><td colspan='9' style='font-weight: bold' align='right'><br /><br />Regards,<br />Team e-leave</td></tr><tr><td align='center'><p style='color:blue;'> This is a system generated response. Please do not respond to this email id.</p></td></tr></table>";
                            bool check = SendWebMail(toemail, "Leave Application Notification", mailbody, "", "", "info@hummingsoft.com.my");
                            if (check == true)
                            {
                                clearfeilds();
                                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
                            }
                            else
                            {
                                clearfeilds();
                                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "errormail();", true);
                            }
                        }
                        else if (r1 == 3)
                        {
                            clearfeilds1();
                            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "errornotavail();", true);
                        }

                        else if(r1 == 2)
                        {
                            clearfeilds();
                            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
                        }
                        else
                        {
                            clearfeilds();
                            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "errormandatory_p();", true);
                        }
                    }
                    else
                    {
                        clearfeilds();
                        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error1();", true);
                    }
                }
            }
            else
            {

                clearfeilds();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error1();", true);
            }
        }

        //To clear the feilds
        protected void clearfeilds()
        {
            txtreason_hr.Text = "";
            txtphone_hr.Text = "";
            txtdate_hr.Text = "";
            fill_lbl_hr();
            fill_ltype_hr();
            fill_period_hr();
            fill_collegues_hr();
        }

        protected void clearfeilds1()
        {
            ddlltype_hr.SelectedIndex = 0;
            txtdate_hr.Text = "";
        }

        protected void clearfeilds2()
        {
            ddlltype_hr.SelectedIndex = 0;
        }

        protected void clearfeilds3()
        {
            txtsdate.Text = "";
            txtedate.Text = "";
            txtreason_hr.Text = "";
            txtphone_hr.Text = "";
            fill_lbl_hr();
            fill_ltype_hr();
            fill_period_hr();
            fill_collegues_hr();
        }

        //To get the no: of days selected
        protected double getcount()
        {
            double ct = 0;
            double hf = 0.5;
            string a;
            if (int.Parse(ddlper_hr.SelectedValue.ToString()) == 1 && txtdate_hr.Text.Trim() != "")
            {
                a = txtdate_hr.Text.Trim();
                string[] values = a.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    ct = ct + 1;
                }
            }
            else if (int.Parse(ddlper_hr.SelectedValue.ToString()) == 2 && txtdate_hr.Text.Trim() != "")
            {
                a = txtdate_hr.Text.Trim();
                string[] values = a.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    ct = ct + hf;
                }
            }
            else
            {
                ct = 0;
            }
            return ct;
        }

        public static DataTable fetchdatesmaternity(int userid)
        {
            bus_eleave bus = new bus_eleave();
            bus.userid = userid;
            DataTable dt = bus.fetch_holidaysma();
            DataTable dtma = new DataTable();
            dtma.Columns.Add("dates1");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string[] split = dt.Rows[i]["dates"].ToString().Split(',');
                for (int j = 0; j < split.Length; j++)
                {
                    DataRow dr = dtma.NewRow();
                    dr["dates1"] = split[j];
                    dtma.Rows.Add(dr);
                }
            }
            return dtma;
        }

        //To bind label with Name, Department and Position
        protected void fill_lbl_hr()
        {
            obj.userid = int.Parse(Session["user_id"].ToString());
            DataTable dt1 = obj.fetch_details();
            if (dt1.Rows.Count > 0)
            {
                lblname_hr.Text = dt1.Rows[0][0].ToString();
                lbldep_hr.Text = dt1.Rows[0][1].ToString();
                lblpos_hr.Text = dt1.Rows[0][2].ToString();
                txtphone_hr.Text = dt1.Rows[0][3].ToString();
            }
            else
            {

            }
        }

        //To fill Leave Type DropDownList
        protected void fill_ltype_hr()
        {
            obj.userid = int.Parse(Session["user_id"].ToString());
            DataTable dt1 = obj.fetch_leavetypes();
            if (dt1.Rows.Count > 0)
            {
                ddlltype_hr.DataSource = dt1;
                ddlltype_hr.DataBind();
                ddlltype_hr.Items.Insert(0, new ListItem("-----SELECT-----", ""));
            }
            else
            {

            }
        }

        //To fill Period DropDownList
        protected void fill_period_hr()
        {
            DataTable dt1 = obj.fetch_period();
            if (dt1.Rows.Count > 0)
            {
                ddlper_hr.DataSource = dt1;
                ddlper_hr.DataBind();
                ddlper_hr.Items.Insert(0, new ListItem("-----SELECT-----", ""));
            }
            else
            {

            }
        }

        //To fill Covered By DropDownList
        protected void fill_collegues_hr()
        {
            obj1.userid = int.Parse(Session["user_id"].ToString());
            DataTable dt1 = obj1.fetch_collegues();
            if (dt1.Rows.Count > 0)
            {
                ddljobc_hr.DataSource = dt1;
                ddljobc_hr.DataBind();
                ddljobc_hr.Items.Insert(0, new ListItem("-----SELECT-----", ""));
            }
            else
            {

            }
        }

        [WebMethod]

        public static int countchk(int userid, int type, string dates)
        {
            return 1;
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

        //  start : from here for showing clientside noti for insufficiant leaves
        [WebMethod]

        public static int in_out_maternity(int userid, int typ,int per, string sd, string ed)
        {
            double ct1 = 0.0;
            bus_eleave bus1 = new bus_eleave();
            List<DateTime> holday = new List<DateTime>();
            DataTable dtio = fetchdatesmaternity(userid);
            for (int i = 0; i < dtio.Rows.Count; i++)
            {
                holday.Add(DateTime.Parse(dtio.Rows[i]["dates1"].ToString()));
            }

            DateTime sd1 = DateTime.Parse(sd);
            DateTime ed1 = DateTime.Parse(ed);
            while (sd1 <= ed1)
            {
                if (holday.Contains(sd1))
                {
                    sd1 = sd1.AddDays(1);
                }
                else
                {
                    // get the count
                    ct1 = ct1 + 1;
                    sd1 = sd1.AddDays(1);
                }
            }

            bus1.userid = userid;
            bus1.ltype = typ;
            if (per == 1)
            {
                bus1.rdays = ct1;
            }
            else
            {
                bus1.rdays = ct1 / 2;
            }

            int res = bus1.check_in_out();
            return res;

        }

        [WebMethod]

        public static int in_out_others(int userid, int typ,int per, string ds)
        {
            bus_eleave bus2 = new bus_eleave();
            bus2.userid = userid;
            bus2.ltype = typ;
            bus2.rdays = getc(per,ds);
            int res1 = bus2.check_in_out();
            return res1;
        }

        public static double getc(int per ,string ds)
        {
            double ct1 = 0.0;
            double hf1 = 0.5;
            string a1;
            if (per == 1 )
            {
                a1 = ds;
                string[] values = a1.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    ct1 = ct1 + 1;
                }
            }
            else if (per == 2 )
            {
                a1 = ds;
                string[] values = a1.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    ct1 = ct1 + hf1;
                }
            }
            else
            {
                ct1 = 0;
            }
            return ct1;
        }
        // end : from here for showing clientside noti for insufficiant leaves


        [WebMethod]

        public static double in_out_maternity_days(int userid, int typ, int per, string sd, string ed)
        {
            double ct1 = 0.0, req=0.0;
            bus_eleave bus1 = new bus_eleave();
            List<DateTime> holday = new List<DateTime>();
            DataTable dtio = fetchdatesmaternity(userid);
            for (int i = 0; i < dtio.Rows.Count; i++)
            {
                holday.Add(DateTime.Parse(dtio.Rows[i]["dates1"].ToString()));
            }

            DateTime sd1 = DateTime.Parse(sd);
            DateTime ed1 = DateTime.Parse(ed);
            while (sd1 <= ed1)
            {
                if (holday.Contains(sd1))
                {
                    sd1 = sd1.AddDays(1);
                }
                else
                {
                    // get the count
                    ct1 = ct1 + 1;
                    sd1 = sd1.AddDays(1);
                }
            }
            req = ct1;
            return req;

        }


    }
}