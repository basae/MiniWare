using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class User
    {
        public int? Id { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? Celular { get; set; }
        public string Correo { get; set; }
        public int? Grado { get; set; }
        public string Grupo { get; set; }
    }
}
