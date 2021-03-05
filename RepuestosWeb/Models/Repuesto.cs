using System;
using System.Collections.Generic;

#nullable disable

namespace RepuestosWeb.Models
{
    public partial class Repuesto
    {
        public Repuesto()
        {
            Cotizas = new HashSet<Cotiza>();
            Fotografia = new HashSet<Fotografium>();
            RepuestoCategoria = new HashSet<RepuestoCategorium>();
            RepuestoComercios = new HashSet<RepuestoComercio>();
            VerRepuestos = new HashSet<VerRepuesto>();
        }

        public int RepuestoId { get; set; }
        public string RepuestoNombre { get; set; }
        public string RepuestoDescripcionCorta { get; set; }
        public string RepuestoDescripcionLarga { get; set; }
        public string RepuestoNroParte { get; set; }
        public string RepuestoVinvehiculo { get; set; }
        public int TipoId { get; set; }
        public int MotorId { get; set; }
        public int UnidadMedidaId { get; set; }
        public int PaisFabricacionId { get; set; }

        public virtual Motor Motor { get; set; }
        public virtual PaisFabricacion PaisFabricacion { get; set; }
        public virtual Tipo Tipo { get; set; }
        public virtual UnidadMedidum UnidadMedida { get; set; }
        public virtual ICollection<Cotiza> Cotizas { get; set; }
        public virtual ICollection<Fotografium> Fotografia { get; set; }
        public virtual ICollection<RepuestoCategorium> RepuestoCategoria { get; set; }
        public virtual ICollection<RepuestoComercio> RepuestoComercios { get; set; }
        public virtual ICollection<VerRepuesto> VerRepuestos { get; set; }
    }
}
