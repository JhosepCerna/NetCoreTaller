using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tsp.AppWebVenta.Models;

namespace Tsp.AppWebVenta.AccesoDatos
{
    public class ProductoRepository
    {
        private readonly TestVentaContext _context;

        public ProductoRepository(TestVentaContext context)
        {
            _context = context;
        }

        // Agregar un PRODUCTO
        public void Agregar(Producto p)
        {
            _context.Producto.Add(p);
            _context.SaveChanges();
        }

        // Busca el ID del PRODUCTO
        public Producto Buscar(string name)
        {
            Producto productoDato = _context.Producto.FirstOrDefault(c => c.Nombre.Equals(name));
            _context.SaveChanges();
            return productoDato;
        }

        // Mostrar todo los PRODUCTOS
        public IEnumerable<Producto> Mostrar()
        {
            var lista = _context.Producto.OrderBy(a => a.Nombre);
            _context.SaveChanges();
            return lista;
        }
    }
}
