<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cfleave.aspx.cs" Inherits="eleave_view.hr.cfleave" MasterPageFile="~/hr/hr.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .arrange {
            text-align: right;
            padding: 20px;
            padding-top: 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header">
        <h1>Carryforward Leave</h1>
    </div>
    <div class="table-responsive">
        <asp:GridView ID="grd_cflistr" runat="server" CssClass="table table-bordered table-hover" ClientIDMode="Static" OnPreRender="grd_cflist_PreRender"></asp:GridView>
    </div>
    <div class="col-md-12">
        <div class="row">
            <div class="col-md-8">
            </div>
            <div class="col-md-4">
                <div class="arrange">
                    <asp:Button ID="btnpdf" runat="server" CssClass="btn btn-success" Text="Export to PDF" ClientIDMode="Static" OnClick="btnpdf_Click" />
                    <asp:Button ID="btnexl" runat="server" CssClass="btn btn-success" Text="Export to Excel" ClientIDMode="Static" OnClick="btnexl_Click" />
                </div>
            </div>
            <%--            <div class="col-md-1">
                <asp:Button ID="btnprint" runat="server" CssClass="btn btn-success pull-right" Text="Print Report" ClientIDMode="Static" OnClick="btnprint_Click"/>
            </div>--%>
        </div>
    </div>
</asp:Content>
