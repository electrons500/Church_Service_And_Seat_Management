var datatables;
$(document).ready(function() {
    datatables = $('#emptable').DataTable({
        "ajax": {
            "url": "/Members/GetMembersData",
            "type": "GET",
            "datatype":"json"
        },
        "columns": [
            {
                "data": "memberId",
                "width": "10%"
            },            
            {
                "data": "fullName",
                "width":"40%"
            },
            {
                "data": "residence",
                "width": "10%"
            },
            {
                "data": "phoneNumber",
                "width": "10%"
            },
            {
                "data": "memberId",
                "width": "30%",
                "render": function (data) {
                    return `<div class='text-center'>
                        
                        <button type='button' class='btn btn-success btn-sm' data-toggle='modal' data-target='#editMembersModal' data-whatever='${data}'><i class='fa fa-thermometer-half'> Check temperature</i></a>
                         
                        </div>`
                    
                }
            }
            
        ],
        "language": {
            "emptyTable":"No data found"
        },
        "width": "100%",
        "lengthMenu": [[5, 10, 25, 50, -1], [5, 10, 25, 50, "All"]],
        responsive: true

    });
});

function Delete(path) {
    swal({
        title: "Are you sure you want to delete?",
        text: "deletion cannot be undone",
        icon: "warning",
        buttons: true,
        dangermode: true

    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                url: path,
                type: "DELETE",
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        datatables.ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }
                }
            })
        }

    })
}