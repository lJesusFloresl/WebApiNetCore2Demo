using System;
using System.Collections.Generic;

namespace WebApiNetCore2Demo.Models.Database
{
    public partial class OrdenVenta
    {
        public OrdenVenta()
        {
            OrdenVentaDetalle = new HashSet<OrdenVentaDetalle>();
        }

        public int Id { get; set; }
        public string Cliente { get; set; }
        public int FormaPagoId { get; set; }
        public decimal Total { get; set; }
        public DateTime FechaCompra { get; set; }

        public FormaPago FormaPago { get; set; }
        public ICollection<OrdenVentaDetalle> OrdenVentaDetalle { get; set; }
    }
}
