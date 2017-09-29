<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="status_leave_hr.aspx.cs" Inherits="eleave_view.hr.status_leave_hr" MasterPageFile="~/hr/hr.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function success() {
            swal({
                title: 'Success!',
                text: 'Your request has been succesfully Updated',
                type: 'success',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>
    <script type="text/javascript">
        function errormail() {
            swal({
                title: 'Error!',
                text: 'Mail Not Send',
                type: 'error',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>
    <script type="text/javascript">
        function error() {
            swal({
                title: 'Error!',
                text: 'Something Went Wrong',
                type: 'error',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>
    <script type="text/javascript">
        function warning() {
            swal({
                title: 'Error!',
                text: 'Could Not Fetch Mail Details',
                type: 'error',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>
    
    <style type="text/css">
        .WordWrap1 {
            /*width: 100%;*/
            word-break: break-all;
        }
    </style>

    <script type="text/javascript">
        function PostToNewWindow() {
            originalTarget = document.forms[0].target;
            document.forms[0].target = '_blank';
            window.setTimeout("document.forms[0].target=originalTarget;", 300);
            return true;
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header">
        <h1>Leaves<small><a href="applyleave_hr.aspx"> Request Leave</a></small></h1>
    </div>
    <div class="table-responsive">
        <asp:GridView ID="status_hr" runat="server"
            CssClass="table table-bordered table-hover" AutoGenerateColumns="False"
            DataKeyNames="lid" ClientIDMode="Static" OnPreRender="status_hr_PreRender">
            <Columns>
                <asp:TemplateField HeaderText="No.">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ltype" HeaderText="Leave Type" />
                <asp:BoundField DataField="req_date" HeaderText="Applied On" />
                <asp:BoundField DataField="dates" HeaderText="Dates Applied" >
                <ItemStyle CssClass="WordWrap1" />
                </asp:BoundField>
                <asp:BoundField DataField="period" HeaderText="Period" />
                <asp:BoundField DataField="rej_reason" HeaderText="Reject Reason" >
                <ItemStyle CssClass="WordWrap1" />
                </asp:BoundField>
                <asp:BoundField DataField="stat" HeaderText="Status" />
<%--                <asp:TemplateField HeaderText="Operation_Test">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkedit" runat="server" CssClass="icon-edit" ToolTip="Edit Leave" Visible='<%# Isvisible((string)Eval("stat")) %>' OnClick="lnkedit_Click"></asp:LinkButton>
                        <asp:LinkButton ID="lnkcancel" runat="server" CssClass="clip-cancel-circle" ToolTip="Cancel Leave" Visible='<%# Isvisible((string)Eval("stat")) %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="Operation">
                    <ItemTemplate>
                        <asp:Button ID="btncancel_hr" runat="server" CssClass="btn btn-bricky" Visible='<%# Isvisible((string)Eval("stat")) %>'
                            Text="Cancel" OnClick="btncancel_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Download">
                    <ItemTemplate>
                        <asp:LinkButton ID="dwnld_hr" runat="server"
                            Visible='<%# Isenable((string)Eval("stat")) %>' CssClass="icon-external-link"
                            OnClick="LinkButton1_Click" OnClientClick="PostToNewWindow()"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <PagerStyle BorderStyle="None" />
        </asp:GridView>
    </div>

</asp:Content>
