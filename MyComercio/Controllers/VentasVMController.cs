using Microsoft.AspNetCore.Mvc;
using MyComercio.Data;
using MyComercio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyComercio.Controllers
{
    public class VentasVMController : Controller
    {
        private readonly MyComercioContext _context;

        public VentasVMController(MyComercioContext context)
        {
            _context = context;
        }


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

            if(ModelState.IsValid)
            {
               var venta= _context.Venta.Add(model.VentaCabecera);
                _context.SaveChanges();

                foreach (var item in ventaDetalles)
                {
                    item.IdVenta = venta.Entity.Id;
                    _context.VentaDetalle.Add(item);
                    _context.SaveChanges();
                }

                return RedirectToAction("Index", "Ventas");

            }


            return View();
        }


        private static List<VentaDetalle> ventaDetalles = new List<VentaDetalle>();
        public JsonResult AddProduct(int IdProducto, int cantidad)
        {
            Add(IdProducto, cantidad);

            return Json(ventaDetalles);
        }
        public IActionResult AddProductAjax(int IdProducto, int cantidad)
        {
            Add(IdProducto, cantidad);

            return View(ventaDetalles);

        }

        private void Add(int IdProducto, int cantidad)
        {
            var product = ventaDetalles.Where(x => x.IdProducto == IdProducto).FirstOrDefault();
            if(product!=null)
            {
                product.Cantidad += cantidad;

            }
            else
            { 
                var newProduct = new VentaDetalle();
                newProduct.IdProducto = IdProducto;
                newProduct.Cantidad = cantidad;
                newProduct.Precio = GetPrecioProducto(IdProducto);
                ventaDetalles.Add(newProduct);
            }

           
        }


        public IActionResult DeleteProduct(int IdProducto)
        {
            var product= ventaDetalles.Where(x => x.IdProducto == IdProducto).FirstOrDefault();
            if(product!=null)
            {
                ventaDetalles.Remove(product);
            }
            return View("AddProductAjax", ventaDetalles);
        }

        private decimal GetPrecioProducto(int IdProducto)
        {
            var producto = _context.Producto.Where(x => x.Id == IdProducto).FirstOrDefault();
            return producto.Precio;
        }

      

       




    }
}
