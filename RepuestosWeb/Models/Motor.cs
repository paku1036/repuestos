using System;
using System.Collections.Generic;

#nullable disable

namespace RepuestosWeb.Models
{
    public partial class Motor
    {
        public Motor()
        {
            Repuestos = new HashSet<Repuesto>();
        }

        public int MotorId { get; set; }
        public string MotorDescripcion { get; set; }
        public int SubModeloId { get; set; }

        public virtual SubModelo SubModelo { get; set; }
        public virtual ICollection<Repuesto> Repuestos { get; set; }
    }
}
