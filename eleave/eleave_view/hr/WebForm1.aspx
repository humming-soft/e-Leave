<%@ Page Title="" Language="C#" MasterPageFile="~/hr/hr.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="eleave_view.hr.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h5>kvdvdvcjvcdsjvhdcjvsj</h5>
    <asp:GridView ID="GridView1" runat="server">
        <Columns>
            <asp:TemplateField HeaderText="Test">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>
</asp:Content>
