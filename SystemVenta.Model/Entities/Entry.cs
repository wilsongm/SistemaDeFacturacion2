using System;
using System.Collections.Generic;
using System.Text;

namespace SystemVenta.Model.Entities
{
    public class Entry
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Quantity { get; set; }
        public int PrividerId { get; set; }
        public int ProductId { get; set; }
        public virtual Provider Provider { get; set; }
        public virtual Product Product { get; set; }

    }
}
