var TableData = function () {
    //function to initiate DataTable
    //DataTable is a highly flexible tool, based upon the foundations of progressive enhancement, 
    //which will add advanced interaction controls to any HTML table
    //For more information, please visit https://datatables.net/
    var runDataTable = function () {
       // var oTable = $('#grd_app_rej').dataTable({
        var oTable = $("[id$=grd_app_rej]").dataTable({
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
        $('#grd_app_rej_wrapper .dataTables_filter input').addClass("form-control input-sm").attr("placeholder", "Search");
        // modify table search input
        $('#grd_app_rej_wrapper .dataTables_length select').addClass("m-wrap small");
        // modify table per page dropdown
    };

    var runDataTable1 = function () {
        var oTable = $('#grd_users').dataTable({
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
        $('#grd_users_wrapper .dataTables_filter input').addClass("form-control input-sm").attr("placeholder", "Search");
        // modify table search input
        $('#grd_users_wrapper .dataTables_length select').addClass("m-wrap small");
        // modify table per page dropdown
    };

    var runDataTable2 = function () {
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

    var runDataTable3 = function () {
        var oTable = $('#grdcancelappr').dataTable({
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
        $('#grdcancelappr_wrapper .dataTables_filter input').addClass("form-control input-sm").attr("placeholder", "Search");
        // modify table search input
        $('#grdcancelappr_wrapper .dataTables_length select').addClass("m-wrap small");
        // modify table per page dropdown
    };

    var runDataTable4 = function () {
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

    var runDataTable5 = function () {
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

    var runDataTable6 = function () {
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

    var runDataTable7 = function () {
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
        }
    };
}();