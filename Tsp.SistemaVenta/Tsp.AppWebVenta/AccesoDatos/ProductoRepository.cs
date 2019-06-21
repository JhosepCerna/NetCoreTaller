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
        private readonly VentaDB _context;

        public ProductoRepository(VentaDB context)
        {
            _context = context;
        }

        // Agregar un PRODUCTO
        public void Agregar(Producto p)
        {
            _context.producto.Add(p);
            _context.SaveChanges();
        }

        // Busca el ID del PRODUCTO
        public Producto Buscar(string name)
        {
            Producto productoDato = _context.producto.FirstOrDefault(c => c.nombre.Equals(name));
            _context.SaveChanges();
            return productoDato;
        }

        // Mostrar todo los PRODUCTOS
        public IEnumerable<Producto> Mostrar()
        {
            var lista = _context.producto.OrderBy(a => a.nombre);
            _context.SaveChanges();
            return lista;
        }
    }
}
