using System;
using System.Collections.Generic;

namespace Tsp.AppWebVenta.Models
{
    public partial class DetalleVenta
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public int IdVenta { get; set; }
        public float? SubTotal { get; set; }
        public int? Cantidad { get; set; }

        public Producto IdProductoNavigation { get; set; }
        public Venta IdVentaNavigation { get; set; }
    }
}
