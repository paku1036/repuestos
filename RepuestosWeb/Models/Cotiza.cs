using System;
using System.Collections.Generic;

#nullable disable

namespace RepuestosWeb.Models
{
    public partial class Cotiza
    {
        public int CotizaId { get; set; }
        public DateTime CotizaFechaHora { get; set; }
        public int ClienteId { get; set; }
        public int RepuestoId { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Repuesto Repuesto { get; set; }
    }
}
