$(document).ready(function () {

    $inputSearch = $("#inputSearch"),
    cacheTeachers = [],
    chapa = "";
    personId = 0;
    annotationsType = [];

    $("#btnAddAnnotation").off('click').on('click', function () {
        $(".modalAnnotation").modal("show");
        clearModal();
        $("#inputAnnotationDescription").prop('disabled', false);
    });

    getAnnotationsType();

    $inputSearch.keyup(function (e, n) {
        var value = $inputSearch.val().trim(), tmpl = "";

        $("#annnotationsSection").addClass("hidden");
        $("#imgloading").addClass("hidden");

        if (value.length >= 3) {
            $("#imgloading").removeClass("hidden");
            $.ajax(
            {
                type: 'POST',
                url: '/Annotation/GeyEmployeesByName',
                data: { search: value },
                dataType: "json",
                success: function (data) {
                    cacheTeachers = data;
                    for (var i = 0; i < data.length; i++) {
                        tmpl += '<blockquote class="blockquote" style="margin-top:0; margin-bottom:0;">';
                        tmpl += '<p><a href="#" data-person-id="' + data[i].Person.Id + '" data-chapa="' + data[i].Chapa + '">' + data[i].Name + '</a></p>';
                        tmpl += '<footer class="blockquote-footer">' + data[i].Role + '</footer>';
                        tmpl += '</blockquote>';
                    }

                    appendTemplate(tmpl);
                    $("#imgloading").addClass("hidden");                    
                },
                error: function (err) {
                    console.log(err);
                    sweetAlert("Oops...", "Something went wrong!", "error");
                    $("#imgloading").addClass("hidden");
                }
            });
        }
    });

    $("#btnSaveAnnotation").off("click").on("click", function () {

        var formIsValid = $("#formCrudAnnotation").valid();
        var dataSend = {};
        var laddaButton = $("#btnSaveAnnotation").ladda();

        if (formIsValid == true) {
            laddaButton.ladda('toggle');

            dataSend.Nro = $("#inputAnnotationNro").val();
            dataSend.AnnotationTypeId = $("#inputAnnotationDescription").val();
            dataSend.Date = convertDateUsToDateBr($("#inputAnnotationDate").val());
            dataSend.ResolutionDate = convertDateUsToDateBr($("#inputAnnotationResolutionDate").val());
            dataSend.Content = $("#inputAnnotationContent").val();
            dataSend.Chapa = chapa;
            dataSend.PersonId = personId;
            dataSend.Description = $("#inputAnnotationDescription option:selected").text();

            $.ajax(
            {
                type: 'POST',
                url: '/Annotation/SaveAnnotation',
                dataType: "json",
                data: dataSend,
                success: function (data) {
                    $(".modalAnnotation").modal("hide");
                    swal("Good job!", "", "success");
                    laddaButton.ladda('toggle');
                    if (dataSend.Nro == 0) {
                        addRow(data, data.Nro);
                    } else {
                        updateRow(data);
                    }
                },
                error: function (err) {
                    laddaButton.ladda('toggle');
                    sweetAlert("Oops...", "Something went wrong!", "error");
                }
            });
        }

    });
});

function appendTemplate(tmpl) {
    $("#resultset").html("");
    $("#resultset").append(tmpl);

    $("#resultset a").off('click').on('click', function () {
        chapa = $(this).data().chapa;
        personId = $(this).data().personId;
        annotations = {}, tmplAnnotations = "";

        for (var i = 0; i < cacheTeachers.length; i++) {
            if (cacheTeachers[i].Chapa == chapa) {
                annotations = cacheTeachers[i];
            }
        }

        for (var i = 0; i < annotations.Person.Annotations.length; i++) {
            var date = "", resolutionDate = "";

            if (annotations.Person.Annotations[i].Date != null) {
                date = moment(annotations.Person.Annotations[i].Date).format("MM/DD/Y");
            }

            if (annotations.Person.Annotations[i].ResolutionDate != null) {
                resolutionDate = moment(annotations.Person.Annotations[i].ResolutionDate).format("MM/DD/Y");
            }

            if (annotations.Person.Annotations[i].Codusuario == null) {
                annotations.Person.Annotations[i].Codusuario = "";
            }

            tmplAnnotations += '<tr class="annotation-tr" data-annotation-person-id="' + annotations.Person.Id + '" data-annotation-type-id="' + annotations.Person.Annotations[i].AnnotationTypeId + '" data-annotation-nro="' + annotations.Person.Annotations[i].Nro + '" data-annotation-description="' + annotations.Person.Annotations[i].AnnotationDescription + '" data-annotation-content="' + annotations.Person.Annotations[i].Content + '" data-annotation-date="' + date + '" data-annotation-resolution-date="' + resolutionDate + '" data-lastmodifiedby="' + annotations.Person.Annotations[i].Codusuario + '">';
            tmplAnnotations += '<td class="annotation-nro">' + annotations.Person.Annotations[i].Nro + '</td>';
            tmplAnnotations += '<td class="annotation-description">' + annotations.Person.Annotations[i].AnnotationDescription + '</td>';
            tmplAnnotations += '<td class="color-blue-grey-lighter annotation-content">' + annotations.Person.Annotations[i].Content.substring(0,30)+'...' + '</td>';
            tmplAnnotations += '<td class="table-date annotation-date">' + date + '</td>';
            tmplAnnotations += '<td class="table-date annotation-lastmodifiedby">' + annotations.Person.Annotations[i].Codusuario + '</td>';
            tmplAnnotations += '<td class="table-icon-cell text-center"><button class="btn btn-sm btn-warning btn-rounded button-show"><i class="fa fa-pencil-square-o"></i></button></td>';
            tmplAnnotations += '</tr>';
        }

        $blockquote = $(this).closest("blockquote");
        $("#resultset blockquote").css("display", "none");
        $($blockquote).css("display", "");
        $("#annnotationsSection").removeClass("hidden");
        $("#tableAnnotations tbody").html(tmplAnnotations);
        $(".label-total-annotation").html(annotations.Person.Annotations.length + ' Evaluation notes');
        attachTableAnnotationsBtnShowClick();
    });
}

function addRow(dataSend, nro) {
    if (dataSend.Date != null) {
        dataSend.Date = moment(dataSend.Date).format("MM/DD/Y");
    }

    if (dataSend.ResolutionDate != null) {
        dataSend.ResolutionDate = moment(dataSend.ResolutionDate).format("MM/DD/Y");
    }

    if (dataSend.Codusuario == null) {
        dataSend.Codusuario = "";
    }

    var tmpl = "";
    tmpl += '<tr class="annotation-tr" data-annotation-person-id="' + dataSend.PersonId + '" data-annotation-type-id="' + dataSend.AnnotationTypeId + '" data-annotation-nro="' + nro + '" data-annotation-description="' + dataSend.AnnotationDescription + '" data-annotation-content="' + dataSend.Content + '" data-annotation-date="' + dataSend.Date + '" data-annotation-resolution-date="' + dataSend.ResolutionDate + '">';
    tmpl += '<td class="annotation-nro">' + nro + '</td>';
    tmpl += '<td class="annotation-description">' + dataSend.AnnotationDescription + '</td>';
    tmpl += '<td class="color-blue-grey-lighter annotation-content">' + dataSend.Content.substring(0, 30) + '...' + '</td>';
    tmpl += '<td class="table-date annotation-date">' + dataSend.Date + '</td>';
    tmpl += '<td class="table-date annotation-lastmodifiedby">' + dataSend.Codusuario + '</td>';
    tmpl += '<td class="table-icon-cell text-center"><button class="btn btn-sm btn-warning btn-rounded button-show"><i class="fa fa-pencil-square-o"></i></button></td>';
    tmpl += '</tr>';

    $("#tableAnnotations tbody").append(tmpl);
    attachTableAnnotationsBtnShowClick();
}

function updateRow(dataSend) {
    dataSend.Date = convertDateBrToDateUs(dataSend.Date);
    dataSend.ResolutionDate = convertDateBrToDateUs(dataSend.ResolutionDate);

    if (dataSend.Date != null && dataSend.Date != "") {
        dataSend.Date = moment(dataSend.Date).format("MM/DD/Y");
    }

    if (dataSend.ResolutionDate != null && dataSend.ResolutionDate != "") {
        dataSend.ResolutionDate = moment(dataSend.ResolutionDate).format("MM/DD/Y");
    }

    if (dataSend.Codusuario == null) {
        dataSend.Codusuario = "";
    }

    $tr = $("#tableAnnotations tbody").find('tr[data-annotation-nro=' + dataSend.Nro + ']');

    $($tr).data('annotationContent', dataSend.Content);
    $($tr).data('annotationDate', dataSend.Date);
    $($tr).data('annotationResolutionDate', dataSend.ResolutionDate);

    $($tr).find('.annotation-content').html(dataSend.Content.substring(0, 30) + '...');
    $($tr).find('.annotation-date').html(dataSend.Date);
    $($tr).find('.annotation-lastmodifiedby').html(dataSend.Codusuario);
}

function clearModal() {
    $("#inputAnnotationDescription").val('');
    $("#inputAnnotationContent").val('');
    $("#inputAnnotationDate").val('');
    $("#inputAnnotationResolutionDate").val('');
    $("#inputAnnotationPersonId").val('');
    $("#inputAnnotationNro").val(0);
}

function getAnnotationsType() {
    $.ajax(
    {
        type: 'POST',
        url: '/Annotation/GeyAnnotationsType',
        dataType: "json",
        success: function (data) {
            selectAnnotations = "";
            for (var i = 0; i < data.length; i++) {
                selectAnnotations += '<option value="' + data[i].Id + '">' + data[i].Description + '</option>';
            }
            $("#inputAnnotationDescription").append(selectAnnotations);
        },
        error: function (err) {
            console.log(err);
            sweetAlert("Oops...", "Something went wrong!", "error");
        }
    });
}

function attachTableAnnotationsBtnShowClick() {
    $("#tableAnnotations tbody .button-show").off('click')
    .on('click', function () {

        $tr = $(this).closest(".annotation-tr");

        annotationTypeId = $($tr).data('annotationTypeId');
        nro = $($tr).data('annotationNro');
        description = $($tr).data('annotationDescription');
        content = $($tr).data('annotationContent');
        date = $($tr).data('annotationDate');
        resolutionDate = $($tr).data('annotationResolutionDate') == null ? "" : $($tr).data('annotationResolutionDate');

        console.log(resolutionDate);

        $("#inputAnnotationDescription").val(annotationTypeId).prop('disabled', 'disabled');
        $("#inputAnnotationContent").val(content);
        $("#inputAnnotationDate").val(date);
        $("#inputAnnotationResolutionDate").val(resolutionDate);
        $("#inputAnnotationNro").val(nro);

        $(".modalAnnotation").modal("show");
    });
}