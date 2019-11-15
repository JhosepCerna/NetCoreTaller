using System;
using System.Collections.Generic;

namespace Tsp.AppWebVenta.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Venta = new HashSet<Venta>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Dni { get; set; }
        public int? Edad { get; set; }

        public ICollection<Venta> Venta { get; set; }
    }
}
