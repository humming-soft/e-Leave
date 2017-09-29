<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cf.aspx.cs" Inherits="eleave_view.hr.cf" MasterPageFile="~/hr/hr.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function success() {
            swal({
                title: 'Success!',
                text: 'Leaves Carryforwarded Successfully ',
                type: 'success',
                allowEscapeKey: false,
                allowOutsideClick: false
            },
                function () {
                    window.location = "cf.aspx";
                });
        }
    </script>
    <script type="text/javascript">
        function error() {
            swal({
                title: 'Error!',
                text: 'Carry Forward Already Done!',
                type: 'error',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header">
        <h1>Carry Forward Leave <small>
            <asp:LinkButton ID="lnkcf" runat="server" OnClick="lnkcf_Click">Carry Forward</asp:LinkButton></small></h1>
    </div>
    <div class="table-responsive">
        <asp:GridView ID="grd_cflist" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="False" ClientIDMode="Static" OnPreRender="grd_cflist_PreRender">
            <Columns>
                <asp:BoundField DataField="No." HeaderText="No." />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Gender" HeaderText="Gender" />
                <asp:BoundField DataField="Date Of Join" HeaderText="Date Of Join" />
                <asp:BoundField DataField="Department" HeaderText="Department" />
                <asp:BoundField DataField="Designation" HeaderText="Designation" />
                <asp:BoundField DataField="Grade" HeaderText="Grade" />
                <asp:BoundField DataField="Leaves Forwarded" HeaderText="Leaves Forwarded" />
                <asp:BoundField DataField="Forwarded Date" HeaderText="Forwarded Date" />
                <asp:BoundField DataField="Region" HeaderText="Region" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
