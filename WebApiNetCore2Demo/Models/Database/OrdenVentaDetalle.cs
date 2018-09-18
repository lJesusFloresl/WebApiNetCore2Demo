using System;
using System.Collections.Generic;

namespace WebApiNetCore2Demo.Models.Database
{
    public partial class OrdenVentaDetalle
    {
        public int Id { get; set; }
        public int? OrdenVentaId { get; set; }
        public int ProductoId { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Total { get; set; }

        public OrdenVenta OrdenVenta { get; set; }
        public Producto Producto { get; set; }
    }
}
