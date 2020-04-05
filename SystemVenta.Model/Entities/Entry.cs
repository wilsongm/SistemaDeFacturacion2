using System;
using System.Collections.Generic;
using System.Text;
using SystemVenta.Model.Generic;

namespace SystemVenta.Model.Entities
{
    public class Entry : BaseModel
    {
        public Entry()
        {

        }

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public string ProviderName { get; set; }
        public int ProviderId { get; set; }
        public int ProductId { get; set; }
        public virtual Provider Provider { get; set; }
        public virtual Product Product { get; set; }

    }
}
