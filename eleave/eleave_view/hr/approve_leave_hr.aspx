<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="approve_leave_hr.aspx.cs" Inherits="eleave_view.hr.approve_leave_hr" MasterPageFile="~/hr/hr.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function success_approve()
        {
        swal({
            title: 'Success!',
            text: 'Leave Sanctioned Sucessfully',
            type: 'success',
            allowEscapeKey: false,
            allowOutsideClick: false
        },
                function () {
                    window.location = "approve_leave_hr.aspx";
                });
        }

    </script>

    <script type="text/javascript">
        function fail_approve()
        {
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
    function success() {
        swal({
            title: 'Success!',
            text: 'Leave Rejected Sucessfully',
            type: 'success',
            allowEscapeKey: false,
            allowOutsideClick: false
        },
                function () {
                    window.location = "approve_leave_hr.aspx";
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
     <script type="text/javascript" language="javascript">
         var gridViewId = '#<%= app_rej_hr.ClientID %>';
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

    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header">                            
        <h1>Leaves Aplied</h1>                                 
    </div>    

				<div class="table-responsive">
                    
                    <asp:GridView ID="app_rej_hr" runat="server" AutoGenerateColumns="False" DataKeyNames="lid" CssClass="table table-bordered table-hover" OnRowDataBound="app_rej_hr_RowDataBound">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="Chk_all_hr"  runat="server" onclick="javascript:checkAll(this)" />
                                </HeaderTemplate>
                                <EditItemTemplate>
                                    <%--<asp:CheckBox ID="chk_all_hr" runat="server" />--%>
                                    <asp:TextBox ID="TextBox1" runat="server" onclick="javascript:unCheckSelectAll(this)"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chk_hr" runat="server" OnCheckedChanged="btn_approve_hr_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="No">                                
                                <ItemTemplate>
                                     <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="user_id" HeaderText="Name" />
                            <asp:BoundField DataField="l_type" HeaderText="Type" />
                            <asp:BoundField DataField="days_req" HeaderText="No: of Days" />
                            <asp:BoundField DataField="dates" HeaderText="Dates" />
                            
                            <asp:TemplateField HeaderText="Approve">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="approve_lev_hr" runat="server" CssClass="btn btn-green" OnClick="approve_lev_hr_Click"><i class="glyphicon glyphicon-ok-sign"></i></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                           
                            <asp:TemplateField HeaderText="Reject">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="rej_lev_hr" runat="server" CssClass="btn btn-bricky" OnClick="rej_lev_hr_Click"><i class="glyphicon glyphicon-remove-circle"></i></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
				</div>
			
		<!-- end: Grid HR Approve/Reject -->
    <asp:Button ID="btn_approve_hr" runat="server" Text="Approve" CssClass="btn btn-green" OnClick="btn_approve_hr_Click" ClientIDMode="Static"/>
    <asp:Button ID="btn_reject_hr" runat="server" Text="Reject" CssClass="btn btn-red" OnClick="btn_reject_hr_Click" ClientIDMode="Static"  />
</asp:Content>
