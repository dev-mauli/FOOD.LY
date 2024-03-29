﻿$(document).ready(function () {
    ProfileData();
    $('#btnChangePasswordClick').click(function () {
        $('#DivChangePassword').show(1000);
        $('#DivDeactiveNote').hide();
    });

    $('#btnDeactiveClick').click(function () {
        $('#DivDeactiveNote').show(1000);
        $('#DivChangePassword').hide();
    });

});

//GET :  Profile Details
function ProfileData() {
    var url = '/Profile/Profiledetails';
    $.ajax({
        url: url,
        type: "POST",
        processData: false,
        contentType: false,
        data: {},
        success: function (data) {
            var newData = $.parseJSON(data.msg);
            {
                //FOR LABEL SHOW
                $('#txtFULLNAMElbl').html(newData[0].FULLNAME);
                $('#txtEMAIL1lbl').html(newData[0].EMAIL);
                $('#txtCONTACTNUMlbl').html(newData[0].MOBILENO);
                $('#txtINSTALINKlbl').html(newData[0].INSTALINK);
                $('#txtYOUTUBELINKlbl').html(newData[0].YOUTUBELINK);
                $('#txtFACEBOOKLINKlbl').html(newData[0].FBLINK);

                //FOR PROFILE NAME
                $('#lblprofilename').html(newData[0].FULLNAME);

                //FOR EDIT
                $('#txtID_EDIT').val(newData[0].ID);
                $('#txtFULLNAME_EDIT').val(newData[0].FULLNAME);
                $('#txtEMAIL1_EDIT').val(newData[0].EMAIL);
                $('#txtCONTACTNUM_EDIT').val(newData[0].MOBILENO);
                $('#txtINSTALINK_EDIT').val(newData[0].INSTALINK);
                $('#txtYOUTUBELINK_EDIT').val(newData[0].YOUTUBELINK);
                $('#txtFACEBOOKLINK_EDIT').val(newData[0].FBLINK);

            }

        },
        error: function (er) {

        }
    });
}

//UPDATE : Profile Details
function UpdateProf() {
    var REGISTER_MST_UPDT =
    {
        FULLNAME: $('#txtFULLNAME_EDIT').val(),
        MOBILENO: $('#txtCONTACTNUM_EDIT').val(),
        INSTALINK: $('#txtINSTALINK_EDIT').val(),
        FBLINK: $('#txtFACEBOOKLINK_EDIT').val(),
        YOUTUBELINK: $('#txtYOUTUBELINK_EDIT').val()
    };

    var REGISTER_MST_JSON = JSON.stringify(REGISTER_MST_UPDT);

    var url = '/Profile/ProfileDetailsUpdate';

    if ($("#btnregisterUpdate").val() === "UpdateProf") {
        if (!isvalidProfile()) {
            Swal.fire({ title: "Please Enter Values!", confirmButtonColor: "#3051d3", icon: "error" });
        }
        else {
            $.ajax({
                url: url,
                data: { mdl: REGISTER_MST_JSON },
                dataType: 'json',
                type: 'POST',
                success: function (data) {
                    ProfileData();
                    Swal.fire({
                        position: 'center',
                        icon: 'success',
                        title: 'Seved Successfully.',
                        showConfirmButton: false,
                        timer: 1500
                    });
                },
                error: function (data) {
                    Swal.fire({ title: "Something Went Wrong", text: "Reason:" + data, confirmButtonColor: "#3051d3", icon: "error" });
                    return false;
                }

            });
        }
    }

}

//UPDATE : Profile Password
function PasswordChange() {
    var REGISTER_MST_UPDT =
    {
        OLDPASSWORD: $('#txtOLDPASSWORD').val(),
        PASSWORD: $('#txtPASSWORD_EDIT').val()
    };

    var REGISTER_MST_JSON = JSON.stringify(REGISTER_MST_UPDT);

    var url = '/Profile/ProfileChangePassword';

    if ($("#btnChangePassword").val() === "PasswordChng") {
        if (!isvalidPWD()) {
            Swal.fire({ title: "Please Enter Values!", confirmButtonColor: "#3051d3", icon: "error" });
        }
        else {
            if ($('#txtPASSWORD_EDIT').val() !== $('#txtCNFRMPASSWORD_EDIT').val())
            {
                $('#txtPASSWORD_EDIT').css('border-bottom', '1px solid red');
                $('#txtCNFRMPASSWORD_EDIT').css('border-bottom', '1px solid red');
                Swal.fire({ title: "Please Enter Same Password!", confirmButtonColor: "#3051d3", icon: "error" });
            }
            else {
                $('#txtPASSWORD_EDIT').css('border-bottom', '1px solid #ccc');
                $('#txtCNFRMPASSWORD_EDIT').css('border-bottom', '1px solid #ccc');
                $.ajax({
                    url: url,
                    data: { mdl: REGISTER_MST_JSON },
                    dataType: 'json',
                    type: 'POST',
                    success: function (data) {
                        ProfileData();
                        Swal.fire({
                            position: 'center',
                            icon: 'success',
                            title: 'Updated Successfully.',
                            showConfirmButton: false,
                            timer: 1500
                        });
                    },
                    error: function (data) {
                        Swal.fire({ title: "Something Went Wrong", text: "Reason:" + data, confirmButtonColor: "#3051d3", icon: "error" });
                        return false;
                    }

                });
            }
        }
    }

}

//VALIDATION : Profile Validation
function isvalidProfile() {
    var rntValue = true;

    if ($('#txtFULLNAME_EDIT').val() === '') {
        $('#txtFULLNAME_EDIT').css('border-bottom', '1px solid red');
        rntValue = false;
    }
    else {
        $('#txtFULLNAME_EDIT').css('border-bottom', '1px solid #ccc');
    }
   
    if ($('#txtCONTACTNUM_EDIT').val() === '') {
        $('#txtCONTACTNUM_EDIT').css('border-bottom', '1px solid red');
        rntValue = false;
    }
    else {
        $('#txtCONTACTNUM_EDIT').css('border-bottom', '1px solid #ccc');
    }
    if ($('#txtINSTALINK_EDIT').val() === '') {
        $('#txtINSTALINK_EDIT').css('border-bottom', '1px solid red');
        rntValue = false;
    }
    else {
        $('#txtINSTALINK_EDIT').css('border-bottom', '1px solid #ccc');
    }

    if ($('#txtYOUTUBELINK_EDIT').val() === '') {
        $('#txtYOUTUBELINK_EDIT').css('border-bottom', '1px solid red');
        rntValue = false;
    }
    else {
        $('#txtYOUTUBELINK_EDIT').css('border-bottom', '1px solid #ccc');
    }
    if ($('#txtFACEBOOKLINK_EDIT').val() === '') {
        $('#txtFACEBOOKLINK_EDIT').css('border-bottom', '1px solid red');
        rntValue = false;
    }
    else {
        $('#txtFACEBOOKLINK_EDIT').css('border-bottom', '1px solid #ccc');
    }

    return rntValue;
}

//VALIDATION : Profile Chnage Password
function isvalidPWD() {
    var rntValue = true;

    if ($('#txtOLDPASSWORD').val() === '') {
        $('#txtOLDPASSWORD').css('border-bottom', '1px solid red');
        rntValue = false;
    }
    else {
        $('#txtOLDPASSWORD').css('border-bottom', '1px solid #ccc');
    }

    if ($('#txtPASSWORD_EDIT').val() === '') {
        $('#txtPASSWORD_EDIT').css('border-bottom', '1px solid red');
        rntValue = false;
    }
    else {
        $('#txtPASSWORD_EDIT').css('border-bottom', '1px solid #ccc');
    }
    if ($('#txtCNFRMPASSWORD_EDIT').val() === '') {
        $('#txtCNFRMPASSWORD_EDIT').css('border-bottom', '1px solid red');
        rntValue = false;
    }
    else {
        $('#txtCNFRMPASSWORD_EDIT').css('border-bottom', '1px solid #ccc');
    }
   
    return rntValue;
}