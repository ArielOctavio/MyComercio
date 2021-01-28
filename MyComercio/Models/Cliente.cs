using MyComercio.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyComercio.Models
{
    public class Cliente:Persona
    {
      
        [Display(Name = "Correo electrónico",Prompt ="Ej. juan@gmail.com")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", 
            ErrorMessage = "El E-mail ingresado no es valido")]
       //[EmailAddress]
        public string Email { get; set; }

       

    }
}
