using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eleave_c;
using System.Data;

namespace eleave_view.hr
{
    public partial class approve_leave_hr : System.Web.UI.Page
    {
        bus_eleave_HS obj = new bus_eleave_HS();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
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
                    fill_app_rej_hr();

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

        protected void fill_app_rej_hr()
        {          
            DataTable dt=obj.fill_app_rej_hr();
            if(dt.Rows.Count>0)
            {
                app_rej_hr.DataSource = dt;
                app_rej_hr.DataBind();
            }
            else
            {
                btn_approve_hr.Visible = false;
                btn_reject_hr.Visible = false;
            }            
        }

        protected void approve_lev_hr_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            GridViewRow row = lnk.NamingContainer as GridViewRow;
            obj.lid = int.Parse(app_rej_hr.DataKeys[row.RowIndex].Value.ToString());            
            int res = obj.accept_leave();
            if (res == 1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success_approve();", true);
            }
            else
            {
                fill_app_rej_hr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "fail_approve();", true);
            }
        }

        protected void rej_lev_hr_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            GridViewRow row = lnk.NamingContainer as GridViewRow;
            obj.lid = int.Parse(app_rej_hr.DataKeys[row.RowIndex].Value.ToString());   
            int res = obj.reject_leave();
            if (res == 1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
            }
            else
            {
                fill_app_rej_hr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
            }
        }

        protected void btn_approve_hr_Click(object sender, EventArgs e)
        {
            int res = 0;
            if(res==0)
            {
                foreach (GridViewRow gvrow in app_rej_hr.Rows)
                {                    
                    CheckBox chkapprove = (CheckBox)gvrow.FindControl("chk_hr");
                    if (chkapprove.Checked)
                    {
                        obj.lid = Convert.ToInt32(app_rej_hr.DataKeys[gvrow.RowIndex].Value);
                        res = obj.accept_leave();
                    }
                }
                if (res == 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success_approve();", true);
                }
                else if(res==2)
                {
                    fill_app_rej_hr();
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "fail_approve();", true);
                }
                else
                {
                //    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "approve_null();", true);
                }
            }                        
        }

        protected void btn_reject_hr_Click(object sender, EventArgs e)
        {
            int res1 = 0;
            if (res1 == 0)
            {
                foreach (GridViewRow gvrow in app_rej_hr.Rows)
                {
                    CheckBox chkapprove_rej= (CheckBox)gvrow.FindControl("chk_hr");
                    if (chkapprove_rej.Checked)
                    {
                        obj.lid = Convert.ToInt32(app_rej_hr.DataKeys[gvrow.RowIndex].Value);
                        res1 = obj.reject_leave();
                    }
                }
                if (res1 == 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
                }
                else if( res1==2)
                {
                    fill_app_rej_hr();
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
                }
                else
                {
                //    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "reject_null();", true);
                }
            }
        }

        protected void app_rej_hr_RowDataBound(object sender, GridViewRowEventArgs e)
        {
          
       }
    }
}