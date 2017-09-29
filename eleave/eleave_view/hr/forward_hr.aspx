<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forward_hr.aspx.cs" Inherits="eleave_view.hr.forward_hr" MasterPageFile="~/hr/hr.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var gridViewId = '#<%= grd_forward.ClientID %>';
        function checkAll(selectAllCheckbox) {
            //get all checkboxes within item rows and select/deselect based on select all checked status
            //:checkbox is jquery selector to get all checkboxes
            $('td :checkbox', gridViewId).prop("checked", selectAllCheckbox.checked);
        }
        function unCheckSelectAll(selectCheckbox) {
            //if any item is unchecked, uncheck header checkbox as well
            if (!selectCheckbox.checked)
                $('th :checkbox', gridViewId).prop("checked", false);
        }
    </script>
    <script type="text/javascript">
        function success() {
            swal({
                title: 'Success!',
                text: 'Your request has been succesfully updated !',
                type: 'success',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>
    <script type="text/javascript">
        function error() {
            swal({
                title: 'Error!',
                text: 'Something Went Wrong !',
                type: 'error',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>
    <script type="text/javascript">
        function warning() {
            swal({
                title: 'Warning!',
                text: 'Atleast Select One record !',
                type: 'warning',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>
    <style type="text/css">
        .hidden {
            display: none;
        }
    </style>
    <script type="text/javascript">
        function warning2() {
            swal({
                title: 'Warning!',
                text: 'Enter Reject Reason !',
                type: 'warning',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>
    <script type="text/javascript">
        function errormail() {
            swal({
                title: 'Warning!',  
                text: 'Mail Not Sent!',
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

    <%--TO view medical certificate--%>
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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="page-header">
        <h1>Forward Leave</h1>
    </div>
    <div class="table-responsive">

        <asp:GridView ID="grd_forward" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="lid" OnPreRender="grd_forward_PreRender">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkall" runat="server" onclick="checkAll(this);" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chk" runat="server" onclick="unCheckSelectAll(this);" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="No.">
                    <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="name" HeaderText="Name" />
                <asp:BoundField DataField="depname" HeaderText="Department" />
                <asp:BoundField DataField="desig" HeaderText="Designation" />
                <asp:BoundField DataField="ltype" HeaderText="Leave Type" />
                <asp:BoundField DataField="dates" HeaderText="Dates Applied" >
                <ItemStyle CssClass="WordWrap1" />
                </asp:BoundField>
                <asp:BoundField DataField="period" HeaderText="Period" />
                <asp:BoundField DataField="reason" HeaderText="Reason" >
                <ItemStyle CssClass="WordWrap1" />
                </asp:BoundField>
                <asp:BoundField DataField="med_path" HeaderText="File Path">
                    <HeaderStyle CssClass="hidden"></HeaderStyle>
                    <ItemStyle CssClass="hidden"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderText="Medical Certificate">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnk_dwn" runat="server" Visible='<%# Isenable((string)Eval("ltype")) %>' CssClass="icon-external-link" ToolTip="Medical Certificate" OnClick="lnk_dwn_Click" CausesValidation="False" OnClientClick="PostToNewWindow();"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="email" HeaderText="Email">
                    <HeaderStyle CssClass="hidden"></HeaderStyle>
                    <ItemStyle CssClass="hidden"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderText="Reject Reason">
                    <ItemTemplate>
                        <asp:TextBox ID="txtrejs" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="req1" runat="server" ErrorMessage="Required" ControlToValidate="txtrejs" ValidationGroup='<%# "Group_" + Container.DataItemIndex %>' ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Minimum 7 & Maximum 50, No Special Charcaters allowed" ForeColor="Red" ControlToValidate="txtrejs" ValidationExpression="^[a-zA-Z0-9,.!? ]{7,50}$" ValidationGroup='<%# "Group_" + Container.DataItemIndex %>'></asp:RegularExpressionValidator>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Forward">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkforward" runat="server" CssClass="btn btn-green" OnClick="lnkforward_Click" CausesValidation="False"><i class="glyphicon glyphicon-ok-sign"></i></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Reject">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkreject" runat="server" CssClass="btn btn-bricky" OnClick="lnkreject_Click" ValidationGroup='<%# "Group_" + Container.DataItemIndex %>'><i class="glyphicon glyphicon-remove-circle"></i></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div class="table-responsive">
        <table class="table-responsive">
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnaccept" runat="server" Text="Forward" CssClass="btn btn-success" OnClick="btnaccept_Click" CausesValidation="False" /></td>
                <td></td>
                <td></td>
                <td>
                    <asp:Button ID="btnreject" runat="server" Text="Reject" CssClass="btn btn-orange" CausesValidation="False" /></td>
            </tr>
        </table>
    </div>
    <!-- Modal: Start -->
    <asp:Panel ID="Panel1" runat="server" Style="display: none">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <asp:LinkButton ID="lnkclos" runat="server" CssClass="close clip-close-2"></asp:LinkButton>
                    <h4 class="modal-title">Reject Reason</h4>
                </div>
                <div class="modal-body">
                    <p>
                        <asp:TextBox ID="txtbreason" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required" ControlToValidate="txtbreason" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Minimum 7 & Maximum 50, No Special Charcaters allowed" ForeColor="Red" ControlToValidate="txtbreason" ValidationExpression="^[a-zA-Z0-9,.!? ]{7,50}$"></asp:RegularExpressionValidator>
                    </p>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnrejc" runat="server" Text="OK" CssClass="btn btn-default" OnClick="btnrejc_Click" />
                </div>
            </div>
        </div>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Panel1" TargetControlID="btnreject" OkControlID="lnkclos"></ajaxToolkit:ModalPopupExtender>
    <!-- Modal :End -->

</asp:Content>
