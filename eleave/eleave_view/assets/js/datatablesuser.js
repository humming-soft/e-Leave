var TableData = function () {
    //function to initiate DataTable
    //DataTable is a highly flexible tool, based upon the foundations of progressive enhancement, 
    //which will add advanced interaction controls to any HTML table
    //For more information, please visit https://datatables.net/

    var runDataTable = function () {
        var oTable = $('#grd_leaves').dataTable({
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
        $('#grd_leaves_wrapper .dataTables_filter input').addClass("form-control input-sm").attr("placeholder", "Search");
        // modify table search input
        $('#grd_leaves_wrapper .dataTables_length select').addClass("m-wrap small");
        // modify table per page dropdown
    };
    var runDataTable1 = function () {
        var oTable = $('#grd_cancel').dataTable({
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
        $('#grd_cancel_wrapper .dataTables_filter input').addClass("form-control input-sm").attr("placeholder", "Search");
        // modify table search input
        $('#grd_cancel_wrapper .dataTables_length select').addClass("m-wrap small");
        // modify table per page dropdown
    };

    return {
        //main function to initiate template pages
        init: function () {
            runDataTable();
            runDataTable1();
        }
    };
}();