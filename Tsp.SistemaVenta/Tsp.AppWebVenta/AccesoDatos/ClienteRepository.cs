using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tsp.AppWebVenta.Models;

namespace Tsp.AppWebVenta.AccesoDatos
{
    public class ClienteRepository
    {
        private readonly TestVentaContext _context;

        public ClienteRepository(TestVentaContext context)
        {
            _context = context;
        }

        // Agregar un CLIENTE
        public void Agregar(Cliente c) {
            _context.Cliente.Add(c);
            _context.SaveChanges();
        }

        // Buscar por IDCLIENTE
        public Cliente Buscar(string id) {
            Cliente clienteDatos = _context.Cliente.FirstOrDefault(c => c.Dni.Equals(id));
            _context.SaveChanges();
            return clienteDatos;
        }

        // Obtener todo los CLIENTES
        public List<Cliente> Mostrar() {
            List<Cliente> lista = _context.Cliente.ToList();
            _context.SaveChanges();
            return lista;
        }
    }
}
