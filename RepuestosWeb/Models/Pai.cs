using System;
using System.Collections.Generic;

#nullable disable

namespace RepuestosWeb.Models
{
    public partial class Pai
    {
        public Pai()
        {
            Regions = new HashSet<Region>();
        }

        public int PaisId { get; set; }
        public string PaisNombre { get; set; }

        public virtual ICollection<Region> Regions { get; set; }
    }
}
