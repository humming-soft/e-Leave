﻿/*
Author : Agaile
14/01/2016
Custom user addition form validation script
*/
var userval = function () {
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
    var runUserFormValidator = function () {
        var form = $('#form1');
        var errorHandler = $('.errorHandler', form);
        jQuery.validator.addMethod("fullname", function (value, element) {
            return this.optional(element) || /^[a-z\s]+$/i.test(value);
        }, "Only alphabetical characters");

        jQuery.validator.addMethod("mail", function (value, element) {
            return this.optional(element) || /^\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b$/i.test(value);
        }, "Enter Valid Email id");
        form.validate({
            rules: {
                ctl00$ContentPlaceHolder1$txtname: {
                    minlength: 3,
                    maxlength: 30,
                    fullname: true,
                    required: true
                },
                ctl00$ContentPlaceHolder1$txtuname: {
                    minlength: 3,
                    maxlength: 30,
                    alphanumeric: true,
                    required: true
                    
                },
                ctl00$ContentPlaceHolder1$txtemail: {
                    required: true,
                    mail: true,
                    maxlength: 30
                },
                ctl00$ContentPlaceHolder1$ddlgender: {
                    required: true
                },
                ctl00$ContentPlaceHolder1$txtdoj: {
                    required: true
                },
                ctl00$ContentPlaceHolder1$txtdoje: {
                    required: true
                },
                ctl00$ContentPlaceHolder1$txtdob: {
                    required: true
                },
                ctl00$ContentPlaceHolder1$ddldep: {
                    required: true
                },
                ctl00$ContentPlaceHolder1$ddlgrade: {
                    required: true
                },
                ctl00$ContentPlaceHolder1$ddldesi: {
                    required: true
                },
                ctl00$ContentPlaceHolder1$ddlregion: {
                    required: true
                },
                ctl00$ContentPlaceHolder1$txtcategory: {
                    required: true
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
            runUserFormValidator();
        }
    };
}();