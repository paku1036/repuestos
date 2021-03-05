using System;
using System.Collections.Generic;

#nullable disable

namespace RepuestosWeb.Models
{
    public partial class PaisFabricacion
    {
        public PaisFabricacion()
        {
            Repuestos = new HashSet<Repuesto>();
        }

        public int PaisFabricacionId { get; set; }
        public string PaisFabricacionNombre { get; set; }

        public virtual ICollection<Repuesto> Repuestos { get; set; }
    }
}
