using Microsoft.AspNetCore.Mvc.Rendering;
using MyComercio.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyComercio.Helper
{
    public static class MyHelper 
    {
        private static MyComercioContext _context = new MyComercioContext();

        public static SelectList GetPaisesSelectList()
        {
            var lstPaises = _context.Pais.ToList();
            var SelectListPaises = new SelectList(lstPaises, "Id", "Descripcion");
            return SelectListPaises;
        }

        public static SelectList GetCategoriasList()
        {
            var lstCategoria = _context.CategoriaProducto.ToList();
            var SelectListCategoria = new SelectList(lstCategoria, "Id", "Descripcion");
            return SelectListCategoria;
        }
 
    }
}
