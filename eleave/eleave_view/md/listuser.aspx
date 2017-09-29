<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="listuser.aspx.cs" Inherits="eleave_view.md.listuser" MasterPageFile="~/md/md.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header">
        <h1>Users</h1>
    </div>
    <div class="table-responsive">
        <asp:GridView ID="grd_users" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="uid" ClientIDMode="Static" OnPreRender="grd_users_PreRender">
            <Columns>
                <asp:TemplateField HeaderText="No.">
                    <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="name" HeaderText="Name" />
                <asp:BoundField DataField="uname" HeaderText="User Name" />
                <asp:BoundField DataField="gender" HeaderText="Gender" />
                <asp:BoundField DataField="doj" HeaderText="Date Of Join" />
                <asp:BoundField DataField="dep" HeaderText="Department" />
                <asp:BoundField DataField="designation" HeaderText="Designation" />
                <asp:BoundField DataField="grade" HeaderText="Grade" />
                <asp:BoundField DataField="region" HeaderText="Region" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
