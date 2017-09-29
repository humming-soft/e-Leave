<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cholidays_hr.aspx.cs" Inherits="eleave_view.hr.cholidays_hr" MasterPageFile="~/hr/hr.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function success() {
            swal({
                title: 'Success!',
                text: 'Successfully removed Hummingsoft holidays !',
                type: 'success',
                allowEscapeKey: false,
                allowOutsideClick: false
            },
                function () {
                    window.location = "holidays_upload.aspx";
                });
        }
    </script>
    <script type="text/javascript">
        function errornolid() {
            swal({
                title: 'Warning!',
                text: 'Something Went Wrong',
                type: 'warning',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>
    <script type="text/javascript">
        function error() {
            swal({
                title: 'Error!',
                text: 'Operation Failed!',
                type: 'error',
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
