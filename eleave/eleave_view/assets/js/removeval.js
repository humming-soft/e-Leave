var removeval = function () {
    var removeFormValidator = function () {
        var form = $('#form1');
        //var errorHandler = $('.errorHandler', form);

       // $('[name="ctl00$ContentPlaceHolder1$txtreason"]').rules('remove');
        $('[name="ctl00$ContentPlaceHolder1$txtphone"]').rules("remove");
        //$('[name="ctl00$ContentPlaceHolder1$txtdate"],[name="ctl00$ContentPlaceHolder1$txtreason"], [name="ctl00$ContentPlaceHolder1$ddljobc"],[name="ctl00$ContentPlaceHolder1$txtphone"]').each(function () {
        //    $(this).rules('remove');
        //});

        //$("#form1").valid();  // validation test only
        //$('[name="TextBox1"], [name="TextBox2"],[name="DropDownList2"]').each(function () {
        //    $(this).rules('remove');
        //});
        form.valid();
    };
    return {
        //main function to initiate template pages
        init: function () {
            //alert('remove');
            removeFormValidator();
        }
    };
}();