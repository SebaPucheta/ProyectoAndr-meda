using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseDeDatos;
using Entidades;
using System.Data;

namespace Negocio
{
    public class CarritoNegocio
    {

        public static DataView cargarProducto(ItemEntidad producto, ApunteEntidad apunte, LibroEntidad libro)
        {
            
            DataTable tabla = new DataTable();
            DataRow fila;

            //[0] imagen
            //[1] id
            //[2] nombre
            //[3] tipo
            //[4] precio
            //[5] cantidad
            //[6] subtotal

            //Creo las columnas de la tabla
            tabla.Columns.Add("img", typeof(string));
            tabla.Columns.Add("idProducto", typeof(int));
            tabla.Columns.Add("nombreProducto", typeof(string));
            tabla.Columns.Add("tipoProducto", typeof(string));
            tabla.Columns.Add("precioUnitario", typeof(float));

            fila = tabla.NewRow();
            if (producto is ApunteEntidad)
            {
                fila[1] = apunte.idApunte;
                fila[2] = apunte.nombreApunte;
                fila[3] = "Apunte";
                fila[4] = apunte.precioApunte;
            }
            else if (producto is LibroEntidad)
            {
                fila[1] = libro.idLibro;
                fila[2] = libro.nombreLibro;
                fila[3] = "Libro";
                fila[4] = libro.precioLibro;
            }
            tabla.Rows.Add(fila);
            DataView dataView = new DataView(tabla);
            return dataView;
           
        }
    }

}

