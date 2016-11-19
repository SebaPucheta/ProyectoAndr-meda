﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class FacturaEntidad
    {
        public int idFactura { get; set; }
        public DateTime fecha { get; set; }
        public float total { get; set; }
        public int idUsuario { get; set; }
        public int idEstadoPago { get; set; }
        public int idFacturaMP { get; set; }
        public List<ProductoCarrito> listaProductoCarrito { get; set; }
    }
}