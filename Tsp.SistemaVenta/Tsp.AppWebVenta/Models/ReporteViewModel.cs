using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tsp.AppWebVenta.Models
{
    public class ReporteViewModel
    {
        public string nombreView { get; set; }
        public string apellidoView { get; set; }
        public int codigoView { get; set; }
        public DateTime? fechaView { get; set; }
        public float? montoTotalView { get; set; }

        public ReporteViewModel(string nombreView, string apellidoView, int codigoView, DateTime? fechaView, float? montoTotalView)
        {
            this.nombreView = nombreView;
            this.apellidoView = apellidoView;
            this.codigoView = codigoView;
            this.fechaView = fechaView;
            this.montoTotalView = montoTotalView;
        }
    }
}
