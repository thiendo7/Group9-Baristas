$(document).ready(function () {
    $("#dataTable").DataTable({
        "responsive": true,
        "autoWidth": false,
    });
    $('#Content').summernote();
    $('#Description').summernote();
});