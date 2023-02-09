$(document).ready(function () {
    var aarco = {
        RestoreSelects: function (option) {
            switch (option) {
                case 1:
                    $('#SubmarcaSelect').empty().append("<option selected value='0'>Seleccione una Submarca</option>");
                    $('#ModeloSelect').empty().append("<option selected value='0'>Seleccione un Modelo</option>");
                    $('#DescripcionSelect').empty().append("<option selected value='0'>Seleccione una Descripcion</option>");
                    break;
                case 2:
                    $('#ModeloSelect').empty().append("<option selected value='0'>Seleccione un Modelo</option>");
                    $('#DescripcionSelect').empty().append("<option selected value='0'>Seleccione una Descripcion</option>");
                    break;
                case 3:
                    $('#DescripcionSelect').empty().append("<option selected value='0'>Seleccione una Descripcion</option>");
                    break;
            }
            
        },
        GetMarcas: function () {
            $.ajax({
                cache: false,
                async: true,
                type: "GET",
                url: '/Marcas',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    console.log("Marcas: ",response);
                    var html = "<option selected value='0'>Seleccione una Marca</option>";
                    for (var i = 0; i < response.length; i++) {
                        html += " <option value=" + response[i].id + ">" + response[i].nombre + "</option>"
                    }
                    $('#MarcaSelect').empty();
                    $('#MarcaSelect').append(html);
                },
                error: function () {
                    alert('Ocurio un error inesperado')
                }

            });
        },
        GetSubmarcas: function (id) {
            $.ajax({
                cache: false,
                async: true,
                type: "GET",
                url: '/Submarcas/' + id,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    console.log("Submarcas: ", response);
                    var html = "<option selected value='0'>Seleccione una Submarca</option>";
                    for (var i = 0; i < response.length; i++) {
                        html += " <option value=" + response[i].id + ">" + response[i].nombre + "</option>"
                    }
                    $('#SubmarcaSelect').empty();
                    $('#SubmarcaSelect').append(html);
                },
                error: function () {
                    alert('Ocurio un error inesperado')
                }

            });
        },
        GetModelos: function (id) {
            $.ajax({
                cache: false,
                async: true,
                type: "GET",
                url: '/Modelos/' + id,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    console.log("Modelos: ", response);
                    var html = "<option selected value='0'>Seleccione un modelo</option>";
                    for (var i = 0; i < response.length; i++) {
                        html += " <option value=" + response[i].id + ">" + response[i].nombre + "</option>"
                    }
                    $('#ModeloSelect').empty();
                    $('#ModeloSelect').append(html);
                },
                error: function () {
                    alert('Ocurio un error inesperado')
                }

            });
        },
        GetDescriptions: function (id) {
            $.ajax({
                cache: false,
                async: true,
                type: "GET",
                url: '/Descripcions/' + id,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    console.log("Descripciones: ", response);
                    var html = "<option selected value='0'>Seleccione una descripcion</option>";
                    for (var i = 0; i < response.length; i++) {
                        html += " <option value=" + response[i].descriptionId + ">" + response[i].nombre + "</option>"
                    }
                    $('#DescripcionSelect').empty();
                    $('#DescripcionSelect').append(html);
                },
                error: function () {
                    alert('Ocurio un error inesperado')
                }

            });
        },
        GetPostalCodeData: function (PostalCode) {
            $.ajax({
                cache: false,
                async: true,
                type: "GET",
                url: 'https://api-test.aarco.com.mx/api-examen/api/examen/sepomex/' + PostalCode,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    $("#Estado").empty();
                    $("#Municipio").empty();
                    $("#Colonia").empty().append("<option selected value='0'>Seleccione una colonia</option>");
                    console.log("PostalCode response: ", response);
                    var result = JSON.parse(response.CatalogoJsonString)[0];
                    $("#Estado").val(result.Municipio.Estado.sEstado);
                    $("#Municipio").val(result.Municipio.sMunicipio);
                    var html = "<option selected value='0'>Seleccione una colonia</option>";
                    var colonias = result.Ubicacion;
                    for (var i = 0; i < colonias.length; i++) {
                        html += "<option value=" + colonias[i].iIdUbicacion + ">" + colonias[i].sUbicacion + "</option>";
                    }
                    $("#Colonia").empty().append(html);

                    
                },
                error: function () {
                    alert('Ocurio un error inesperado')
                }

            });
        },
        PostDataRequest: function (id) {
            $.ajax({
                cache: false,
                async: true,
                type: "POST",
                url: 'https://api-test.aarco.com.mx/api-examen/api/examen/crear-peticion',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify({DescripcionId: id}),
                success: function (response) {
                    console.log("DataRequest: ", response);
                    $.ajax({
                        cache: false,
                        async: true,
                        type: "GET",
                        url: 'https://api-test.aarco.com.mx/api-examen/api/examen/peticion/'+ response,
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {
                            console.log("LastRequest: ", response);

                        },
                        error: function () {
                            alert('Ocurio un error inesperado')
                        }

                    });
                },
                error: function () {
                    alert('Ocurio un error inesperado')
                }

            });
        },
        UserInteraction: function () {
            $("#MarcaSelect").on('change', function () {
                aarco.RestoreSelects(1);
                var id = $("#MarcaSelect option:selected")[0].value;
                aarco.GetSubmarcas(id);
            });
            $("#SubmarcaSelect").on('change', function () {
                aarco.RestoreSelects(2);
                var id = $("#SubmarcaSelect option:selected")[0].value;
                aarco.GetModelos(id);
            });
            $("#ModeloSelect").on('change', function () {
                aarco.RestoreSelects(3);
                var id = $("#ModeloSelect option:selected")[0].value;
                aarco.GetDescriptions(id);
            });
            $("#PostalCode").on("keyup", function () {
                var text = $(this).val();
                if (text.length >= 5) {
                    aarco.GetPostalCodeData(text);
                }
            });
            $("#SubmitBtn").click(function () {
                var descripcion = $("#DescripcionSelect").val();
                if (descripcion != 0 && descripcion != "") {
                    aarco.PostDataRequest(descripcion);
                } else {
                    alert("complete todos los campos");
                }
            });
        },
        Init: function () {
            this.RestoreSelects(1);
            this.GetMarcas();
            this.UserInteraction();
        }
    };
    aarco.Init();
});
