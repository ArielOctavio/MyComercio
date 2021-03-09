using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyComercio.Models
{
    public class VentaDetalle
    {
        public int Id { get; set; }

        public int IdVenta { get; set; }


        [Display(Name ="Producto")]
        public int IdProducto { get; set; }

        public int Cantidad { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public Decimal Precio { get; set; }


        [NotMapped]
        public string DescripcionProducto { get { return GetProducto().Descripcion; } }


        [NotMapped]
        public decimal Total { get { return Precio * Cantidad; } }


        public Producto GetProducto()
        {
            Producto producto;

            using(var _context=new MyComercio.Data.MyComercioContext()) 
            {
                producto = _context.Producto.Where(x => x.Id == IdProducto).FirstOrDefault();
            }


            return producto;

        }

    }
}
