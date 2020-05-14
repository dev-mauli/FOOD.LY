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

    $("input[type='radio']").click(function () {

        var radioValue = $("input[name='Foodtype']:checked").val();
        if (radioValue) {
            // alert("Your are a - " + radioValue);
            $("#DivshowFoodType").show(1000);
            //  $("#lblshowFoodType").append(radioValue);
            $("#lblshowFoodType").text("Selected Category: " + radioValue);

        }
    });
});


// add receipe
function AddItem() {
  
    var RECIPE_MST =
    {
        TITLE: $('#txtTITLE').val(),
        CAT: $("input[name='Foodtype']:checked").val(),
        DESCRIPTION: $('#summernote').summernote('code')
    };

    var RECIPE_MST_JSON = JSON.stringify(RECIPE_MST);

    var url = '/AddRecipe/SAVE';

    if ($("#btnaddreceipe").val() === "save") {
        if (!isvalid1()) {
            alert("Please Provide Values.");
        }
        else {
            $.ajax({
                url: url,
                data: { mdl: RECIPE_MST_JSON },
                dataType: 'json',
                type: 'POST',
                success: function (data) {
                    alert('SAVED SUCESSFULLY.');
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
    if ($('#lblshowFoodType').text() === '') {
        rntValue = false;
    }

    //if ($('#summernote').val() === '') {
    //    $('#summernote').css('border-bottom', '1px solid red');
    //    rntValue = false;
    //}
    //else {
    //    $('#summernote').css('border-bottom', '1px solid #ccc');
    //}
    return rntValue;
}






// periview images
function preview() {
    $(document).ready(function () {
        $("#recipeimage").change(function () {

            //  $("#previewBannerimage").show(1000);
            var previewimages = $("#previewrecipeimage");
            previewimages.html("");
            $($(this)[0].files).each(function (i) {
                var file = $(this);
                var reader = new FileReader();
                reader.onload = function (e) {
                    var img = $("<img id="+i+" />");
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