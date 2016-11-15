using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class FacturaEntidadQuery : FacturaEntidad
    {
        public string nombreTipoPago { get; set; }
        public string nombreUsuario { get; set; }
        public string nombreEstadoPago { get; set; }
        public string nombreCliente { get; set; }
        public string apellidoCliente { get; set; }
        public string mailCliente { get; set; }
    }
}