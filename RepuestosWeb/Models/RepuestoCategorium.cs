using System;
using System.Collections.Generic;

#nullable disable

namespace RepuestosWeb.Models
{
    public partial class RepuestoCategorium
    {
        public int RepuestoCategoriaId { get; set; }
        public int RepuestoId { get; set; }
        public int CategoriaId { get; set; }

        public virtual Categorium Categoria { get; set; }
        public virtual Repuesto Repuesto { get; set; }
    }
}
