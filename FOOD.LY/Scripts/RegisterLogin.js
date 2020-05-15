$(document).ready(function () {
    $("#btnlogout").click(function () {
        toastr.info("Logout Sucessfully", {
            "positionClass": "md-toast-top-right",
        });
    });

});

//REGISTER FUNATION
function SaveData() {
	var REGISTER_MST =
	{
		EMAIL: $('#txtEMAIL').val(),
		PASSWORD: $('#txtPASSWORD').val()
	};

	var REGISTER_MST_JSON = JSON.stringify(REGISTER_MST);

	var url = '/Home/Register';

	if ($("#btnregister").val() === "Signup") {
        if (!isvalid()) {
            toastr.info("Please Provide Values.", {
                "positionClass": "md-toast-top-right",
            });
		}
		else {
			$.ajax({
				url: url,
				data: { mdl: REGISTER_MST_JSON },
				dataType: 'json',
				type: 'POST',
				success: function (data) {
					//alert('Register Sucessfully.Login');
					//$('#panel7').show("slow");
                    //$('#panel8').hide("slow");
                    toastr.success("Register Sucessfully", {
                        "positionClass": "md-toast-top-right",
                    });
				},
				error: function (data) {
					//alert("Insert Error");
                    toastr.error("Error occur!","Please try again.", {
                        "positionClass": "md-toast-top-right",
                    });
					return false;
				}

			});
		}
	}

}

//LOGIN FUNCTION
function LaginData() {
	var LOGIN_MST =
	{
		EMAIL: $('#txtEMAIL1').val(),
		PASSWORD: $('#txtPASSWORD1').val()
	};

	var LOGIN_MST_JSON = JSON.stringify(LOGIN_MST);

	var url = '/Home/Login';

	if ($("#btnlogin").val() === "Login") {

		$.ajax({
			url: url,
			data: { mdl: LOGIN_MST_JSON },
			dataType: 'json',
			type: 'POST',
			success: function (data) {
                if (data.msg === "1") {
                   
					//alert('YOU ARE NOW LOGGED IN : WELCOME');
                    toastr.success("YOU ARE NOW LOGGED IN", "WELCOME",  {
                        "positionClass": "md-toast-top-right",
                    });
                    location.reload();
					
				} else {    
					//alert("Insert Error");
                    toastr.error("Error occur!", "Please try again.", {
                        "positionClass": "md-toast-top-right",
                    });
				}

			},
			error: function (data) {
				//location.reload();
				//alert("Insert Error");
                toastr.error("Error occur!", "Please try again.", {
                    "positionClass": "md-toast-top-right",
                });
				return false;
			}

		});

	}

}

function isvalid() {
	var rntValue = true;

	if ($('#txtEMAIL').val() === '') {
		$('#txtEMAIL').css('border-bottom', '1px solid red');
		rntValue = false;
	}
	else {
		$('#txtEMAIL').css('border-bottom', '1px solid #ccc');
	}
	if ($('#txtCONTACTNO').val() === '') {
		$('#txtCONTACTNO').css('border-bottom', '1px solid red');
		rntValue = false;
	}
	else {
		$('#txtCONTACTNO').css('border-bottom', '1px solid #ccc');
	}

	if ($('#txtPASSWORD').val() === '') {
		$('#txtPASSWORD').css('border-bottom', '1px solid red');
		rntValue = false;
	}
	else {
		$('#txtPASSWORD').css('border-bottom', '1px solid #ccc');
	}
	if ($('#txtPASSWORDCNFM').val() === '') {
		$('#txtPASSWORDCNFM').css('border-bottom', '1px solid red');
		rntValue = false;
	}
	else {
		$('#txtPASSWORDCNFM').css('border-bottom', '1px solid #ccc');
	}


	return rntValue;
}
