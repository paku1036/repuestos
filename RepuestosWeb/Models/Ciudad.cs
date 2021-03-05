using System;
using System.Collections.Generic;

#nullable disable

namespace RepuestosWeb.Models
{
    public partial class Ciudad
    {
        public Ciudad()
        {
            Clientes = new HashSet<Cliente>();
            Comercios = new HashSet<Comercio>();
        }

        public int CiudadId { get; set; }
        public string CiudadNombre { get; set; }
        public int RegionId { get; set; }

        public virtual Region Region { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Comercio> Comercios { get; set; }
    }
}
