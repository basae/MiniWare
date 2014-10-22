using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class MensajePersonal
    {
        public int? Id { get; set; }
        public MensajeGeneral Mensaje { get; set; }
        public int? IdUsuario { get; set; }
        public bool? Visto { get; set; }
    }
}
