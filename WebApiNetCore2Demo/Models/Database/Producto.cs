using System;
using System.Collections.Generic;

namespace WebApiNetCore2Demo.Models.Database
{
    public partial class Producto
    {
        public Producto()
        {
            OrdenVentaDetalle = new HashSet<OrdenVentaDetalle>();
        }

        public int Id { get; set; }
        public string Clave { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }

        public ICollection<OrdenVentaDetalle> OrdenVentaDetalle { get; set; }
    }
}
