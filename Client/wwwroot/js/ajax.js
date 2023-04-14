function detail(nik, firstName, lastName, birthDate, gender, hiringDate, email, phoneNumber) {
    let genderName = "";
    if (gender == 0) {
        genderName = "Laki-Laki";
    } else {
        genderName = "Perempuan";
    };
    let txt = `<li>Nik              : ${nik}</li>
               <li>Nama Depan       : ${firstName}</li>
               <li>Nama Belakang    : ${lastName}</li>
               <li>Tanggal Lahir    : ${birthDate}</li>
               <li>Jenis Kelamin    : ${genderName}</li>
               <li>Tanggal Masuk    : ${hiringDate}</li>
               <li>E-Mail           : ${email}</li>
               <li>Handphone        : ${phoneNumber}</li>
              `;

    $(".modal-body").html(txt);
    $("h1#exampleModalLabel.modal-title").html(firstName);

}

$(document).ready(function () {
    //initialisasi sekali saat HTML selesai di load
    $('#myTable').DataTable({
        //dom: '<"top"i>rt<"bottom"flp><"clear">',
        dom: 'B<"clear">lfrtip',
        buttons: [
            { extend: 'copy', text: '<i class="fa fa-files-o"></i>', titleAttr: 'Copy', className: 'btn btn-outline-primary' },
            { extend: 'csv', text: '<i class="fa fa-file-text-o"></i>', titleAttr: 'CSV', className: 'btn btn-outline-info' },
            { extend: 'excel', text: '<i class="fa fa-file-excel-o"></i>', titleAttr: 'Excel', className: 'btn btn-outline-success' },
            { extend: 'pdf', text: '<i class="fa fa-file-pdf-o"></i>', titleAttr: 'PDF', className: 'btn btn-outline-danger' },
            { extend: 'print', text: '<i class="fa fa-print"></i>', className: 'btn btn-outline-info' }
        ],

        ajax: {
            url: "https://localhost:7290/api/Employees", //=> CORS
            dataSrc: "data",
            dataType: "JSON"
        },

        columns: [
            {
                data: null,
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            { data: "nik" },
            {
                data: null,
                render: function (data, type, row) {
                    return data.firstName + ' ' + data.lastName;
                }
            },
            {
                data: "gender",
                render: function (gender) {
                    let genderName = "";
                    if (gender == 0) {
                        genderName = "Laki-Laki";
                    } else {
                        genderName = "Perempuan";
                    };
                    return genderName;
                }
            },
            {
                data: "email"
            },
            {
                data: "",
                render: function (data, type, row) {
                    return `<button class="btn btn-primary" onclick="detail(
                    '${row['nik']}', 
                    '${row['firstName']}',
                    '${row['lastName']}',
                    '${row['birthDate']}', 
                    '${row['gender']}',
                    '${row['hiringDate']}',
                    '${row['email']}',
                    '${row['phoneNumber']}'
                    )"data-bs-toggle="modal" data-bs-target="#modalEmployee"><i class="fa fa-list" aria-hidden="true"></i></button>

                        <button class="btn btn-warning" data-toggle="modal" onclick="showEditModal(${row['nik']})" 
                        data-target="#employeeEditModal"><i class="fas fa-edit"></i></i></button>

                        <button class="btn btn-danger" onclick="removeEmployee(${row['nik']})">
                        <i class="fa fa-trash" aria-hidden="true"></i></button></td>`;
                }
            },
        ],
    });
});

//Detail Employee
function detail(nik, firstName, lastName, birthDate, gender, hiringDate, email, phoneNumber) {
    let genderName = "";
    if (gender == 0) {
        genderName = "Laki-Laki";
    } else {
        genderName = "Perempuan";
    }
    let text = `<li>NIK              : ${nik}</li>
               <li>First Name       : ${firstName}</li>
               <li>Last Name        : ${lastName}</li>
               <li>Birth Date       : ${birthDate}</li>
               <li>Gender           : ${genderName}</li>
               <li>Hiring Date      : ${hiringDate}</li>
               <li>Email            : ${email}</li>
               <li>Phone Number     : ${phoneNumber}</li>
                `;
    $(".modal-bodydetail").html(text);
    //$("h1#exampleModalLabel.modal-title").html(firstName);
}

// Function Insert Data Employee
/*function InsertDataEmployee() {
    let obj = new Object();
    obj.nik = $("#nik").val();
    obj.firstName = $("#firstName").val();
    obj.lastName = $("#lastName").val();
    obj.birthDate = $("#birthDate").val();
    obj.gender = parseInt($("#gender").val());
    obj.hiringDate = $("#hiringDate").val();
    obj.phone = $("#phone").val();
    obj.email = $("#email").val();*/

$('#submit').click(function (e) {
    let obj = new Object();
    obj.nik = $("#nik").val();
    obj.firstName = $("#firstName").val();
    obj.lastName = $("#lastName").val();
    obj.birthDate = $("#birthDate").val();
    obj.gender = parseInt($("#gender").val());
    obj.hiringDate = $("#hiringDate").val();
    obj.email = $("#email").val();
    obj.phoneNumber = $("#phone").val();
    obj.managerId = $("#managerId").val();
    if (obj.managerId === "") {
        obj.managerId = null;
    }
    /*obj.managerId = $("#major").val();
        obj.email = $("#degree").val();
        obj.email = $("#gpa").val();
        obj.email = $("#universityName").val();
        obj.email = $("#password").val();
        obj.email = $("#confirmPassword").val();*/

    console.log(obj)
    $.ajax({
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        url: "https://localhost:7290/api/Employees",
        type: "POST",
        dataType: "JSON",
        contentType: "application/json;charset=utf-8",
        data: JSON.stringify(obj), //jika terkena 415 unsupported media type (tambahkan headertype Json & JSON.Stringify();)
    }).done((result) => {
        //console.log(result)
        Swal.fire({
            position: 'center',
            icon: 'success',
            title: 'Your work has been saved',
            showConfirmButton: false,
            timer: 1500
        })
        $('#modalInsertData').model('hide');
        $('#myTable').DataTable().ajax.reload();


    }).fail((error) => {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Something went wrong!',
            footer: '<a href="">Why do I have this issue?</a>'
        })
        $('#modalInsertData').modal('hide');
        /*$('#myTable').DataTable().ajax.reload();*/
        console.log(obj)
    })
    /*$('#myTable').DataTable().ajax.reload();*/
})


//Delete Data
/*function removeEmployee(nik) {
    console.log(nik)
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
                url: `https://localhost:7020/api/Employees?key=${nik}`,
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
                $("#myTable").DataTable().ajax.reload();
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
}*/

function removeEmployee(nik) {
    console.log(nik)
    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: 'btn btn-success ml-2',
            cancelButton: 'btn btn-danger mr-2'
        },
        buttonsStyling: false
    })

    swalWithBootstrapButtons.fire({
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
                type: "DELETE",
                url: `https://localhost:7290/api/Employees?key=${nik}`,
                data: {}
            }).done((result) => {
                swalWithBootstrapButtons.fire(
                    'Deleted!',
                    'Your file has been deleted.',
                    'success'
                ).then(function () {
                    $('#myTable').DataTable().ajax.reload();
                });
            });
        } else if (
            result.dismiss === Swal.DismissReason.cancel
        ) {
            swalWithBootstrapButtons.fire(
                'Cancelled',
                'Your imaginary file is safe :)',
                'error'
            ).then(function () {
                $('#myTable').DataTable().ajax.reload();
            });
        }
    });
}