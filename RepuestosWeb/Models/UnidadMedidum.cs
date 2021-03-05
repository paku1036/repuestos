using System;
using System.Collections.Generic;

#nullable disable

namespace RepuestosWeb.Models
{
    public partial class UnidadMedidum
    {
        public UnidadMedidum()
        {
            Repuestos = new HashSet<Repuesto>();
        }

        public int UnidadMedidaId { get; set; }
        public string UnidadMedidaNombre { get; set; }

        public virtual ICollection<Repuesto> Repuestos { get; set; }
    }
}
