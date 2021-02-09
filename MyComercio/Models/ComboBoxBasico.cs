using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyComercio.Models
{
    public class ComboBoxBasico
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="La descripcion es obligatoria")]
        public string Descripcion { get; set; }


    }
}
