<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="holidays_upload.aspx.cs" Inherits="eleave_view.hr.holidays_upload" MasterPageFile="~/hr/hr.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function success() {
            swal({
                title: 'Success!',
                text: 'Succesfully Uploaded Holidays!',
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
                text: 'Check the Upload Format',
                type: 'error',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>
    <script type="text/javascript">
        function errornoval() {
            swal({
                title: 'Error!',
                text: 'You have some form errors!',
                type: 'error',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>
    <style type="text/css">
        .cust {
            width: 30%;
        }
    </style>
    <style type="text/css">
        .cust1 {
            width: 50%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header">
        <h1>Upload Holidays List<small><a href="cholidays_hr.aspx"> Clear Hummingsoft Holidays /</a></small><small><a href="cholidays.aspx"> Clear Summersoft Holidays</a></small></h1>
    </div>
    <div class="row">
        <div class="col-md-12">
            <!-- start: Upload Holidays HR -->
            <div class="panel panel-default">
                <div class="panel-heading">
                    <i class="clip-upload-2"></i>Upload Holiday List
                    <div class="panel-tools">
                        <a class="btn btn-xs btn-link panel-collapse collapses" href="#"></a><a class="btn btn-xs btn-link panel-expand"
                            href="#"><i class="icon-resize-full"></i></a><a class="btn btn-xs btn-link panel-close"
                                href="#"><i class="icon-remove"></i></a>
                    </div>
                </div>
                <div class="panel-body">
                    <h4 style="text-align: justify">Format for Uploading the data,copy all the cells in the excel including the header and paste it into the below shown box.
                            The columns must in the format Event Name,Event Date(yyyy-mm-dd),Event Color</h4>
                    <img src="../assets/images/leaves.jpg" height="auto" width="100%" />
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
                                    Region <span class="symbol required"></span>
                                </label>
                                <asp:DropDownList ID="ddlreg" runat="server" CssClass="form-control cust" ClientIDMode="Static" DataTextField="region" DataValueField="region_id"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label class="control-label">
                                    Holidays <span class="symbol required"></span>
                                </label>
                                <asp:TextBox ID="txtholidays_hr" runat="server" TextMode="MultiLine"
                                    CssClass="form-control cust1" ClientIDMode="Static" MaxLength="1" Rows="2"></asp:TextBox>
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
                            <asp:Button ID="btnreq_hr" runat="server" Text="Upload" CssClass="btn btn-success" OnClientClick="bulkvali()" OnClick="btnreq_hr_Click" />
                            <%--OnClientClick="leavevali()" onclick="btnreq_Click"--%>
                        </div>
                        <div class="col-md-4">
                        </div>
                    </div>
                </div>
            </div>
            <!-- end: Upload Holidays HR -->
        </div>
    </div>
</asp:Content>
