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
    public class PersonaController : Controller
    {
        private readonly VentaDB _con;
        private ClienteLogica cli;

        public PersonaController(VentaDB con)
        {
            _con = con;
        }

        public IActionResult Cliente()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cliente(string nombre, string apellido, string telefono, string dni, string edad) {
            try
            {
                cli = new ClienteLogica();
                Cliente cl = new Cliente
                {
                    nombre = nombre,
                    apellidos = apellido,
                    telefono = telefono,
                    dni = dni,
                    edad = Convert.ToInt32(edad)
                };
                cli.RegistrarCliente(_con, cl);
                return RedirectToAction("Venta", "Transaccion", new { ID = cl.dni });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}