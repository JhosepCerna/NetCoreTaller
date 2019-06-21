using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tsp.AppWebVenta.AccesoDatos;
using Tsp.AppWebVenta.LogicaNegocio;
using Tsp.AppWebVenta.Models;

namespace Tsp.AppWebVenta.Controllers
{
    public class MercaderiaController : Controller
    {
        private readonly VentaDB _con;
        private ProductoLogica pro;

        public MercaderiaController(VentaDB con)
        {
            _con = con;
        }

        public IActionResult Producto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Producto(string nombre, string precioUnitario) {
            try
            {
                pro = new ProductoLogica();
                Producto pr = new Producto
                {
                    nombre = nombre,
                    precioUnitario = Convert.ToSingle(precioUnitario)
                };
                pro.RegistrarProducto(_con, pr);
                return View();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}