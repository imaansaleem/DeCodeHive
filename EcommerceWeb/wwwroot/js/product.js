var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/product/getall' },
        "columns": [
            //column names must be exact
            { data: 'title', "width": "25%" },
            { data: 'isbn', "width": "15%" },
            { data: 'listPrice', "width": "5%" },
            { data: 'author', "width": "15%" },
            { data: 'category.name', "width": "15%" },
            {
                data: 'id',

                //defining customer render function
                "render": function (data) {
                    //html we want to render
                    //` will allow multiline html
                    return `<div class = "btn-group" role="group">
                    <a href = "/admin/product/upsert?id=${data}" class = "btn btn-primary btn-sm mx-2"><i class="bi bi-pencil-square"></i> Edit</a>
                    <a onClick=Delete('/admin/product/delete/${data}') class = "btn btn-danger btn-sm mx-2"><i class="bi bi-trash3-fill"></i> Delete</a>
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
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
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