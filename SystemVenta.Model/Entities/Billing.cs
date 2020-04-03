using System;
using System.Collections.Generic;
using System.Text;

namespace SystemVenta.Model.Entities
{
    public class Billing
    {

        public int Id { get; set; }
        public DateTime? Fecha { get; set; }
        public int Quantity { get; set; }
        public double Descuento { get; set; }
        public double Itbis { get; set; }
        public int ProductId { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public Product Product { get; set; }

    }
}
