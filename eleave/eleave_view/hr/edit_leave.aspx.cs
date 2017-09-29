using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eleave_c;
using System.Data;
using System.Web.Services;

namespace eleave_view.hr
{
    public partial class edit_leave : System.Web.UI.Page
    {
        bus_eleave obj = new bus_eleave();
        bus_eleave_HS obj1 = new bus_eleave_HS();
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
                    fill_period_hr();
                    fill_collegues_hr();
                    fill_ldetails();
                    txtdate_hr_edit.Attributes.Add("readonly", "readonly");
                    txtedate_edit.Attributes.Add("readonly", "readonly");
                    txtsdate_edit.Attributes.Add("readonly", "readonly");

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

        protected void fill_ldetails()
        {
            obj.lid = int.Parse(Session["eleave_id"].ToString());
            DataTable ld = obj.fill_ldetails();
            if (ld.Rows.Count > 0)
            {
                //string agaile = ld.Rows[0][0].ToString();
                if (ld.Rows[0][0].ToString() != "Maternity")
                {
                    lblltype_hr.Text = ld.Rows[0][0].ToString();
                    txtdate_hr_edit.Text = ld.Rows[0][1].ToString();
                    ddlper_hr.Items.FindByText(ld.Rows[0][2].ToString()).Selected = true;
                    ddljobc_hr.Items.FindByText(ld.Rows[0][3].ToString()).Selected = true;
                    txtreason_hr.Text = ld.Rows[0][4].ToString();
                }
                else
                {
                    string splitted = ld.Rows[0][1].ToString();
                    txtsdate_edit.Text = splitted.Split(',').First();
                    txtedate_edit.Text = splitted.Split(',').Last();
                    lblltype_hr.Text = ld.Rows[0][0].ToString();
                    ddlper_hr.Items.FindByText(ld.Rows[0][2].ToString()).Selected = true;
                    ddljobc_hr.Items.FindByText(ld.Rows[0][3].ToString()).Selected = true;
                    txtreason_hr.Text = ld.Rows[0][4].ToString();
                }
                
            }
            else
            {

            }

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

        public static string fetch_details(int eleave_id)
        {
            bus_eleave bus = new bus_eleave();
            bus.id = eleave_id;
            string leav = bus.fetch_details_edit();
            return leav;
        }

        protected void up_leaves_Click(object sender, EventArgs e)
        {

        }

        protected void c_update_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/hr/status_leave_hr.aspx");
        }
    }
}