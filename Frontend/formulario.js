const URL = "http://localhost:5286/api/Final/";
let sucursalId;

async function cargarConfiguraciones() {
  try {
    const response = await fetch(URL + "configuraciones");
    const responseJson = await response.json();

    if (!responseJson.success) {
      console.log(responseJson.message);
    }
    const configuraciones = responseJson.data;
    const formulario = document.getElementById("formulario");

    configuraciones.forEach((configuracion) => {
      formulario.style[configuracion.nombre] = configuracion.valor;
    });
  } catch (error) {
    console.log("Error al cargar configuraciones:", error);
  }
}

async function cargarSucursal() {
  try {
    const response = await fetch(URL + "sucursal");
    const responseJson = await response.json();

    if (!responseJson.success) {
      console.log(responseJson.message);
    }
    const sucursal = responseJson.data;

    sucursalId = sucursal.id;

    $("#nombre").val(sucursal.nombre);
    $("#ciudad").val(sucursal.ciudad);
    $("#tipo").val(sucursal.tipoId);
    $("#provincia").val(sucursal.provinciaId);
    $("#telefono").val(sucursal.telefono);
    $("#nombreTitular").val(sucursal.nombreTitular);
    $("#apellidoTitular").val(sucursal.apellidoTitular);
    $("#fechaAlta").val(new Date(sucursal.fechaAlta).toLocaleDateString());
  } catch (error) {
    console.log("Error al cargar sucursal:", error);
  }
}

$(document).ready(function () {
  cargarConfiguraciones();
  cargarSucursal();

  $("#formulario").validate({
    rules: {
      //aca van los nombres de los campos, es decir la propiedad name
      nombre: "required",
      ciudad: "required",
      tipo: "required",
      provincia: "required",
      telefono: {
        required: true,
        minlength: 8,
      },
      nombreTitular: "required",
      apellidoTitular: "required",
    },
    messages: {
      nombre: "Por favor ingrese el nombre de la sucursal",
      ciudad: "Por favor ingrese la ciudad",
      tipo: "Por favor seleccione un tipo",
      provincia: "Por favor seleccione una provincia",
      telefono: {
        required: "Por favor ingrese un teléfono",
        minlength: "El teléfono debe tener al menos 8 caracteres",
      },
      nombreTitular: "Por favor ingrese el nombre del titular",
      apellidoTitular: "Por favor ingrese el apellido del titular",
    },
    errorClass: "is-invalid",
    validClass: "is-valid",
    submitHandler: async function (form) {
      try {

        event.preventDefault(); // Evita que se recargue la página. acordarse de esta linea

        const sucursal = {
          nombre: $("#nombre").val(),
          ciudad: $("#ciudad").val(),
          tipoId: $("#tipo").val(),
          provinciaId: $("#provincia").val(),
          telefono: $("#telefono").val(),
          nombreTitular: $("#nombreTitular").val(),
          apellidoTitular: $("#apellidoTitular").val(),
        };

        const response = await fetch(URL + "sucursal/" + sucursalId, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(sucursal)
        });

        const result = await response.json();

        if (!result.success) {
          console.log(result.message);
        }

        alert("Sucursal actualizada correctamente:"
            + "\nMensaje: " + result.message
            + "\nResultado: " + result.success
            + "\nSucursal: "
            + "\nNombre: " + sucursal.nombre
            + "\nCiudad: " + sucursal.ciudad
            + "\nTipo: " + sucursal.tipoId
            + "\nProvincia: " + sucursal.provinciaId
            + "\nTelefono: " + sucursal.telefono
            + "\nNombre Titular: " + sucursal.nombreTitular
            + "\nApellido Titular: " + sucursal.apellidoTitular
        );
        console.log("Sucursal actualizada correctamente:", result);
      } catch (error) {
        console.log("Error al cargar sucursal");
      }
    }
  });
});
