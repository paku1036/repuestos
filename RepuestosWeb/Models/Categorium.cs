using System;
using System.Collections.Generic;

#nullable disable

namespace RepuestosWeb.Models
{
    public partial class Categorium
    {
        public Categorium()
        {
            InverseCategoriaPadrei = new HashSet<Categorium>();
            RepuestoCategoria = new HashSet<RepuestoCategorium>();
        }

        public int CategoriaId { get; set; }
        public string CategoriaNombre { get; set; }
        public int CategoriaPadreiId { get; set; }

        public virtual Categorium CategoriaPadrei { get; set; }
        public virtual ICollection<Categorium> InverseCategoriaPadrei { get; set; }
        public virtual ICollection<RepuestoCategorium> RepuestoCategoria { get; set; }
    }
}
