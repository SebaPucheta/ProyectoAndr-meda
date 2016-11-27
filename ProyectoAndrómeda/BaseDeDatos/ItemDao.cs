using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace BaseDeDatos
{
    public class ItemDao : Conexion
    {

        public static List<ItemEntidad> DevolverUltimoIngresos()
        {
            //Me tiene que devolver apuntes e libros ordenados por el ultimo id

            List<ItemEntidad> lista = new List<ItemEntidad>();
            string query = @" (	
	                            SELECT TOP 3 idApunte AS idItem,'Apunte' AS tipoItem, nombreApunte AS nombreItem, descripcionApunte AS descripcionItem, precioApunte AS precioItem, urlImagenApunte AS urlImagenItem
	                            FROM Apunte
                              )
                              UNION
                              (
	                            SELECT TOP 3 idLibro AS idItem, 'Libro' AS tipoItem, nombreLibro AS nombreItem, descripcionLibro AS descripcionItem, precioLibro AS precioItem, urlImagenLibro AS urlImagenItem
	                            FROM Libro
                              )
                              ORDER BY idItem DESC";

            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (dr["tipoItem"].ToString().Equals("Apunte"))
                {
                    ApunteEntidad apunte = new ApunteEntidad();
                    apunte.nombreApunte = dr["nombreItem"].ToString();
                    apunte.descripcionApunte = dr["descripcionItem"].ToString();
                    apunte.precioApunte = float.Parse(dr["precioItem"].ToString());
                    apunte.imagenApunte = dr["urlImagenItem"].ToString();
                    lista.Add(apunte);
                }
                else
                {
                    LibroEntidadQuery libro = new LibroEntidadQuery();
                    libro.nombreLibro = dr["nombreItem"].ToString();
                    libro.descripcionLibro = dr["descripcionItem"].ToString();
                    libro.precioLibro = float.Parse(dr["precioItem"].ToString());
                    libro.imagenLibro = dr["urlImagenItem"].ToString();
                    lista.Add(libro);
                }
            }

            dr.Close();
            cmd.Connection.Close();
            return lista;
        }


        public static List<ItemEntidad> DevolverMasVendidos()
        {
            //Me tiene que devolver una lista con los apuntes o libros mas vendidos, ordenados ubicado en primer lugar los mas vendidos

            List<ItemEntidad> lista = new List<ItemEntidad>();
            string query = @" SELECT TOP 3 sum(de.cantidad) as cantidadVendida, de.idItem as idItem, 
	                         (CASE WHEN de.idTipoItem=1 THEN 'Libro' 
			                       WHEN DE.idTipoItem=2 THEN 'Apunte' END) AS tipoItem,
	                         (CASE WHEN de.idTipoItem=1 THEN (SELECT nombreLibro FROM Libro WHERE idLibro=idItem) 
			                       WHEN DE.idTipoItem=2 THEN (SELECT nombreApunte FROM Apunte WHERE idApunte=idItem)END) AS nombreItem,
	                         (CASE WHEN de.idTipoItem=1 THEN (SELECT precioLibro FROM Libro WHERE idLibro=idItem) 
			                       WHEN DE.idTipoItem=2 THEN (SELECT precioApunte FROM Apunte WHERE idApunte=idItem)END) AS precioItem,
	                         (CASE WHEN de.idTipoItem=1 THEN (SELECT descripcionLibro FROM Libro WHERE idLibro=idItem) 
			                       WHEN DE.idTipoItem=2 THEN (SELECT descripcionApunte FROM Apunte WHERE idApunte=idItem)END) AS descripcionItem,
                             (CASE WHEN de.idTipoItem=1 THEN (SELECT urlImagenLibro FROM Libro WHERE idLibro=idItem) 
                                   WHEN DE.idTipoItem=2 THEN (SELECT urlImagenApunte FROM Apunte WHERE idApunte=idItem)END) AS urlImagenItem
                             FROM DetalleFactura de
                             GROUP BY de.idItem, de.idTipoItem
                             ORDER BY cantidadVendida";

            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (dr["tipoItem"].ToString().Equals("Apunte"))
                {
                    ApunteEntidad apunte = new ApunteEntidad();
                    apunte.idApunte = int.Parse(dr["idItem"].ToString());
                    apunte.nombreApunte = dr["nombreItem"].ToString();
                    apunte.descripcionApunte = dr["descripcionItem"].ToString();
                    apunte.precioApunte = float.Parse(dr["precioItem"].ToString());
                    apunte.imagenApunte = dr["urlImagenItem"].ToString();
                    lista.Add(apunte);
                }
                else
                {
                    LibroEntidadQuery libro = new LibroEntidadQuery();
                    libro.idLibro = int.Parse(dr["idItem"].ToString());
                    libro.nombreLibro = dr["nombreItem"].ToString();
                    libro.descripcionLibro = dr["descripcionItem"].ToString();
                    libro.precioLibro = float.Parse(dr["precioItem"].ToString());
                    libro.imagenLibro = dr["urlImagenItem"].ToString();
                    lista.Add(libro);
                }
            }

            dr.Close();
            cmd.Connection.Close();
            return lista;
        }

    }
}
