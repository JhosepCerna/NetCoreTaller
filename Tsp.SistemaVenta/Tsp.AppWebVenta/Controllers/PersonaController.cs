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
        private readonly TestVentaContext _con;
        private ClienteLogica cli;

        public PersonaController(TestVentaContext con)
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
                    Nombre = nombre,
                    Apellidos = apellido,
                    Telefono = telefono,
                    Dni = dni,
                    Edad = Convert.ToInt32(edad)
                };
                cli.RegistrarCliente(_con, cl);
                return RedirectToAction("Venta", "Transaccion", new { ID = cl.Dni });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}