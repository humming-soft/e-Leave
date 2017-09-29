using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eleave_c;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using System.Data;
using System.IO;

namespace eleave_view.md
{
    public partial class leavetaken : System.Web.UI.Page
    {
        bus_eleave bus = new bus_eleave();
        ReportDocument rd = new ReportDocument();
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
                    DataTable dt = bus.fetch_leaves_taken();
                    if (dt.Rows.Count > 0)
                    {

                        grd_ltaken.DataSource = dt;
                        grd_ltaken.DataBind();
                    }
                    else
                    {
                        btnpdf.Visible = false;
                        btnexl.Visible = false;
                    }

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

        protected void export_pdf()
        {
            DataTable dtpdf = bus.fetch_leaves_taken();
            if (dtpdf.Rows.Count > 0)
            {
                rd.Load(Server.MapPath(Request.ApplicationPath) + "/hr/leavestaken.rpt");
                rd.SetDataSource(dtpdf);
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Leaves_Taken");
                dtpdf.Dispose();
            }
            else
            {

            }
        }

        protected void export_excel()
        {
            DataTable dtexl = bus.fetch_leaves_taken();
            if (dtexl.Rows.Count > 0)
            {
                DataGrid grid = new DataGrid();
                grid.HeaderStyle.Font.Bold = true;
                grid.DataSource = dtexl;
                grid.DataBind();
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=Leaves_Taken.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                Response.Write("<b>Leaves Taken as on :" + DateTime.Now.ToString("dd/MM/yyyy") + "</b><br>");
                //Response.Write("<tr colspan=3> <td><b> Zone - Age Wise Outstanding Report Greater Than - " + txtmonth.Text + " months </td></tr>");
                StringWriter StringWriter = new System.IO.StringWriter();
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                grid.RenderControl(HtmlTextWriter);
                Response.Write(StringWriter.ToString());
                Response.End();
                dtexl.Dispose();
            }
            else
            {

            }
        }

        protected void grd_ltaken_PreRender(object sender, EventArgs e)
        {
            if (grd_ltaken.Rows.Count > 0)
            {
                grd_ltaken.UseAccessibleHeader = true;
                grd_ltaken.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void btnpdf_Click(object sender, EventArgs e)
        {
            export_pdf();
        }

        protected void btnexl_Click(object sender, EventArgs e)
        {
            export_excel();
        }
    }
}