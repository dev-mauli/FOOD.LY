$(document).ready(function () {
    AllPost();
    function AllPost() {
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
                    $('#txtFULLNAMElbl').append(newData[0].FULLNAME);
                    $('#txtEMAIL1lbl').append(newData[0].EMAIL);
                    $('#txtCONTACTNUMlbl').append(newData[0].MOBILENO);
                    $('#txtINSTALINKlbl').append(newData[0].INSTALINK);
                    $('#txtYOUTUBELINKlbl').append(newData[0].YOUTUBELINK);
                    $('#txtFACEBOOKLINKlbl').append(newData[0].FBLINK);

                    //FOR PROFILE NAME
                    $('#lblprofilename').append(newData[0].FULLNAME);

                    //FOR EDIT
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
});