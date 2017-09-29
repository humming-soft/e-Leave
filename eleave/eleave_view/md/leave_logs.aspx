<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="leave_logs.aspx.cs" Inherits="eleave_view.md.leave_logs" MasterPageFile="~/md/md.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .WordWrap1 {
            /*width: 100%;*/
            word-break: break-all;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header">
        <h1>Leave Status - All User's</h1>
    </div>
    <div class="table-responsive">
        <asp:GridView ID="grd_log" runat="server" CssClass="table table-bordered table-hover" ClientIDMode="Static" AutoGenerateColumns="False" DataKeyNames="lid" OnPreRender="grd_log_PreRender">
            <Columns>
                <asp:TemplateField HeaderText="No.">
                    <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="ltype" HeaderText="Leave Type" />
                <asp:BoundField DataField="req_date" HeaderText="Requested Date" />
                <asp:BoundField DataField="dates" HeaderText="Dates Applied" >
                <ItemStyle CssClass="WordWrap1" />
                </asp:BoundField>
                <asp:BoundField DataField="period" HeaderText="Period" />
                <asp:BoundField DataField="rej_reason" HeaderText="Reject Reason" >
                <ItemStyle CssClass="WordWrap1" />
                </asp:BoundField>
                <asp:BoundField DataField="stat" HeaderText="Status" />
            </Columns>

        </asp:GridView>
    </div>
</asp:Content>
