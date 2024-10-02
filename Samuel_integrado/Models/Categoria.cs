using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Samuel_integrado.Models
{
    public class Categoria
    {
        public int? IdCategoria { get; set; }
        public string Categorias { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}