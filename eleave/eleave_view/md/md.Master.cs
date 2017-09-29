using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eleave_view.md
{
    public partial class md : System.Web.UI.MasterPage
    {
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
                    lbluname.Text = Session["name"].ToString();
                    SetCurrentPage();

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

        private void SetCurrentPage()
        {
            var pageName = GetPageName();

            switch (pageName)
            {
                case "dash.aspx":
                    dash.Attributes["class"] = "active";
                    break;
                case "app_rej.aspx":
                    leaves.Attributes["class"] = "active";
                    leaves1.Attributes["class"] = "active open";
                    break;
                case "cancelappr.aspx":
                    leaves.Attributes["class"] = "active";
                    leaves2.Attributes["class"] = "active open";
                    break;
                case "listuser.aspx":
                    settings.Attributes["class"] = "active";
                    settings1.Attributes["class"] = "active open";
                    break;
                case "leave_logs.aspx":
                    settings.Attributes["class"] = "active";
                    settings2.Attributes["class"] = "active open";
                    break;
                case "leavetaken.aspx":
                    rpt.Attributes["class"] = "active";
                    rpt1.Attributes["class"] = "active open";
                    break;
                case "balleave.aspx":
                    rpt.Attributes["class"] = "active";
                    rpt2.Attributes["class"] = "active open";
                    break;
                case "cfleave.aspx":
                    rpt.Attributes["class"] = "active";
                    rpt3.Attributes["class"] = "active open";
                    break;
            }
        }

        private string GetPageName()
        {
            return Request.Url.ToString().Split('/').Last();
        }
    }
}