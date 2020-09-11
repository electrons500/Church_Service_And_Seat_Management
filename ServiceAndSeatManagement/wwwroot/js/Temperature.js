var datatables;
$(document).ready(function () {
    datatables = $('#emptable').DataTable({
        "ajax": {
            "url": "/membertemperature/GetTemperature",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            {
                "data": "temperatureId",
                "width": "10%"
            },
            {
                "data": "memberName",
                "width": "30%"
            },
            {
                "data": "tempuratureNumber",
                "width": "10%"
            },
            {
                "data": "verifyName",
                "width": "20%"
            },
            {
                "data": "temperatureId",
                "width": "30%",
                "render": function (data) {
                    return `<div class='text-center'>

                        <a class='btn btn-warning btn-sm' href='/membertemperature/Edit?id=${data}'><i class='fa fa-edit'> Edit</i></a>
                        &nbsp;
                        <a onClick=Delete('/membertemperature/DeleteAllDataApiJson?id=${data}') class='btn btn-danger btn-sm text-white' style='cursor:pointer'><i class='fa fa-trash-o'> Delete</i></a>
                         
                        </div>`

                }
            }

        ],
        "language": {
            "emptyTable": "No data found"
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
                        //toastr.success(data.message);
                        swal({
                            title: "Congratulations",
                            text: "You have successfully deleted member temperature",
                            icon: "success",
                            button: "OK"

                        });

                        datatables.ajax.reload();
                    } else {
                        //toastr.error(data.message);
                        swal({
                            title: "Failed",
                            text: "Member temperature failed to delete!",
                            icon: "error",
                            button: "OK"

                        });
                    }
                }
            })
        }

    })
}