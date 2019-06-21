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

        public void RegistrarCliente(VentaDB db, Cliente clien)
        {
            clienteLogica = new ClienteRepository(db);
            clienteLogica.Agregar(clien);
        }

        public Cliente BuscarCliente(VentaDB db, string identidad) {
            clienteLogica = new ClienteRepository(db);
            Cliente clienteSearch = clienteLogica.Buscar(identidad);
            return clienteSearch;
        }
    }
}
