using System;
using System.Collections.Generic;

#nullable disable

namespace RepuestosWeb.Models
{
    public partial class Tipo
    {
        public Tipo()
        {
            Repuestos = new HashSet<Repuesto>();
        }

        public int TipoId { get; set; }
        public string TipoNombre { get; set; }

        public virtual ICollection<Repuesto> Repuestos { get; set; }
    }
}
