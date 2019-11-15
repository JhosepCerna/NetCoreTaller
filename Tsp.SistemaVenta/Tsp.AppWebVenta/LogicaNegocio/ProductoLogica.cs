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

        public void RegistrarProducto(TestVentaContext db, Producto prod)
        {
            productoLogica = new ProductoRepository(db);
            productoLogica.Agregar(prod);
        }

        public IEnumerable<Producto> ListarProductos(TestVentaContext db)
        {
            productoLogica = new ProductoRepository(db);
            IEnumerable<Producto> listaProducto = productoLogica.Mostrar();
            return listaProducto;
        }

        public Producto BuscarProducto(TestVentaContext db, string nombreProd)
        {
            productoLogica = new ProductoRepository(db);
            Producto productoSearch = productoLogica.Buscar(nombreProd);
            return productoSearch;
        }
    }
}
