<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="leaves.aspx.cs" Inherits="eleave_view.user.leaves" MasterPageFile="~/user/user.Master" %>

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
    <style type="text/css">
        .WordWrap {
            overflow-x: auto; /* Use horizontal scroller if needed; for Firefox 2, not needed in Firefox 3 */
             white-space: pre-wrap; /* css-3 */
              white-space: -moz-pre-wrap !important; /* Mozilla, since 1999 */ 
              white-space: -pre-wrap; /* Opera 4-6 */ 
              white-space: -o-pre-wrap; /* Opera 7 */ /* width: 99%; */ 
              word-wrap: break-word; /* Internet Explorer 5.5+ */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header">                            
<h1>Leaves<small><a href="leaveapply.aspx"> Request Leave</a></small></h1>                                 
</div>
<div class="table-responsive">
    <asp:GridView ID="GridView1" runat="server" 
        CssClass="table table-bordered table-hover" AutoGenerateColumns="False" 
        DataKeyNames="lid" AllowPaging="True" 
        onpageindexchanging="GridView1_PageIndexChanging" PageSize="5">
        <Columns>
            <asp:TemplateField HeaderText="No.">
            <ItemTemplate>
             <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ltype" HeaderText="Leave Type" />
            <asp:BoundField DataField="req_date" HeaderText="Applied On" />
            <asp:BoundField DataField="dates" HeaderText="Dates Applied" />
            <asp:BoundField DataField="stat" HeaderText="Status" />
            <asp:TemplateField HeaderText="Operation">
                <ItemTemplate>
                    <asp:Button ID="btncancel" runat="server" CssClass="btn btn-bricky" Visible='<%# Isvisible((string)Eval("stat")) %>' 
                        Text="Cancel" onclick="btncancel_Click" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Download">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" 
                        Visible='<%# Isenable((string)Eval("stat")) %>' CssClass="clip-download-2" 
                        onclick="LinkButton1_Click"> Download</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerStyle BorderStyle="None" />
    </asp:GridView>
</div>
</asp:Content>
