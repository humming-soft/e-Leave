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

        protected void lnkremove_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            GridViewRow row = lnk.NamingContainer as GridViewRow;
            int id = int.Parse(grd_users.DataKeys[row.RowIndex].Value.ToString());
            bus.id = id;
            int r = bus.deleteuser(); // now doing only soft delete
            if (r == 1) //success
            {
                fillusers();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
            }
            else if (r == 2) //no lid
            {
                fillusers();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "errornolid();", true);
            }
            else //fail
            {
                fillusers();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
            }
        }

        protected void grd_users_PreRender(object sender, EventArgs e)
        {
            if (grd_users.Rows.Count > 0)
            {
                grd_users.UseAccessibleHeader = true;
                grd_users.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void lnkedit_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            GridViewRow row = lnk.NamingContainer as GridViewRow;
            int id = int.Parse(grd_users.DataKeys[row.RowIndex].Value.ToString());
            Session["edit_id"] = id;
            Response.Redirect("~/hr/edituser.aspx");
        }
    }
}