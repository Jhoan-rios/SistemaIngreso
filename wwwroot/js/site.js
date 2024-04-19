
//eliminar
function ConfirmJob(id){
    Swal.fire({
        title: "Seguro quieres eliminar esto?",
        text: "No puedes revertirlo despues!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Si, Borralo!"
    }).then((result) => {
        if (result.isConfirmed) {
            location.href = "http://localhost:5136/Jobs/Delete/"+id;
            Swal.fire({
                title: "Borrado!",
                text: "Este archivo ha sido borrado.",
                icon: "success"
            });
        }
    });
}

function Crear(){
    Swal.fire({
        title: "Creado!",
        text: "El empleado ha sido exitosamente creado.",
        icon: "success"
    });
}
