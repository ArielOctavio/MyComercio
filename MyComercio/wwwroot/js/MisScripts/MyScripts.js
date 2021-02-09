//Declaro las URL que voy a usar
var urlClientes = "/Clientes/GetCliente";
var urlProductos ="/Productos/GetProductos"





//Clientes
$("#ClienteBusqueda").keyup(function (value) {
    $("#IdCliente").val(null);
    // alert($("#ClienteBusqueda").val())
    var filtroCliente = $("#ClienteBusqueda").val();

    $.getJSON(urlClientes, { nombre: filtroCliente },
        function (data) {
            var items = "";
            $("#Resultados").empty();
            $.each(data, function (i, cliente) {
                items += '<div class="listaResultados" onclick="completarDatosCliente(' + "'" + cliente.id + "'," + "'" + cliente.nombre + "'," + "'" + cliente.apellido + "'" + ');" >' + cliente.nombre + '  ' + cliente.apellido + ' </div>';
            });
            $("#Resultados").html(items);

        });
});

function completarDatosCliente(id, nombre, apellido) {

    // console.log(id + " " + nombre);
    $("#IdCliente").val(id);
    $("#ClienteBusqueda").val(id + "- " + nombre + " " + apellido);
    $("#ClienteBusquedaId").val(id);
    $("#Resultados").empty();

}

//End Clientes
$("#BuscarProducto").keyup(function (value) {
    $("#ProductoID").val(null);

    var filtroProducto = $("#BuscarProducto").val();

    $.getJSON(urlProductos, { productoDescript: filtroProducto },

        function (data) {
            var item = "";
            $("#ResultadosProductos").empty();
            $.each(data, function (i, producto) {

                item += '<div class="listaResultados" onclick="completarDatosProducto(' + "'" + producto.id + "'," + "'" + producto.descripcion + "'" + ');" >' + producto.id + '  ' + producto.descripcion + ' </div>';

            });
            $("#ResultadosProductos").html(item);

        });


});

//Productos

