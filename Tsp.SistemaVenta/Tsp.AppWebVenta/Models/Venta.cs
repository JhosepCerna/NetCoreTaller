using System;
using System.Collections.Generic;

namespace Tsp.AppWebVenta.Models
{
    public partial class Venta
    {
        public Venta()
        {
            DetalleVenta = new HashSet<DetalleVenta>();
        }

        public int Id { get; set; }
        public int IdCliente { get; set; }
        public DateTime? Fecha { get; set; }
        public float? MontoTotal { get; set; }

        public Cliente IdClienteNavigation { get; set; }
        public ICollection<DetalleVenta> DetalleVenta { get; set; }
    }
}
