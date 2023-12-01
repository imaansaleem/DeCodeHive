﻿var dataTable;

$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        responsive: true,
        "ajax": { url: '/admin/company/getall' },
        "columns": [
            { data: 'name', "width": "25%" },
            { data: 'streetAddress', "width": "10%" },
            { data: 'city', "width": "2%" },
            { data: 'state', "width": "15%" },
            { data: 'phonenumber', "width": "15%" },
            {
                data: 'id',

                "render": function (data) {
                    return `<div class = "d-none d-md-block btn-group" role="group">
                    <a href = "/admin/company/upsert?id=${data}" class = "btn btn-primary btn-sm mx-2">Edit</a>
                    <a onClick=Delete('/admin/company/delete/${data}') class = "btn btn-danger btn-sm mx-2">Delete</a>
                    </div>
                    <div class = "d-md-none btn-group" role="group">
                    <a href = "/admin/company/upsert?id=${data}" class = "btn btn-primary btn-sm mx-2"><i class="bi bi-pencil-square"></i></a>
                    <a onClick=Delete('/admin/company/delete/${data}') class = "btn btn-danger btn-sm mx-2"><i class="bi bi-trash3-fill"></i></a>
                    </div>`
                },


                "width": "20%"
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        iconHtml: '<i class="bi bi-exclamation" style="color: #1a1a1a; font-size: 75px;"></i>',
        showCancelButton: true,
        confirmButtonColor: '#d9534f',
        cancelButtonColor: '#1a1a1a',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        }
    })
}