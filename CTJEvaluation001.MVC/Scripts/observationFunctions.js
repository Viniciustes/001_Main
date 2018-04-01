$(document).ready(function () {
    $btnObservationSave = $("#btnObservationSave");


    $btnObservationSave.on('click', function () {

    });

});

function ObservationSave(data, laddaButton) {
    $.ajax(
    {
        type: 'POST',
        url: '/SelfEvaluation/Save',
        data: data,
        dataType: "json",
        success: function (data) {
            swal("Good job!", "", "success");
            laddaButton.ladda('toggle');
        },
        error: function (err) {
            sweetAlert("Oops...", "Something went wrong!", "error");
            laddaButton.ladda('toggle');
        }
    });
}