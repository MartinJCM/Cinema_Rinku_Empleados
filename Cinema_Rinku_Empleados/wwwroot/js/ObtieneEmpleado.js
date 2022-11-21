$("#NumeroEmpleado").change(function () {

    ObtieneDatosEpleado($("#NumeroEmpleado").val())

});

let numeroEmpleado = $("#NumeroEmpleado").val();

if (numeroEmpleado != "") {

    document.getElementById("CantEntregas").value = "";
    ObtieneDatosEpleado(numeroEmpleado);
}

function ObtieneDatosEpleado(numeroEmpleado) {
        $.ajax({
            url: Url_1.ObtieneDatosEmpleado,
            data: { numeroEmpleado },
        dataType: "json"
    }).done(function (data) {

        if (data.nombreCompleto != "" && data.rolId != "") {
            document.getElementById('Nombre').value = data.nombreCompleto;
            document.getElementById('RolId').value = data.rolId;
            document.getElementById('Rol').value = data.rol;
        }
    });
}