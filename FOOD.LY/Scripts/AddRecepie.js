$(document).ready(function () {

    preview();
    $("#heading").show(1000);
    $('#btnadditem').click(function () {
        $("#addpage").show(1000);
        $("#detailspage").hide();
        $("#btngetdetails").show(1000);
        $("#btnadditem").hide();
    });
    $('#btngetdetails').click(function () {
        $("#addpage").hide();
        $("#detailspage").show(1000);
        $("#btnadditem").show(1000);
        $("#btngetdetails").hide();
    });
    $('#btnaddimages').click(function () {
        $("#imagesDiv").toggle(1000);
    });
});


// add receipe
function AddItem() {
    var selValue = $("input[type='radio']:checked").val();
    var REGISTER_MST =
    {
        TITLE: $('#txtTITLE').val(),
        CAT: selValue,
        DESCRIPTION: $('#summernote').text()
        // DESCRIPTION: $('#summernote').summernote('code')
    };

    var REGISTER_MST_JSON = JSON.stringify(REGISTER_MST);

    var url = '/AddRecipe/SAVE';

    if ($("#btnadditem").val() == "save") {
        if (!isvalid1()) {
            alert("Please Provide Values.");
        }
        else {
            $.ajax({
                url: url,
                data: { mdl: REGISTER_MST_JSON },
                dataType: 'json',
                type: 'POST',
                success: function (data) {
                    alert('Register Sucessfully.Login');
                    //$('#panel7').show("slow");
                    //$('#panel8').hide("slow");
                },
                error: function (data) {
                    alert("Insert Error");
                    return false;
                }

            });
        }
    }
}


function isvalid1() {
    var rntValue = true;

    if ($('#txtTITLE').val() === '') {
        $('#txtTITLE').css('border-bottom', '1px solid red');
        rntValue = false;
    }
    else {
        $('#txtTITLE').css('border-bottom', '1px solid #ccc');
    }
    if ($('#txtRADIOVEG').val() === '' || $('#txtRADIONNVG').val() === '') {
        $('#txtRADIOVEG').css('border-bottom', '1px solid red');
        $('#txtRADIONNVG').css('border-bottom', '1px solid red');
        rntValue = false;
    }
    else {
        $('#txtRADIOVEG').css('border-bottom', '1px solid #ccc');
        $('#txtRADIONNVG').css('border-bottom', '1px solid #ccc');
    }

    if ($('#summernote').val() === '') {
        $('#summernote').css('border-bottom', '1px solid red');
        rntValue = false;
    }
    else {
        $('#summernote').css('border-bottom', '1px solid #ccc');
    }
    return rntValue;
}






// periview images
function preview() {
    $(document).ready(function () {
        $("#recipeimage").change(function () {

            //  $("#previewBannerimage").show(1000);
            var previewimages = $("#previewrecipeimage");
            previewimages.html("");
            $($(this)[0].files).each(function () {
                var file = $(this);
                var reader = new FileReader();
                reader.onload = function (e) {
                    var img = $("<img />");
                    img.attr("style", "border: 2px solid #ddd; border-radius: 4px; padding: 5px;  height: 220px; width: 20%; object-fit: cover;");
                    img.attr("src", e.target.result);
                    previewimages.append(img);
                    $("#previewrecipeimage").show();
                };
                reader.readAsDataURL(file[0]);
            });
        });
    });
}