using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eleave_view
{
    public partial class sessiontimeout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            logout();
        }

        protected void logout()
        {
            //Session.Abandon();
            Session.Clear();
            Session["is_login"] = "f";
        }
    }
}