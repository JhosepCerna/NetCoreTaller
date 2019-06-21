using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tsp.AppWebVenta.AccesoDatos;
using Tsp.AppWebVenta.Models;

namespace Tsp.AppWebVenta.LogicaNegocio
{
    public class VentaLogica
    {
        private VentaRepository ventaLogica;

        public void RegistrarVenta(VentaDB db, Venta vent)
        {
            ventaLogica = new VentaRepository(db);
            ventaLogica.Agregar(vent);
        }

        public void RegistrarDetalleVenta(VentaDB db, DetalleVenta detvent)
        {
            ventaLogica = new VentaRepository(db);
            ventaLogica._Agregar(detvent);
        }

        private float ConvertirAlTotal(VentaDB db, string codigoOperac)
        {
            ventaLogica = new VentaRepository(db);
            IEnumerable<DetalleVenta> montosubtotal = ventaLogica.ObtenerSubTotal(Convert.ToInt32(codigoOperac));
            float totalDetVen = 0f;
            foreach (var item in montosubtotal)
            {
                totalDetVen += item.subTotal;
            }
            return totalDetVen;
        }

        public void EditarMontoTotal(VentaDB db, string idOperac) {
            ventaLogica = new VentaRepository(db);
            float montoEditar = ConvertirAlTotal(db, idOperac);
            ventaLogica.ActualizarMontoTotal(Convert.ToInt32(idOperac), montoEditar);
        }

        public List<ReporteViewModel> ListarVentas(VentaDB db) {
            ventaLogica = new VentaRepository(db);
            List<ReporteViewModel> list = ventaLogica.MostrarVentas();
            return list;
        }
    }
}
