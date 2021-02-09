using Microsoft.AspNetCore.Mvc;
using MyComercio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyComercio.Controllers
{
    public class VentasVMController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewVenta()
        {
            return View();
        }


        [HttpPost]
        public IActionResult NewVenta(VentasViewModel model)
        {
            return View();
        }


        private static List<VentaDetalle> ventaDetalles = new List<VentaDetalle>();
        public JsonResult AddProduct(int IdProducto, int cantidad)
        {
            var newProduct = new VentaDetalle();
            newProduct.IdProducto = IdProducto;
            newProduct.Cantidad = cantidad;

            ventaDetalles.Add(newProduct);

            return Json(ventaDetalles);
        }


    }
}
