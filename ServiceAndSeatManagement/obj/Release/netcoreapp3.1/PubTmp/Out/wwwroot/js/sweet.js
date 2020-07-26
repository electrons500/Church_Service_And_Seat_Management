function DisplaySweetAlert(senderButton, sendData, callUrl, requestVerificationToken) {
  
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
                DisplaySuccessMessage(data.msg, data.redirectUrlInSuccess);// display result returned from method in controller (successful or failed)
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


function DisplaySuccessMessage(msg, redirectUrl) {
    swal("Done!", msg, "success");
    //location.reload(true);
    callback: function () {
        if (redirectUrl === undefined || redirectUrl === null || redirectUrl === "") {
            return;
        } else {
            location.href = redirectUrl;//Go to redirectUrl after user closed displaying success message
        }
    }
}