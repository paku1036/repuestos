using System;
using System.Collections.Generic;

#nullable disable

namespace RepuestosWeb.Models
{
    public partial class TipoLogin
    {
        public TipoLogin()
        {
            Clientes = new HashSet<Cliente>();
        }

        public int TipoLoginId { get; set; }
        public string TipoLoginNombre { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
