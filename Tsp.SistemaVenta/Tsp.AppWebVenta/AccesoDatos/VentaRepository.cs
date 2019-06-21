using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tsp.AppWebVenta.Models;

namespace Tsp.AppWebVenta.AccesoDatos
{
    public class VentaRepository
    {
        private readonly VentaDB _context;

        public VentaRepository(VentaDB context)
        {
            _context = context;
        }

        // Agregar una VENTA
        public void Agregar(Venta v)
        {
            _context.venta.Add(v);
            _context.SaveChanges();
        }

        // Agregar un DETALLE DE VENTA
        public void _Agregar(DetalleVenta dv)
        {
            _context.detalleVenta.Add(dv);
            _context.SaveChanges();
        }

        //Obtener el SUBTOTAL de los productos vendidos
        public IEnumerable<DetalleVenta> ObtenerSubTotal(int identVenta) {
            var subtotales = _context.detalleVenta.Where(a => a.idVenta == identVenta);
            _context.SaveChanges();
            return subtotales;
        }

        // Actualizar el MONTO TOTAL de la VENTA
        public void ActualizarMontoTotal(int IdVentaTrans, float montoTotalVenta) {
            var modificar = _context.venta.FirstOrDefault(b => b.id == IdVentaTrans);
            modificar.montoTotal = montoTotalVenta;
            _context.venta.Update(modificar);
            _context.SaveChanges();
        }

        public List<ReporteViewModel> MostrarVentas() {
            var queryLinqJoin = from person in _context.cliente
                                join sales in _context.venta on person.id equals sales.idCliente
                                select new { name = person.nombre, lastname = person.apellidos, code = sales.id, date = sales.fecha ,amount = sales.montoTotal };
            _context.SaveChanges();
            List<ReporteViewModel> listSales = new List<ReporteViewModel>();
            foreach (var item in queryLinqJoin)
            {
                ReporteViewModel r = new ReporteViewModel(item.name, item.lastname, item.code, item.date, item.amount);
                listSales.Add(r);
            }

            return listSales;
        }
    }
}
