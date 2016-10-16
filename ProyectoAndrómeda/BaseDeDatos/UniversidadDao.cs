using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.Sql;
using System.Data.SqlClient;

namespace BaseDeDatos
{
    public class UniversidadDao : Conexion
    {
        /// <summary>
        /// Consultar: todas las universidades registradas en la base de datos
        /// </summary>
        /// <returns>Lista de objetos universidad</returns>
        public static List<UniversidadEntidad> ConsultarUniversidad()
        {
            List<UniversidadEntidad> lista = new List<UniversidadEntidad>();
            string consulta = @"SELECT idUniversidad, nombreUniversidad FROM Universidad WHERE baja = 0";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());

            SqlDataReader dr = cmd.ExecuteReader();

            List<UniversidadEntidad> listaUni = new List<UniversidadEntidad>();
            while (dr.Read())
            {
                UniversidadEntidad uni = new UniversidadEntidad();
                uni.idUniversidad = int.Parse(dr["idUniversidad"].ToString());
                uni.nombreUniversidad = dr["nombreUniversidad"].ToString();

                listaUni.Add(uni);
            }

            dr.Close();
            cmd.Connection.Close();
            return listaUni;

        }
    }
}
