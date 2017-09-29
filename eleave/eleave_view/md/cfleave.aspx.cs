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

namespace eleave_view.md
{
    public partial class cfleave : System.Web.UI.Page
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
                    DataTable dt = bus.fillcflist();
                    if (dt.Rows.Count > 0)
                    {

                        grd_cflistr.DataSource = dt;
                        grd_cflistr.DataBind();
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

        protected void export_excel()
        {
            DataTable dtexl = bus.fillcflist();
            if (dtexl.Rows.Count > 0)
            {
                DataGrid grid = new DataGrid();
                grid.HeaderStyle.Font.Bold = true;
                grid.DataSource = dtexl;
                grid.DataBind();
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=Carry_Forward_Leave.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                Response.Write("<b>Carry Forwarded Leaves for the Following Year </b><br>");
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

        protected void export_pdf()
        {
            DataTable dtpdf = bus.fillcflist();
            if (dtpdf.Rows.Count > 0)
            {
                rd.Load(Server.MapPath(Request.ApplicationPath) + "/hr/cf_leave.rpt");
                rd.SetDataSource(dtpdf);
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Carry_Forwarded_Leave");
                dtpdf.Dispose();
            }
            else
            {

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

        protected void grd_cflistr_PreRender(object sender, EventArgs e)
        {
            if (grd_cflistr.Rows.Count > 0)
            {
                grd_cflistr.UseAccessibleHeader = true;
                grd_cflistr.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}