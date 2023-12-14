var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        responsive: true,
        "ajax": { url: '/admin/company/getall'},
        "columns": [
            //column names must be exact
            { data: 'name', "width": "15%" },
            { data: 'streetAddress', "width": "15%" },
            { data: 'city', "width": "15%" },
            { data: 'state', "width": "15%" },
            { data: 'phoneNumber', "width": "20%" },
            {
                data: 'id',

                //defining customer render function
                "render": function (data) {
                    //html we want to render
                    //` will allow multiline html
                    return `<div class = "d-none d-md-block btn-group" role="group">
                    <a href = "/admin/company/upsert?id=${data}" class = "btn btn-primary btn-sm mx-2">Edit</a>
                    <a onClick=Delete('/admin/company/delete/${data}') class = "btn btn-danger btn-sm mx-2">Delete</a>
                    </div>
                    <div class = "d-md-none btn-group" role="group">
                    <a href = "/admin/company/upsert?id=${data}" class = "btn btn-primary btn-sm mx-2"><i class="bi bi-pencil-square"></i></a>
                    <a onClick=Delete('/admin/company/delete/${data}') class = "btn btn-danger btn-sm mx-2"><i class="bi bi-trash3-fill"></i></a>
                    </div>`
                },


                //maximum allowble width

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
        //If the user confirms the deletion, it sends an AJAX DELETE request to the specified URL(url) using jQuery's $.ajax function.
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                //http delete
                type: 'DELETE',
                //data is actually success message
                success: function (data) {
                    // it reloads the DataTable to reflect the updated data
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        }
    })
}