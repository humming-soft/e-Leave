var TableData = function () {
    //function to initiate DataTable
    //DataTable is a highly flexible tool, based upon the foundations of progressive enhancement, 
    //which will add advanced interaction controls to any HTML table
    //For more information, please visit https://datatables.net/
    var runDataTable = function () {
        var oTable = $('#grd_users').dataTable({
            "aoColumnDefs": [{
                'bSortable': false,
                "aTargets": [0,9,10]
            }],
            "oLanguage": {
                "sLengthMenu": "Show _MENU_ Rows",
                "sSearch": "",
                "pagingType": "full_numbers"
            },
            "aaSorting": [
                [1, 'asc']
            ],
            "aLengthMenu": [
                [5, 10, 15, 20, -1],
                [5, 10, 15, 20, "All"] // change per page values here
            ],
            // set the initial value
            "iDisplayLength": 10,
        });
        $('#grd_users_wrapper .dataTables_filter input').addClass("form-control input-sm").attr("placeholder", "Search");
        // modify table search input
        $('#grd_users_wrapper .dataTables_length select').addClass("m-wrap small");
        // modify table per page dropdown
    };

    var runDataTable1 = function () {
        var oTable = $('#grd_userleaves').dataTable({
            "aoColumnDefs": [{
                "aTargets": [0]
            }],
            "oLanguage": {
                "sLengthMenu": "Show _MENU_ Rows",
                "sSearch": "",
                "pagingType": "full_numbers"
            },
            "aaSorting": [
                [0, 'asc']
            ],
            "aLengthMenu": [
                [5, 10, 15, 20, -1],
                [5, 10, 15, 20, "All"] // change per page values here
            ],
            // set the initial value
            "iDisplayLength": 10,
        });
        $('#grd_userleaves_wrapper .dataTables_filter input').addClass("form-control input-sm").attr("placeholder", "Search");
        // modify table search input
        $('#grd_userleaves_wrapper .dataTables_length select').addClass("m-wrap small");
        // modify table per page dropdown
    };

    var runDataTable2 = function () {
        var oTable = $('#status_hr').dataTable({
            "aoColumnDefs": [{
                "aTargets": [0]
            }],
            "oLanguage": {
                "sLengthMenu": "Show _MENU_ Rows",
                "sSearch": "",
                "pagingType": "full_numbers"
            },
            "aaSorting": [
                [0, 'asc']
            ],
            "aLengthMenu": [
                [5, 10, 15, 20, -1],
                [5, 10, 15, 20, "All"] // change per page values here
            ],
            // set the initial value
            "iDisplayLength": 10,
        });
        $('#status_hr_wrapper .dataTables_filter input').addClass("form-control input-sm").attr("placeholder", "Search");
        // modify table search input
        $('#status_hr_wrapper .dataTables_length select').addClass("m-wrap small");
        // modify table per page dropdown
    };

    var runDataTable3 = function () {
        //var oTable = $('#grd_forward').dataTable({
        var oTable = $("[id$=grd_forward]").dataTable({
            "aoColumnDefs": [{
                'bSortable': false,
                "aTargets": [0,8,9,10,11,12,13]
            }],
            "oLanguage": {
                "sLengthMenu": "Show _MENU_ Rows",
                "sSearch": "",
                "pagingType": "full_numbers"
            },
            "aaSorting": [
                [1, 'asc']
            ],
            "aLengthMenu": [
                [5, 10, 15, 20, -1],
                [5, 10, 15, 20, "All"] // change per page values here
            ],
            // set the initial value
            "iDisplayLength": 10,
        });
        $('#grd_forward_wrapper .dataTables_filter input').addClass("form-control input-sm").attr("placeholder", "Search");
        // modify table search input
        $('#grd_forward_wrapper .dataTables_length select').addClass("m-wrap small");
        // modify table per page dropdown
    };

    var runDataTable4 = function () {
        var oTable = $('#grd_cancel_hr').dataTable({
            "aoColumnDefs": [{
                "aTargets": [0]
            }],
            "oLanguage": {
                "sLengthMenu": "Show _MENU_ Rows",
                "sSearch": "",
                "pagingType": "full_numbers"
            },
            "aaSorting": [
                [0, 'asc']
            ],
            "aLengthMenu": [
                [5, 10, 15, 20, -1],
                [5, 10, 15, 20, "All"] // change per page values here
            ],
            // set the initial value
            "iDisplayLength": 10,
        });
        $('#grd_cancel_hr_wrapper .dataTables_filter input').addClass("form-control input-sm").attr("placeholder", "Search");
        // modify table search input
        $('#grd_cancel_hr_wrapper .dataTables_length select').addClass("m-wrap small");
        // modify table per page dropdown
    };

    var runDataTable5 = function () {
        var oTable = $('#grd_cflist').dataTable({
            "aoColumnDefs": [{
                "aTargets": [0]
            }],
            "oLanguage": {
                "sLengthMenu": "Show _MENU_ Rows",
                "sSearch": "",
                "pagingType": "full_numbers"
            },
            "aaSorting": [
                [0, 'asc']
            ],
            "aLengthMenu": [
                [5, 10, 15, 20, -1],
                [5, 10, 15, 20, "All"] // change per page values here
            ],
            // set the initial value
            "iDisplayLength": 10,
        });
        $('#grd_cflist_wrapper .dataTables_filter input').addClass("form-control input-sm").attr("placeholder", "Search");
        // modify table search input
        $('#grd_cflist_wrapper .dataTables_length select').addClass("m-wrap small");
        // modify table per page dropdown
    };


    var runDataTable6 = function () {
        var oTable = $('#grd_ltaken').dataTable({
            "aoColumnDefs": [{
                "aTargets": [0]
            }],
            "oLanguage": {
                "sLengthMenu": "Show _MENU_ Rows",
                "sSearch": "",
                "pagingType": "full_numbers"
            },
            "aaSorting": [
                [0, 'asc']
            ],
            "aLengthMenu": [
                [5, 10, 15, 20, -1],
                [5, 10, 15, 20, "All"] // change per page values here
            ],
            // set the initial value
            "iDisplayLength": 10,
        });
        $('#grd_ltaken_wrapper .dataTables_filter input').addClass("form-control input-sm").attr("placeholder", "Search");
        // modify table search input
        $('#grd_ltaken_wrapper .dataTables_length select').addClass("m-wrap small");
        // modify table per page dropdown
    };

    var runDataTable7 = function () {
        var oTable = $('#grd_bal').dataTable({
            "aoColumnDefs": [{
                "aTargets": [0]
            }],
            "oLanguage": {
                "sLengthMenu": "Show _MENU_ Rows",
                "sSearch": "",
                "pagingType": "full_numbers"
            },
            "aaSorting": [
                [0, 'asc']
            ],
            "aLengthMenu": [
                [5, 10, 15, 20, -1],
                [5, 10, 15, 20, "All"] // change per page values here
            ],
            // set the initial value
            "iDisplayLength": 10,
        });
        $('#grd_bal_wrapper .dataTables_filter input').addClass("form-control input-sm").attr("placeholder", "Search");
        // modify table search input
        $('#grd_bal_wrapper .dataTables_length select').addClass("m-wrap small");
        // modify table per page dropdown
    };


    var runDataTable8 = function () {
        var oTable = $('#grd_cflistr').dataTable({
            "aoColumnDefs": [{
                "aTargets": [0]
            }],
            "oLanguage": {
                "sLengthMenu": "Show _MENU_ Rows",
                "sSearch": "",
                "pagingType": "full_numbers"
            },
            "aaSorting": [
                [0, 'asc']
            ],
            "aLengthMenu": [
                [5, 10, 15, 20, -1],
                [5, 10, 15, 20, "All"] // change per page values here
            ],
            // set the initial value
            "iDisplayLength": 10,
        });
        $('#grd_cflistr_wrapper .dataTables_filter input').addClass("form-control input-sm").attr("placeholder", "Search");
        // modify table search input
        $('#grd_cflistr_wrapper .dataTables_length select').addClass("m-wrap small");
        // modify table per page dropdown
    };

    var runDataTable9 = function () {
        var oTable = $('#grd_log').dataTable({
            "aoColumnDefs": [{
                "aTargets": [0]
            }],
            "oLanguage": {
                "sLengthMenu": "Show _MENU_ Rows",
                "sSearch": "",
                "pagingType": "full_numbers"
            },
            "aaSorting": [
                [0, 'asc']
            ],
            "aLengthMenu": [
                [5, 10, 15, 20, -1],
                [5, 10, 15, 20, "All"] // change per page values here
            ],
            // set the initial value
            "iDisplayLength": 10,
        });
        $('#grd_log_wrapper .dataTables_filter input').addClass("form-control input-sm").attr("placeholder", "Search");
        // modify table search input
        $('#grd_log_wrapper .dataTables_length select').addClass("m-wrap small");
        // modify table per page dropdown
    };

    var runDataTable12 = function () {
        var oTable = $('#grd_leave_dwnld').dataTable({
            "aoColumnDefs": [{
                "aTargets": [0]
            }],
            "oLanguage": {
                "sLengthMenu": "Show _MENU_ Rows",
                "sSearch": "",
                "pagingType": "full_numbers"
            },
            "aaSorting": [
                [0, 'asc']
            ],
            "aLengthMenu": [
                [5, 10, 15, 20, -1],
                [5, 10, 15, 20, "All"] // change per page values here
            ],
            // set the initial value
            "iDisplayLength": 10,
        });
        $('#grd_leave_dwnld_wrapper .dataTables_filter input').addClass("form-control input-sm").attr("placeholder", "Search");
        // modify table search input
        $('#grd_leave_dwnld_wrapper .dataTables_length select').addClass("m-wrap small");
        // modify table per page dropdown
    };

    var runDataTable21 = function () {
        //var oTable = $('#grd_forward').dataTable({
        var oTable = $("[id$=approved_hr]").dataTable({
            "aoColumnDefs": [{
                'bSortable': false,
                "aTargets": [0, 8, 9, 10, 11, 12, 13]
            }],
            "oLanguage": {
                "sLengthMenu": "Show _MENU_ Rows",
                "sSearch": "",
                "pagingType": "full_numbers"
            },
            "aaSorting": [
                [1, 'asc']
            ],
            "aLengthMenu": [
                [5, 10, 15, 20, -1],
                [5, 10, 15, 20, "All"] // change per page values here
            ],
            // set the initial value
            "iDisplayLength": 10,
        });
        $('#approved_hr_wrapper .dataTables_filter input').addClass("form-control input-sm").attr("placeholder", "Search");
        // modify table search input
        $('#approved_hr_wrapper .dataTables_length select').addClass("m-wrap small");
        // modify table per page dropdown
    };


   return {
        //main function to initiate template pages
        init: function () {
            runDataTable();
            runDataTable1();
            runDataTable2();
            runDataTable3();
            runDataTable4();
            runDataTable5();
            runDataTable6();
            runDataTable7();
            runDataTable8();
            runDataTable9();
            runDataTable12();
            //runDataTable21();
        }
    };
}();