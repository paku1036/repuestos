using System;
using System.Collections.Generic;

#nullable disable

namespace RepuestosWeb.Models
{
    public partial class Modelo
    {
        public Modelo()
        {
            SubModelos = new HashSet<SubModelo>();
        }

        public int ModeloId { get; set; }
        public string ModeloNombre { get; set; }
        public int MarcaId { get; set; }

        public virtual Marca Marca { get; set; }
        public virtual ICollection<SubModelo> SubModelos { get; set; }
    }
}
