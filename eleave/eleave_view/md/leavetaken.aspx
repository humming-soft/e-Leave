<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="leavetaken.aspx.cs" Inherits="eleave_view.md.leavetaken" MasterPageFile="~/md/md.Master" %>

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
        <h1>Leaves Taken</h1>
    </div>
    <div class="table-responsive">
        <asp:GridView ID="grd_ltaken" runat="server" CssClass="table table-bordered table-hover"  AutoGenerateColumns="False" ClientIDMode="Static" OnPreRender="grd_ltaken_PreRender">
            <Columns>
                <asp:BoundField DataField="No." HeaderText="No." />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Gender" HeaderText="Gender" />
                <asp:BoundField DataField="Annual" HeaderText="Annual" />
                <asp:BoundField DataField="Medical" HeaderText="Medical" />
                <asp:BoundField DataField="Marriage" HeaderText="Marriage" />
                <asp:BoundField DataField="Maternity" HeaderText="Maternity" />
                <asp:BoundField DataField="Paternity" HeaderText="Paternity" />
                <asp:BoundField DataField="Hospitalization" HeaderText="Hospitalization" />
                <asp:BoundField DataField="Compassionate" HeaderText="Compassionate" />
                <asp:BoundField DataField="Unpaid" HeaderText="Unpaid" />
                <asp:BoundField DataField="Replacement" HeaderText="Replacement" />
            </Columns>
        </asp:GridView>
    </div>
    <div class="col-md-12">
        <div class="row">
            <div class="col-md-8">
            </div>
            <div class="col-md-4">
                <div class="arrange">
                    <asp:Button ID="btnpdf" runat="server" CssClass="btn btn-success" Text="Export to PDF" ClientIDMode="Static" OnClick="btnpdf_Click"/>
                    <asp:Button ID="btnexl" runat="server" CssClass="btn btn-success" Text="Export to Excel" ClientIDMode="Static" OnClick="btnexl_Click"/>
                </div>
            </div>
            <%--            <div class="col-md-1">
                <asp:Button ID="btnprint" runat="server" CssClass="btn btn-success pull-right" Text="Print Report" ClientIDMode="Static" OnClick="btnprint_Click" />
            </div>--%>
        </div>
    </div>
</asp:Content>
