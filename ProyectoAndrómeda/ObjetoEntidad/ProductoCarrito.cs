using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public class ProductoCarrito
    {
        public int idProductoCarrito { get; set; }
        public ItemEntidad item { get; set; }
        public int cantidad { get; set; }
        public float subtotal { get; set; }
        public int idTipoItem { get; set; }
    }
}
