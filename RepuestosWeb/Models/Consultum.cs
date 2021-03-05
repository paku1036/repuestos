using System;
using System.Collections.Generic;

#nullable disable

namespace RepuestosWeb.Models
{
    public partial class Consultum
    {
        public int ConsultaId { get; set; }
        public string BusquedaTexto { get; set; }
        public string ConsultaCantidadCoincidencias { get; set; }
        public int ClienteId { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
