using System;
using System.Collections.Generic;

namespace WebApiNetCore2Demo.Models.Database
{
    public partial class FormaPago
    {
        public FormaPago()
        {
            OrdenVenta = new HashSet<OrdenVenta>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public ICollection<OrdenVenta> OrdenVenta { get; set; }
    }
}
