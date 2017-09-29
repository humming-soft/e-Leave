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
    public partial class userleavesall : System.Web.UI.Page
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
                    fill_leaves_all();

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

        protected void fill_leaves_all()
        {
            DataTable dt = bus.fill_leaves_all();
            grd_userleaves.DataSource = dt;
            grd_userleaves.DataBind();
        }

        protected void grd_userleaves_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_userleaves.PageIndex = e.NewPageIndex;
            fill_leaves_all();
        }

        protected void grd_userleaves_PreRender(object sender, EventArgs e)
        {
            if (grd_userleaves.Rows.Count > 0)
            {
                grd_userleaves.UseAccessibleHeader = true;
                grd_userleaves.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}