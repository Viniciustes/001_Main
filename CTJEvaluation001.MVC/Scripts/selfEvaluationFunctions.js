$(document).ready(function () {

    $btnCrud5aSave = $("#btnCrud5aSave"),
    $btnCrud5bSave = $("#btnCrud5bSave");
    $btnCrud5OtherTypesSave = $("#btnCrud5OtherTypesSave");
    $btnCrud6Save = $("#btnCrud6Save");
    $btnCrud7Save = $("#btnCrud7Save");
    $btnSelfEvalSave = $("#btnSelfEvalSave");

    $checkboxCrudProfDevOtherTypes = $(".row-table-professional-development-other-types input[type=checkbox]");
    $checkboxCrudProfAttitude = $(".row-table-professional-attitude input[type=checkbox]");

    $addRowTableProfessionalDevelopment01 = $("#btnAddRowTableProfessionalDevelopment01");
    $editRowTableProfessionalDevelopment01 = $(".row-table-professional-development-01 .label-edit");
    $removeRowTableProfessionalDevelopment01 = $(".row-table-professional-development-01 .label-remove");

    $addRowTableProfessionalDevelopment02 = $("#btnAddRowTableProfessionalDevelopment02");
    $editRowTableProfessionalDevelopment02 = $(".row-table-professional-development-02 .label-edit");
    $removeRowTableProfessionalDevelopment02 = $(".row-table-professional-development-02 .label-remove");

    $addRowTableDigitalLiteracy = $("#btnAddRowTableDigitalLiteracy");
    $editRowTableDigitalLiteracy = $(".row-table-digital-literacy .label-edit");
    $removeRowTableDigitalLiteracy = $(".row-table-digital-literacy .label-remove");

    $editRowTableProfessionalDevelopmentOtherTypes = $(".row-table-professional-development-other-types .label-edit");
    $editRowTableProfAttitude = $(".row-table-professional-attitude .label-edit");

    $crud5AModal = $('.crud5a-modal');
    $crud5OtherTypesModal = $(".crud5-other-types-modal");
    $crud5BModal = $('.crud5b-modal');
    $crud6Modal = $('.crud6-modal');
    $crud7Modal = $('.crud7-modal');

    applyEventShowImage();

    $checkboxCrudProfDevOtherTypes.click(function (event) {
        var isChecked = $(this).is(":checked"), $inputCheckType = $(this);
        event.preventDefault();

        var $rowParent = $(this).closest(".row-table-professional-development-other-types"),
            rowName = $($rowParent).find(".content-name").html(),
            rowAno = $($rowParent).data('selfevalAno'),
            rowCtjEvalId = $($rowParent).data('selfevalCtjevalid'),
            rowCtjEvalName = $($rowParent).data('selfevalCtjevalname'),
            $btnEdit = $($rowParent).find('.label-edit');

        if (isChecked) {
            $crud5OtherTypesModal.find("#inputCrud5OtherTypesDetails").val("");
            $crud5OtherTypesModal.find("#inputCrud5OtherTypesName").val(rowName);
            $crud5OtherTypesModal.modal('show');

            $btnCrud5OtherTypesSave.off('click').on('click', function () {
                var formIsValid = $("#formCrud5OtherTypes").valid();
                var laddaButton = $btnCrud5OtherTypesSave.ladda();

                if (formIsValid == true) {
                    laddaButton.ladda('toggle');
                    var details = $("#inputCrud5OtherTypesDetails").val();

                    var dataSend = {
                        details: details,
                        ano: 2016,
                        chapa: "002115",
                        ctjevalid: rowCtjEvalId,
                        ctjevalname: rowCtjEvalName,
                        details: details,
                        ischecked: 1
                    };

                    $.ajax(
                    {
                        type: 'POST',
                        url: '/SelfEvaluation/ProjectActivity',
                        data: dataSend,
                        dataType: "json",
                        success: function (data) {
                            laddaButton.ladda('toggle');
                            $inputCheckType.prop('checked', true);
                            $btnEdit.prop('disabled', false);
                            var dataReturn = data;
                            $($rowParent).data('selfevalCtjevaldetails', dataReturn.Details);
                            $crud5OtherTypesModal.modal('hide');                            
                            swal("Good job!", "", "success");
                        },
                        error: function (err) {
                            laddaButton.ladda('toggle');
                            sweetAlert("Oops...", "Something went wrong!", "error");
                        }
                    });
                }
            });
        } else {
            swal({
                title: "Are you sure?",
                text: "You will not be able to recover this imaginary file!",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes, delete it!",
                closeOnConfirm: false
            }, function () {
                var details = $("#inputCrud5OtherTypesDetails").val();

                var dataSend = {
                    details: details,
                    ano: 2016,
                    chapa: "002115",
                    ctjevalid: rowCtjEvalId,
                    ctjevalname: rowCtjEvalName,
                    details: details,
                    ischecked: 0
                };

                projectActivityRemove(dataSend, function (data) {
                    $inputCheckType.prop('checked', false);
                    $btnEdit.prop('disabled', true);
                    $($rowParent).data('selfevalCtjevaldetails', '');
                    swal("Deleted!", "Your imaginary file has been deleted.", "success");
                });
            });
        }
    });

    $editRowTableProfessionalDevelopmentOtherTypes.click(function () {
        var $rowParent = $(this).closest(".row-table-professional-development-other-types"),
            rowName = $($rowParent).find(".content-name").html(),
            rowDetails = $($rowParent).data('selfevalCtjevaldetails'),
            rowAno = $($rowParent).data('selfevalAno'),
            rowCtjEvalId = $($rowParent).data('selfevalCtjevalid'),
            rowCtjEvalName = $($rowParent).data('selfevalCtjevalname')

        $crud5OtherTypesModal.find("#inputCrud5OtherTypesDetails").val(rowDetails);
        $crud5OtherTypesModal.find("#inputCrud5OtherTypesName").val(rowName);
        $crud5OtherTypesModal.modal('show');

        $btnCrud5OtherTypesSave.off('click').on('click', function () {
            var formIsValid = $("#formCrud5OtherTypes").valid();
            var laddaButton = $btnCrud5OtherTypesSave.ladda();

            if (formIsValid) {
                laddaButton.ladda('toggle');
                var details = $("#inputCrud5OtherTypesDetails").val();

                var dataSend = {
                    details: details,
                    ano: 2016,
                    chapa: "002115",
                    ctjevalid: rowCtjEvalId,
                    ctjevalname: rowCtjEvalName,
                    details: details,
                    ischecked: 1
                };

                $.ajax(
                {
                    type: 'POST',
                    url: '/SelfEvaluation/ProjectActivity',
                    data: dataSend,
                    dataType: "json",
                    success: function (data) {
                        var dataReturn = data;
                        //$rowParent.find(".content-details").html(dataReturn.Details);
                        $($rowParent).data('selfevalCtjevaldetails', dataReturn.Details);
                        $crud5OtherTypesModal.modal('hide');
                        laddaButton.ladda('toggle');
                        swal("Good job!", "", "success")
                    },
                    error: function (err) {
                        laddaButton.ladda('toggle');
                        sweetAlert("Oops...", "Something went wrong!", "error");
                    }
                });
            }
        });
    });

    $("#inputCrud5aFile, #inputCrud5bFile").change(function () {
        var fileName = $(this).val();
        var arrFileName = fileName.split('\\');
        var file = "";

        if (arrFileName.length > 0) {
            file = arrFileName[arrFileName.length - 1];
        } else {
            file = "No file chosen";
        }

        var div = $(this).closest("div.fileinput");
        var span = $(div).find("span.fileinput-new");
        $(span).html('<span class="glyphicon glyphicon-file"></span> ' + file);
    });

    $addRowTableProfessionalDevelopment01.click(function () {
        $("#formCrud5a").find('label.error').css('display', 'none');
        $crud5AModal.find("#inputCrud5aDate").val("");
        $crud5AModal.find("#inputCrud5aDescription").val("");
        $crud5AModal.find('span.fileinput-new').html('No file chosen');
        $crud5AModal.modal('show');

        $btnCrud5aSave.off('click').on('click', function () {

            var formIsValid = $("#formCrud5a").valid();
            var laddaButton = $btnCrud5aSave.ladda();

            if (formIsValid == true) {
                laddaButton.ladda('toggle');
                var date = $("#inputCrud5aDate").val(),
                    description = $("#inputCrud5aDescription").val();

                if (window.FormData !== undefined) {
                    var fileUpload = $("#inputCrud5aFile").get(0);
                    var files = fileUpload.files;

                    // Create FormData object
                    var fileData = new FormData();

                    for (var i = 0; i < files.length; i++) {
                        fileData.append(files[i].name, files[i]);
                    }

                    date = convertDateUsToDateBr(date);
                    fileData.append('data', date);
                    fileData.append('description', description);
                    fileData.append('tipo', 1);

                    $.ajax({
                        url: '/SelfEvaluation/ProfissionalDevelpment',
                        type: "POST",
                        contentType: false, // Not to set any content header
                        processData: false, // Not to process data
                        data: fileData,
                        success: function (data) {
                            var dataReturn = data,
                                trTmpl = "";

                            trTmpl = trTmpl = getRowProfessionalDevelopment01Tmpl(dataReturn);

                            if ($(".row-table-professional-development-01").length == 0) {
                                $(".tbody-professional-development-01").html('');
                            }

                            laddaButton.ladda('toggle');
                            $(".tbody-professional-development-01").append(trTmpl);
                            applyEventShowImage();
                            removeRowTableProfessionalDevelopment01OnClick();
                            $crud5AModal.modal('hide');                            
                            swal("Good job!", "", "success");
                        },
                        error: function (err) {
                            laddaButton.ladda('toggle');
                            sweetAlert("Oops...", "Something went wrong!", "error");                            
                        }
                    });
                } else {
                    sweetAlert("Oops...", "FormData is not supported.", "error");
                }
            }
        });
    });

    removeRowTableProfessionalDevelopment01OnClick();

    $addRowTableProfessionalDevelopment02.click(function () {
        $crud5BModal.find("#inputCrud5bDate").val("");
        $crud5BModal.find("#inputCrud5bDescription").val("");
        $crud5BModal.find("#inputCrud5bDetails").val("");
        $crud5AModal.find('span.fileinput-new').html('No file chosen');
        $crud5BModal.modal('show');

        $btnCrud5bSave.off('click').on('click', function () {
            var formIsValid = $("#formCrud5b").valid();
            var laddaButton = $btnCrud5bSave.ladda();

            if (formIsValid == true) {
                laddaButton.ladda('toggle');
                var date = $("#inputCrud5bDate").val(),
                description = $("#inputCrud5bDescription").val(),
                details = $("#inputCrud5bDetails").val();

                if (window.FormData !== undefined) {
                    var fileUpload = $("#inputCrud5bFile").get(0);
                    var files = fileUpload.files;

                    // Create FormData object
                    var fileData = new FormData();

                    for (var i = 0; i < files.length; i++) {
                        fileData.append(files[i].name, files[i]);
                    }

                    date = convertDateUsToDateBr(date);
                    fileData.append('data', date);
                    fileData.append('description', description);
                    fileData.append('details', details);
                    fileData.append('tipo', 2);

                    $.ajax({
                        url: '/SelfEvaluation/ProfissionalDevelpment',
                        type: "POST",
                        contentType: false, // Not to set any content header
                        processData: false, // Not to process data
                        data: fileData,
                        success: function (data) {
                            var dataReturn = data,
                                trTmpl = "";

                            trTmpl = trTmpl = getRowProfessionalDevelopment02Tmpl(dataReturn);

                            if ($(".tbody-professional-development-02").find('tr .alert').length == 1) {
                                $(".tbody-professional-development-02").html('');
                            }

                            $(".tbody-professional-development-02").append(trTmpl);
                            applyEventShowImage();
                            removeRowTableProfessionalDevelopment02OnClick();
                            $crud5BModal.modal('hide');
                            laddaButton.ladda('toggle');
                            swal("Good job!", "", "success");
                        },
                        error: function (err) {
                            laddaButton.ladda('toggle');
                            sweetAlert("Oops...", "Something went wrong!", "error");
                        }
                    });
                } else {
                    alert("FormData is not supported.");
                }
            }
        });
    });

    removeRowTableProfessionalDevelopment02OnClick();

    $addRowTableDigitalLiteracy.click(function () {
        $crud6Modal.find("#inputCrud6Date").val("");
        $crud6Modal.find("#inputCrud6Evidence").val("");
        $crud6Modal.modal("show");

        $btnCrud6Save.off('click').on('click', function () {
            var formIsValid = $("#formCrud6").valid();
            var laddaButton = $btnCrud6Save.ladda();

            if (formIsValid == true) {
                laddaButton.ladda('toggle');
                var date = $("#inputCrud6Date").val(),
                description = $("#inputCrud6Evidence").val();

                date = convertDateUsToDateBr(date);

                var dataSend = {
                    data: date,
                    description: description
                };

                $.ajax(
                {
                    type: 'POST',
                    url: '/SelfEvaluation/DigitalLiteracy',
                    data: dataSend,
                    dataType: "json",
                    success: function (data) {
                        var dataReturn = data,
                                trTmpl = "";

                        trTmpl = trTmpl = getRowDigitalLiteracyTmpl(dataReturn);

                        if ($(".tbody-digital-literacy").find('tr .alert').length == 1) {
                            $(".tbody-digital-literacy").html('');
                        }

                        $(".tbody-digital-literacy").append(trTmpl);
                        applyEventShowImage();
                        removeRowTableDigitalLiteracyOnClick();
                        $crud6Modal.modal('hide');
                        laddaButton.ladda('toggle');
                        swal("Good job!", "", "success");
                    },
                    error: function (err) {
                        laddaButton.ladda('toggle');
                        sweetAlert("Oops...", "Something went wrong!", "error");
                    }
                });
            }
        });
    });

    removeRowTableDigitalLiteracyOnClick();

    $checkboxCrudProfAttitude.click(function (event) {
        var isChecked = $(this).is(":checked"), $inputCheckType = $(this);
        event.preventDefault();

        var $rowParent = $(this).closest(".row-table-professional-attitude"),
            rowName = $($rowParent).find(".content-name").html(),
            rowAno = $($rowParent).data('selfevalAno'),
            rowCtjEvalId = $($rowParent).data('selfevalCtjevalid'),
            rowCtjEvalName = $($rowParent).data('selfevalCtjevalname'),
            $btnEdit = $($rowParent).find('.label-edit')    ;

        if (isChecked) {
            $crud7Modal.find("#inputCrud7Details").val("");
            $crud7Modal.find("#inputCrud7Activity").val(rowName);
            $crud7Modal.modal('show');

            $btnCrud7Save.off('click').on('click', function () {
                var formIsValid = $("#formCrud7").valid();
                var laddaButton = $btnCrud7Save.ladda();

                if (formIsValid == true) {
                    laddaButton.ladda('toggle');
                    var details = $("#inputCrud7Details").val();

                    var dataSend = {
                        details: details,
                        ano: 2016,
                        chapa: "002115",
                        ctjevalid: rowCtjEvalId,
                        ctjevalname: rowCtjEvalName,
                        details: details,
                        ischecked: 1
                    };

                    $.ajax(
                    {
                        type: 'POST',
                        url: '/SelfEvaluation/ProjectActivity',
                        data: dataSend,
                        dataType: "json",
                        success: function (data) {
                            var dataReturn = data;
                            $inputCheckType.prop('checked', true);
                            $btnEdit.prop('disabled', false);
                            $($rowParent).data('selfevalCtjevaldetails', dataReturn.Details);
                            $crud7Modal.modal('hide');
                            laddaButton.ladda('toggle');
                            swal("Good job!", "", "success")
                        },
                        error: function (err) {
                            laddaButton.ladda('toggle');
                            sweetAlert("Oops...", "Something went wrong!", "error");
                        }
                    });
                }
            });

        } else {
            swal({
                title: "Are you sure?",
                text: "",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes, delete it!",
                closeOnConfirm: false
            }, function () {
                var details = $("#inputCrud7Details").val();

                var dataSend = {
                    details: details,
                    ano: 2016,
                    chapa: "002115",
                    ctjevalid: rowCtjEvalId,
                    ctjevalname: rowCtjEvalName,
                    details: details,
                    ischecked: 0
                };

                projectActivityRemove(dataSend, function (data) {
                    $($rowParent).data('selfevalCtjevaldetails', '');
                    $inputCheckType.prop('checked', false);
                    $btnEdit.prop('disabled', true);
                    swal("Deleted!", "", "success");
                });
            });
        }
    });

    $editRowTableProfAttitude.click(function () {
        var $rowParent = $(this).closest(".row-table-professional-attitude"),
            rowName = $($rowParent).find(".content-name").html(),
            rowDetails = $($rowParent).data('selfevalCtjevaldetails'),
            rowAno = $($rowParent).data('selfevalAno'),
            rowCtjEvalId = $($rowParent).data('selfevalCtjevalid'),
            rowCtjEvalName = $($rowParent).data('selfevalCtjevalname');

        $crud7Modal.find("#inputCrud7Activity").val(rowName);
        $crud7Modal.find("#inputCrud7Details").val(rowDetails);
        $crud7Modal.modal('show');

        $btnCrud7Save.off('click').on('click', function () {
            var formIsValid = $("#formCrud7").valid();
            var laddaButton = $btnCrud7Save.ladda();

            if (formIsValid == true) {
                laddaButton.ladda('toggle');
                var details = $("#inputCrud7Details").val();

                var dataSend = {
                    details: details,
                    ano: 2016,
                    chapa: "002115",
                    ctjevalid: rowCtjEvalId,
                    ctjevalname: rowCtjEvalName,
                    details: details,
                    ischecked: 1
                };

                $.ajax(
                {
                    type: 'POST',
                    url: '/SelfEvaluation/ProjectActivity',
                    data: dataSend,
                    dataType: "json",
                    success: function (data) {
                        var dataReturn = data;
                        console.log(data);
                        $rowParent.find(".content-details").html(dataReturn.Details);
                        $rowParent.data('selfeval-ctjevaldetails', dataReturn.Details);
                        $crud7Modal.modal('hide');
                        laddaButton.ladda('toggle');
                        swal("Good job!", "", "success")
                    },
                    error: function (err) {
                        laddaButton.ladda('toggle');
                        sweetAlert("Oops...", "Something went wrong!", "error");
                    }
                });
            }
        });
    });

    $btnSelfEvalSave.on('click', function () {

        var laddaButton = $(this).ladda();
        laddaButton.ladda('toggle');

        var $inputFileUnderWay = $("#inputDegreeUnderWayFile"),
            $inputCtjEvents01Confirm = $("#inputCtjEvents01Confirm:checked"),
            $inputCtjEvents02Confirm = $("#inputCtjEvents02Confirm:checked"),
            $inputCtjEvents02AConfirm = $("#inputCtjEvents02AConfirm:checked"),
            $inputDegree = $('input[name=degree]:checked'),
            $inputCertOfProf = $("input[name=inputCertOfProf]:checked"),
            $inputDigitalProjects = $("#inputDigitalProjects"),
            $inputFinalReflectionA = $("#inputFinalReflectionA"),
            $inputFinalReflectionB = $("#inputFinalReflectionB");
        $inputFinalReflectionC = $("#inputFinalReflectionC");
        $inputFinalReflectionD = $("#inputFinalReflectionD");
        $inputFinalReflectionE = $("#inputFinalReflectionE");
        $inputFinalReflectionF = $("#inputFinalReflectionF");
        $inputFinalReflectionG = $("#inputFinalReflectionG");

        if ($inputFileUnderWay.val() != "") {
            if (window.FormData !== undefined) {
                var fileUpload = $inputFileUnderWay.get(0);
                var files = fileUpload.files;

                // Create FormData object
                fileData = new FormData();

                for (var i = 0; i < files.length; i++) {
                    fileData.append(files[i].name, files[i]);
                }

                fileData.append('ano', 2016);
                fileData.append('chapa', '002115');
                fileData.append('ctjevents01confirm', $inputCtjEvents01Confirm.val());
                fileData.append('ctjevents02confirm', $inputCtjEvents02Confirm.val());
                fileData.append('ctjevents02aconfirm', $inputCtjEvents02AConfirm.val());
                fileData.append('degree', $inputDegree.val());
                fileData.append('certificateofproficiency', $inputCertOfProf.val());
                fileData.append('digitalproject', $inputDigitalProjects.val());
                fileData.append('finalreflectiona', $inputFinalReflectionA.val());
                fileData.append('finalreflectionb', $inputFinalReflectionB.val());
                fileData.append('finalreflectionc', $inputFinalReflectionC.val());
                fileData.append('finalreflectiond', $inputFinalReflectionD.val());
                fileData.append('finalreflectione', $inputFinalReflectionE.val());
                fileData.append('finalreflectionf', $inputFinalReflectionF.val());
                fileData.append('finalreflectiong', $inputFinalReflectionG.val());

                selfEvalSaveWithUpload(fileData, laddaButton);

            } else {
                alert("FormData is not supported.");
                laddaButton.ladda('toggle');
            }
        } else {
            var dataSend = {};

            dataSend.chapa = "002115";
            dataSend.ano = 2016;
            dataSend.ctjevents01confirm = $inputCtjEvents01Confirm.val();
            dataSend.ctjevents02confirm = $inputCtjEvents02Confirm.val();
            dataSend.ctjevents02aconfirm = $inputCtjEvents02AConfirm.val();
            dataSend.degree = $inputDegree.val();
            dataSend.certificateofproficiency = $inputCertOfProf.val();
            dataSend.digitalproject = $inputDigitalProjects.val();
            dataSend.finalreflectiona = $inputFinalReflectionA.val();
            dataSend.finalreflectionb = $inputFinalReflectionB.val();
            dataSend.finalreflectionc = $inputFinalReflectionC.val();
            dataSend.finalreflectiond = $inputFinalReflectionD.val();
            dataSend.finalreflectione = $inputFinalReflectionE.val();
            dataSend.finalreflectionf = $inputFinalReflectionF.val();
            dataSend.finalreflectiong = $inputFinalReflectionG.val();

            selfEvalSave(dataSend, laddaButton);
        }
    });

    if ($('input[name=degree]:checked').val() == '2') {
        $("#collapseQ6Upload").collapse('show');
    }
    else {
        $("#collapseQ6Upload").collapse('hide');
    }
});

function professionalDevelpmentSave(dataSave) {
    $.ajax({
        url: '/SelfEvaluation/ProfissionalDevelpment',
        type: "POST",
        contentType: false, // Not to set any content header
        processData: false, // Not to process data
        data: dataSave,
        success: function (data) {
            console.log(data);

            $crud5AModal.modal('hide');
            laddaButton.ladda('toggle');
            swal("Good job!", "", "success")
        },
        error: function (err) {
            alert(err.statusText);
        }
    });
}

function professionalDevelpmentRemove(data, _callback) {
    $.ajax(
    {
        type: 'POST',
        url: '/SelfEvaluation/ProfissionalDevelpmentDelete',
        data: data,
        dataType: "json",
        success: _callback(data)
    });
}

function projectActivitySave(data, _callback) {
    $.ajax(
    {
        type: 'POST',
        url: '/SelfEvaluation/ProjectActivity',
        data: data,
        dataType: "json",
        success: _callback(data)
    });
}

function projectActivityRemove(data, _callback) {
    $.ajax(
    {
        type: 'POST',
        url: '/SelfEvaluation/ProjectActivityDelete',
        data: data,
        dataType: "json",
        success: _callback(data)
    });
}

function digitalLiteracySave(data, _callback) {
    $.ajax(
    {
        type: 'POST',
        url: '/SelfEvaluation/DigitalLiteracy',
        data: data,
        dataType: "json",
        success: _callback(data)
    });
}

function digitalLiteracyRemove(data, _callback) {
    $.ajax(
    {
        type: 'POST',
        url: '/SelfEvaluation/DigitalLiteracyDelete',
        data: data,
        dataType: "json",
        success: _callback(data)
    });
}

function selfEvalSave(data, laddaButton) {
    $.ajax(
    {
        type: 'POST',
        url: '/SelfEvaluation/Save',
        data: data,
        dataType: "json",
        success: function (data) {
            swal("Good job!", "", "success")
            laddaButton.ladda('toggle');
        },
        error: function (err) {
            sweetAlert("Oops...", "Something went wrong!", "error");
            laddaButton.ladda('toggle');
        }
    });
}

function selfEvalSaveWithUpload(data, _callback) {
    $.ajax({
        url: '/SelfEvaluation/Save',
        type: "POST",
        contentType: false, // Not to set any content header
        processData: false, // Not to process data
        data: data,
        success: function (data) {
            swal("Good job!", "", "success")
            laddaButton.ladda('toggle');
        },
        error: function (err) {
            sweetAlert("Oops...", "Something went wrong!", "error");
            laddaButton.ladda('toggle');
        }
    });
}

function applyEventShowImage() {
    $('.label-show-image').off('click').on('click', function (event) {
        button = $(this);
        var filename = button.data('filename');
        var appbasepath = '\\' + button.data('appbasepath');
        var basepath = button.data('basepath');
        var mime = button.data('mime');
        var fullname = appbasepath + basepath + filename;

        var modal = $("#modalShowImagem");
        modal.find('.modal-title').html(filename);
        modal.find('.modal-body').html('');
        if (mime == "application/pdf") {
            modal.find('.modal-body').append('<object data="' + fullname + '" widht="100%" height="600" type="application/pdf"></object>');
        } else {
            modal.find('.modal-body').append('<img src="' + fullname + '" alt="Imagem" class="img-show-imagem">');
        }
        modal.modal("show");
    });
}

function getRowProfessionalDevelopment01Tmpl(dataReturn) {
    var tmpl = "";
    var milli = dataReturn.Data.replace(/\/Date\((-?\d+)\)\//, '$1');

    var d = new Date(parseInt(milli));
    var dFormat = moment(d).format("DD/MM/YYYY");

    tmpl += '<tr class="row-table-professional-development-01" data-selfeval-ano="' + dataReturn.Ano + '" data-selfeval-tipo="' + dataReturn.Tipo + '" data-selfeval-nseq="' + dataReturn.Nseq + '" data-selfeval-image="' + dataReturn.Imagem.AppBasepath + dataReturn.Imagem.Basepath + dataReturn.Imagem.Filename + '">';
    tmpl += '<td class="table-date content-date">' + dFormat + '</td>';
    tmpl += '<td class="color-blue-grey-lighter content-description">' + dataReturn.Description + '</td>';
    tmpl += '<td class="table-icon-cell text-right"><button class="label-show-image btn btn-sm btn-info btn-rounded" data-toggle="modal" data-target=".modalShowImagem" data-appbasepath="' + dataReturn.Imagem.AppBasepath + '" data-basepath="' + dataReturn.Imagem.Basepath + '" data-filename="' + dataReturn.Imagem.Filename + '" data-mime="' + dataReturn.Imagem.Mime + '"><i class="glyphicon glyphicon-picture"></i></button> <button class="label-remove btn btn-sm btn-danger btn-rounded"><i class="fa fa-times"></i></button></td>';
    tmpl += '</tr>';

    return tmpl;
}

function getRowProfessionalDevelopment02Tmpl(dataReturn) {
    var tmpl = "";
    var milli = dataReturn.Data.replace(/\/Date\((-?\d+)\)\//, '$1');
    var d = new Date(parseInt(milli));
    var dFormat = moment(d).format("DD/MM/YYYY");

    tmpl += '<tr class="row-table-professional-development-02" data-selfeval-ano="' + dataReturn.Ano + '" data-selfeval-tipo="' + dataReturn.Tipo + '" data-selfeval-nseq="' + dataReturn.Nseq + '" data-selfeval-image="' + dataReturn.Imagem.AppBasepath + dataReturn.Imagem.Basepath + dataReturn.Imagem.Filename + '">';
    tmpl += '<td class="table-date content-date">' + dFormat + '</td>';
    tmpl += '<td class="color-blue-grey-lighter content-description">' + dataReturn.Description + '</td>';
    tmpl += '<td class="color-blue-grey-lighter content-details">' + dataReturn.Description + '</td>';
    tmpl += '<td class="table-icon-cell text-right"><button class="label-show-image btn btn-sm btn-info btn-rounded" data-toggle="modal" data-target=".modalShowImagem" data-appbasepath="' + dataReturn.Imagem.AppBasepath + '" data-basepath="' + dataReturn.Imagem.Basepath + '" data-filename="' + dataReturn.Imagem.Filename + '" data-mime="' + dataReturn.Imagem.Mime + '"><i class="glyphicon glyphicon-picture"></i></button> <button class="label-remove btn btn-sm btn-danger btn-rounded"><i class="fa fa-times"></i></button></td>';
    tmpl += '</tr>';

    return tmpl;
}

function getRowDigitalLiteracyTmpl(dataReturn) {
    var tmpl = "";
    var milli = dataReturn.Data.replace(/\/Date\((-?\d+)\)\//, '$1');
    var d = new Date(parseInt(milli));
    var dFormat = moment(d).format("DD/MM/YYYY");

    tmpl += '<tr class="row-table-digital-literacy" data-selfeval-ano="' + dataReturn.Ano + '" data-selfeval-nseq="' + dataReturn.Nseq + '">';
    tmpl += '<td class="table-date content-date">' + dFormat + '</td>';
    tmpl += '<td class="color-blue-grey-lighter content-description">' + dataReturn.Description + '</td>';
    tmpl += '<td class="table-icon-cell text-right"><button class="label-remove btn btn-sm btn-danger btn-rounded"><i class="fa fa-times"></i></button></td>';
    tmpl += '</tr>';

    return tmpl;
}

function removeRowTableProfessionalDevelopment01OnClick() {
    $(".row-table-professional-development-01 .label-remove").off('click').on('click', function () {
        var $rowParent = $(this).closest(".row-table-professional-development-01"),
            rowDate = $($rowParent).find(".content-date").html(),
            rowContent = $($rowParent).find(".content-description").html(),
            rowTipo = $($rowParent).data('selfevalTipo'),
            rowAno = $($rowParent).data('selfevalAno'),
            rowNseq = $($rowParent).data('selfevalNseq');

        var dataSend = {
            data: rowDate,
            nseq: rowNseq,
            description: rowContent,
            tipo: rowTipo,
            ano: rowAno
        };

        swal({
            title: "Are you sure?",
            text: "You will not be able to recover this imaginary file!",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Yes, delete it!",
            closeOnConfirm: false
        }, function () {
            professionalDevelpmentRemove(dataSend, function (data) {
                $rowParent.remove();
                swal("Deleted!", "", "success");

                if ($(".row-table-professional-development-01").length == 0) {
                    $(".tbody-professional-development-01").append('<tr><td colspan="3"><div class="alert alert-warning">There are no records.</div></td></tr>');
                }
            });
        });
    });
}

function removeRowTableProfessionalDevelopment02OnClick() {
    $(".row-table-professional-development-02 .label-remove").off('click').click(function () {
        var $rowParent = $(this).closest(".row-table-professional-development-02"),
            rowDate = $($rowParent).find(".content-date").html(),
            rowContent = $($rowParent).find(".content-description").html(),
            rowDetails = $($rowParent).find(".content-details").html(),
            rowAno = $($rowParent).data('selfevalAno'),
            rowNseq = $($rowParent).data('selfevalNseq');

        var dataSend = {
            data: rowDate,
            description: rowContent,
            details: rowDetails,
            tipo: 2,
            nseq: rowNseq,
            ano: rowAno
        };

        swal({
            title: "Are you sure?",
            text: "",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Yes, delete it!",
            closeOnConfirm: false
        }, function () {
            professionalDevelpmentRemove(dataSend, function (data) {
                $rowParent.remove();
                swal("Deleted!", "", "success");

                if ($(".row-table-professional-development-02").length == 0) {
                    $(".tbody-professional-development-02").append('<tr><td colspan="4"><div class="alert alert-warning">There are no records.</div></td></tr>');
                }
            });
        });
    });
}

function removeRowTableDigitalLiteracyOnClick() {
    $(".row-table-digital-literacy .label-remove").off('click').on('click', function () {
        var $rowParent = $(this).closest(".row-table-digital-literacy"),
            rowDate = $($rowParent).find(".content-date").html(),
            rowContent = $($rowParent).find(".content-description").html(),
            rowAno = $($rowParent).data('selfevalAno'),
            rowNseq = $($rowParent).data('selfevalNseq');

        var dataSend = {
            data: rowDate,
            description: rowContent,
            ano: rowAno,
            nseq: rowNseq
        };

        swal({
            title: "Are you sure?",
            text: "",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Yes, delete it!",
            closeOnConfirm: false
        }, function () {

            digitalLiteracyRemove(dataSend, function (data) {
                $rowParent.remove();
                swal("Deleted!", "", "success");

                if ($(".row-table-digital-literacy").length == 0) {
                    $(".tbody-digital-literacy").append('<tr><td colspan="3"><div class="alert alert-warning">There are no records.</div></td></tr>');
                }
            });
        });
    });
}