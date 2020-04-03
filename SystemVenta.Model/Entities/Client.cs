using System;
using System.Collections.Generic;
using System.Text;
using SystemVenta.Model.Enum;

namespace SystemVenta.Model.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public Category CategoryState { get; set; }


    }
}
