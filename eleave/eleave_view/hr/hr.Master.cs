using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eleave_view.hr
{
    public partial class hr : System.Web.UI.MasterPage
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
                case "hrdash.aspx":
                    dash.Attributes["class"] = "active";
                    break;
                case "status_leave_hr.aspx":
                    leaves.Attributes["class"] = "active";
                    leaves1.Attributes["class"] = "active open";
                    break;
                case "applyleave_hr.aspx":
                    leaves.Attributes["class"] = "active";
                    leaves1.Attributes["class"] = "active open";
                    break;
                case "cancel_hr.aspx":
                    leaves.Attributes["class"] = "active";
                    leaves2.Attributes["class"] = "active open";
                    break;
                case "forward_hr.aspx":
                    leaves.Attributes["class"] = "active";
                    leaves3.Attributes["class"] = "active open";
                    break;
                case "download_all_hr.aspx":
                    leaves.Attributes["class"] = "active";
                    leaves4.Attributes["class"] = "active open";
                    break;
                case "app_rej_forward_hr.aspx":
                    leaves.Attributes["class"] = "active";
                    leaves5.Attributes["class"] = "active open";
                    break;
                case "listuser.aspx":
                    settings.Attributes["class"] = "active";
                    settings1.Attributes["class"] = "active open";
                    break;
                case "adduser.aspx":
                    settings.Attributes["class"] = "active";
                    settings1.Attributes["class"] = "active open";
                    break;
                case "edituser.aspx":
                    settings.Attributes["class"] = "active";
                    settings1.Attributes["class"] = "active open";
                    break;
                case "holidays_upload.aspx":
                    settings.Attributes["class"] = "active";
                    settings2.Attributes["class"] = "active open";
                    break;
                case "leave_logs.aspx":
                    settings.Attributes["class"] = "active";
                    settings3.Attributes["class"] = "active open";
                    break;
                case "cf.aspx":
                    settings.Attributes["class"] = "active";
                    settings4.Attributes["class"] = "active open";
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