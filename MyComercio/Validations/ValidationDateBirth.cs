using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyComercio.Validations
{
    public class ValidationDateBirth : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            //value va a ser una fecha de nacimiento
            var fechaNacimiento = (DateTime)value;
            var fechaActual = DateTime.Now;
            if(fechaNacimiento > fechaActual)
            {
                return false;
            }
           
            return true;
        }
    }

    public class ValidationMinimunDateBrirth : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var fechaMinimaDeNacimiento = DateTime.Now.AddYears(-120);

            if ((DateTime)value < fechaMinimaDeNacimiento)
            {
                return false;

            }

            return true;
          
        }

    }

}
