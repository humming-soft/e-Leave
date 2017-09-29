<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hrdash.aspx.cs" Inherits="eleave_view.hr.hrdash" MasterPageFile="~/hr/hr.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function cfnot() {
            swal({
                title: 'Warning!',
                text: 'Perform Carryforward!',
                type: 'warning',
                allowEscapeKey: false,
                allowOutsideClick: false
            },
                function () {
                    window.location = "cf.aspx";
                });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header">
        <h1>Dashboard</h1>
    </div>
    <!-- start: PAGE CONTENT -->
    <!-- start: DIALER -->
    <div class="row">
        <div class="col-sm-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <i class=" clip-paperplane "></i>
                    Leaves
                                <div class="panel-tools">
                                    <a class="btn btn-xs btn-link panel-collapse collapses" href="#"></a>
                                    <a class="btn btn-xs btn-link panel-expand" href="#">
                                        <i class="icon-resize-full"></i>
                                    </a>
                                    <a class="btn btn-xs btn-link panel-close" href="#">
                                        <i class="icon-remove"></i>
                                    </a>
                                </div>
                </div>
                <div class="panel-body">
                    <div id="ann1">
                        <center>
                            <div id="ann"></div>
                        </center>
                    </div>
                    <div id="med1">
                        <center>
                            <div id="med"></div>
                        </center>
                    </div>
                    <div id="repl1">
                        <center>
                            <div id="repl"></div>
                        </center>
                    </div>
                    <div id="mrg1">
                        <center>
                            <div id="mrg"></div>
                        </center>
                    </div>
                    <div id="pl1">
                        <center>
                            <div id="pl"></div>
                        </center>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- End: DIALER -->
    <!-- start: FULL CALENDAR -->
    <div class="row">
        <div class="col-sm-12">
            <!-- start: FULL CALENDAR PANEL -->
            <div class="panel panel-default">
                <div class="panel-heading">
                    <i class="clip-calendar"></i>
                    Calendar
									<div class="panel-tools">
                                        <a class="btn btn-xs btn-link panel-collapse collapses" href="#"></a>
                                        <a class="btn btn-xs btn-link panel-expand" href="#">
                                            <i class="icon-resize-full"></i>
                                        </a>
                                        <a class="btn btn-xs btn-link panel-close" href="#">
                                            <i class="icon-remove"></i>
                                        </a>
                                    </div>
                </div>
                <div class="panel-body">
                    <div class="col-sm-12">
                        <div id='calendar'></div>
                    </div>
                </div>
            </div>
            <!-- end: FULL CALENDAR PANEL -->
        </div>
    </div>

    <div id="event-management" class="modal fade" tabindex="-1" data-width="760" style="display: none;">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;
                    </button>
                    <h4 class="modal-title" id="modal-title">Holiday Details</h4>
                </div>
                <div class="modal-body" id="modal-body">
                    <h2 id="mbody"></h2>
                </div>
                <div class="modal-footer">
                    <button type="button" data-dismiss="modal" class="btn btn-light-grey">
                        Close
                    </button>
                </div>
            </div>
        </div>
    </div>

    <!-- end: PAGE CONTENT-->
</asp:Content>
