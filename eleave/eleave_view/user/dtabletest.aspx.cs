using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using eleave_c;

namespace eleave_view.user
{
    public partial class dtabletest : System.Web.UI.Page
    {
        bus_eleave bus = new bus_eleave();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillgrid();
            }
        }

        protected void fillgrid()
        {
            DataTable dt = bus.fillusers();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_PreRender(object sender, EventArgs e)
        {
            if(GridView1.Rows.Count>0)
            {
                GridView1.UseAccessibleHeader = true;
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}