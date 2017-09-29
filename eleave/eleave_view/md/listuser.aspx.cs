using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using eleave_c;

namespace eleave_view.md
{
    public partial class listuser : System.Web.UI.Page
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
                    fillusers();

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

        protected void fillusers()
        {
            DataTable dt = bus.fillusers();
            grd_users.DataSource = dt;
            grd_users.DataBind();
        }

        protected void grd_users_PreRender(object sender, EventArgs e)
        {
            if (grd_users.Rows.Count > 0)
            {
                grd_users.UseAccessibleHeader = true;
                grd_users.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}