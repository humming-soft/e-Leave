using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using eleave_c;
using System.Web.Services;
using System.Text.RegularExpressions;

namespace eleave_view.hr
{
    public partial class adduser : System.Web.UI.Page
    {
        bus_eleave bus = new bus_eleave();
        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Regex name = new Regex("^[a-zA-Z ]{3,30}$");
        Regex uname = new Regex("^[a-zA-Z0-9_]{3,30}$");
        Match match, namematch, unamematch;
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
                    fillgender();
                    filldep();
                    fillregion();
                    txtdoj.Attributes.Add("readonly", "readonly");
                    txtdob.Attributes.Add("readonly", "readonly");
                    txtcategory.Attributes.Add("readonly", "readonly");

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
        public static List<Event> disdates()
        {
            List<Event> dates = new List<Event>();
            bus_eleave bus = new bus_eleave();
            DataTable dt = bus.fetchdisdates();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Event _holiday = new Event();
                _holiday.EventDate = dt.Rows[i]["dates"].ToString();
                dates.Add(_holiday);
            }
            return dates;
        }

        [WebMethod]
        public static int checkusername(string uname)
        {
            bus_eleave bus = new bus_eleave();
            bus.user_name = uname;
            int ru = bus.checkusername();
            return ru;
        }

        [WebMethod]
        public static int checkemail(string email)
        {
            bus_eleave bus = new bus_eleave();
            bus.email = email;
            int re = bus.checkemail();
            return re;
        }

        protected void fillgender()
        {
            DataTable dtg = bus.fillgender();
            ddlgender.DataSource = dtg;
            ddlgender.DataBind();
            ddlgender.Items.Insert(0, new ListItem("-----SELECT-----", ""));
        }

        protected void filldep()
        {
            DataTable dtdep = bus.filldep();
            ddldep.DataSource = dtdep;
            ddldep.DataBind();
            ddldep.Items.Insert(0, new ListItem("-----SELECT-----", ""));
        }

        protected void fillregion()
        {
            DataTable reg = bus.fillregion();
            ddlregion.DataSource = reg;
            ddlregion.DataBind();
            ddlregion.Items.Insert(0, new ListItem("-----SELECT-----", ""));
        }

        protected void clearfeilds()
        {
            txtname.Text = "";
            txtuname.Text = "";
            txtdoj.Text = "";
            txtemail.Text = "";
            ddlgender.SelectedIndex = 0;
            ddldep.SelectedIndex = 0;
            ddlgrade.SelectedIndex = 0;
            ddldesi.SelectedIndex = 0;
            ddlregion.SelectedIndex = 0;
        }

        [WebMethod]
        public static List<Desi> filldesi(int dep)
        {
            List<Desi> des = new List<Desi>();
            bus_eleave bus = new bus_eleave();
            bus.id = dep;
            DataTable dt = bus.fetchdesignation();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Desi _Desi = new Desi();
                _Desi.dsg_id = int.Parse(dt.Rows[i]["dsg_id"].ToString());
                _Desi.designation = dt.Rows[i]["designation"].ToString();
                des.Add(_Desi);
            }
            return des;
        }

        [WebMethod]
        public static List<grade> fillgrade(int grade)
        {
            List<grade> grd = new List<grade>();
            bus_eleave bus = new bus_eleave();
            bus.id = grade;
            DataTable dt = bus.fetchgrade();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                grade _grade = new grade();
                _grade.grade_id = int.Parse(dt.Rows[i]["grade_id"].ToString());
                _grade.grade_desc = dt.Rows[i]["grade_desc"].ToString();
                _grade.category = dt.Rows[i]["category"].ToString();
                grd.Add(_grade);
            }
            return grd;
        }

        protected void btnuseradd_Click(object sender, EventArgs e)
        {
            if (txtname.Text != "" && txtuname.Text != "" && txtemail.Text != "" && ddlgender.SelectedIndex != 0 && txtdoj.Text != "" && txtdob.Text != "" && ddldep.SelectedIndex != 0 && Request.Form[ddldesi.UniqueID] != null && Request.Form[ddlgrade.UniqueID] != null && ddlregion.SelectedIndex != 0)
            {
                if (txtemail.Text.Trim().Length <= 30)
                {
                    namematch = name.Match(txtname.Text.Trim());
                    if (namematch.Success)
                    {
                        unamematch = uname.Match(txtuname.Text.Trim());
                        if (unamematch.Success)
                        {
                            match = regex.Match(txtemail.Text.Trim());
                            if (match.Success)
                            {
                                bus.name = txtname.Text.Trim();
                                bus.user_name = txtuname.Text.Trim();
                                bus.email = txtemail.Text.Trim();
                                bus.gender = ddlgender.SelectedItem.ToString().Trim();
                                bus.doj = DateTime.Parse(txtdoj.Text.Trim());
                                bus.dob = DateTime.Parse(txtdob.Text.Trim());
                                bus.dep = int.Parse(ddldep.SelectedValue.ToString());
                                bus.desi = int.Parse(Request.Form[ddldesi.UniqueID]);
                                bus.grade = int.Parse(Request.Form[ddlgrade.UniqueID]);
                                bus.region = int.Parse(ddlregion.SelectedValue.ToString());
                                int r = bus.add_user();
                                if (r == 1)
                                {
                                    clearfeilds();
                                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
                                }
                                else if (r == 2)
                                {
                                    clearfeilds();
                                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_dupli();", true);
                                }
                                else if (r == 4)
                                {
                                    clearfeilds();
                                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_dupliemail();", true);
                                }
                                else
                                {
                                    clearfeilds();
                                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
                                }
                            }
                            else
                            {
                                ddldep.SelectedIndex = 0;
                                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "errorinvalid();", true);
                            }// end email regex
                        }
                        else
                        {
                            ddldep.SelectedIndex = 0;
                            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "erroruname();", true);
                        }// end uname regex
                    }
                    else
                    {
                        ddldep.SelectedIndex = 0;
                        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "errorname();", true);
                    } // end name regex
                }
                else
                {
                    ddldep.SelectedIndex = 0;
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "errorlength();", true);
                }// end length email
            }
            else
            {
                clearfeilds();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error1();", true);
            }
        }
    }
}