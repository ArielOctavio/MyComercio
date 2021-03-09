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



//Productos
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


function completarDatosProducto(id, descripcion) {

    $("#BuscarProducto").val(id + ' - ' + descripcion);
    $("#ProductoID").val(id);
    $("#ResultadosProductos").empty();
}


function addProduct() {
    var url = "/VentasVM/AddProduct";
    var productoId = $('#ProductoID').val();
    var cantidad = $('#CantidadID').val();

    $.getJSON(url, { IdProducto: productoId, cantidad: cantidad },

        function (data) {
            var item = "";

            $.each(data, function (i, producto) {

                item += '<div class="col-md-4">' + producto.idProducto + '</div> <div class="col-md-4">' + producto.descripcionProducto + '</div> <div class="col-md-4">' + producto.cantidad + '</div>';

            })

            $("#ListadoProductos").html(item);

        }
    )
}


function addProductAjax() {
   
    var productoId = $('#ProductoID').val();
    var cantidad = $('#CantidadID').val();

    $.ajax({

        url: "/VentasVM/AddProductAjax",
        data: { IdProducto: productoId, cantidad: cantidad },
        type: "post",
        cache: false,

        success: function (retorno) {
            $("#ListadoProductos").html(retorno);
        },
        error: function (error) {


            console.log(error);
        }
    });
}


function BorrarProducto(id) {
    $.ajax({

        url: "/VentasVM/DeleteProduct",
        data: { IdProducto: id },
        type: "post",
        cache: false,
        success: function (retorno) {

            $("#ListadoProductos").html(retorno);

        },
        error: function (error) {

            console.log(error);
        }

    });


}


// End Productos



//Venta detalle list
function MostrarDetalles(Id) {

    //Creamos una funcion ajax que envie los datos al metodo Buscar del Controler Persona
    $.ajax({
        //Direccion donde nos queremos comunicar Controller/Metodo
        url: "/VentaDetalles/MostrarDetalles",
        //parametros que le pasamos a el Metodo del Controller ( si se fijan en el Controller el metodo Busqueda, recibe como parametro "filtro")
        data: { 'idVenta': Id },
        //El tipo es post ya que enviamos datos
        type: "post",
        cache: false,
        success: function (retorno) {
            //Si el metodo busqueda del controller devuelve algo, lo guardamos en retorno - lo que devuelve es la pagina (View) buscar, osea es un pedazo de codigo HTML que podemos insertar en el DivDinamico
            $("#DivDetalleVenta").html(retorno);

        },
        error: function (retorno) {
            //Si el metodo ajax falla entra por aca y nos advierte de un error

            alert("Se ha producido un error");


        }
    });
    return true;
};