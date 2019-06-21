using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tsp.AppWebVenta.Models
{
    public class DetalleVenta
    {
        [Key]
        public int id { get; set; }
        public int? idProducto { get; set; }
        public int? idVenta { get; set; }
        public float subTotal { get; set; }
        public int cantidad { get; set; }
    }
}
