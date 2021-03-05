using System;
using System.Collections.Generic;

#nullable disable

namespace RepuestosWeb.Models
{
    public partial class RepuestoComercio
    {
        public int RepuestoComercioId { get; set; }
        public int ComercioId { get; set; }
        public int RepuestoId { get; set; }

        public virtual Comercio Comercio { get; set; }
        public virtual Repuesto Repuesto { get; set; }
    }
}
