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
    public class FacultadDao:Conexion
    {
        public static List<FacultadEntidad> ConsultarFacultadXUniversidad(int idUniversidad)
        {
            List<FacultadEntidad> listaFac = new List<FacultadEntidad>();
            string query = "SELECT idFacultad, nombreFacultad, idUniversidad, idCiudad FROM Facultad WHERE idUniversidad = @idUniversidad AND baja = 0";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue("@idUniversidad", idUniversidad);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                FacultadEntidad fac = new FacultadEntidad();
                fac.idFacultad = int.Parse(dr["idFacultad"].ToString());
                fac.nombreFacultad = dr["nombreFacultad"].ToString();
                fac.idUniversidad = (int)dr["idUniversidad"];
                fac.idCiudad = int.Parse(dr["idCiudad"].ToString());
                listaFac.Add(fac);
            }
            dr.Close();
            cmd.Connection.Close();
            return listaFac;
        }
        public static FacultadEntidad ConsultarFacultadXDescripcion(string descripcion)
        {
            FacultadEntidad fac = new FacultadEntidad();
            string query = "SELECT idFacultad, nombreFacultad, idUniversidad, idCiudad FROM Facultad WHERE nombreFacultad like @nombreFacultad";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue("@nombreFacultad", descripcion);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                fac.idFacultad = int.Parse(dr["idFacultad"].ToString());
                fac.nombreFacultad = dr["nombreFacultad"].ToString();
                fac.idUniversidad = (int)dr["idUniversidad"];
                fac.idCiudad = int.Parse(dr["idCiudad"].ToString());
            }
            dr.Close();
            cmd.Connection.Close();
            return fac;
        }
    }
}
