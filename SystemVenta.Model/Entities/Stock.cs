using System;
using System.Collections.Generic;
using System.Text;
using SystemVenta.Model.Generic;

namespace SystemVenta.Model.Entities
{
    public class Stock : BaseModel
    {
        public Stock()
        {

        }
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int Quantity { get; set; }
        public int? EntryId { get; set; }
        public virtual Entry Entry { get; set; }
        public int? BillingId { get; set; }
        public virtual Billing Billing { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public virtual Product Product { get; set; }

    }
}
