using MyComercio.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyComercio.Models
{
    public class Ciudad
    {

        private readonly MyComercioContext _context;

        public Ciudad(MyComercioContext context)
        {
            _context = context;
        }

        public Ciudad() { }


        public int Id { get; set; }

        public int IdPais { get; set; }

        public string Descripcion { get; set; }


        public Pais GetPais()
        {
            var pais = _context.Pais.Where(x => x.Id == IdPais).FirstOrDefault();
            return pais;
        }
        
    }
}
