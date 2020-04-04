using System;
using System.Collections.Generic;
using System.Text;
using SystemVenta.Model.Generic;

namespace SystemVenta.Model.Entities
{
    public class Product : BaseModel
    {
        public Product()
        {
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }

    }
}
