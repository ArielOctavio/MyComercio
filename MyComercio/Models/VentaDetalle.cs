using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyComercio.Models
{
    public class VentaDetalle
    {
        public int Id { get; set; }

        public int IdVenta { get; set; }

        public int IdProducto { get; set; }

        public int Cantidad { get; set; }

    }
}
