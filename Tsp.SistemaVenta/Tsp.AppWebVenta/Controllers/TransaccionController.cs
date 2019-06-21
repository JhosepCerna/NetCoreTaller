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
    public class TransaccionController : Controller
    {
        private readonly VentaDB _con;
        private ClienteLogica clienteVenta;
        private VentaLogica ventaOperacion;
        private ProductoLogica productoVenta;

        public TransaccionController(VentaDB con)
        {
            _con = con;
        }

        public IActionResult Venta(string ID)
        {
            try
            {
                clienteVenta = new ClienteLogica();
                Cliente clienteBuscado = clienteVenta.BuscarCliente(_con, ID);
                return View(clienteBuscado);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Venta(string docIdentidad, string fecha)
        {
            try
            {
                clienteVenta = new ClienteLogica();
                Cliente IDCliente = clienteVenta.BuscarCliente(_con, docIdentidad);
                ventaOperacion = new VentaLogica();
                Venta ve = new Venta
                {
                    idCliente = IDCliente.id,
                    fecha = Convert.ToDateTime(fecha),
                    montoTotal = 0.00f
                };
                ventaOperacion.RegistrarVenta(_con, ve);
                return RedirectToAction("DetalleVenta", "Transaccion", new { ID = ve.id });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult DetalleVenta(string ID)
        {
            try
            {
                productoVenta = new ProductoLogica();
                IEnumerable<Producto> listProducto = productoVenta.ListarProductos(_con);
                ViewBag.Codigo = ID;
                return View(listProducto);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult DetalleVenta(string codigoOperacion, string productoSelect, string cantidad)
        {
            try
            {
                productoVenta = new ProductoLogica();
                Producto IDProducto = productoVenta.BuscarProducto(_con, productoSelect);
                ventaOperacion = new VentaLogica();
                DetalleVenta deve = new DetalleVenta
                {
                    idProducto = IDProducto.id,
                    idVenta = Convert.ToInt32(codigoOperacion),
                    subTotal = Convert.ToInt32(cantidad) * IDProducto.precioUnitario,
                    cantidad = Convert.ToInt32(cantidad)
                };
                ventaOperacion.RegistrarDetalleVenta(_con, deve);
                return RedirectToAction("DetalleVenta", "Transaccion", new { ID = codigoOperacion });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult ReporteVenta(string ID) {
            try
            {
                ventaOperacion = new VentaLogica();
                ViewBag.Indice = 1;
                ventaOperacion.EditarMontoTotal(_con, ID);
                List<ReporteViewModel> v = ventaOperacion.ListarVentas(_con);
                return View(v);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult ReporteVentaTotal()
        {
            try
            {
                ventaOperacion = new VentaLogica();
                ViewBag.Indice = 1;
                List<ReporteViewModel> v = ventaOperacion.ListarVentas(_con);
                return View(v);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}