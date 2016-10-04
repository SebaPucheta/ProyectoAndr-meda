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
    public class CarreraDao:Conexion
    {
        public static List<CarreraEntidad> ConsultarCarreraXFacultad(int idFacultad)
        {
            string consulta = @"SELECT idCarrera, nombreCarrera, idFacultad 
                                FROM Carrera WHERE idFacultad = @idFacultad";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue("@idFacultad", idFacultad);
            SqlDataReader dr = cmd.ExecuteReader();
            List<CarreraEntidad> listaCarrera = new List<CarreraEntidad>();
            while (dr.Read())
            {
                CarreraEntidad car = new CarreraEntidad();
                car.idCarrera = int.Parse(dr["idCarrera"].ToString());
                car.nombreCarrera = dr["nombreCarrera"].ToString();
                car.idFacultad = int.Parse(dr["idFacultad"].ToString());
                listaCarrera.Add(car);
            }
            dr.Close();
            cmd.Connection.Close();
            return listaCarrera;
        }

        public static CarreraEntidad ConsultarCarreraXDescripcion(string descripcion)
        {
            CarreraEntidad car = new CarreraEntidad();
            string consulta = @"SELECT idCarrera, nombreCarrera, idFacultad 
                                FROM Carrera WHERE nombreCarrera like @nombreCarrera";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"nombreCarrera", descripcion);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                car.idCarrera = int.Parse(dr["idCarrera"].ToString());
                car.nombreCarrera = dr["nombreCarrera"].ToString();
                car.idFacultad = int.Parse(dr["idFacultad"].ToString());
            }
            dr.Close();
            cmd.Connection.Close();
            return car;
        }
    }
}
