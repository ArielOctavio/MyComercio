using Microsoft.AspNetCore.Mvc.Rendering;
using MyComercio.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyComercio.Helper
{
    public class MyHelper:IDisposable 

    {

        private readonly MyComercioContext _context;

        public MyHelper(MyComercioContext context)
        {
            _context = context;
        }

        public MyHelper() { }

        public SelectList GetPaisesSelectList()
        {

            var lstPaises = _context.Pais.ToList();
            var SelectListPaises = new SelectList(lstPaises, "Id", "Descripcion");
            return SelectListPaises;
        
        }

        public void Dispose()
        {
            
        }
    }
}
