using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eleave_c;

namespace eleave_view.hr
{
    public partial class cholidays : System.Web.UI.Page
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
                if (Session["is_login"].ToString() == "f")
                {
                    Response.Redirect("~/unauthorised.aspx");
                }
                else
                {
                    clear_holidays();
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void clear_holidays()
        {
            int r = bus.clear_holidays();
            if (r == 1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
            }
        }
    }
}