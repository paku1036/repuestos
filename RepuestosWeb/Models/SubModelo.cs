using System;
using System.Collections.Generic;

#nullable disable

namespace RepuestosWeb.Models
{
    public partial class SubModelo
    {
        public SubModelo()
        {
            Motors = new HashSet<Motor>();
        }

        public int SubModeloId { get; set; }
        public string SubModeloNombre { get; set; }
        public int ModeloId { get; set; }

        public virtual Modelo Modelo { get; set; }
        public virtual ICollection<Motor> Motors { get; set; }
    }
}
