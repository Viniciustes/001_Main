$(document).ready(function(){


	$("#ctj_inservice_minicourse").click(function () {
		$("#collapse_ctj_inservice_minicourse").collapse('toggle');
	});

	$("#ctj_inservice_general_meetings").click(function () {
		$("#collapse_ctj_inservice_general_meetings").collapse('toggle');
	});

	$("#ctj_inservice_branch_meetings").click(function () {
		$("#collapse_ctj_inservice_branch_meetings").collapse('toggle');
	});

	$("#check-bird-17").click(function () {
		$("#collapse-check-bird-17").collapse('toggle');
	});
	$("#check-bird-18").click(function () {
		$("#collapse-check-bird-18").collapse('toggle');
	});
	$("#check-bird-19").click(function () {
		$("#collapse-check-bird-19").collapse('toggle');
	});
	$("#check-bird-20").click(function () {
		$("#collapse-check-bird-20").collapse('toggle');
	});


	$("#q2").click(function () {
		$("#collapseQ2").collapse('toggle');
	});

	$("#q3").click(function () {
		$("#collapseQ3").collapse('toggle');
	});

	$("input[name=degree]").change(function () {

		if ($(this).val() == '2')
		{
			$("#collapseQ6Upload").collapse('show');
		} 
		else
		{
			$("#collapseQ6Upload").collapse('hide');
		}
	});

	$("#indicadores-ano input[type=radio]").change(function () {
	    swal({ title: "", text: "Loading", imageUrl: "/Content/img/loading.gif", showCancelButton: false, showConfirmButton: false });
	    var $this = $(this);
	    var contextoAno = $this.val();

	    $.ajax(
        {
            type: 'POST',
            url: '/Account/ChangeYearContext',
            data: {"contextoAno": contextoAno},
            dataType: "json",
            success: function (data) {
                var pathname = window.location.pathname.split("/");

                if (pathname[2] == "Observation") {
                    window.location.href = "/";
                } else {
                    window.location.reload(true);
                }
            }
        });
	});

});