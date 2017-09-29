<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="download_all_hr.aspx.cs" Inherits="eleave_view.hr.download_all_hr" MasterPageFile="~/hr/hr.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .hidden {
            display: none;
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
    <style type="text/css">
        .WordWrap1 {
            /*width: 100%;*/
            word-break: break-all;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header">
        <h1>Download Approved Leaves</h1>
    </div>
    <div class="table-responsive">
        <asp:GridView ID="grd_leave_dwnld" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover" DataKeyNames="lid" ClientIDMode="Static" OnPreRender="grd_leave_dwnld_PreRender">
            <Columns>
                <asp:TemplateField HeaderText="No.">
                    <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="region_id" HeaderText="Region">
                    <HeaderStyle CssClass="hidden" />
                    <ItemStyle CssClass="hidden" />
                </asp:BoundField>
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="ltype" HeaderText="Leave Type" />
                <asp:BoundField DataField="req_date" HeaderText="Requested Date" />
                <asp:BoundField DataField="dates" HeaderText="Dates Applied" >
                <ItemStyle CssClass="WordWrap1" />
                </asp:BoundField>
                <asp:BoundField DataField="period" HeaderText="Period" />
                <asp:BoundField DataField="stat" HeaderText="Status" />
                <asp:BoundField DataField="med_path" HeaderText="File Path">
                    <HeaderStyle CssClass="hidden"></HeaderStyle>
                    <ItemStyle CssClass="hidden"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderText="Medical Certificate">
                    <ItemTemplate>
                        <asp:LinkButton ID="med_lnk" runat="server" CssClass="icon-external-link" Visible='<%# Isenable((string)Eval("ltype")) %>' OnClientClick="PostToNewWindow()" OnClick="med_lnk_Click" ToolTip="Medical Certificate" ></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Download">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkdwnld_all" runat="server" CssClass="icon-external-link" ToolTip="Download" OnClick="lnkdwnld_all_Click" OnClientClick="PostToNewWindow()"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
