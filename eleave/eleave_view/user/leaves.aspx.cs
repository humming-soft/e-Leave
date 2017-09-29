using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using eleave_c;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace eleave_view.user
{
    public partial class leaves : System.Web.UI.Page
    {
        bus_eleave bus = new bus_eleave();
        ReportDocument rd = new ReportDocument();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                checklogin();
            }
        }

        public void checklogin()
        {
            if (Session["is_login"] != null)
            {
                if (Session["is_login"].ToString() == "t")
                {
                    fill_grid();

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

        protected void fill_grid()
        {
            bus.userid =int.Parse(Session["user_id"].ToString());
            DataTable dt = bus.fill_grid();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected Boolean Isenable(string Status)
        {
            //string a = Status;
             if (Status == "Approved")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected Boolean Isvisible(string Status)
        {
            //string a = Status;
            if (Status == "HR Level Pending")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            GridViewRow row = lnk.NamingContainer as GridViewRow;
            int id = int.Parse(GridView1.DataKeys[row.RowIndex].Value.ToString());
            download_leaves(id);
        }

        private void download_leaves(int id)
        {
            bus.lid = id;
            DataTable dt = bus.fetch_download_leaves();
            if (dt.Rows.Count > 0)
            {
                rd.Load(Server.MapPath(Request.ApplicationPath) + "/user/download_approved.rpt");
                rd.SetDataSource(dt);
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Approved_Leave");
            }
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            int id = int.Parse(GridView1.DataKeys[row.RowIndex].Value.ToString());
            bus.lid = id;
            int r = bus.cancel_leave();
            if (r == 1)
            {
                fill_grid();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
            }
            else
            {
                fill_grid();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            fill_grid();
        }

    }
}