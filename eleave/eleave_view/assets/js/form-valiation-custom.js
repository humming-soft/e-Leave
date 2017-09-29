var FormValidatorCustom = function () {
    var runValidator2 = function () {
        var form2 = $('#form1');
        var errorHandler2 = $('.errorHandler', form2);
        var successHandler2 = $('.successHandler', form2);
        $.validator.addMethod("getEditorValue", function () {
            $("#editor1").val($('.summernote').code());
            if ($("#editor1").val() != "" && $("#editor1").val() != "<br>") {
                $('#editor1').val('');
                return true;
            } else {
                return false;
            }
        }, 'This field is required.');
        form2.validate({
            errorElement: "span", // contain the error msg in a small tag
            errorClass: 'help-block',
            errorPlacement: function (error, element) { // render error placement for each input type
                if (element.attr("type") == "radio" || element.attr("type") == "checkbox") { // for chosen elements, need to insert the error after the chosen container
                    error.insertAfter($(element).closest('.form-group').children('div').children().last());
                } else if (element.hasClass("ckeditor")) {
                    error.appendTo($(element).closest('.form-group'));
                } else {
                    error.insertAfter(element);
                    // for other inputs, just perform default behavior
                }
            },
            ignore: "",
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
                }
        },
        messages: {
            firstname: "Please specify your first name",
            lastname: "Please specify your last name",
            email: {
                required: "We need your email address to contact you",
                email: "Your email address must be in the format of name@domain.com"
            },
            services: {
                minlength: jQuery.format("Please select  at least {0} types of Service")
            }
        },
        invalidHandler: function (event, validator) { //display error alert on form submit
            successHandler2.hide();
            errorHandler2.show();
        },
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
            $(element).closest('.form-group').removeClass('has-error').addClass('has-success').find('.symbol').removeClass('required').addClass('ok');
        },
        submitHandler: function (form) {
            successHandler2.show();
            errorHandler2.hide();
            form2.submit();
        }
    });
    $('.summernote').summernote({
        height: 300,
        tabsize: 2
    });
    CKEDITOR.disableAutoInline = true;
    $('textarea.ckeditor').ckeditor();
};
return {
    //main function to initiate template pages
    init: function () {
        runValidator2();
    }
};
} ();