<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit_leave.aspx.cs" Inherits="eleave_view.hr.edit_leave" MasterPageFile="~/hr/hr.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function success() {
            swal({
                title: 'Success!',
                text: 'Your request has been succesfully sent',
                type: 'success'
            },
                function () {
                    window.location = "status_leave_hr.aspx";
                });
        }
    </script>
    <script type="text/javascript">
        function error() {
            swal({
                title: 'Error!',
                text: 'Something Went Wrong',
                type: 'error'
            });
        }
    </script>
    <script type="text/javascript">
        function error1() {
            swal({
                title: 'Error!',
                text: 'You have some form errors!',
                type: 'error'
            });
        }
    </script>
    <script type="text/javascript">
        function warning() {
            swal({
                title: 'Warning!',
                text: 'Failed to fetch the details needed',
                type: 'warning'
            });
        }
    </script>
    <script type="text/javascript">
        function errorpdf() {
            swal({
                title: 'Error!',
                text: 'Invalid File Extension/ Format',
                type: 'error'
            });
        }
    </script>
    <script type="text/javascript">
        function errorpdfsize() {
            swal({
                title: 'Error!',
                text: 'Max File size is 3 MB',
                type: 'error'
            });
        }
    </script>
    <script type="text/javascript">
        function errornotavail() {
            swal({
                title: 'Error!',
                text: 'You Leave Count is over the required limit ',
                type: 'error'
            });
        }
    </script>

    <script type="text/javascript">
        function errornofile() {
            swal({
                title: 'Error!',
                text: 'Upload Medical Certificate',
                type: 'error'
            });
        }
    </script>
    <script type="text/javascript">
        function errorsrange() {
            swal({
                title: 'Error!',
                text: 'Start Date & End Date Can\'t be same',
                type: 'error'
            });
        }
    </script>
    <script type="text/javascript">
        function errormail() {
            swal({
                title: 'Warning!',
                text: 'Failed to send email!',
                type: 'warning'
            });
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header">
        <h1>Edit Leave</h1>
    </div>
    <div class="row">
        <div class="col-md-12">
            <!-- start: edit Leave HR -->
            <div class="panel panel-default">
                <div class="panel-heading">
                    <i class="clip-plus-circle-2"></i>Edit Leave
                    <div class="panel-tools">
                        <a class="btn btn-xs btn-link panel-collapse collapses" href="#"></a>
                        <a class="btn btn-xs btn-link panel-expand" href="#"><i class="icon-resize-full"></i></a>
                        <a class="btn btn-xs btn-link panel-close" href="#"><i class="icon-remove"></i></a>
                    </div>
                </div>
                <div class="panel-body">
                    <h2>
                        <i class="icon-edit-sign teal"></i>Edit</h2>
                    <hr>
                    <%--<form action="#" role="form" id="form2">--%>
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
                                <asp:Label ID="lblname_hr" runat="server" CssClass="form-control"
                                    ClientIDMode="Static"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                    Position <span class="symbol required"></span>
                                </label>
                                <asp:Label ID="lblpos_hr" runat="server" CssClass="form-control"
                                    ClientIDMode="Static"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                    Department <span class="symbol required"></span>
                                </label>
                                <asp:Label ID="lbldep_hr" runat="server" CssClass="form-control"
                                    ClientIDMode="Static"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                    Leave Type <span class="symbol required"></span>
                                </label>
                                <asp:Label ID="lblltype_hr" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:Label>
                            </div>
                            <div class="form-group" id="fup_hr" style="display: none">
                                <label class="control-label">
                                    Upload File <span class="symbol required"></span>
                                </label>
                                <asp:FileUpload ID="fupload_hr" runat="server"
                                    CssClass="fileupload fileupload-new" ClientIDMode="Static" />
                                <p class="help-block">
                                    Allowed File type is PDF. <span class="clip-file-pdf"></span>
                                </p>
                            </div>
                            <div class="form-group" id="dates">
                                <label class="control-label">
                                    Dates <span class="symbol required"></span>
                                </label>
                                <asp:TextBox ID="txtdate_hr_edit" runat="server" CssClass="chosen-disabled form-control"
                                    ClientIDMode="Static" BackColor="White"></asp:TextBox>
                            </div>
                            <div class="form-group" id="dateranges" style="display: none">
                                <label class="control-label">
                                    Dates <span class="symbol required"></span>
                                </label>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="col-sm-6" style="padding-left: 0px !important; padding-right: 0px !important;">
                                            <asp:TextBox ID="txtsdate_edit" runat="server" CssClass="chosen-disabled form-control" ClientIDMode="Static" BackColor="White"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-1">
                                            <span>to</span>
                                        </div>
                                        <div class="col-sm-5" style="padding-left: 0px !important; padding-right: 0px !important;">
                                            <asp:TextBox ID="txtedate_edit" runat="server" CssClass="chosen-disabled form-control" ClientIDMode="Static" BackColor="White"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                    Period <span class="symbol required"></span>
                                </label>
                                <asp:DropDownList ID="ddlper_hr" runat="server" CssClass="form-control"
                                    ClientIDMode="Static" DataTextField="period" DataValueField="period_id">
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                    Reason <span class="symbol required"></span>
                                </label>
                                <asp:TextBox ID="txtreason_hr" runat="server" TextMode="MultiLine"
                                    CssClass="form-control" ClientIDMode="Static" MaxLength="1" Rows="2"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                    Your Job Will be coverd by <span class="symbol required"></span>
                                </label>
                                <asp:DropDownList ID="ddljobc_hr" runat="server" CssClass="form-control"
                                    ClientIDMode="Static" DataTextField="Name" DataValueField="user_id">
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                    Contact No <span class="symbol required"></span>
                                </label>
                                <asp:TextBox ID="txtphone_hr" runat="server" CssClass="form-control"
                                    ClientIDMode="Static"></asp:TextBox>
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
                            <asp:Button ID="up_leaves" runat="server" Text="Update" CssClass="btn btn-success" OnClientClick="leave_edit()" OnClick="up_leaves_Click" />
                            <asp:Button ID="c_update" runat="server" Text="Cancel" CssClass="btn btn-success" OnClick="c_update_Click" />
                        </div>
                        <div class="col-md-4">
                        </div>
                    </div>
                    <%-- </form>--%>
                </div>
            </div>
            <!-- end: edit Leave HR -->
        </div>
    </div>
</asp:Content>
