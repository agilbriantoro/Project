$(document).ready(function () {
    $('#datatablesSimple').DataTable({
        ajax: {
            url: "https://localhost:7290/api/Employee",
            dataSrc: "data",
            dataType: "JSON",
        },
        columns: [
            {
                data: null,
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            { data: "FirstName" },
            { data: "LastName" },
            { data: "Email" },
            { data: "PhoneNumber" },
            { data: "HiringDate" },
            {
                row: "",
                render: function (data, type, row) {
                    return `<button type="button" class="btn btn-primary btn-xs dt-edit" style="margin-right:16px;" onclick="update('${data}', '${row["firstName"]}', '${row["lastName"]}')" data-bs-toggle="modal" data-bs-target="#modalUpdate">
                                <i class="fas fa-pen"></i>
                                <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
                            </button>
                            <button type="button" class="btn btn-danger btn-xs dt-delete" id="deleteBtn" onclick="remove('${data}')">
                                <i class="fas fa-remove"></i>
                                <span class="glyphicon glyphicon-remove" aria-hidden="true"></span>
                            </button>`;
                }
            },
        ],
        dom: '<"top"Bf>rt<"bottom"pli><"clear">',
        buttons: [
            {
                extends: 'copy',
                text: '<i class="fa fa-files-o"></i>',
                titleAttr: 'Copy'
            },
            {
                extend: 'excel',
                text: '<i class="fa fa-file-excel-o"></i>',
                titleAttr: 'Excel'
            },
            {
                extend: 'csv',
                text: '<i class="fa fa-file-csv"></i>',
                titleAttr: 'CSV'
            },
            {
                extend: 'pdf',
                text: '<i class="fa fa-file-pdf-o"></i>',
                titleAttr: 'PDF'
            },
        ]
    });
    $("#plus").html(`
                <button type="button" class="btn btn-primary btn-xs dt-edit" style="margin-right:16px; margin-bottom: 15px;" data-bs-toggle="modal" data-bs-target="#exampleModal">
                    <i class="fas fa-plus"></i>
                    <span aria-hidden="true"></span>
                </button>`);

});

$("#formData").ready(function () {
    $("#modalTitle").html("Insert")
    $("#submit").click(function (e) {
        e.preventDefault();
        let today = new Date();
        let obj = {};
        obj.firstName = $("#firstName").val();
        obj.lastName = $("#lastName").val();
        obj.lastUpdate = $("#lastUpdate").val();;
        $.ajax({
            url: "https://localhost:7290/api/Employee",
            type: "POST",
            dataType: "json",
            contentType: "application/json;charset=utf-8",
            data: JSON.stringify(obj), //jika terkena 415 unsupported media type (tambahkan headertype Json & JSON.Stringify();)
        }).done((result) => {
            alert("success")
            $("#myTable").DataTable().ajax.reload()
            $("#exampleModal").modal("hide")
        }).fail((error) => {
            alert(error.message)
            $("#exampleModal").modal("hide")
        })
    });
});

function remove(id) {
    $.ajax({
        type: "DELETE",
        url: "https://localhost:7290/api/Employee?key=" + id,
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        data: id, //jika terkena 415 unsupported media type (tambahkan headertype Json & JSON.Stringify();)
    })

        .done((result) => {
            alert("success to delete data")
            $("#myTable").DataTable().ajax.reload()
            $("#exampleModal").modal("hide")
        }).fail((error) => {
            alert(error.message)
            $("#exampleModal").modal("hide")
        })
}

function update(a, b, c) {
    $("#modalUpdateTitle").html("Update");
    $("#update").html();

}