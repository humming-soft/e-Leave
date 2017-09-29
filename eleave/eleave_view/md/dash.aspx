<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dash.aspx.cs" Inherits="eleave_view.md.dash" MasterPageFile="~/md/md.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header">
        <h1>Dashboard</h1>
    </div>
    <!-- start: DIALER -->
    <div class="row">
        <div class="col-sm-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <i class=" icon-bar-chart "></i>
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
                    <div class="col-sm-12">
                        <div id="container" style="min-width: 310px; height: 400px; margin: 0 auto"></div>
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

</asp:Content>
