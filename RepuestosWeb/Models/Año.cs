using System;
using System.Collections.Generic;

#nullable disable

namespace RepuestosWeb.Models
{
    public partial class Año
    {
        public Año()
        {
            Marcas = new HashSet<Marca>();
        }

        public int AñoId { get; set; }
        public int? AñoDato { get; set; }

        public virtual ICollection<Marca> Marcas { get; set; }
    }
}
