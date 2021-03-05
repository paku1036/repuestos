using System;
using System.Collections.Generic;

#nullable disable

namespace RepuestosWeb.Models
{
    public partial class Comercio
    {
        public Comercio()
        {
            RepuestoComercios = new HashSet<RepuestoComercio>();
        }

        public int ComercioId { get; set; }
        public string ComercioNombre { get; set; }
        public int CiudadId { get; set; }

        public virtual Ciudad Ciudad { get; set; }
        public virtual ICollection<RepuestoComercio> RepuestoComercios { get; set; }
    }
}
