using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using System.Data;
using System.IO;
using eleave_c;

namespace eleave_view.hr
{
    public partial class balleave : System.Web.UI.Page
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
            if (Session["is_login"]!= null)
            {
                if (Session["is_login"].ToString() == "t")
                {
                    DataTable dt = bus.fetch_leaves_balance();
                    if (dt.Rows.Count > 0)
                    {

                        grd_bal.DataSource = dt;
                        grd_bal.DataBind();
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

        protected void grd_bal_PreRender(object sender, EventArgs e)
        {
            if (grd_bal.Rows.Count > 0)
            {
                grd_bal.UseAccessibleHeader = true;
                grd_bal.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void btnexl_Click(object sender, EventArgs e)
        {
            export_excel();
        }

        protected void export_excel()
        {
            DataTable dtexl = bus.fetch_leaves_balance();
            if (dtexl.Rows.Count > 0)
            {
                DataGrid grid = new DataGrid();
                grid.HeaderStyle.Font.Bold = true;
                grid.DataSource = dtexl;
                grid.DataBind();
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=Balance_Leave.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                Response.Write("<b>Balanace Leave Available as on :" + DateTime.Now.ToString("dd/MM/yyyy") + "</b><br>");
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

        protected void btnpdf_Click(object sender, EventArgs e)
        {
            export_pdf();
        }

        protected void export_pdf()
        {
            DataTable dtpdf = bus.fetch_leaves_balance();
            if (dtpdf.Rows.Count > 0)
            {
                rd.Load(Server.MapPath(Request.ApplicationPath) + "/hr/bal_leave.rpt");
                rd.SetDataSource(dtpdf);
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Balance_Leave");
                dtpdf.Dispose();
            }
            else
            {

            }
        }

        //protected void btnprint_Click(object sender, EventArgs e)
        //{
        //    DataTable dtpt = bus.fetch_leaves_balance();
        //    if (dtpt.Rows.Count > 0)
        //    {
        //        rd.Load(Server.MapPath(Request.ApplicationPath) + "/hr/bal_leave.rpt");
        //        rd.SetDataSource(dtpt);
        //        rd.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
        //        rd.PrintOptions.PaperSize = PaperSize.PaperA4;
        //        rd.PrintToPrinter(1, false, 0, 15);
        //        dtpt.Dispose();
        //    }
        //    else
        //    {

        //    }
        //}
    }
}