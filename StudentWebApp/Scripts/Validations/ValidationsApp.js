 
$("#txtFirstName").blur(function () {
    var regex = new RegExp("^[a-zA-Z0-9\s]+$");
    // input fields have the value
    var firstName = $('#txtFirstName').val();
    var result = regex.test(firstName.trim());
    debugger;
    if (firstName.trim().length == 0)
    {
       // label has only text, not value
        $('#hdnFirstName').text("Please enter value for First Name");
        var hdnFirstName = $('#hdnFirstName').text();
        return false;
    }
    else if (regex.test(firstName.trim()))
    {
        $('#hdnFirstName').text('');
       console.log(firstName + "valid");
        return true;
    }
    else if (!regex.test(firstName.trim()))
    {
        $('#hdnFirstName').text("First Name can be numbers or characters");
        var hdnFirstName = $('#hdnFirstName').text();
        console.log(firstName + "in-valid");
        return false;
    }
});

$("#txtLastName").blur(function () {
    var regex = new RegExp("^[a-zA-Z0-9\s]+$");
    // input fields have the value
    var lastName = $('#txtLastName').val();
    var result = regex.test(lastName.trim());
    debugger;
    if (lastName.trim().length == 0) {
        // label has only text, not value
        $('#hdnLastName').text("Please enter value for Last Name");
        var hdnLastName = $('#hdnLastName').text();
        return false;
    }
    else if (regex.test(lastName.trim())) {
        $('#hdnLastName').text('');
        console.log(lastName + "valid");
        return true;
    }
    else if (!regex.test(lastName.trim())) {
        $('#hdnLastName').text("Last Name can be numbers or characters");
        var hdnLastName = $('#hdnLastName').text();
        console.log(lastName + "in-valid");
        return false;
    }
});

$("#txtEmail").blur(function () {
    var x = $("#txtEmail").val();
    var atpos = x.indexOf("@");
    var dotpos = x.lastIndexOf(".");
    if (atpos < 1 || dotpos < atpos + 2 || dotpos + 2 >= x.length) {
        alert("Not a valid e-mail address");
        return false;
    }
});

$(function () {
    $("#datepicker").datepicker({ dateFormat: "dd-mm-yy" });
});