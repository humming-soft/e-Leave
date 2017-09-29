<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="eleave_view.user.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    function Showalert() {
        swal({
            title: 'Congratulations!',
            text: 'Your message has been succesfully sent',
            type: 'success',
            allowEscapeKey: false,
            allowOutsideClick: false
        });
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <!-- start: PAGE CONTENT -->
					<div class="row">
						<div class="col-sm-6">
							<!-- start: DATE/TIME PICKER PANEL -->
							<div class="panel panel-default">
								<div class="panel-heading">
									<i class="icon-external-link-sign"></i>
									Date/Time Picker
									<div class="panel-tools">
										<a class="btn btn-xs btn-link panel-collapse collapses" href="#">
										</a>
										<a class="btn btn-xs btn-link panel-config" href="#panel-config" data-toggle="modal">
											<i class="icon-wrench"></i>
										</a>
										<a class="btn btn-xs btn-link panel-refresh" href="#">
											<i class="icon-refresh"></i>
										</a>
										<a class="btn btn-xs btn-link panel-expand" href="#">
											<i class="icon-resize-full"></i>
										</a>
										<a class="btn btn-xs btn-link panel-close" href="#">
											<i class="icon-remove"></i>
										</a>
									</div>
								</div>
								<div class="panel-body">
									<p>
										Date Picker
									</p>
									<div class="input-group">
										<asp:TextBox ID="bootdate" runat="server" CssClass="form-control date-picker"></asp:TextBox>
										<span class="input-group-addon"> <i class="icon-calendar"></i> </span>
									</div>
								</div>
                                <div class="panel-body">
                                <p>Send Mail</p>
                                    <div class="input-group">
                                     <asp:Button ID="Button1" runat="server" Text="Send Mail" onclick="Button1_Click" />
                                    </div>
                                </div>
							</div>
							<!-- end: DATE/TIME PICKER PANEL -->
						</div>
					</div>
					<!-- end: PAGE CONTENT-->
</asp:Content>
