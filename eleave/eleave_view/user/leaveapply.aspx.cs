using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using eleave_c;
using System.IO;
using System.Web.Mail;


namespace eleave_view.user
{
    public partial class leaveapply : System.Web.UI.Page
    {
        bus_eleave bus = new bus_eleave();
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
                    fill_userdetails();
                    fill_leavetypes();
                    fill_period();
                    fill_collegues();
                    txtdate.Attributes.Add("readonly", "readonly");
                    txtsdate.Attributes.Add("readonly", "readonly");
                    txtedate.Attributes.Add("readonly", "readonly");

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

        [WebMethod]
        public static List<Event> disdates(int userid)
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
        [WebMethod]

        public static int browser_back()
        {
            string p = HttpContext.Current.Request.Url.AbsoluteUri;
            string[] parts = p.Split('/');
            string pagename = parts[parts.Length - 2];
            if (pagename == "leaveapply.aspx")
            {
                leaveapply obj = new leaveapply();
                obj.b_back();
            }
           
            return 1;
        }

        protected void fetch_mail_details()
        {
            toemail = "";
            bus.role = Session["role"].ToString();
            DataTable dt = bus.fetch_mail_details();
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

        public static DataTable fetchdatesmaternity_cochin(int userid)
        {
            bus_eleave bus = new bus_eleave();
            bus.userid = userid;
            DataTable dt = bus.fetch_holidays_cochin();
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


        protected void fill_userdetails()
        {
            bus.userid = int.Parse(Session["user_id"].ToString());
            DataTable dt1 = bus.fetch_details();
            if (dt1.Rows.Count > 0)
            {
                lblname.Text = dt1.Rows[0][0].ToString();
                lbldep.Text = dt1.Rows[0][1].ToString();
                lblpos.Text = dt1.Rows[0][2].ToString();
                txtphone.Text = dt1.Rows[0][3].ToString();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "warning();", true);
            }
        }
        protected void fill_leavetypes()
        {
            bus.userid = int.Parse(Session["user_id"].ToString());
            DataTable dt2 = bus.fetch_leavetypes();
            if (dt2.Rows.Count > 0)
            {
                ddlltype.DataSource = dt2;
                ddlltype.DataBind();
                ddlltype.Items.Insert(0, new ListItem("-----SELECT-----", ""));
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "warning();", true);
            }
        }
        protected void fill_period()
        {
            DataTable dt3 = bus.fetch_period();
            if (dt3.Rows.Count > 0)
            {
                ddlper.DataSource = dt3;
                ddlper.DataBind();
                ddlper.Items.Insert(0, new ListItem("-----SELECT-----", ""));
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "warning();", true);
            }
        }
        protected void fill_collegues()
        {
            bus.userid = int.Parse(Session["user_id"].ToString());
            DataTable dt4 = bus.fetch_collegues();
            if (dt4.Rows.Count > 0)
            {
                ddljobc.DataSource = dt4;
                ddljobc.DataBind();
                ddljobc.Items.Insert(0, new ListItem("-----SELECT-----", ""));
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "warning();", true);
            }
        }

        protected void btnreq_Click(object sender, EventArgs e)
        {
            if (ddlltype.SelectedIndex != 0)
            {
                if (int.Parse(ddlltype.SelectedValue.ToString()) == 2 || int.Parse(ddlltype.SelectedValue.ToString()) == 8) // Medical  or Hospitilization
                {
                    if (fupload.HasFile)
                    {
                        if (fupload.PostedFile.ContentLength < 3145728)
                        {
                            String ext = System.IO.Path.GetExtension(fupload.FileName);
                            if (ext == ".pdf")
                            {
                                if (txtdate.Text != "" && ddlper.SelectedValue.ToString() != "" && txtreason.Text != "" && ddljobc.SelectedValue.ToString() != "" && txtphone.Text != "")
                                {
                                    FileInfo file = new System.IO.FileInfo(fupload.PostedFile.FileName);
                                    string fname = file.Name.Remove((file.Name.Length - file.Extension.Length));
                                    fname = fname + System.DateTime.Now.ToString("_dd-MM-yy_hh;mm;ss") + file.Extension; // renaming file uploads
                                    filename = Path.Combine(HttpContext.Current.Server.MapPath("~/uploads/"), fname);
                                    string filename_vir = Path.Combine("~/uploads/", fname);
                                    bus.userid = int.Parse(Session["user_id"].ToString());
                                    bus.ltype = int.Parse(ddlltype.SelectedValue.ToString());
                                    bus.dates = txtdate.Text.Trim();
                                    bus.period = int.Parse(ddlper.SelectedValue.ToString());
                                    bus.reason = txtreason.Text.Trim();
                                    bus.rdays = getcount();
                                    bus.jobc = ddljobc.SelectedItem.ToString();
                                    bus.contact = txtphone.Text.Trim();
                                    bus.med_path = filename_vir;
                                    // check here the applied leaves exceeds or not (here check only medical)
                                    int r = bus.insert_med();
                                    if (r == 1)
                                    {
                                        fupload.SaveAs(filename);
                                        // send email
                                        fetch_mail_details();
                                        mailbody = "<table  border='1' cellpadding='0' cellspacing='0' style='width: 750px; border-color: black;'><tr><td colspan='9'><br>&nbsp &nbspDear Sir / Madam,<br /><br />&nbsp&nbsp&nbsp&nbsp&nbspLeave application has been submitted by <b>" + Session["name"].ToString() + "</b> on <b>" + DateTime.Now.ToString("dd/MM/yyyy") + ".</b> The details are as follows.<br /><br /></td></tr><tr style='font-weight: 700;'></tr><tr><td colspan='9'><br/><p></p><p> &nbsp&nbsp&nbspName:   " + Session["name"].ToString() + "</p><p>&nbsp&nbsp&nbspDepartment:   " + Session["dep"].ToString() + "</p><p>&nbsp&nbsp&nbspDesignation:   " + Session["des"].ToString() + " </p><p>&nbsp&nbsp&nbspLeave Type:   " + ddlltype.SelectedItem.ToString() + " </p><p>&nbsp&nbsp&nbspPeriod:   " + ddlper.SelectedItem.ToString() + " </p><p>&nbsp&nbsp&nbspReason:   " + txtreason.Text.Trim() + " </p><p>&nbsp&nbsp&nbspclick<a href=" + url2 + "> here </a>to login into the application (UOA)</p><p>&nbsp&nbsp&nbspclick<a href=" + url + "> here </a>to login into the application</p><br/></td></tr><tr></tr><td colspan='9' style='font-weight: bold' align='right'><br /><br />Regards,<br />Team e-leave</td></tr><tr><td align='center'><p style='color:blue;'> This is a system generated response. Please do not respond to this email id.</p></td></tr></table>";
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
                                    clearfeilds();
                                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error1();", true);
                                }

                            }
                            else
                            {
                                clearfeilds2();
                                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "errorpdf();", true);
                                //ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "errorpdf();window.location='" + Request.ApplicationPath + "user/leaves.aspx';", true);
                            }
                        }
                        else
                        {
                            clearfeilds2();
                            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "errorpdfsize();", true);
                        }
                    }
                    else
                    {
                        clearfeilds2();
                        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "errornofile();", true);
                    }
                }
                else if (int.Parse(ddlltype.SelectedValue.ToString()) == 4) // Maternity Leave (Only Women)
                {
                    List<DateTime> holiday = new List<DateTime>();
                    DataTable dt2 = new DataTable();
                    if(int.Parse(Session["region"].ToString()) == 1){
                    dt2 = fetchdatesmaternity(int.Parse(Session["user_id"].ToString()));
                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        holiday.Add(DateTime.Parse(dt2.Rows[i]["dates1"].ToString()));
                    }
                    }
                    else if(int.Parse(Session["region"].ToString()) == 2){
                    dt2 = fetchdatesmaternity_cochin(int.Parse(Session["user_id"].ToString()));
                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        holiday.Add(DateTime.Parse(dt2.Rows[i]["dates1"].ToString()));
                    }
                    }

                    if (txtsdate.Text != "" && txtedate.Text != "" & ddlper.SelectedValue.ToString() != "" && txtreason.Text != "" && ddljobc.SelectedValue.ToString() != "" && txtphone.Text != "")
                    {

                        if (txtsdate.Text != "" && txtedate.Text != "")
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
                                bus.userid = int.Parse(Session["user_id"].ToString());
                                bus.ltype = int.Parse(ddlltype.SelectedValue.ToString());
                                bus.dates = daterange;
                                bus.period = int.Parse(ddlper.SelectedValue.ToString());
                                bus.reason = txtreason.Text.Trim();
                                if (int.Parse(ddlper.SelectedValue.ToString()) == 1)
                                {
                                    bus.rdays = ct;
                                }
                                else
                                {
                                    bus.rdays = ct / 2;
                                }

                                bus.jobc = ddljobc.SelectedItem.ToString();
                                bus.contact = txtphone.Text.Trim();
                                int r1 = bus.insert_leave();
                                if (r1 == 1)
                                {
                                    // send email
                                   fetch_mail_details();
                                   
                                    mailbody = "<table  border='1' cellpadding='0' cellspacing='0' style='width: 750px; border-color: black;'><tr><td colspan='9'><br>&nbsp &nbspDear Sir / Madam,<br /><br />&nbsp&nbsp&nbsp&nbsp&nbspLeave application has been submitted by <b>" + Session["name"].ToString() + "</b> on <b>" + DateTime.Now.ToString("dd/MM/yyyy") + ".</b> The details are as follows.<br /><br /></td></tr><tr style='font-weight: 700;'></tr><tr><td colspan='9'><br/><p></p><p> &nbsp&nbsp&nbspName:   " + Session["name"].ToString() + "</p><p>&nbsp&nbsp&nbspDepartment:   " + Session["dep"].ToString() + "</p><p>&nbsp&nbsp&nbspDesignation:   " + Session["des"].ToString() + " </p><p>&nbsp&nbsp&nbspLeave Type:   " + ddlltype.SelectedItem.ToString() + " </p><p>&nbsp&nbsp&nbspPeriod:   " + ddlper.SelectedItem.ToString() + " </p><p>&nbsp&nbsp&nbspReason:   " + txtreason.Text.Trim() + " </p><p>&nbsp&nbsp&nbspclick<a href=" + url2 + "> here </a>to login into the application (UOA)</p><p>&nbsp&nbsp&nbspclick<a href=" + url + "> here </a>to login into the application</p><br/></td></tr><tr></tr><td colspan='9' style='font-weight: bold' align='right'><br /><br />Regards,<br />Team e-leave</td></tr><tr><td align='center'><p style='color:blue;'> This is a system generated response. Please do not respond to this email id.</p></td></tr></table>";
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
                                else if(r1 ==5)
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
                            clearfeilds();
                            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "errorrange();", true);
                        }
                    }
                    else
                    {
                        clearfeilds();
                        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error1();", true);
                    }
                }
                else if (int.Parse(ddlltype.SelectedValue.ToString()) == 5 || int.Parse(ddlltype.SelectedValue.ToString()) == 6 || int.Parse(ddlltype.SelectedValue.ToString()) == 9) // Unpaid or Compassionate or replacement
                {
                    if (txtdate.Text != "" && ddlper.SelectedIndex != 0 && txtreason.Text != "" && ddljobc.SelectedValue.ToString() != "" && txtphone.Text != "")
                    {
                        bus.userid = int.Parse(Session["user_id"].ToString());
                        bus.ltype = int.Parse(ddlltype.SelectedValue.ToString());
                        bus.dates = txtdate.Text.Trim();
                        bus.period = int.Parse(ddlper.SelectedValue.ToString());
                        bus.reason = txtreason.Text.Trim();
                        bus.rdays = getcount();
                        bus.jobc = ddljobc.SelectedItem.ToString();
                        bus.contact = txtphone.Text.Trim();
                        int r1 = bus.insert_oleave();
                        if (r1 == 1)
                        {
                            // send email
                            fetch_mail_details();
                            mailbody = "<table  border='1' cellpadding='0' cellspacing='0' style='width: 750px; border-color: black;'><tr><td colspan='9'><br>&nbsp &nbspDear Sir / Madam,<br /><br />&nbsp&nbsp&nbsp&nbsp&nbspLeave application has been submitted by <b>" + Session["name"].ToString() + "</b> on <b>" + DateTime.Now.ToString("dd/MM/yyyy") + ".</b> The details are as follows.<br /><br /></td></tr><tr style='font-weight: 700;'></tr><tr><td colspan='9'><br/><p></p><p> &nbsp&nbsp&nbspName:   " + Session["name"].ToString() + "</p><p>&nbsp&nbsp&nbspDepartment:   " + Session["dep"].ToString() + "</p><p>&nbsp&nbsp&nbspDesignation:   " + Session["des"].ToString() + " </p><p>&nbsp&nbsp&nbspLeave Type:   " + ddlltype.SelectedItem.ToString() + " </p><p>&nbsp&nbsp&nbspPeriod:   " + ddlper.SelectedItem.ToString() + " </p><p>&nbsp&nbsp&nbspReason:   " + txtreason.Text.Trim() + " </p><p>&nbsp&nbsp&nbspclick<a href=" + url2 + "> here </a>to login into the application (UOA)</p><p>&nbsp&nbsp&nbspclick<a href=" + url + "> here </a>to login into the application</p><br/></td></tr><tr></tr><td colspan='9' style='font-weight: bold' align='right'><br /><br />Regards,<br />Team e-leave</td></tr><tr><td align='center'><p style='color:blue;'> This is a system generated response. Please do not respond to this email id.</p></td></tr></table>";
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
                    if (txtdate.Text != "" && ddlper.SelectedIndex != 0 && txtreason.Text != "" && ddljobc.SelectedValue.ToString() != "" && txtphone.Text != "")
                    {
                        bus.userid = int.Parse(Session["user_id"].ToString());
                        bus.ltype = int.Parse(ddlltype.SelectedValue.ToString());
                        bus.dates = txtdate.Text.Trim();
                        bus.period = int.Parse(ddlper.SelectedValue.ToString());
                        bus.reason = txtreason.Text.Trim();
                        bus.rdays = getcount();
                        bus.rdays_next = getcount_nxt();
                        bus.jobc = ddljobc.SelectedItem.ToString();
                        bus.contact = txtphone.Text.Trim();
                      
                        // check here the applied leaves exceeds or not (annual, marriage)
                        //int inter = bus.check_avail();
                        //if (inter == 1)
                        //{ 
                        // too many parameters clear sql parameters
                        //    applyleave();
                        //}
                        //else
                        //{
                        //    clearfeilds();
                        //    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "errornotavail();", true);
                        //}
                        int r1 = bus.insert_leave(); // checking and insertion is done in one procedure
                        if (r1 == 1)
                        {
                            // send email
                            fetch_mail_details();
                            mailbody = "<table  border='1' cellpadding='0' cellspacing='0' style='width: 750px; border-color: black;'><tr><td colspan='9'><br>&nbsp &nbspDear Sir / Madam,<br /><br />&nbsp&nbsp&nbsp&nbsp&nbspLeave application has been submitted by <b>" + Session["name"].ToString() + "</b> on <b>" + DateTime.Now.ToString("dd/MM/yyyy") + ".</b> The details are as follows.<br /><br /></td></tr><tr style='font-weight: 700;'></tr><tr><td colspan='9'><br/><p></p><p> &nbsp&nbsp&nbspName:   " + Session["name"].ToString() + "</p><p>&nbsp&nbsp&nbspDepartment:   " + Session["dep"].ToString() + "</p><p>&nbsp&nbsp&nbspDesignation:   " + Session["des"].ToString() + " </p><p>&nbsp&nbsp&nbspLeave Type:   " + ddlltype.SelectedItem.ToString() + " </p><p>&nbsp&nbsp&nbspPeriod:   " + ddlper.SelectedItem.ToString() + " </p><p>&nbsp&nbsp&nbspReason:   " + txtreason.Text.Trim() + " </p><p>&nbsp&nbsp&nbspclick<a href=" + url2 + "> here </a>to login into the application (UOA)</p><p>&nbsp&nbsp&nbspclick<a href=" + url + "> here </a>to login into the application</p><br/></td></tr><tr></tr><td colspan='9' style='font-weight: bold' align='right'><br /><br />Regards,<br />Team e-leave</td></tr><tr><td align='center'><p style='color:blue;'> This is a system generated response. Please do not respond to this email id.</p></td></tr></table>";
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
                        else if(r1 ==2)
                        {
                            clearfeilds();
                            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
                        }
                        else
                        {
                            clearfeilds();
                            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_mandatory_p();", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
            }
        }

        protected double getcount()
        {
            double ct = 0;
            double hf = 0.5;
            double ct1 = 0;
            double ct2 = 0;
            string com = ",";
            string a;
            int year =int.Parse( DateTime.Now.Year.ToString());
            int nxtyear=year+1;
            if (int.Parse(ddlper.SelectedValue.ToString()) == 1 && txtdate.Text.Trim() != "")
            {
                a = txtdate.Text.Trim();
                string[] values = a.Split(',');
                for (int j = 0; j < values.Length; j++)
                {
                    string[] tokens = values[j].Split('-');
                    if (int.Parse(tokens[2]) == nxtyear)
                    {
                        ct1 = ct1 + 1;
                    }
                    if (int.Parse(tokens[2]) == year)
                    {
                        ct = ct + 1;
                    }
                }
            }
               
            else if (int.Parse(ddlper.SelectedValue.ToString()) == 2 && txtdate.Text.Trim() != "")
            {
                a = txtdate.Text.Trim();
                string[] values = a.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    string[] tokens = values[i].Split('-');
                    if (int.Parse(tokens[2]) == nxtyear)
                    {
                        ct1 = ct + hf;
                    }
                    if (int.Parse(tokens[2]) == year)
                    {
                        ct = ct + hf;
                    }
                    
                }
            }
            else
            {
                ct = 0;
            }

            return ct;
        }
        protected double getcount_nxt()
        {
            double ct = 0;
            double hf = 0.5;
            double ct1 = 0;
            double ct2 = 0;
            string com = ",";
            string a;
            int year =int.Parse( DateTime.Now.Year.ToString());
            int nxtyear=year+1;
            if (int.Parse(ddlper.SelectedValue.ToString()) == 1 && txtdate.Text.Trim() != "")
            {
                a = txtdate.Text.Trim();
                string[] values = a.Split(',');
                for (int j = 0; j < values.Length; j++)
                {
                    string[] tokens = values[j].Split('-');
                    if (int.Parse(tokens[2]) == nxtyear)
                    {
                        ct1 = ct1 + 1;
                    }
                    if (int.Parse(tokens[2]) == year)
                    {
                        ct = ct + 1;
                    }
                }
            }
               
            else if (int.Parse(ddlper.SelectedValue.ToString()) == 2 && txtdate.Text.Trim() != "")
            {
                a = txtdate.Text.Trim();
                string[] values = a.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    string[] tokens = values[i].Split('-');
                    if (int.Parse(tokens[2]) == nxtyear)
                    {
                        ct1 = ct + hf;
                    }
                    if (int.Parse(tokens[2]) == year)
                    {
                        ct = ct + hf;
                    }
                    
                }
            }
            else
            {
                ct1 = 0;
            }

            return ct1;
        }
        
        protected void clearfeilds()
        {
            txtreason.Text = "";
            txtphone.Text = "";
            txtdate.Text = "";
            fill_userdetails();
            fill_period();
            fill_leavetypes();
            fill_collegues();
        }

        protected void clearfeilds1()
        {
            txtdate.Text = "";
            ddlltype.SelectedIndex = 0;
        }
        protected void clearfeilds3()
        {
            txtsdate.Text = "";
            txtedate.Text = "";
            txtreason.Text = "";
            txtphone.Text = "";
            fill_userdetails();
            fill_period();
            fill_leavetypes();
            fill_collegues();
        }

        protected void clearfeilds2()
        {
            ddlltype.SelectedIndex = 0;
        }

        public void applyleave()
        {
            bus.userid = int.Parse(Session["user_id"].ToString());
            bus.ltype = int.Parse(ddlltype.SelectedValue.ToString());
            bus.dates = txtdate.Text.Trim();
            bus.period = int.Parse(ddlper.SelectedValue.ToString());
            bus.reason = txtreason.Text.Trim();
            bus.rdays = getcount();
            bus.jobc = ddljobc.SelectedItem.ToString();
            bus.contact = txtphone.Text.Trim();
            int r1 = bus.insert_leave();
            if (r1 == 1)
            {
                clearfeilds();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
            }
            else
            {
                clearfeilds();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
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

        //  start : from here for showing clientside noti for insufficiant leaves
        [WebMethod]

        public static int in_out_maternity(int userid, int typ, int per, string sd, string ed, int region)
        {
            double ct1 = 0.0;
            bus_eleave bus1 = new bus_eleave();
            if(region == 1){
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
            }
            else if(region == 2){
                List<DateTime> holday = new List<DateTime>();
                DataTable dtio = fetchdatesmaternity_cochin(userid);
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

        public static int in_out_others(int userid, int typ, int per, string ds, string thisy, string nexty)
        {
            bus_eleave bus2 = new bus_eleave();
            bus2.userid = userid;
            bus2.ltype = typ;
            bus2.rdays = getc(per, ds);
            if (double.Parse(nexty) > 0.0)
            {
                bus2.nextystatus = 1;
            }
            else
            {
                bus2.nextystatus = 0;
            }
            bus2.nexty = double.Parse(nexty);
            bus2.thisy = double.Parse(thisy);
            int res1 = bus2.check_in_out();
            return res1;
        }

        public static double getc(int per, string ds)
        {
            double ct1 = 0.0;
            double hf1 = 0.5;
            string a1;
            if (per == 1)
            {
                a1 = ds;
                string[] values = a1.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    ct1 = ct1 + 1;
                }
            }
            else if (per == 2)
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

        public static double in_out_maternity_days(int userid, int typ, int per, string sd, string ed, int region)
        {
            double ct1 = 0.0, req = 0.0;
            if (region == 1) // Malaysia
            {
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
            }
            else if (region == 2) //Cochin
            {
                bus_eleave bus1 = new bus_eleave();
                List<DateTime> holday = new List<DateTime>();
                DataTable dtio = fetchdatesmaternity_cochin(userid);
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
            }
            else
            {

            }
            req = ct1;
            return req;

        }

        public void b_back()
        {
            fill_userdetails();
            fill_leavetypes();
            fill_period();
            fill_collegues();
            txtdate.Attributes.Add("readonly", "readonly");
            txtsdate.Attributes.Add("readonly", "readonly");
            txtedate.Attributes.Add("readonly", "readonly");
        }

    }
}