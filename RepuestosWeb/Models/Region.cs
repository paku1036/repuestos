using System;
using System.Collections.Generic;

#nullable disable

namespace RepuestosWeb.Models
{
    public partial class Region
    {
        public Region()
        {
            Ciudads = new HashSet<Ciudad>();
        }

        public int RegionId { get; set; }
        public string RegionNombre { get; set; }
        public int PaisId { get; set; }

        public virtual Pai Pais { get; set; }
        public virtual ICollection<Ciudad> Ciudads { get; set; }
    }
}
