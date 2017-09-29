<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userleavesall.aspx.cs" Inherits="eleave_view.md.userleavesall" MasterPageFile="~/md/md.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header">
        <h1>Leave Status - All User's</h1>
    </div>
    <div class="table-responsive">
        <asp:GridView ID="grd_userleaves" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="False" ClientIDMode="Static" OnPreRender="grd_userleaves_PreRender">
            <Columns>
                <asp:TemplateField HeaderText="No.">
                    <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="name" HeaderText="Name" />
                <asp:BoundField DataField="gender" HeaderText="Gender" />
                <asp:BoundField DataField="yos" HeaderText="Year Of Service" />
                <asp:BoundField DataField="aleave" HeaderText="Annual Leave" />
                <asp:BoundField DataField="sleave" HeaderText="Medical Leave" />
                <asp:BoundField DataField="mleave" HeaderText="Marriage Leave" />
                <asp:BoundField DataField="m2leave" HeaderText="Maternity  Leave" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
