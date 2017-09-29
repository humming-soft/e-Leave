<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chg_pass_hr.aspx.cs" Inherits="eleave_view.hr.chg_pass_hr" MasterPageFile="~/hr/hr.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #oldp:hover, #newp:hover, #cp:hover {
            cursor: pointer;
        }
    </style>
    <script type="text/javascript">
        function success_pwd() {
            swal({
                title: 'Success!',
                text: 'Your Password has been succesfully Updated',
                type: 'success',
                allowEscapeKey: false,
                allowOutsideClick: false
            },
                function () {
                    window.location = "../Logout.aspx";
                });
        }
    </script>

    <script type="text/javascript">
        function error_pwd() {
            swal({
                title: 'Error!',
                text: 'Something Went Wrong. Try Again',
                type: 'error',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>

    <script type="text/javascript">
        function error_old() {
            swal({
                title: 'Error!',
                text: 'Old Password is Wrong',
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
                text: 'You have some form errors!',
                type: 'error',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>
    <script type="text/javascript">
        function error_length() {
            swal({
                title: 'Error!',
                text: 'Password Should be of length 6 to 10 characters!',
                type: 'error',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header">
        <h1>Change Password</h1>
    </div>
    <div class="row">
        <div class="col-md-12">
            <!-- start: FORM VALIDATION 2 PANEL -->
            <div class="panel panel-default">
                <div class="panel-heading">
                    <i class="clip-key "></i>Change Password

					<div class="panel-tools">
                        <a class="btn btn-xs btn-link panel-collapse collapses" href="#"></a>
                        <a class="btn btn-xs btn-link panel-expand" href="#"><i class="icon-resize-full"></i></a>
                        <a class="btn btn-xs btn-link panel-close" href="#"><i class="icon-remove"></i></a>
                    </div>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="errorHandler alert alert-danger no-display">
                                <i class="icon-remove-sign"></i>You have some form errors. Please check below.
                            </div>
                            <div class="successHandler alert alert-success no-display">
                                <i class="icon-ok"></i>Your form validation is successful!
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">
                                    Old Password <span class="symbol required"></span>
                                </label>
                                <span class="input-icon input-icon-right">
                                    <asp:TextBox ID="oldpwd_hr_txt" runat="server" CssClass="form-control" ClientIDMode="Static" TextMode="Password" onchange="chkoldpswd()"></asp:TextBox>
                                    <i id="oldp" class="icon-eye-open"></i>
                                </span>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                    New Password <span class="symbol required"></span>
                                </label>
                                <span class="input-icon input-icon-right">
                                    <asp:TextBox ID="nwpwd_hr_txt" runat="server" CssClass="form-control" ClientIDMode="Static" TextMode="Password"></asp:TextBox>
                                    <i id="newp" class="icon-eye-open"></i>
                                </span>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                    Confirm New Password <span class="symbol required"></span>
                                </label>
                                <span class="input-icon input-icon-right">
                                    <asp:TextBox ID="conf_nwpwd_hr_txt" runat="server" CssClass="form-control" ClientIDMode="Static" TextMode="Password"></asp:TextBox>
                                    <i id="cp" class="icon-eye-open"></i>
                                </span>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div>
                                        <span class="symbol required"></span>Required Fields
                                    <hr>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Button ID="Button1" runat="server" Text="Change Password" CssClass="btn btn-success" OnClick="Button1_Click" OnClientClick="cpassvali()" ClientIDMode="Static" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">
                                </label>
                            </div>
                            <div class="form-group">
                                <div id="pulsate-regular" style="padding: 5px; width: 202px; display: none">
                                    <asp:Label ID="lblop" runat="server" Text="Enter Valid Password" ClientIDMode="Static" ForeColor="Black"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
