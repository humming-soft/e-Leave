<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cancel.aspx.cs" Inherits="eleave_view.user.cancel" MasterPageFile="~/user/user.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function success() {
            swal({
                title: 'Success!',
                text: 'Your request has been succesfully sent',
                type: 'success',
                allowEscapeKey: false,
                allowOutsideClick: false
            },
                    function () {
                        window.location = "listleaves.aspx";
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
        function errormail() {
            swal({
                title: 'Warning!',
                text: 'Failed to send email!',
                type: 'warning',
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header">
        <h1>Cancel Approved Leave</h1>
    </div>
    <div class="table-responsive">
        <asp:GridView ID="grd_cancel" CssClass="table table-bordered table-hover"
            AutoGenerateColumns="False" runat="server" DataKeyNames="lid" ClientIDMode="Static" OnPreRender="grd_cancel_PreRender">
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
                <asp:BoundField DataField="stat" HeaderText="Status" />
                <asp:TemplateField HeaderText="Operation">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkcancel" CssClass="btn btn-bricky" runat="server"
                            OnClick="lnkcancel_Click" Visible='<%# Isvisible((string)Eval("dates")) %>'><i class="glyphicon glyphicon-remove-circle"></i></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
