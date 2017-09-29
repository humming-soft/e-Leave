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
    public partial class WebForm1 : System.Web.UI.Page
    {
        bus_eleave bus = new bus_eleave();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                filldetails();
            }
        }

        public void filldetails()
        {
            DataTable dt = bus.fillusers();
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }
    }
}