using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyComercio.Data;
using MyComercio.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyComercio.Models
{
    public class Persona
    {
        private Guid id;

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Usted debe poner un apellido")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Tenes que escribir mas de 3 caracteres")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Solo puede ingresar letras y espacios")]
        public string Apellido { get; set; }


        [Required(ErrorMessage = "Usted debe poner un nombre")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Solo puede ingresar letras y espacios")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "La Fecha de nacimiento es obligatoria")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")]
        [ValidationDateBirth(ErrorMessage ="La fecha de nacimiento no puede ser mayor a hoy")]
        [ValidationMinimunDateBrirth(ErrorMessage = "La fecha de nacimiento no puede ser menor a 120 años")]
       //Agregar Validacion custom
        public DateTime FechaNacimiento { get; set; }

        [Display(Name = "Teléfono",Prompt ="Ej. 351144445")]
        [Phone(ErrorMessage = "El Teléfono no es valido")]
        public string Telefono { get; set; }

        [Required]
        public int IdPais { get; set; }

        public int IdCiudad { get; set; }


    }

}
