using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tsp.AppWebVenta.AccesoDatos;
using Tsp.AppWebVenta.Models;

namespace Tsp.AppWebVenta.LogicaNegocio
{
    public class ProductoLogica
    {
        private ProductoRepository productoLogica;

        public void RegistrarProducto(VentaDB db, Producto prod)
        {
            productoLogica = new ProductoRepository(db);
            productoLogica.Agregar(prod);
        }

        public IEnumerable<Producto> ListarProductos(VentaDB db)
        {
            productoLogica = new ProductoRepository(db);
            IEnumerable<Producto> listaProducto = productoLogica.Mostrar();
            return listaProducto;
        }

        public Producto BuscarProducto(VentaDB db, string nombreProd)
        {
            productoLogica = new ProductoRepository(db);
            Producto productoSearch = productoLogica.Buscar(nombreProd);
            return productoSearch;
        }
    }
}
