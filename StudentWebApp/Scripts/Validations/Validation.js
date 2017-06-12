/// <reference path="../jquery.validate.min.js" />

//$('#btnSave').click(function () {
$(function () {
    debugger;
    console.log('button click');
    //alert('clicked');
    $('#form1').validate({
        rules: {
            firstName: {
                required: true
            }
        },
        messages: {
            firstName: {
                required: 'Client side first name'
            }
        }
        });
 });