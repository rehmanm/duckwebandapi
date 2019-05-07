
$(document).ready(function () {  
    var baseUrl = 'http://localhost:51667';
    var selDuckFood = $('#selDuckFood');  
 
    $.ajax({
        type: 'GET',
        url: baseUrl + '/api/duckfood',
        dataType: 'json',
        success: function (data) {

            selDuckFood.empty();
            console.log(data);
            $.each(data, function (index, val) {
                selDuckFood.append('<option value ="' + val.FoodID + '">' + val.FoodName + '</li>')

            });
        }
    });

    var selFeedLocation = $('#selFeedLocation');
    $.ajax({
        type: 'GET',
        url: baseUrl + '/api/feedlocation',
        dataType: 'json',
        success: function (data) {

            selFeedLocation.empty();
            console.log(data);
            $.each(data, function (index, val) {
                selFeedLocation.append('<option value ="' + val.FeedLocationID + '">' + val.FeedLocationName + '</li>')

            });
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

   
        console.log(data);
 
        $.ajax({
            type: "POST",
            url: baseUrl + '/api/duckfeed',
            data: data,
            success: function (status) {
                console.log(status);
            } 
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