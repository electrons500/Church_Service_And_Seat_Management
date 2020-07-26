function SaveAlertDialog(senderButton, sendData, callUrl, requestVerificationToken, controller) {
    var a = controller;
    $.ajax({
        url: callUrl,
        type: "POST",
        data: sendData,
        dataType: "json",
        headers: { 'RequestVerificationToken': requestVerificationToken },
        beforeSend: function () {
            //$(preloader).show();//display preloader.
        },
        success: function (data) {
            //$(preloader).hide();//hide preloader.

            if (data.state === 0) {
                DisplaySuccessMessage(data.msg, data.redirectUrlInSuccess,a);// display result returned from method in controller (successful or failed)
            } else {
                DisplayFailureMessage(data.msg);// display result returned from method in controller (successful or failed)
                $(senderButton).attr("disabled", false);//Enable sender button 
            }
        },
        failure: function (response) {
            $(preloader).hide();//hide preloader
            DisplayFailureMessage(response);// display failure response of ajax call
            $(senderButton).attr("disabled", false);//Enable sender button
        }
    });
}


///delete function
function DeleteAlertDialog(senderButton, callUrl, requestVerificationToken,controller) {
    var a = controller;
    $.ajax({
        url: callUrl,
        type: "POST",
        
        dataType: "json",
        headers: { 'RequestVerificationToken': requestVerificationToken },
        beforeSend: function () {
            //$(preloader).show();//display preloader.
        },
        success: function (data) {
            //$(preloader).hide();//hide preloader.

            if (data.state === 0) {
                DisplaySuccessMessage(data.msg, data.redirectUrlInSuccess,a);// display result returned from method in controller (successful or failed)
            } else {
                DisplayFailureMessage(data.msg);// display result returned from method in controller (successful or failed)
                $(senderButton).attr("disabled", false);//Enable sender button 
            }
        },
        failure: function (response) {
            $(preloader).hide();//hide preloader
            DisplayFailureMessage(response);// display failure response of ajax call
            $(senderButton).attr("disabled", false);//Enable sender button
        }
    });
}


//Edit function  Alert dialog display

function UpdateAlertDialog(senderButton, sendData, callUrl, requestVerificationToken, controller) {
    var a = controller
    $.ajax({
        url: callUrl,
        type: "POST",
        data: sendData,
        dataType: "json",
        headers: { 'RequestVerificationToken': requestVerificationToken },
        beforeSend: function () {
            //$(preloader).show();//display preloader.
        },
        success: function (data) {
            //$(preloader).hide();//hide preloader.

            if (data.state === 0) {
                DisplaySuccessMessage(data.msg, data.redirectUrlInSuccess,a);// display result returned from method in controller (successful or failed)
            } else {
                DisplayFailureMessage(data.msg);// display result returned from method in controller (successful or failed)
                $(senderButton).attr("disabled", false);//Enable sender button 
            }
        },
        failure: function (response) {
            $(preloader).hide();//hide preloader
            DisplayFailureMessage(response);// display failure response of ajax call
            $(senderButton).attr("disabled", false);//Enable sender button
        }
    });
}





/// Display given message in a dialog which has a green check circle in title.
/// As an addition, if redirectUrl is not empty, it redirects to that page, 
/// after user closed the dialog box
function  DisplaySuccessMessage(msg, redirectUrl,controllerName) {
    bootbox.dialog({
        title: "<i class=\"fa fa-check-circle\" style=\"color: green;\"></i> Successful",
        centerVertical:true,
        message: msg,
        buttons: {
            main: {
                label: "OK",
                className: "btn-primary",
                callback: function () {
                    if (redirectUrl === undefined || redirectUrl === null || redirectUrl === "") {
                        return;
                    } else {
                      
                        location.href = "/"+ controllerName +"/Index";
                        
                    }
                       

                }
            }
        }
    });
}

/// Display given message in a dialog which has a red exclamation mark in title
function DisplayFailureMessage(msg) {
    bootbox.dialog({
        title: "<i class=\"fa fa-exclamation-circle\" style=\"color: red;\"></i> Failed",
        message: msg,
        buttons: {
            main: {
                label: "OK",
                className: "btn-primary"
            }
        }
    });
}



