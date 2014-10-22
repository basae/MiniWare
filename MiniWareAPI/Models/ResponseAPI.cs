using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class ResponseAPI<T>
    {
        public bool Error { get; set; }
        public string Mensage { get; set; }
        public IEnumerable<T> List { get; set; }
        public object Modelo { get; set; }
        public ResponseAPI()
        {
            this.Error = false;
            this.Mensage = string.Empty;
            this.List = null;
            this.Modelo = null;
        }
    }
}
