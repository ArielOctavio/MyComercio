using MyComercio.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyComercio.Models
{
    public class Producto
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public string Color { get; set; }
        
        
        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public Decimal Precio { get; set; }

        [Required]
        public int IdCategoria { get; set; }

        public int IdMarca { get; set; }

        public string FileName { get; set; }


        public CategoriaProducto GetCategoriaProducto()
        {

            CategoriaProducto categoria;
            using(var context=new MyComercioContext())
            {
                categoria = context.CategoriaProducto.Where(x => x.Id == IdCategoria).FirstOrDefault();
            }

            return categoria;
        }
    }
}
