using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tsp.AppWebVenta.AccesoDatos;
using Tsp.AppWebVenta.Models;

namespace Tsp.AppWebVenta.LogicaNegocio
{
    public class ClienteLogica
    {
        private ClienteRepository clienteLogica;

        public void RegistrarCliente(TestVentaContext db, Cliente clien)
        {
            clienteLogica = new ClienteRepository(db);
            clienteLogica.Agregar(clien);
        }

        public Cliente BuscarCliente(TestVentaContext db, string identidad) {
            clienteLogica = new ClienteRepository(db);
            Cliente clienteSearch = clienteLogica.Buscar(identidad);
            return clienteSearch;
        }
    }
}
