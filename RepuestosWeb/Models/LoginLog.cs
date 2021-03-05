using System;
using System.Collections.Generic;

#nullable disable

namespace RepuestosWeb.Models
{
    public partial class LoginLog
    {
        public LoginLog()
        {
            Clientes = new HashSet<Cliente>();
        }

        public int LoginLogId { get; set; }
        public DateTime? LoginLogFechaHoraa { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
