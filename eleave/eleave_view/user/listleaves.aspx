<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="listleaves.aspx.cs" Inherits="eleave_view.user.listleaves" MasterPageFile="~/user/user.Master" %>

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
<h1>Leaves<small><a href="leaveapply.aspx"> Request Leave</a></small></h1>                                 
</div>
    <div class="table-responsive">
        <asp:GridView ID="grd_leaves" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover" DataKeyNames="lid" ClientIDMode="Static" OnPreRender="grd_leaves_PreRender">
            <Columns>
                <asp:TemplateField HeaderText="No.">
                    <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
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
                <asp:TemplateField HeaderText="Operation">
                    <ItemTemplate>
                        <asp:Button ID="btncancel" runat="server" CssClass="btn btn-bricky" OnClick="btncancel_Click" Text="Cancel" Visible='<%# Isvisible((string)Eval("stat")) %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Download">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnldownload" runat="server" CssClass="icon-external-link" OnClick="lnldownload_Click" ToolTip="Download" Visible='<%# Isenable((string)Eval("stat")) %>' OnClientClick="PostToNewWindow()"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
