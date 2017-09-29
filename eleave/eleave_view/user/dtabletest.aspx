<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dtabletest.aspx.cs" Inherits="eleave_view.user.dtabletest" MasterPageFile="~/user/user.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header">
        <h1>JQuery Data Table Test Page</h1>
    </div>
    <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" ClientIDMode="Static" OnPreRender="GridView1_PreRender"></asp:GridView>
</asp:Content>

