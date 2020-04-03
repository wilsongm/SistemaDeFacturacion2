using System;
using System.Collections.Generic;
using System.Text;
using SystemVenta.Model.Entities;

namespace SystemVenta.Bi.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
    }
}
