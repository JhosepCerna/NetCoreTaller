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
        private readonly TestVentaContext _context;

        public VentaRepository(TestVentaContext context)
        {
            _context = context;
        }

        // Agregar una VENTA
        public void Agregar(Venta v)
        {
            _context.Venta.Add(v);
            _context.SaveChanges();
        }

        // Agregar un DETALLE DE VENTA
        public void _Agregar(DetalleVenta dv)
        {
            _context.DetalleVenta.Add(dv);
            _context.SaveChanges();
        }

        //Obtener el SUBTOTAL de los productos vendidos
        public IEnumerable<DetalleVenta> ObtenerSubTotal(int identVenta) {
            var subtotales = _context.DetalleVenta.Where(a => a.IdVenta == identVenta);
            _context.SaveChanges();
            return subtotales;
        }

        // Actualizar el MONTO TOTAL de la VENTA
        public void ActualizarMontoTotal(int IdVentaTrans, float montoTotalVenta) {
            var modificar = _context.Venta.FirstOrDefault(b => b.Id == IdVentaTrans);
            modificar.MontoTotal = montoTotalVenta;
            _context.Venta.Update(modificar);
            _context.SaveChanges();
        }

        public List<ReporteViewModel> MostrarVentas() {
            var queryLinqJoin = from person in _context.Cliente
                                join sales in _context.Venta on person.Id equals sales.IdCliente
                                select new { name = person.Nombre, lastname = person.Apellidos, code = sales.Id, date = sales.Fecha ,amount = sales.MontoTotal };
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
