$(document).ready(function () {
    var tabelReload = $('#myTable').DataTable({
        ajax: {
            url: "https://localhost:7290/api/Employee", //=> CORS
            dataSrc: "data"
        },
        columns: [
            {
                data: null,
                render: function (data, type, row, x) {
                    return x.row + x.settings._iDisplayStart + 1;
                }
            },
            { data: "nik" },
            { data: "firstName" },
            { data: "lastName" },
            { data: "email" },
            { data: "hiringDate" },
            {
                row: "",
                render: function (data, type, row) {
                    return `<button onclick="detail('${row.nik}',
                        '${row.firstName}',
                        '${row.lastName}',
                        '${row.birthDate}',
                        '${row.gender}',
                        '${row.email}',
                        '${row.phoneNumber}',
                        '${row.hiringDate}',
                        '${row.departmentId}',
                        '${row.positionId}',
                        '${row.addressId}',
                        '${row.managerId}')" type="button" class="btn btn-success btn-xs dt-detail" style="margin-right:6px;" data-bs-toggle="modal" data-bs-target="#exampleModalDetail"><i class="fas fa-info-circle"></i> <span aria-hidden="true" style="font-family:sans-serif"></span></button>
                            <button type="button" class="btn btn-primary btn-xs dt-edit" style="margin-right:6px;"><i class="fas fa-pen"></i> <span aria-hidden="true" style="font-family:sans-serif"></span></button>
                            <button type="button" class="btn btn-danger btn-xs dt-trash" style="margin-right:6px;"><i class="fas fa-trash"></i> <span aria-hidden="true" style="font-family:sans-serif"></span></button>`;
                }
            }
        ],
        dom: '<"top"<"clear">Blf>rt<"bottom"ip>',
        buttons: [
            {
                extend: 'copyHtml5',
                text: '<i class="fa fa-files-o"></i style="color:white"> <span aria-hidden="true" style="font-family:sans-serif">Copy</span>',
                titleAttr: 'Copy',
                exportOptions: {
                    modifier: {
                        page: 'current'
                    }
                }
            },
            {
                extend: 'excelHtml5',
                text: '<i class="fa fa-file-excel-o" style="color:green"></i> <span aria-hidden="true" style="font-family:sans-serif">Excel</span>',
                titleAttr: 'Excel',
                exportOptions: {
                    columns: [0, 1, 2]
                }
            },
            {
                extend: 'csvHtml5',
                text: '<i class="fa fa-file-text-o" style="color:cyan"></i> <span aria-hidden="true" style="font-family:sans-serif">CSV</span>',
                titleAttr: 'CSV',
                exportOptions: {
                    columns: [0, 1, 2]
                }
            },
            {
                extend: 'pdfHtml5',
                text: '<i class="fa fa-file-pdf-o" style="color:red"></i> <span aria-hidden="true" style="font-family:sans-serif">PDF</span>',
                titleAttr: 'PDF',
                exportOptions: {
                    columns: [0, 1, 2]
                }
            },
            {
                extend: 'print',
                text: '<i class="fa fa-print" style="color:black"></i> <span aria-hidden="true" style="font-family:sans-serif">Print</span>',
                exportOptions: {
                    columns: [0, 1, 2]
                }
            },
            'colvis'
        ],
        "bDestroy": true
    });

    $("#plus").html(`
                <button type="button" class="btn btn-primary btn-xs dt-edit" style="margin-right:16px; margin-bottom: 15px;" data-bs-toggle="modal" data-bs-target="#exampleModal"
                 onclick="create()">
                    <i class="fas fa-plus" style="color:#ffffff"></i>
                    <span aria-hidden="true" style="font-family:sans-serif">Add New Data</span>
                </button>`);
});


function detail(a, b, c, d, e, f, g, h, i, j, k, l) {
    document.getElementById('update_nik').innerHTML = a
    document.getElementById('update_firstName').innerHTML = b
    document.getElementById('update_lastName').innerHTML = c
    document.getElementById('update_birthDate').innerHTML = d
    document.getElementById('update_gender').innerHTML = e
    document.getElementById('update_email').innerHTML = f
    document.getElementById('update_phoneNumber').innerHTML = g
    document.getElementById('update_hiringDate').innerHTML = h
    document.getElementById('update_departmentId').innerHTML = i
    document.getElementById('update_positionId').innerHTML = j
    document.getElementById('update_addressId').innerHTML = k
    document.getElementById('update_managerId').innerHTML = l
}

function create() {
    $("#modalTitle").html("Create");
    $("#modalBody").html();
    /*var obj = new Object();*/ //sesuaikan sendiri nama objectnya dan beserta isinya
    //ini ngambil value dari tiap inputan di form nya
    $("#staff").click(function (x) {
        x.preventDefault();
        let today = new Date;
        let obj = {};
        obj.nik = $("#nik").val();
        obj.firstName = $("#firstName").val();
        obj.lastName = $("#lastName").val();
        obj.birthDate = today
        obj.gender = $("#gender").val();
        obj.email = $("#email").val();
        obj.phoneNumber = $("#phoneNumber").val();
        obj.hiringDate = today;
        obj.departmentId = $("#departmentId").val();
        obj.positionId = $("#positionId").val();
        obj.addressId = $("#addressId").val();
        obj.managerId = $("#managerId").val();

        //isi dari object kalian buat sesuai dengan bentuk object yang akan di post
        console.log(obj)
        $.ajax({
            url: "https://localhost:7290/api/Employee",
            type: "POST",
            dataType: "json",
            contentType: "application/json;charset=utf-8",
            data: JSON.stringify(obj),//jika terkena 415 unsupported media type (tambahkan headertype Json & JSON.Stringify();)
        }).done(() => {
            //buat alert pemberitahuan jika success
            Swal.fire({
                position: 'top-end',
                icon: 'success',
                title: 'Your work has been saved',
                showConfirmButton: false,
                timer: 1500
            })
            $("#myTable").DataTable().ajax.reload();
        }).fail(() => {
            //alert pemberitahuan jika gagal
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Something went wrong!',
                footer: '<a href="">Why do I have this issue?</a>'
            })
        })
    })
}

//Update Function
$(document).on('click', '.edit', function () {
    var id = $(this).attr("id");
    $('#formUpdate').html('');
    $.ajax({
        url: "https://localhost:7290/api/Employee",
        type: "UPDATE",
        method: 'get',
        data: { id: id },
        dataType: 'json',
        success: function (data) {
            $('#firstName').val(data.firstName);
            $('#lastName').val(data.lastName);
            $('#email').val(email);
            $('#phoneNumber').val(phone);
            $('#createDate').val(createDate);
            $('#lastUpdate').val(lastUpdate);
            $('#addressId').val(addressId);
            $('.modal-title').text('Update Customer');
        }
    })
    $("#myTable").DataTable().ajax.reload();
});

//Delete Data
function remove(id) {
    console.log(id)
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Yes, delete it!',
        cancelButtonText: 'No, cancel!',
        reverseButtons: true
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: `https://localhost:7146/api/Staff?key=${id}`,
                type: "DELETE",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
            }).done(result => {
                Swal.fire(
                    'Deleted!',
                    'An Customer has been deleted.',
                    'success'
                );
                $("#myTable").DataTable().ajax.reload();
            }).fail(error => {
                Swal.fire(
                    'Failed!',
                    error.message,
                    'error'
                )
            })

        } else if (
            result.dismiss === Swal.DismissReason.cancel
        ) {
            Swal.fire(
                'Cancelled',
                'Customer data is safe',
                'error'
            )
        }
    })
}

