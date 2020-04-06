using System;
using System.Collections.Generic;
using System.Text;

namespace SystemVenta.Bi.Dto
{
  public  class BillingDto 
    {
        public int Id { get; set; }
        public DateTime? Fecha { get; set; }
        public int Quantity { get; set; }
        public double Descuento { get; set; }
        public double Itbis { get; set; }
        public double Total { get; set; }
        public int ProductId { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ProducName { get; set; }
        public string ProductSelled { get; set; }

        public bool ClientType { get; set; }
    }
}
