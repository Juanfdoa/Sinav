var dataTable;

$(document).ready(function () {
    cargarDatatable();
});


function cargarDatatable() {
    dataTable = $("#tblSupplier").DataTable({
        "responsive": true,
        "ajax": {
            "url": "/admin/supplier/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "width": "5%" },
            { "data": "name", "width": "13%" },
            { "data": "nit", "width": "13%" },
            { "data": "phone", "width": "13%" },
            { "data": "address", "width": "13%" },
            { "data": "email", "width": "13%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/Admin/supplier/Edit/${data}" class="btn btn-outline-primary" style="cursor:pointer; width:100px;" data-toggle="tooltip" data-placement="top" title="Editar">
                                <i class="far fa-edit"></i>
                                </a>
                                &nbsp;
                                <a onclick=Delete("/Admin/supplier/Delete/${data}") class="btn btn-outline-primary" style="cursor:pointer; width:100px;" data-toggle="tooltip" data-placement="top" title="Eliminar">
                                 <i class="far fa-trash-alt"></i>
                                </a>
                            </div>`;
                }, "width": "30%"
            }
        ],
        "language": {
            "decimal": "",
            "emptyTable": "No hay registros",
            "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
            "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
            "infoFiltered": "(Filtrado de _MAX_ total entradas)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ Entradas",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Buscar:",
            "zeroRecords": "Sin resultados encontrados",
            "paginate": {
                "first": "Primero",
                "last": "Ultimo",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "Esta seguro de borrar?",
        text: "Este contenido no se puede recuperar!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#FF001F",
        confirmButtonText: "Si, borrar!",
        closeOnconfirm: true
    }, function () {
        $.ajax({
            type: 'DELETE',
            url: url,
            success: function (data) {
                if (data.success) {
                    toastr.success(data.message);
                    dataTable.ajax.reload();
                }
                else {
                    toastr.error(data.message);
                }
            }
        });
    });
}