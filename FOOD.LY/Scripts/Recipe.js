$(document).ready(function () {

	SinglePost(GetURLParameterInvoiceID("r"));

	function GetURLParameterInvoiceID(sParam) {

		var sPageURL = window.location.search.substring(1);
		var sURLVariables = sPageURL.split('?');
		if (sURLVariables.length >= 1) {
			var i = 1;
			var sParameterName = sURLVariables[0].split('=');
			return sParameterName[1];
		} else {
			return window.location.href = "/Home";
		}
	}

	$(window).scroll(function () {
		if ($(window).scrollTop() === $(document).height() - ($(window).height())) {
			//AllPost();
		}
	});
});
function SinglePost(r) {
	var REGISTER_MST =
	{
		RID: r
	};
	var url = '/Recipe/SingleDetails';
	var REGISTER_MST_JSON = JSON.stringify(REGISTER_MST);
	$.ajax({
		url: url,
		data: { mdl: REGISTER_MST_JSON },
		dataType: 'json',
		type: 'POST',
		success: function (data) {
			var newData = $.parseJSON(data.msg);
			if (data.msg !== "[]") {
				var markup = '';
				var img = '';
				var count = newData.length;
				for (i = 0; i < newData.length; i++) {
					var a = [];
					if (newData[i].IMAGE.indexOf("|") === -1) {
						a = newData[i].IMAGE;
					} else {
						var b = newData[i].IMAGE;
						a = b.split('|');
					}

					for (j = 0; j < a.length; j++) {
						img += `<img src="${a[j]}" alt="Card image cap">`;
					}
					$('#divimg').append(img);
					$('#title').append(newData[i].TITLE);
					if (newData[i].CAT === "Veg") {
						$('#lbltag').append(`<label id="lblshowFoodType" style="font-size: 15px;" class="badge badge-success">Veg</label>`);
					} else {
						$('#lbltag').append(`<label id="lblshowFoodType" style="font-size: 15px;" class="badge badge-danger">Non-Veg</label>`);
					}
					$('#postedby').append(`<span>Posted By <a href="/Profile/User/${newData[i].LOGINID}">${newData[i].FULLNAME}</a> - ${newData[i].ENTEREDON} (${newData[i].AGO})</span>`);
					$('#countlike').append(newData[i].COUNTER);
					$('#countviews').append(newData[i].COUNTER);
					$('#descpition').append(newData[i].DESCRIPTION);
					$('#lblprofilename').append(newData[i].FULLNAME);
					$('#imgprofile').append(`<img src="${newData[i].USERPHOTO}" class="img-fluid rounded-circle z-depth-2">`);
					var social = '';
					if (newData[i].INSTA !== "") {
						social += `<a href="${newData[i].INSTA}" target="_blank"><i class="fab fa-instagram-f mr-2"> </i></a>`;
					}
					if (newData[i].FB !== "") {
						social += `<a href="${newData[i].FB}" target="_blank"><i class="fab fa-facebook-f mr-2"> </i></a>`;
					}
					if (newData[i].YOUTUBE !== "") {
						social += `<a href="${newData[i].YOUTUBE}" target="_blank"><i class="fab fa-youtube-f mr-2"> </i></a>`;
					}
					$('#divsocialprofile').append(social);
					$('.fotorama').fotorama();
				}
			}
		},
		error: function (er) {

		}
	});
}



