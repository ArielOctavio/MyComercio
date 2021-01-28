using Microsoft.AspNetCore.Mvc.Rendering;
using MyComercio.Data;
using MyComercio.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyComercio.Models
{
    public class Pais
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [ValidationUniqueKeyPais]
        public string Descripcion { get; set; }

     
     
    }
}
