using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tsp.AppWebVenta.Models
{
    public class Venta
    {
        [Key]
        public int id { get; set; }
        public int? idCliente { get; set; }
        public DateTime fecha { get; set; }
        public float montoTotal { get; set; }
    }
}
