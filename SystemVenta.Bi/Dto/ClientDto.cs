using System;
using System.Collections.Generic;
using System.Text;


namespace SystemVenta.Bi.Dto
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Category { get; set; }
    }
}
