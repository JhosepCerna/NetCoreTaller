using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tsp.AppWebVenta.Models;

namespace Tsp.AppWebVenta.AccesoDatos
{
    public class VentaDB : DbContext
    {
        public VentaDB(DbContextOptions<VentaDB> options) : base(options){}

        public DbSet<Cliente> cliente { get; set; }
        public DbSet<Producto> producto { get; set; }
        public DbSet<Venta> venta { get; set; }
        public DbSet<DetalleVenta> detalleVenta { get; set; }
    }
}
