using System;
using System.Collections.Generic;
using System.Text;

namespace SystemVenta.Model.Entities
{
    public class Product
    {
        public Product()
        {
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
    }
}
