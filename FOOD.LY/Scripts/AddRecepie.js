$(document).ready(function () {
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
});