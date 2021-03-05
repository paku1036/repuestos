using System;
using System.Collections.Generic;

#nullable disable

namespace RepuestosWeb.Models
{
    public partial class Fotografium
    {
        public int FotografiaId { get; set; }
        public string FotografiaNombre { get; set; }
        public int? RepuestoId { get; set; }

        public virtual Repuesto Repuesto { get; set; }
    }
}
