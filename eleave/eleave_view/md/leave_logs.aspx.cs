using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using eleave_c;

namespace eleave_view.md
{
    public partial class leave_logs : System.Web.UI.Page
    {
        bus_eleave bus = new bus_eleave();
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
            bus.userid = int.Parse(Session["user_id"].ToString());
            DataTable dt = bus.fill_logs();
            grd_log.DataSource = dt;
            grd_log.DataBind();
        }

        protected void grd_log_PreRender(object sender, EventArgs e)
        {
            if (grd_log.Rows.Count > 0)
            {
                grd_log.UseAccessibleHeader = true;
                grd_log.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

    }
}