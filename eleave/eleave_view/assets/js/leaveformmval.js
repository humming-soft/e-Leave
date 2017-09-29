/*
Author : Agaile
06/01/2015
Custom leave application form validation script for medical
*/
var leavevalm = function () {
    var runSetDefaultValidation = function () {
        $.validator.setDefaults({
            errorElement: "span", // contain the error msg in a small tag
            errorClass: 'help-block',
            errorPlacement: function (error, element) { // render error placement for each input type
                if (element.attr("type") == "radio" || element.attr("type") == "checkbox") { // for chosen elements, need to insert the error after the chosen container
                    error.insertAfter($(element).closest('.form-group').children('div').children().last());
                } else if (element.attr("name") == "card_expiry_mm" || element.attr("name") == "card_expiry_yyyy") {
                    error.appendTo($(element).closest('.form-group').children('div'));
                } else {
                    error.insertAfter(element);
                    // for other inputs, just perform default behavior
                }
            },
            ignore: ':hidden',
            highlight: function (element) {
                $(element).closest('.help-block').removeClass('valid');
                // display OK icon
                $(element).closest('.form-group').removeClass('has-success').addClass('has-error').find('.symbol').removeClass('ok').addClass('required');
                // add the Bootstrap error class to the control group
            },
            unhighlight: function (element) { // revert the change done by hightlight
                $(element).closest('.form-group').removeClass('has-error');
                // set error class to the control group
            },
            success: function (label, element) {
                label.addClass('help-block valid');
                // mark the current input as valid and display OK icon
                $(element).closest('.form-group').removeClass('has-error');
            },
            highlight: function (element) {
                $(element).closest('.help-block').removeClass('valid');
                // display OK icon
                $(element).closest('.form-group').addClass('has-error');
                // add the Bootstrap error class to the control group
            },
            unhighlight: function (element) { // revert the change done by hightlight
                $(element).closest('.form-group').removeClass('has-error');
                // set error class to the control group
            }
        });
    };
    var runLeaveFormValidatorm = function () {
         var form = $('#form1');
         var errorHandler = $('.errorHandler', form);
         $.validator.addMethod('filesize', function (value, element, param) {
             // param = size (in bytes) 
             // element = element to validate (<input>)
             // value = value of the element (file name)
             return this.optional(element) || (element.files[0].size <= param)
         }, "File must be less than 3 Mb");
        form.validate({
            rules: {
                ctl00$ContentPlaceHolder1$ddlltype: {
                    required: true
                },
                ctl00$ContentPlaceHolder1$txtdate: {
                    required: true
                },
                ctl00$ContentPlaceHolder1$ddlper: {
                    required: true
                },
                ctl00$ContentPlaceHolder1$txtreason: {
                    required: true
                },
                ctl00$ContentPlaceHolder1$ddljobc: {
                    required: true
                },
                ctl00$ContentPlaceHolder1$txtphone: {
                    required: true,
                    digits: true,
                    minlength: 10,
                    maxlength: 10
                },
                ctl00$ContentPlaceHolder1$fupload: {
                    required: true,
                    filesize: 3145728,
                    accept: "application/pdf"
                }
            },
            submitHandler: function (form) {
                errorHandler.hide();
                form.submit();
            },
            invalidHandler: function (event, validator) { //display error alert on form submit
                errorHandler.show();
            }
        });
    };
    return {
        //main function to initiate template pages
        init: function () {
            runSetDefaultValidation();
            runLeaveFormValidatorm();
            
        }
    };
}();