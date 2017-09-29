<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="eleave_view.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>e - Leave</title>
    <script type="text/javascript">
        function DisableBack() {
            window.history.forward();
        }
        DisableBack();
        window.onload = DisableBack;
        window.onpageshow = function (evt) {
            if (evt.persisted) DisableBack();
        }
        window.onunload = function () { void (0); }
    </script>
    <!-- start: META -->
    <meta charset="utf-8" />
    <!--[if IE]><meta http-equiv='X-UA-Compatible' content="IE=edge,IE=9,IE=8,chrome=1" /><![endif]-->
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimum-scale=1.0, maximum-scale=1.0" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    <!-- end: META -->
    <!-- start: MAIN CSS -->
    <link rel="shortcut icon" href="assets/images/favicon.ico" type="image/x-icon">
    <link href="assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" media="screen" />
    <link rel="stylesheet" href="assets/plugins/font-awesome/css/font-awesome.min.css" />
    <link rel="stylesheet" href="assets/fonts/style.css" />
    <link rel="stylesheet" href="assets/css/main.css" />
    <link rel="stylesheet" href="assets/css/main-responsive.css" />
    <link rel="stylesheet" href="assets/plugins/iCheck/skins/all.css" />
    <link rel="stylesheet" href="assets/plugins/perfect-scrollbar/src/perfect-scrollbar.css" />
    <link rel="stylesheet" href="assets/css/theme_light.css" id="skin_color" />
    <!--[if IE 7]>
		<link rel="stylesheet" href="assets/plugins/font-awesome/css/font-awesome-ie7.min.css">
		<![endif]-->
    <!-- end: MAIN CSS -->
    <!-- start: CSS REQUIRED FOR THIS PAGE ONLY -->
    <!-- end: CSS REQUIRED FOR THIS PAGE ONLY -->

</head>
<!-- start: BODY -->
<body class="login example2">
    <div class="main-login col-sm-4 col-sm-offset-4">
        <div class="logo">
            <i class="clip-IE"></i>-Leave
        </div>
        <!-- start: LOGIN BOX -->
        <div class="box-login">
            <h3>Sign in to your account</h3>
            <p>
                Please enter your Username and Password to log in.
            </p>
            <form id="form1" class="form-login" runat="server">
                <div class="errorHandler alert alert-danger no-display" id="loginerror">
                    <i class="icon-remove-sign"></i>You have some form errors. Please check below.
                </div>
                <div class="errorHandler alert alert-danger" runat="server" id="inval">
                    <i class="icon-remove-sign"></i>The Username and Password you entered don't match.
                </div>
                <fieldset>
                    <div class="form-group">
                        <span class="input-icon">
                            <asp:TextBox ID="username" CssClass="form-control" runat="server" placeholder="Username" onMouseOver="unload();"></asp:TextBox>
                            <i class="icon-user"></i></span>
                    </div>
                    <div class="form-group form-actions">
                        <span class="input-icon">
                            <asp:TextBox ID="password" CssClass="form-control password" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                            <i class="icon-lock"></i></span>
                    </div>
                    <div class="form-actions">
                        <asp:Button ID="logi" CssClass="btn btn-bricky pull-right" runat="server"
                            Text="Login" OnClientClick="vali()" OnClick="logi_Click" />
                    </div>
                </fieldset>
            </form>
        </div>
        <!-- end: LOGIN BOX -->
        <!-- start: COPYRIGHT -->
        <div class="copyright">
            2015 &copy; <i class="clip-IE"></i>-Leave by <a href="http://summersoft.in/" target="_blank"> summersoft pvt ltd.</a>
        </div>
        <!-- end: COPYRIGHT -->
    </div>
    <!-- start: MAIN JAVASCRIPTS -->
    <!--[if lt IE 9]>
		<script src="assets/plugins/respond.min.js"></script>
		<script src="assets/plugins/excanvas.min.js"></script>
		<![endif]-->
    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/plugins/jquery-ui/jquery-ui-1.10.2.custom.min.js"></script>
    <script src="assets/plugins/bootstrap/js/bootstrap.min.js"></script>
    <script src="assets/plugins/blockUI/jquery.blockUI.js"></script>
    <script src="assets/plugins/iCheck/jquery.icheck.min.js"></script>
    <script src="assets/plugins/perfect-scrollbar/src/jquery.mousewheel.js"></script>
    <script src="assets/plugins/perfect-scrollbar/src/perfect-scrollbar.js"></script>
    <script src="assets/js/main.js"></script>
    <!-- end: MAIN JAVASCRIPTS -->
    <!-- start: JAVASCRIPTS REQUIRED FOR THIS PAGE ONLY -->
    <script src="assets/plugins/jquery-validation/dist/jquery.validate.min.js"></script>
    <script src="assets/js/login_custom.js"></script>
    <!-- end: JAVASCRIPTS REQUIRED FOR THIS PAGE ONLY -->
    <script>
        function vali() {
            jQuery(document).ready(function () {
                Main.init();
                Login.init();
            });
        }
    </script>

    <script type="text/javascript">
        function unload() {
            if (document.getElementById("inval"))
            document.getElementById("inval").className = "no-display";
        }
    </script>

</body>
<!-- end: BODY -->
</html>
