using System;
using System.Collections.Generic;

#nullable disable

namespace RepuestosWeb.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Consulta = new HashSet<Consultum>();
            Cotizas = new HashSet<Cotiza>();
            VerRepuestos = new HashSet<VerRepuesto>();
        }

        public int ClienteId { get; set; }
        public string ClienteNombre { get; set; }
        public string ClienteCuenta { get; set; }
        public int ClienteTelefono { get; set; }
        public int LoginLogId { get; set; }
        public int TipoLoginId { get; set; }
        public int? CiudadId { get; set; }

        public virtual Ciudad Ciudad { get; set; }
        public virtual LoginLog LoginLog { get; set; }
        public virtual TipoLogin TipoLogin { get; set; }
        public virtual ICollection<Consultum> Consulta { get; set; }
        public virtual ICollection<Cotiza> Cotizas { get; set; }
        public virtual ICollection<VerRepuesto> VerRepuestos { get; set; }
    }
}
