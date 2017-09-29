<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="update_profile.aspx.cs" Inherits="eleave_view.user.update_profile" MasterPageFile="~/user/user.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function success() {
            swal({
                title: 'Success!',
                text: 'Your profile has been succesfully Updated',
                type: 'success',
                allowEscapeKey: false,
                allowOutsideClick: false
            },
                function () {
                    window.location = "dash.aspx";
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
                title: 'Warning!',
                text: 'Failed to fetch the details needed',
                type: 'warning',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>
    <script type="text/javascript">
        function errorlength() {
            swal({
                title: 'Error!',
                text: 'Address 1 & Address 2 can\'t be of length grater than 20 charcaters',
                type: 'error',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header">
        <h1>Update Profile</h1>
    </div>
    <div class="row">
        <div class="col-md-12">
            <!-- start: Edit Profile -->
            <div class="panel panel-default">
                <div class="panel-heading">
                    <i class="clip-user-4"></i>Update Profile
                    <div class="panel-tools">
                        <a class="btn btn-xs btn-link panel-collapse collapses" href="#"></a>
                        <a class="btn btn-xs btn-link panel-expand" href="#"><i class="icon-resize-full"></i></a>
                        <a class="btn btn-xs btn-link panel-close" href="#"><i class="icon-remove"></i></a>
                    </div>
                </div>
                <div class="panel-body">
                    <h2>
                        <i class="icon-edit-sign teal"></i>Update Profile</h2>
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
                                    Name
                                </label>
                                <asp:Label ID="lblname" runat="server" CssClass="form-control"
                                    ClientIDMode="Static"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                    Username
                                </label>
                                <asp:Label ID="lbluname" runat="server" CssClass="form-control"
                                    ClientIDMode="Static"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                    Email
                                </label>
                                <asp:Label ID="lblemail" runat="server" CssClass="form-control"
                                    ClientIDMode="Static"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                    Gender
                                </label>
                                <asp:Label ID="lblgender" runat="server" CssClass="form-control"
                                    ClientIDMode="Static"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                    Date Of Join
                                </label>
                                <asp:Label ID="lbldoj" runat="server" CssClass="form-control"
                                    ClientIDMode="Static"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                    Department
                                </label>
                                <asp:Label ID="lbldep" runat="server" CssClass="form-control"
                                    ClientIDMode="Static"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                    Designation
                                </label>
                                <asp:Label ID="lbldesg" runat="server" CssClass="form-control"
                                    ClientIDMode="Static"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                    Grade
                                </label>
                                <asp:Label ID="lblgrade" runat="server" CssClass="form-control"
                                    ClientIDMode="Static"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                    Address 1 <span class="symbol required"></span>
                                </label>
                                <asp:TextBox ID="txtadd1" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                    Address 2 <span class="symbol required"></span>
                                </label>
                                <asp:TextBox ID="txtadd2" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                    Contact No <span class="symbol required"></span>
                                </label>
                                <asp:TextBox ID="txtphone" runat="server" CssClass="form-control"
                                    ClientIDMode="Static"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                    Region
                                </label>
                                <asp:Label ID="lblregion" runat="server" CssClass="form-control"
                                    ClientIDMode="Static"></asp:Label>
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
                            <asp:Button ID="btnuprofile" runat="server" Text="Update" CssClass="btn btn-success" OnClientClick="uprofilevali()" OnClick="btnuprofile_Click" />
                        </div>
                        <div class="col-md-4">
                        </div>
                    </div>
                </div>
            </div>
            <!-- end: Edit Profile -->
        </div>
    </div>
</asp:Content>
