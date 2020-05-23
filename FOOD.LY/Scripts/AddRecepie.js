$(document).ready(function () {

	// preview image
	preview();

	//hide and show
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

	//get radio buttons values
	$("input[type='radio']").click(function () {
		var radioValue = $("input[name='Foodtype']:checked").val();
		if (radioValue) {
			$("#DivshowFoodType").show(1000);
			$("#lblshowFoodType").text("Selected Category : " + radioValue);
			if (radioValue == "Veg") {
				$("#lblshowFoodType").attr("class", "badge badge-success");
			} else {
				$("#lblshowFoodType").attr("class", "badge badge-danger");
			}
		}
	});
});

//save image to folder
function SaveRecipeImage() {

	var data = new FormData();
	var files = $("#recipeimage").get(0).files;
	for (i = 0; i <= files.length; i++) {
		if (files.length > 0) {
			data.append("MyImages" + i, files[i]);
		}
	}

	var url = '/AddRecipe/UploadFile';

	if ($("#btnaddreceipe").val() === "save") {
		if (!isvalid1()) {
			Swal.fire({ title: "Please Enter Values!", confirmButtonColor: "#3051d3", icon: "error" });
		}
		else {
			$.ajax({
				url: url,
				type: "POST",
				processData: false,
				contentType: false,
				data: data,
				success: function (data) {
					AddItem(data);
					//alert("Success");
				},
				error: function (er) {
					Swal.fire({ title: "Something Went Wrong", text: "Reason:" + data, confirmButtonColor: "#3051d3", icon: "error" });
				}

			});
		}
	}
}

// save recipe and image path to DB
function AddItem(data) {
	var RECIPE_MST =
	{
		TITLE: $('#txtTITLE').val(),
		CAT: $("input[name='Foodtype']:checked").val(),
		DESCRIPTION: $('#summernote').summernote('code'),
		IMAGE: data,
		VIDEO: ""
	};
	var url = '/AddRecipe/SAVE';
	var RECIPE_MST_JSON = JSON.stringify(RECIPE_MST);

	$.ajax({
		url: url,
		data: { mdl: RECIPE_MST_JSON },
		dataType: 'json',
		type: 'POST',
		success: function (data) {
			let timerInterval;
			Swal.fire({
				title: 'Saving!',
				html: 'Saving Recipe : <b></b> milliseconds.',
				timer: 3000,
				timerProgressBar: true,
				onBeforeOpen: () => {
					Swal.showLoading();
					timerInterval = setInterval(() => {
						const content = Swal.getContent();
						if (content) {
							const b = content.querySelector('b');
							if (b) {
								b.textContent = Swal.getTimerLeft();
							}
						}
					}, 100);
				},
				onClose: () => {
					clearInterval(timerInterval);
					Swal.fire({
						position: 'center',
						icon: 'success',
						title: 'Receipe Saved Successfully!',
						showConfirmButton: false,
						timer: 2000
					});
					Clear();
				}
			}).then((result) => {
				/* Read more about handling dismissals below */
				if (result.dismiss === Swal.DismissReason.timer) {
					console.log('I was closed by the timer');
				}
			});
			Clear();
		},
		error: function (data) {
			Swal.fire({ title: "Something Went Wrong", text: "Reason:" + data, confirmButtonColor: "#3051d3", icon: "error" });
			return false;
		}

	});
}

//validations
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

// periview images function
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
					var img = $("<img id=" + i + " />");
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

//clear function
function Clear() {
	$('#txtTITLE').val("");
	$("#summernote").summernote("code", '<p style="line-height: 1;"><span style="font-size: 18px;">﻿</span><span style="font-size: 18px;">﻿</span><b><u><span style="font-size: 18px;">Ingredients&nbsp;:-</span></u></b></p><ul><li><span style="font-size: 14px;">E.g :- Oil</span></li><li><span style="font-size: 14px;">Tomato</span></li><li><span style="font-size: 14px;"><br></span></li></ul><p><span style="font-weight: bolder; font-size: 18px;"><u>Procedure :-</u></span></p><ul><li><span style="font-size: 14px;">E.g :- Cut Tomatoes, Onions</span></li><li><br></li></ul>');
	$('#previewrecipeimage').val("");
}