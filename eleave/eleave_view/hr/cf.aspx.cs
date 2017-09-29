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
    public partial class cf : System.Web.UI.Page
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
                    enable_disable();
                    fillcflist();

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

        protected void fillcflist()
        {
            DataTable dt = bus.fillcflist();
            if (dt.Rows.Count > 0)
            {
                grd_cflist.DataSource = dt;
                grd_cflist.DataBind();
            }
            else
            {
            }
        }

        protected void grd_cflist_PreRender(object sender, EventArgs e)
        {
            if (grd_cflist.Rows.Count > 0)
            {
                grd_cflist.UseAccessibleHeader = true;
                grd_cflist.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void lnkcf_Click(object sender, EventArgs e)
        {
            int r = bus.checkcf();
            if(r==1) // apply carry forward
            {
                int re = bus.cf();
                {
                    if(re ==1)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
                    }
                    else
                    {

                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
            }
        }

        protected void enable_disable()
        {
            int chk = bus.checkcf();
            if(chk == 1)
            {
                lnkcf.Visible = true;
            }
            else
            {
                lnkcf.Visible = false;
            }
        }

    }
}