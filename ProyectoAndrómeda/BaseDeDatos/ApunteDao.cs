﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;
namespace BaseDeDatos
{
    public class ApunteDao: Conexion
    {

        /// <summary>
        /// Consultar: un solo apunte de un ID determinado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ApunteEntidad ConsultarApunte(int id)
        {
            ApunteEntidad apu = new ApunteEntidad();
            string consulta = @"SELECT idApunte, stock, precioApunte, cantHoja, nombreApunte, descripcionApunte, anoApunte,
                                                codigoBarraApunte, idPrecioHoja, idCategoria, idTipoApunte, idEditorial, idEstado, 
                                                idProfesor, idMateria
                                FROM Apunte WHERE idApunte = @id";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                apu.idApunte = int.Parse(dr["idApunte"].ToString());
                if (dr["stock"] != DBNull.Value)
                    apu.stock = int.Parse(dr["stock"].ToString());
                apu.precioApunte = float.Parse(dr["precioApunte"].ToString());
                apu.cantHoja = int.Parse(dr["cantHoja"].ToString());
                apu.nombreApunte = dr["nombreApunte"].ToString();
                apu.descripcionApunte = dr["descripcionApunte"].ToString();
                apu.anoApunte = int.Parse(dr["anoApunte"].ToString());
                apu.codigoBarraApunte = dr["codigoBarraApunte"].ToString();
                if (dr["idPrecioHoja"] != DBNull.Value)
                { apu.idPrecioHoja = int.Parse(dr["idPrecioHoja"].ToString()); }
                apu.idCategoria = int.Parse(dr["idCategoria"].ToString());
                apu.idTipoApunte = int.Parse(dr["idTipoApunte"].ToString());
                apu.idEditorial = int.Parse(dr["idEditorial"].ToString());
                if (dr["idEstado"] != DBNull.Value)
                { apu.idEstado = int.Parse(dr["idEstado"].ToString()); }
                if (dr["idProfesor"] != DBNull.Value)
                { apu.idProfesor = int.Parse(dr["idProfesor"].ToString()); }
                apu.idMateria = (int)dr["idMateria"];
            }
            dr.Close();
            cmd.Connection.Close();
            return apu;
        }

        /// <summary>
        /// Consultar todos los apuntes sin filtros, traerlos pelados desde la base de datos
        /// </summary>
        /// <returns></returns>
        public static List<ApunteEntidadQuery> ConsultarApuntesSinFiltros()
        {
            List<ApunteEntidadQuery> lista = new List<ApunteEntidadQuery>();
            string query = @"SELECT DISTINCT a.idApunte, a.precioApunte, a.nombreApunte, a.stock FROM Apunte a WHERE a.baja = 0";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ApunteEntidadQuery apu = new ApunteEntidadQuery();
                apu.idApunte = int.Parse(dr["idApunte"].ToString());
                if (dr["stock"] != DBNull.Value)
                    apu.stock = int.Parse(dr["stock"].ToString());
                apu.precioApunte = float.Parse(dr["precioApunte"].ToString());
                apu.nombreApunte = dr["nombreApunte"].ToString();
                lista.Add(apu);
            }
            dr.Close();
            cmd.Connection.Close();
            return lista;
        }


        public static List<ApunteEntidadQuery> ConsultarTodosLosApuntes()
        {

            //NO ME TRAJO NADA
            List<ApunteEntidadQuery> lista = new List<ApunteEntidadQuery>();
            string query = @"SELECT DISTINCT a.idApunte, a.stock, a.precioApunte, a.cantHoja, a.nombreApunte, a.descripcionApunte, a.anoApunte, a.codigoBarraApunte, a.idMateria,
                                    pr.precioHoja, c.nombreCategoria, tp.nombreTipoApunte, e.nombreEditorial, es.nombreEstado, p.nombreProfesor, p.apellidoProfesor 
                             FROM Apunte a JOIN PrecioXHoja pr ON a.idPrecioHoja = pr.idPrecioHoja
                                            JOIN Categoria c ON a.idCategoria = c.idCategoria
                                            JOIN TipoApunte tp ON a.idTipoApunte = tp.idTipoApunte
                                            JOIN Editorial e ON a.idEditorial = e.idEditorial
                                            JOIN Estado es ON a.idEstado = es.idEstado
                                            JOIN Profesor p ON a.idProfesor = p.idProfesor
                              WHERE a.baja = 0";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ApunteEntidadQuery apu = new ApunteEntidadQuery();
                apu.idApunte = int.Parse(dr["idApunte"].ToString());
                if (dr["stock"] != DBNull.Value)
                    apu.stock = int.Parse(dr["stock"].ToString());
                apu.precioApunte = float.Parse(dr["precioApunte"].ToString());
                apu.cantHoja = int.Parse(dr["cantHoja"].ToString());
                apu.nombreApunte = dr["nombreApunte"].ToString();
                apu.descripcionApunte = dr["descripcionApunte"].ToString();
                apu.anoApunte = int.Parse(dr["anoApunte"].ToString());
                apu.codigoBarraApunte = dr["codigoBarraApunte"].ToString();
                apu.precioHoja = float.Parse(dr["precioHoja"].ToString());
                apu.nombreCategoria = dr["nombreCategoria"].ToString();
                apu.nombreTipoApunte = dr["nombreTipoApunte"].ToString();
                apu.nombreEditorial = dr["nombreEditorial"].ToString();
                apu.nombreEstado = dr["nombreEstado"].ToString();
                apu.nombreProfesor = dr["nombreProfesor"].ToString();
                apu.apellidoProfesor = dr["apellidoProfesor"].ToString();
                apu.idMateria = (int)dr["idMateria"];
                lista.Add(apu);
            }
            dr.Close();
            cmd.Connection.Close();
            return lista;
        }


        public static List<ApunteEntidadQuery> ConsultarApunteXFiltroMateria(string idTipoApunte, string nombreApunte,
                                                                            string idUniversidad, string idFacultad, string idMateria)
        {
            List<ApunteEntidadQuery> lista = new List<ApunteEntidadQuery>();
                string consulta = @"SELECT DISTINCT a.idApunte, a.nombreApunte, a.precioApunte, m.nombreMateria, a.stock as 'stockApunte', e.nombreEditorial, p.nombreProfesor,
                                           p.apellidoProfesor, ta.nombreTipoApunte, a.codigoBarraApunte,
									       a.anoApunte, a.cantHoja, u.nombreUniversidad, f.nombreFacultad, a.descripcionApunte
                                    FROM Apunte a JOIN Editorial e ON a.idEditorial = e.idEditorial
                                			      JOIN Profesor p ON p.idProfesor = a.idProfesor
                                			      JOIN TipoApunte ta ON ta.idTipoApunte = a.idTipoApunte
                                			      JOIN Materia m ON a.idMateria = m.idMateria
                                			      JOIN CarreraXMateria cxr ON cxr.idMateria = m.idMateria
			                                      JOIN Carrera c ON cxr.idCarrera = c.idCarrera
			                                       JOIN Facultad f ON c.idFacultad = f.idFacultad
			                                       JOIN Universidad u ON f.idUniversidad = u.idUniversidad
                                    WHERE ta.idTipoApunte like @idTipoApu AND a.nombreApunte like @nomApu AND u.idUniversidad like @idUni
                                          AND f.idFacultad like @idFacu AND m.idMateria like @idMat AND a.baja = 0";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"idTipoApu", idTipoApunte + '%');
            cmd.Parameters.AddWithValue(@"nomApu", nombreApunte + '%');
            cmd.Parameters.AddWithValue(@"idUni", idUniversidad + '%');
            cmd.Parameters.AddWithValue(@"idFacu", idFacultad + '%');
            cmd.Parameters.AddWithValue(@"idMat", idMateria + '%');
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ApunteEntidadQuery apu = new ApunteEntidadQuery();
                apu.idApunte = int.Parse(dr["idApunte"].ToString());
                apu.nombreApunte = dr["nombreApunte"].ToString();
                apu.precioApunte = float.Parse(dr["precioApunte"].ToString());
                if (dr["stockApunte"] != DBNull.Value)
                    apu.stock = int.Parse(dr["stockApunte"].ToString());
                apu.nombreEditorial = dr["nombreEditorial"].ToString();
                apu.nombreProfesor = dr["nombreProfesor"].ToString();
                apu.apellidoProfesor = dr["apellidoProfesor"].ToString();
                apu.nombreTipoApunte = dr["nombreTipoApunte"].ToString();
                apu.anoApunte = int.Parse(dr["anoApunte"].ToString());
                apu.cantHoja = int.Parse(dr["cantHoja"].ToString());
                apu.codigoBarraApunte = dr["codigoBarraApunte"].ToString();
                apu.descripcionApunte = dr["descripcionApunte"].ToString();
                apu.nombreUniversidad = dr["nombreUniversidad"].ToString();
                apu.nombreFacultad = dr["nombreFacultad"].ToString();
                apu.listaCarreras = ConsultarCarrerasXApunte(apu.idApunte);
                apu.nombreMateria = (string)dr["nombreMateria"];
                lista.Add(apu);
            }
            dr.Close();
            cmd.Connection.Close();
            return lista;
        }

        public static ApunteEntidadQuery ConsultarApunteXMateria(int idMateria)
        {
            ApunteEntidadQuery apu = new ApunteEntidadQuery();
            string consulta = @"SELECT DISTINCT a.idApunte, a.nombreApunte, a.precioApunte, m.nombreMateria, a.stock as 'stockApunte', e.nombreEditorial, p.nombreProfesor,
                                           p.apellidoProfesor, ta.nombreTipoApunte, a.codigoBarraApunte,
									       a.anoApunte, a.cantHoja, a.descripcionApunte
                                    FROM Apunte a JOIN Editorial e ON a.idEditorial = e.idEditorial
                                			      JOIN Profesor p ON p.idProfesor = a.idProfesor
                                			      JOIN TipoApunte ta ON ta.idTipoApunte = a.idTipoApunte
                                			      JOIN Materia m ON a.idMateria = m.idMateria
                                			WHERE  m.idMateria = @idMat AND a.baja = 0";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"idMat", idMateria );
            
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                apu.idApunte = int.Parse(dr["idApunte"].ToString());
                apu.nombreApunte = dr["nombreApunte"].ToString();
                apu.precioApunte = float.Parse(dr["precioApunte"].ToString());
                if (dr["stockApunte"] != DBNull.Value)
                    apu.stock = int.Parse(dr["stockApunte"].ToString());
                apu.nombreEditorial = dr["nombreEditorial"].ToString();
                apu.nombreProfesor = dr["nombreProfesor"].ToString();
                apu.apellidoProfesor = dr["apellidoProfesor"].ToString();
                apu.nombreTipoApunte = dr["nombreTipoApunte"].ToString();
                apu.anoApunte = int.Parse(dr["anoApunte"].ToString());
                apu.cantHoja = int.Parse(dr["cantHoja"].ToString());
                apu.codigoBarraApunte = dr["codigoBarraApunte"].ToString();
                apu.descripcionApunte = dr["descripcionApunte"].ToString();
                apu.nombreMateria = (string)dr["nombreMateria"];
            }
            dr.Close();
            cmd.Connection.Close();
            return apu ;
        }
         public static List<CarreraEntidad> ConsultarCarrerasXApunte(int idApunte)
        {
            List<CarreraEntidad> lista = new List<CarreraEntidad>();
            string consulta = @"SELECT cxm.idCarrera, c.nombreCarrera 
                                FROM Apunte a JOIN CarreraXMateria cxm ON a.idMateria = cxm.idMateria
									          JOIN Carrera c ON cxm.idCarrera = c.idCarrera WHERE a.idApunte = @id AND a.baja = 0";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", idApunte);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                CarreraEntidad car = new CarreraEntidad();
                car.idCarrera = int.Parse(dr["idCarrera"].ToString());
                car.nombreCarrera = dr["nombreCarrera"].ToString();
                lista.Add(car);
            }
            dr.Close();
            cmd.Connection.Close();
            return lista;
        }

        public static List<MateriaEntidad> ConsultarMateriasXApunte(int idApunte)
        {
            List<MateriaEntidad> lista = new List<MateriaEntidad>();
            string consulta = @"SELECT cxm.idMateria, m.nombreMateria 
                                FROM Apunte a JOIN CarreraXMateria cxm ON a.idMateria = cxm.idMateria
									          JOIN Materia m ON cxm.idMateria = m.idMateria WHERE a.idApunte = @id AND a.baja = 0";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", idApunte);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                MateriaEntidad car = new MateriaEntidad();
                car.idMateria = int.Parse(dr["idMateria"].ToString());
                car.nombreMateria = dr["nombreMateria"].ToString();
                lista.Add(car);
            }
            dr.Close();
            cmd.Connection.Close();
            return lista;
        }

        //Filtro de apunte con CARRERA
        public static List<ApunteEntidadQuery> ConsultarApunteXFiltroCarrera(string idTipoApunte, string nombreApunte, string idUniversidad,
                                                                      string idFacultad, string idCarrera)
        {
            List<ApunteEntidadQuery> lista = new List<ApunteEntidadQuery>();
            string consulta = @"SELECT DISTINCT a.idApunte, a.cantHoja, a.nombreApunte, m.nombreMateria, a.descripcionApunte, a.codigoBarraApunte,
                                       u.nombreUniversidad, f.nombreFacultad, e.nombreEditorial, pr.nombreProfesor, pr.apellidoProfesor,
		                               a.stock, a.precioApunte, a.anoApunte, m.nombreMateria, ta.nombreTipoApunte
                                FROM Apunte a INNER JOIN Materia m ON a.idMateria = m.idMateria
			                                  INNER JOIN CarreraXMateria cxr ON cxr.idMateria = m.idMateria
			                                  INNER JOIN Carrera c ON cxr.idCarrera = c.idCarrera
			                                  INNER JOIN Facultad f ON c.idFacultad = f.idFacultad
			                                  INNER JOIN Universidad u ON f.idUniversidad = u.idUniversidad
											  INNER JOIN Editorial e ON e.idEditorial = a.idEditorial
											  INNER JOIN Profesor pr ON pr.idProfesor = a.idProfesor
											  INNER JOIN TipoApunte ta ON ta.idTipoApunte = a.idTipoApunte
                                WHERE a.idTipoApunte LIKE @idTipoApu AND a.nombreApunte LIKE @nomApu AND u.idUniversidad LIKE @idUni 
									 AND f.idFacultad LIKE @idFacu AND c.idCarrera LIKE @idCar AND a.baja=0";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"idTipoApu", idTipoApunte + '%');
            cmd.Parameters.AddWithValue(@"nomApu", nombreApunte + '%');
            cmd.Parameters.AddWithValue(@"idUni", idUniversidad + '%');
            cmd.Parameters.AddWithValue(@"idFacu", idFacultad + '%');
            cmd.Parameters.AddWithValue(@"idCar", idCarrera + '%');
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ApunteEntidadQuery apu = new ApunteEntidadQuery();
                apu.idApunte = int.Parse(dr["idApunte"].ToString());
                apu.anoApunte = int.Parse(dr["anoApunte"].ToString());
                apu.cantHoja = int.Parse(dr["cantHoja"].ToString());
                apu.codigoBarraApunte = dr["codigoBarraApunte"].ToString();
                apu.descripcionApunte = dr["descripcionApunte"].ToString();
                apu.nombreUniversidad = dr["nombreUniversidad"].ToString();
                apu.nombreFacultad = dr["nombreFacultad"].ToString();
                apu.listaCarreras = ConsultarCarrerasXApunte(apu.idApunte);
                apu.nombreMateria = (string)dr["nombreMateria"];
                apu.nombreApunte = dr["nombreApunte"].ToString();
                if (dr["stock"] != DBNull.Value)
                    apu.stock = int.Parse(dr["stock"].ToString());
                apu.precioApunte = float.Parse(dr["precioApunte"].ToString());
                apu.nombreEditorial = dr["nombreEditorial"].ToString();
                apu.nombreProfesor = dr["nombreProfesor"].ToString();
                apu.apellidoProfesor = dr["apellidoProfesor"].ToString();
                apu.nombreTipoApunte = dr["nombreTipoApunte"].ToString();
                lista.Add(apu);
            }
            dr.Close();
            cmd.Connection.Close();
            return lista;
        }

        public static string ConsultarRutaPortada(int id)
        {
            ApunteEntidad apu = new ApunteEntidad();
            string consulta = @"SELECT idApunte, imagenApunte 
                                FROM Apunte WHERE idApunte = @id";
            SqlCommand cmd = new SqlCommand(consulta, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                apu.idApunte = int.Parse(dr["idApunte"].ToString());
                if (dr["stock"] != DBNull.Value)
                    apu.stock = int.Parse(dr["stock"].ToString());
                apu.imagenApunte = dr["imagenApunte"].ToString();
            }
            dr.Close();
            cmd.Connection.Close();
            return apu.imagenApunte;
        }
    }
}
