using System;
using System.Collections.Generic;

namespace Tsp.AppWebVenta.Models
{
    public partial class Producto
    {
        public Producto()
        {
            DetalleVenta = new HashSet<DetalleVenta>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public float? PrecioUnitario { get; set; }

        public ICollection<DetalleVenta> DetalleVenta { get; set; }
    }
}
