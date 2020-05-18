$(document).ready(function () {

});

function LogoUt() {
	var url = '/Home/Logout';
	$.ajax({
		url: url,
		data: {},
		dataType: 'json',
		type: 'POST',
		success: function (data) {
			Swal.fire({
				position: 'center',
				icon: 'success',
				title: 'Log Out Successfully.',
				showConfirmButton: false,
				timer: 1500
			});
			$('#partialView').load('_PartialNav');
			$('#partailindex').load('/Home/_PartialIndex');
		},
		error: function (data) {
			Swal.fire({ title: "Something Went Wrong", text: "Reason:" + data, confirmButtonColor: "#3051d3", icon: "error" });
			return false;
		}

	});
}

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
		if (!isvalidReg()) {
			Swal.fire({ title: "Please Enter Values!", confirmButtonColor: "#3051d3", icon: "error" });
		}
		else {
			$.ajax({
				url: url,
				data: { mdl: REGISTER_MST_JSON },
				dataType: 'json',
				type: 'POST',
				success: function (data) {
					Swal.fire({
						position: 'center',
						icon: 'success',
						title: 'Regitered Successfully.',
						text: "Welcome : " + $('#txtEMAIL').val() + "\nPlease Login",
						showConfirmButton: false,
						timer: 1500
					});
					Clear();
					$('#lilogin').trigger("click");
					//$('#panel8').removeClass();
					//$('#panel8').addClass("tab-pane fade in");
					//$('#panel7').removeClass();
					//$('#panel7').addClass("tab-pane fade in active show");
				},
				error: function (data) {
					Swal.fire({ title: "Something Went Wrong", text: "Reason:" + data, confirmButtonColor: "#3051d3", icon: "error" });
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
	if (!isvalidLog()) {
		Swal.fire({ title: "Please Enter Values!", confirmButtonColor: "#3051d3", icon: "info" });
	}
	else {
		if ($("#btnlogin").val() === "Login") {

			$.ajax({
				url: url,
				data: { mdl: LOGIN_MST_JSON },
				dataType: 'json',
				type: 'POST',
				success: function (data) {
					if (data.msg === "1") {

						Swal.fire({
							position: 'center',
							icon: 'success',
							title: 'Login Successfull.',
							text: "Welcome :" + $('#txtEMAIL1').val(),
							showConfirmButton: false,
							timer: 2000
						});
						$('#modalLRForm').modal('toggle');
						$('#partialView').load('_PartialNav');
						$('#partailindex').load('/Home/_PartialIndex');
						Clear();
					} else {
						Swal.fire({ title: "Not a Valid user", confirmButtonColor: "#3051d3", icon: "info" });
					}

				},
				error: function (data) {
					Swal.fire({ title: "Something Went Wrong", text: "Reason:" + data, confirmButtonColor: "#3051d3", icon: "error" });
					return false;
				}

			});
		}
	}

}

//validation for registration
function isvalidReg() {
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

//validation for login
function isvalidLog() {
	var rntValue = true;

	if ($('#txtEMAIL1').val() === '') {
		$('#txtEMAIL1').css('border-bottom', '1px solid red');
		rntValue = false;
	}
	else {
		$('#txtEMAIL1').css('border-bottom', '1px solid #ccc');
	}
	if ($('#txtPASSWORD1').val() === '') {
		$('#txtPASSWORD1').css('border-bottom', '1px solid red');
		rntValue = false;
	}
	else {
		$('#txtPASSWORD1').css('border-bottom', '1px solid #ccc');
	}
	return rntValue;
}

//clear function
function Clear() {
	$('#txtEMAIL').val("");
	$('#txtPASSWORD').val("");
	$('#txtEMAIL1').val("");
	$('#txtPASSWORD1').val("");
}


