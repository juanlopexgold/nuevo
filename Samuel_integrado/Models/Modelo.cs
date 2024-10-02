using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Samuel_integrado.Models
{
    public class Modelo
    {
         public int? IdModelo { get; set; }  // Nullable in case it's not set yet
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;  
    }
}