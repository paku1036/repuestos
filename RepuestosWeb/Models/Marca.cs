using System;
using System.Collections.Generic;

#nullable disable

namespace RepuestosWeb.Models
{
    public partial class Marca
    {
        public Marca()
        {
            Modelos = new HashSet<Modelo>();
        }

        public int MarcaId { get; set; }
        public string MarcaNombre { get; set; }
        public int? AñoId { get; set; }

        public virtual Año Año { get; set; }
        public virtual ICollection<Modelo> Modelos { get; set; }
    }
}
