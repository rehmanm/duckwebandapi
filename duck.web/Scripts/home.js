
$(document).ready(function () {  
    var baseUrl = 'http://localhost:51667';
    var selDuckFood = $('#selDuckFood');  

    var duckFoodLoaded = false, feedLocationLoaded = false;
    function hideLoader() {

        if (duckFoodLoaded && feedLocationLoaded) {
            $("#loader").hide();
        }

    }

    function showLoader() {
        $("#loader").show();
    }
     
    $.ajax({
        type: 'GET',
        url: baseUrl + '/api/duckfood',
        dataType: 'json',
        beforeSend: function (xhr) {
            showLoader();
        },
        success: function (data) {

            selDuckFood.empty();
            $.each(data, function (index, val) {
                selDuckFood.append('<option value ="' + val.FoodID + '">' + val.FoodName + '</li>')

            });
            duckFoodLoaded = true;
            hideLoader();
        }
    });

    var selFeedLocation = $('#selFeedLocation');
    $.ajax({
        type: 'GET',
        url: baseUrl + '/api/feedlocation',
        dataType: 'json',
        beforeSend: function (xhr) {
            showLoader();
        },
        success: function (data) {

            selFeedLocation.empty();
            console.log(data);
            $.each(data, function (index, val) {
                selFeedLocation.append('<option value ="' + val.FeedLocationID + '">' + val.FeedLocationName + '</li>')

            });
            feedLocationLoaded = true;
            hideLoader();
        }
    })

    function validateTxt(txtControl) {
        var validationID = "#val" + txtControl;
        var txtControlID = "#" + txtControl;
        $(validationID).hide();
        if ($(txtControlID).val() === "") {
            $(txtControlID).focus();
            $(validationID).show();
            
            return false;
        }

        return true;
    }

    function validateEmail(txtControl) {
        var validationID = "#val" + txtControl;
        var txtControlID = "#" + txtControl;
        $(validationID).hide();
        var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        var validEmail = re.test(String($(txtControlID).val()).toLowerCase());
        if (!validEmail) {
            $(txtControlID).focus();
            $(validationID).show();

            return false;
        }

        return true;
    }

    function validatePositive(txtControl) {
        var validationID = "#val" + txtControl;
        var txtControlID = "#" + txtControl;
        $(validationID).hide();
        if ($(txtControlID).val() !== "" && $(txtControlID).val() <= 0) {
            $(txtControlID).focus();
            $(validationID).show();

            return false;
        }

        return true;
    }
        

    $("#btnSubmit").click(function (e) {

        var responseMessage = $("#responseMessage");
        responseMessage.hide();
        var emailInvalid = validateTxt("txtEmail") && validateEmail("txtEmail");
        var timeInvalid = validateTxt("txtTime");
        var numberOfDuckInvalid = validateTxt("txtNumberofDucks") && validatePositive("txtNumberofDucks");
        var amountoffoodInvalid = validateTxt("txtAmountOfFood") && validatePositive("txtAmountOfFood");

        if (!emailInvalid || !timeInvalid || !numberOfDuckInvalid || !amountoffoodInvalid) {
            e.preventDefault();
            return false;
        }


        



        var data =
        {
            "EmailAddress": $("#txtEmail").val(),
            "Time": $("#txtTime").val(),
            "DuckFoodID": $("#selDuckFood").val(),
            "FeedLocationID": $("#selFeedLocation").val(),
            "NumberOfDucks": $("#txtNumberofDucks").val(),
            "FoodType": $("#selFoodType").val(),
            "AmountOfFood": $("#txtAmountOfFood").val(),
            "IsRecurring": $("#chkSameSchedule").prop('checked')
        };

        $.ajax({
            type: "POST",
            url: baseUrl + '/api/duckfeed',
            data: data,
            beforeSend: function (xhr) {
                showLoader();
            },
        }).done(function (status, response) {

                responseMessage.removeClass("alert-success");
                responseMessage.removeClass("alert-danger");


                if (status === 1) {
                    responseMessage.text("Record Inserted Successfully");
                    responseMessage.addClass("alert-success");

                } else if (status === 2) {
                    responseMessage.text("Record Inserted Successfully and Recurring Schedule Also Created");
                    responseMessage.addClass("alert-success");

                } else {
                    responseMessage.text("There is some issue while inserting record");
                    responseMessage.addClass("alert-danger");

                }

            responseMessage.show();
            hideLoader();
            }
            ).fail(function () {

                responseMessage.text("There is some issue while inserting record");
                responseMessage.addClass("alert-danger");

                responseMessage.show();
                hideLoader();
            });

    });



});  

(function () {
    'use strict';
    window.addEventListener('load', function () {
        // Fetch all the forms we want to apply custom Bootstrap validation styles to
        var forms = document.getElementsByClassName('needs-validation');
        // Loop over them and prevent submission
        var validation = Array.prototype.filter.call(forms, function (form) {
            form.addEventListener('submit', function (event) {
                if (form.checkValidity() === false) {
                    event.preventDefault();
                    event.stopPropagation();
                }
                form.classList.add('was-validated');
            }, false);
        });
    }, false);
})();