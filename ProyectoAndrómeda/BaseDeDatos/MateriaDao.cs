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
    public class MateriaDao:Conexion
    {
        /// <summary>
        /// Consultar: una materia de una descripcion determinado
        /// </summary>
        /// <param name="Nombre Pateria"></param>
        /// <returns>MateriaEntidad</returns>
        public static MateriaEntidad ConsultarMateriaXDescripcion(string descripcion)
        {
            string query = @"SELECT idMateria, nombreMateria, descripcionMateria, nivelCursado FROM Materia WHERE nombreMateria like @nombreMateria";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"nombreMateria", descripcion);
            SqlDataReader dr = cmd.ExecuteReader();
            MateriaEntidad mat = new MateriaEntidad();
            while (dr.Read())
            {
                mat.idMateria = int.Parse(dr["idMateria"].ToString());
                mat.nombreMateria = dr["nombreMateria"].ToString();
                mat.nivelCursado = int.Parse(dr["nivelCursado"].ToString());
                mat.descripcionMateria = dr["descripcionMateria"].ToString();
            }
            dr.Close();
            cmd.Connection.Close();
            return mat;
        }

        public static List<MateriaEntidad> ConsultarMateriaXCarrera(int idCarrera)
        {
            List<MateriaEntidad> lista = new List<MateriaEntidad>();
            string consulta = @"SELECT m.idMateria, m.nombreMateria, m.nivelCursado, m.descripcionMateria 
                                FROM Materia m JOIN CarreraXMateria cxm ON cxm.idMateria = m.idMateria
                                WHERE cxm.idCarrera = @idCar AND m.baja = 0";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"idCar", idCarrera);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                MateriaEntidad mat = new MateriaEntidad();
                mat.idMateria = int.Parse(dr["idMateria"].ToString());
                mat.nombreMateria = dr["nombreMateria"].ToString();
                mat.nivelCursado = int.Parse(dr["nivelCursado"].ToString());
                mat.descripcionMateria = dr["descripcionMateria"].ToString();
                lista.Add(mat);
            }
            dr.Close();
            cmd.Connection.Close();
            return lista;
        }

        public static List<MateriaEntidad> ConsultarMateriaXCarreraXNivelCursado(int idCarrera, int nivelCursado)
        {
            List<MateriaEntidad> lista = new List<MateriaEntidad>();
            string consulta = @"SELECT m.idMateria, m.nombreMateria, m.nivelCursado, m.descripcionMateria 
                                FROM Materia m JOIN CarreraXMateria cxm ON cxm.idMateria = m.idMateria
                                WHERE cxm.idCarrera = @idCar AND m.nivelCursado = @nivelCursado and  m.baja = 0";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"idCar", idCarrera);
            cmd.Parameters.AddWithValue(@"nivelCursado", nivelCursado);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                MateriaEntidad mat = new MateriaEntidad();
                mat.idMateria = int.Parse(dr["idMateria"].ToString());
                mat.nombreMateria = dr["nombreMateria"].ToString();
                mat.nivelCursado = int.Parse(dr["nivelCursado"].ToString());
                mat.descripcionMateria = dr["descripcionMateria"].ToString();
                lista.Add(mat);
            }
            dr.Close();
            cmd.Connection.Close();
            return lista;
        }
    }
}
