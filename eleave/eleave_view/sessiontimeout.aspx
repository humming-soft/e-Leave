<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sessiontimeout.aspx.cs" Inherits="eleave_view.sessiontimeout" %>

<!DOCTYPE html>
<!-- Template Name: Clip-One - Responsive Admin Template build with Twitter Bootstrap 3 Version: 1.0 Author: ClipTheme -->
<!--[if IE 8]><html class="ie8 no-js" lang="en"><![endif]-->
<!--[if IE 9]><html class="ie9 no-js" lang="en"><![endif]-->
<!--[if !IE]><!-->
<html lang="en" class="no-js">
<!--<![endif]-->
<!-- start: HEAD -->
<head>
    <title></title>
    <!-- start: META -->
    <meta charset="utf-8" />
    <!--[if IE]><meta http-equiv='X-UA-Compatible' content="IE=edge,IE=9,IE=8,chrome=1" /><![endif]-->
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimum-scale=1.0, maximum-scale=1.0">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta content="" name="description" />
    <meta content="" name="author" />
    <!-- end: META -->
    <!-- start: MAIN CSS -->
    <link rel="shortcut icon" href="assets/images/favicon.ico" type="image/x-icon">
    <link href="assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" media="screen">
    <link href="assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="assets/fonts/style.css" rel="stylesheet" />
    <link href="assets/css/main.css" rel="stylesheet" />
    <link href="assets/css/main-responsive.css" rel="stylesheet" />
    <link href="assets/plugins/iCheck/skins/all.css" rel="stylesheet" />
    <link href="assets/plugins/perfect-scrollbar/src/perfect-scrollbar.css" rel="stylesheet" />
    <link href="assets/css/theme_light.css" rel="stylesheet" id="skin_color" />s
    <!--[if IE 7]>
		<link rel="stylesheet" href="assets/plugins/font-awesome/css/font-awesome-ie7.min.css">
		<![endif]-->
    <!-- end: MAIN CSS -->
    <!-- start: CSS REQUIRED FOR THIS PAGE ONLY -->
    <!-- end: CSS REQUIRED FOR THIS PAGE ONLY -->
    <link rel="shortcut icon" href="favicon.ico" />

    <script type="text/javascript">

        function preventBack() {
            window.history.forward();
        }

        setTimeout("preventBack()", 0);

        window.onunload = function () {
            null
        };

        </script>

</head>

<!-- end: HEAD -->
<!-- start: BODY -->
<body class="error-full-page">
    <div id="sound" style="z-index: -1;"></div>
    <img id="background" src="#" />
    <div id="cholder">
        <canvas id="canvas"></canvas>
    </div>
    <!-- start: PAGE -->
    <div class="container">
        <div class="row">
            <!-- start: 404 -->
            <div class="col-sm-12 page-error">
                <div class="error-number teal">
                    Session Time Out
				
                </div>
                <div class="error-details col-sm-6 col-sm-offset-3">
                    <h3>Oops! Your Session has been expired</h3>
                    <p>
                        Unfortunately the page you were looking for could not be found.
						
                        <br>
                        <a href="MainPage.aspx" class="btn btn-teal btn-return">Click here to Login Again
							</a>
                        <br>
                    </p>

                </div>
            </div>
            <!-- end: 404 -->
        </div>
    </div>
    <!-- end: PAGE -->
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
    <script src="assets/plugins/rainyday/rainyday.js"></script>
    <script src="assets/js/utility-error404.js"></script>
    <!-- end: JAVASCRIPTS REQUIRED FOR THIS PAGE ONLY -->
    <script>
        jQuery(document).ready(function () {
            Main.init();
            Error404.init();
        });
		</script>
</body>
<!-- end: BODY -->
</html>
