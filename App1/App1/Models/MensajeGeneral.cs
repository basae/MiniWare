using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App1.Models
{
    public class MensajeGeneral
    {
        public int? Id { get; set; }
        public string Descripcion { get; set; }
        public string De { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaCierre { get; set; }
        public int Grado { get; set; }
        public string Grupo { get; set; }
    }
}