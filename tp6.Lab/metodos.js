

function validarFormulario()
{
    let nombreId = document.forms["myForm"]["nombreId"].value;
    let apellidoId = document.forms["myForm"]["apellidoId"].value;
    let edadId = document.forms["myForm"]["edadId"].value;
    let empresaId = document.forms["myForm"]["empresaId"].value;

    if (nombreId == "" || apellidoId == "" || edadId == "" || empresaId == "")
    {
        alert("favor de ingresar correctamente los datos");
        return false;
    }
    else
    {
        alert("Su mensaje ha sido enviado");
    }
}

function clearFields()
{
    
    let campos = document.getElementsByClassName("form-control");
    for (let i = 0; i < campos.length; i++) 
    {
        campos[i].value = "";
    }
}