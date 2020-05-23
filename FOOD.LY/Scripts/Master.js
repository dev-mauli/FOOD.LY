$(document).ready(function () {
	AllPost();
	function AllPost() {
		var url = '/Home/AllPost';
		$.ajax({
			url: url,
			type: "POST",
			processData: false,
			contentType: false,
			data: {},
			success: function (data) {
				var newData = $.parseJSON(data.msg);
				if (data.msg != "[]") {
					var markup = '';
					var count = newData.length;
					for (i = 0; i < newData.length; i++) {
						var a = [];
						if (newData[i].IMAGE.indexOf("|") == -1) {
							a = newData[i].IMAGE;
						} else {
							var b = newData[i].IMAGE;
							a = b.split('|');
						}

						markup += `<div><div class="clearfix d-none d-sm-block">
			<div class="card card-cascade narrower card-ecommerce">
				<div style="margin-top: -1.25rem;margin-right: 4%;margin-left: 4%;">
					<div class="fotorama" data-width="1000" data-ratio="700/467" data-max-width="100%" style="border-radius:25px;">`
						for (j = 0; j < a.length; j++) {
							markup += `<img src="${a[j]}" class="card-img-top" alt="">`;
						}
						markup += `</div>
					<a>
						<div class="mask rgba-white-slight waves-effect waves-light"></div>
					</a>
				</div>
				<hr />
				<div class="card-body card-body-cascade">
					<a href="javascript:void(0)" class="text-muted">
						<h5 style="color:green">${newData[i].CAT}</h5>
					</a>
					<h4 class="card-title">
						<strong>
							<a href="/Recipe/${newData[i].RID}">${newData[i].TITLE}</a>
						</strong>
					</h4>
					<hr />

					<p class="card-text">
					<div id="p${i}">
						${newData[i].DESCRIPTION}
					</div>
					</p>
					<div class="text-center">
						<a href="/Recipe/${newData[i].RID}">Read More..</a>
					</div>
					<br />
					<ul class="form-control text-center">
						<li class="list-inline-item float-left"><a href="#" class="black-text"><i class="fas fa-heart"></i> Like</a></li>
						<li class="list-inline-item pr-2 float-center"><a href="#" class="black-text"><i class="fas fa-comments pr-1"></i> Comments</a></li>
						<li class="list-inline-item pr-2 float-right"><a href="#" class="black-text"><i class="fas fa-share-square"></i> Share</a></li>
					</ul>
				</div>

				<div class="card-footer text-muted text-center">
					<span class="float-left">Posted By <a href="/Profile/User/${newData[i].LOGINID}">${newData[i].FULLNAME}</a> - ${newData[i].ENTEREDON} (${newData[i].AGO})</span>
					<span class="float-right">${newData[i].COUNTER} Views</span>
				</div>
			</div>
		</div>
		<hr class="my-5"></div>`;
					}
					$('#divpost').append(markup);
					$('.fotorama').fotorama();
					//for (i = 0; i < count; i++) {
					//	alert($('#p' + i).text());
					//}
				}
			},
			error: function (er) {

			}
		});
	}

	$(window).scroll(function () {
		if ($(window).scrollTop() == $(document).height() - ($(window).height())) {
			AllPost();
		}
	});

});