using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using eleave_c;

namespace eleave_view.hr
{
    public partial class holidays_upload : System.Web.UI.Page
    {
        bus_eleave bus = new bus_eleave();
        datamapper datamapper = new datamapper();
        int CHK_NULL, CHK_EF;
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
                else
                {
                    fill_region();
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void fill_region()
        {
            DataTable dt1 = bus.fillregion();
            if (dt1.Rows.Count > 0)
            {
                ddlreg.DataSource = dt1;
                ddlreg.DataBind();
                ddlreg.Items.Insert(0, new ListItem("-----SELECT-----", ""));
            }
            else
            {

            }
        }


        protected void btnreq_hr_Click(object sender, EventArgs e)
        {
            if (ddlreg.SelectedIndex != 0 && txtholidays_hr.Text != "")
            {
                if (ddlreg.SelectedItem.Text == "Cochin")
                {

                    CHK_NULL = 0;
                    CHK_EF = 0;
                    DateTime dt;
                    DataTable a = datamapper.GetDataTable(txtholidays_hr.Text, true);
                    if (a.Rows.Count > 0)
                    {
                        for (int i = 0; i < a.Rows.Count; i++)
                        {
                            if (a.Rows[i][0].ToString().Trim() == "")
                            {
                                CHK_NULL = 1;
                                break;
                            }
                            else
                            {
                                bus.event_name = a.Rows[i][0].ToString();
                            }
                            if (a.Rows[i][1].ToString().Trim() == "")
                            {
                                CHK_NULL = 1;
                                break;
                            }
                            else
                            {
                                //bus.event_date = DateTime.Parse(a.Rows[i][1].ToString());
                                bool success = DateTime.TryParseExact(a.Rows[i][1].ToString(), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt);
                                if (success)
                                {
                                    bus.event_date = dt;
                                }
                                else
                                {
                                    CHK_EF = 1;
                                }

                            }
                            //if (a.Rows[i][2].ToString().Trim() == "")
                            //{
                            //    CHK_NULL = 1;
                            //    break;
                            //}
                            //else
                            //{
                            //    bus.event_color = a.Rows[i][2].ToString();

                            //}


                        }
                        if (CHK_NULL == 0 && CHK_EF == 0)
                        {
                            int count = 0;
                            int countd = 0;
                            int counts = 0;

                            for (int i = 0; i < a.Rows.Count; i++)
                            {

                                bus.event_name = a.Rows[i][0].ToString();
                                bus.event_date = DateTime.Parse(a.Rows[i][1].ToString());
                                //bus.event_date = DateTime.ParseExact(a.Rows[i][1].ToString().Trim(), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                                bus.event_color = "#ff3232";
                                int r = bus.upload_holidays();
                                if (r == 1)
                                {
                                    countd++;
                                    //lblsuccesfulmsg.Text = +countd + " Record(s) inserted Succesfully ";
                                }
                                else if (r == 2)
                                {
                                    counts++;
                                    count = counts - countd;
                                    //lblduplicatemsg.Text = "There are " + count + " Duplicated Value(s)";
                                }
                                else
                                {

                                }
                            }
                            addSatSun_C();
                            txtholidays_hr.Text = "";
                            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
                        }
                        else
                        {
                            txtholidays_hr.Text = "";
                            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
                        }
                    }
                }
                else
                {
                    CHK_NULL = 0;
                    CHK_EF = 0;
                    DateTime dt;
                    DataTable a = datamapper.GetDataTable(txtholidays_hr.Text, true);
                    if (a.Rows.Count > 0)
                    {
                        for (int i = 0; i < a.Rows.Count; i++)
                        {
                            if (a.Rows[i][0].ToString().Trim() == "")
                            {
                                CHK_NULL = 1;
                                break;
                            }
                            else
                            {
                                bus.event_name = a.Rows[i][0].ToString();
                            }
                            if (a.Rows[i][1].ToString().Trim() == "")
                            {
                                CHK_NULL = 1;
                                break;
                            }
                            else
                            {
                                //bus.event_date = DateTime.Parse(a.Rows[i][1].ToString());
                                bool success = DateTime.TryParseExact(a.Rows[i][1].ToString(), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt);
                                if (success)
                                {
                                    bus.event_date = dt;
                                }
                                else
                                {
                                    CHK_EF = 1;
                                }

                            }
                            //if (a.Rows[i][2].ToString().Trim() == "")
                            //{
                            //    CHK_NULL = 1;
                            //    break;
                            //}
                            //else
                            //{
                            //    bus.event_color = a.Rows[i][2].ToString();

                            //}


                        }
                        if (CHK_NULL == 0 && CHK_EF == 0)
                        {
                            int count = 0;
                            int countd = 0;
                            int counts = 0;

                            for (int i = 0; i < a.Rows.Count; i++)
                            {

                                bus.event_name = a.Rows[i][0].ToString();
                                bus.event_date = DateTime.Parse(a.Rows[i][1].ToString());
                                //bus.event_date = DateTime.ParseExact(a.Rows[i][1].ToString().Trim(), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                                bus.event_color = "#ff3232";
                                int r = bus.upload_holidays_malaysia();
                                if (r == 1)
                                {
                                    countd++;
                                    //lblsuccesfulmsg.Text = +countd + " Record(s) inserted Succesfully ";
                                }
                                else if (r == 2)
                                {
                                    counts++;
                                    count = counts - countd;
                                    //lblduplicatemsg.Text = "There are " + count + " Duplicated Value(s)";
                                }
                                else
                                {

                                }
                            }
                            addSatSun_M();
                            txtholidays_hr.Text = "";
                            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
                        }
                        else
                        {
                            txtholidays_hr.Text = "";
                            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
                        }
                    }

                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "errornoval();", true);
            }
        }

        protected void addSatSun_M()
        {
            int year = int.Parse(DateTime.Now.Year.ToString());
            DateTime Date = new DateTime(year, 1, 1);
            while (Date.Year == year)
            {
                if (Date.DayOfWeek == DayOfWeek.Saturday)
                {
                    bus.event_name = "Saturday";
                    bus.event_date = Date;
                    bus.event_color = "#35aa47";
                }
                else if (Date.DayOfWeek == DayOfWeek.Sunday)
                {
                    bus.event_name = "Sunday";
                    bus.event_date = Date;
                    bus.event_color = "#35aa47";
                }
                int r = bus.upload_holidays_malaysia();
                Date = Date.AddDays(1);
            }
        }

        protected void addSatSun_C()
        {
            int year = int.Parse(DateTime.Now.Year.ToString());
            DateTime Date = new DateTime(year, 1, 1);
            while (Date.Year == year)
            {
                if (Date.DayOfWeek == DayOfWeek.Saturday)
                {
                    bus.event_name = "Saturday";
                    bus.event_date = Date;
                    bus.event_color = "#35aa47";
                }
                else if (Date.DayOfWeek == DayOfWeek.Sunday)
                {
                    bus.event_name = "Sunday";
                    bus.event_date = Date;
                    bus.event_color = "#35aa47";
                }
                int r = bus.upload_holidays();
                Date = Date.AddDays(1);
            }
        }
    }
}