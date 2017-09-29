<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edituser.aspx.cs" Inherits="eleave_view.hr.edituser" MasterPageFile="~/hr/hr.Master" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function success() {
            swal({
                title: 'Success!',
                text: 'User Details Updated succesfully !',
                type: 'success',
                allowEscapeKey: false,
                allowOutsideClick: false
            },
                function () {
                    window.location = "listuser.aspx";
                });
        }
    </script>
    <script type="text/javascript">
        function error_dupli() {
            swal({
                title: 'Error!',
                text: 'Username Cannot be Same!',
                type: 'error',
                allowEscapeKey: false,
                allowOutsideClick: false
            },
                 function () {
                     window.location = "listuser.aspx";
                 });
        }
    </script>
    <script type="text/javascript">
        function error_dupli_email() {
            swal({
                title: 'Error!',
                text: 'Email Cannot be Same!',
                type: 'error',
                allowEscapeKey: false,
                allowOutsideClick: false
            },
                 function () {
                     window.location = "listuser.aspx";
                 });
        }
    </script>
    <script type="text/javascript">
        function error() {
            swal({
                title: 'Error!',
                text: 'Something Went Wrong!',
                type: 'error',
                allowEscapeKey: false,
                allowOutsideClick: false
            },
            function () {
                window.location = "listuser.aspx";
            });
        }
    </script>
    <script type="text/javascript">
        function error1() {
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
        function errorinvalid() {
            swal({
                title: 'Error!',
                text: 'Invalid mail format!',
                type: 'error',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>
    <script type="text/javascript">
        function errorlength() {
            swal({
                title: 'Error!',
                text: 'Email can\'t be of length more than 30 characters!',
                type: 'error',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>
    <script type="text/javascript">
        function errorname() {
            swal({
                title: 'Error!',
                text: 'Invalid name format!',
                type: 'error',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>
    <script type="text/javascript">
        function erroruname() {
            swal({
                title: 'Error!',
                text: 'Invalid username format!',
                type: 'error',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header">
        <h1>Edit User</h1>
    </div>
    <div class="row">
        <div class="col-md-12">
            <!-- start: Apply Leave HR -->
            <div class="panel panel-default">
                <div class="panel-heading">
                    <i class="clip-user-2"></i>Edit User
                    <div class="panel-tools">
                        <a class="btn btn-xs btn-link panel-collapse collapses" href="#"></a><a class="btn btn-xs btn-link panel-expand"
                            href="#"><i class="icon-resize-full"></i></a><a class="btn btn-xs btn-link panel-close"
                                href="#"><i class="icon-remove"></i></a>
                    </div>
                </div>
                <div class="panel-body">
                    <h2>
                        <i class="icon-edit-sign teal"></i>EDIT </h2>
                    <hr>
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
                                    Name <span class="symbol required"></span>
                                </label>
                                <asp:TextBox ID="txtname" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                    Username <span class="symbol required"></span>
                                </label>
                                <asp:TextBox ID="txtuname" runat="server" CssClass="form-control" ClientIDMode="Static" onchange="checkusername_edit()"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                    Email <span class="symbol required"></span>
                                </label>
                                <asp:TextBox ID="txtemail" runat="server" CssClass="form-control" ClientIDMode="Static" onchange="checkemail_edit()"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                    Gender <span class="symbol required"></span>
                                </label>
                                <asp:DropDownList ID="ddlgender" runat="server" CssClass="form-control" ClientIDMode="Static" DataTextField="gender" DataValueField="gid"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                    Date Join <span class="symbol required"></span>
                                </label>
                                <asp:TextBox ID="txtdoje" runat="server" CssClass="chosen-disabled form-control" BackColor="White" ClientIDMode="Static"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                    Date of Birth <span class="symbol required"></span>
                                </label>
                                <asp:TextBox ID="txtdob" runat="server" CssClass="chosen-disabled form-control" BackColor="White" ClientIDMode="Static"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                    Department <span class="symbol required"></span>
                                </label>
                                <asp:DropDownList ID="ddldep" runat="server" CssClass="form-control" ClientIDMode="Static" DataTextField="dep_name" DataValueField="dep_id" onchange="filldesi()"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                    Designation <span class="symbol required"></span>
                                </label>
                                <asp:DropDownList ID="ddldesi" runat="server" CssClass="form-control" ClientIDMode="Static" DataTextField="designation" DataValueField="dsg_id" onchange="fillgrade()"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                    Grade <span class="symbol required"></span>
                                </label>
                                <asp:DropDownList ID="ddlgrade" runat="server" CssClass="form-control" ClientIDMode="Static" DataTextField="grade_desc" DataValueField="grade_id"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                    Category <span class="symbol required"></span>
                                </label>
                                <asp:TextBox ID="txtcategory" runat="server" CssClass="form-control" ClientIDMode="Static" BackColor="White"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                    Region <span class="symbol required"></span>
                                </label>
                                <asp:DropDownList ID="ddlregion" runat="server" CssClass="form-control" ClientIDMode="Static" DataTextField="region" DataValueField="region_id"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label">
                                </label>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                </label>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                </label>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                </label>
                            </div>
                            <div class="form-group">
                                <div id="pulsate-regularun" style="padding: 5px; width: 202px; display: none">
                                    <asp:Label ID="lblun" runat="server" Text="Username Already Taken" ClientIDMode="Static" ForeColor="Black"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                </label>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                </label>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                </label>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                </label>
                            </div>
                            <div class="form-group">
                                <div id="pulsate-regularem" style="padding: 5px; width: 202px; display: none">
                                    <asp:Label ID="lblem" runat="server" Text="Email can't be same" ClientIDMode="Static" ForeColor="Black"></asp:Label>
                                </div>
                            </div>
                        </div>
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
                        <div class="col-md-8">
                            <asp:Button ID="btnupuser" runat="server" Text="Update" ClientIDMode="Static" CssClass="btn btn-success" OnClientClick="uservali()" OnClick="btnupuser_Click" />
                        </div>
                        <div class="col-md-4">
                        </div>
                    </div>
                </div>
            </div>
            <!-- end: Apply Leave HR -->
        </div>
    </div>
</asp:Content>
