using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyComercio.Models
{
    public class VentasViewModel
    {
        public Venta VentaCabecera { get; set; }
        public List<VentaDetalle> VentaDetallesList { get; set; }

    }
}
