using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace BaseDeDatos
{
    public class UsuarioDao : Conexion
    {
        /// <summary>
        /// Registrar Usuario y Cliente
        /// </summary>
        /// <param name=""></param>
        public static void RegistrarUsuario(UsuarioEntidad user, ClienteEntidad cli)
        {
            SqlConnection cn = obtenerBD();
            SqlTransaction trans = cn.BeginTransaction();
            try
            {
                string consulta = @"INSERT INTO Cliente (nombreCliente, apellidoCliente, nroDni, idTipoDNI, email) VALUES (@nom, @ape, @dni, @tipoDni, @email); SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(consulta, cn, trans);
                cmd.Parameters.AddWithValue(@"nom", cli.nombreCliente);
                cmd.Parameters.AddWithValue(@"ape", cli.apellidoCliente);
                cmd.Parameters.AddWithValue(@"dni", cli.nroDni);
                cmd.Parameters.AddWithValue(@"tipoDni", cli.idTipoDNI);
                cmd.Parameters.AddWithValue(@"email", cli.email);
                cli.idCliente = Convert.ToInt32(cmd.ExecuteScalar());

                consulta = @"INSERT INTO Usuario (nombreUsuario, contrasena, idCliente) VALUES (@usuario, @pass, @idCli)";
                cmd = new SqlCommand(consulta, cn, trans);
                cmd.Parameters.AddWithValue("@usuario", user.nombreUsuario);
                cmd.Parameters.AddWithValue("@pass", user.contrasena);
                cmd.Parameters.AddWithValue("@idCli", cli.idCliente);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                trans.Rollback();
                cn.Close();
            }
            trans.Commit();
            cn.Close();
        }

        /// <summary>
        /// Registrar Cliente
        /// </summary>
        /// <param name=""></param>
        public static void RegistrarUsuarioCliente(UsuarioEntidad user, ClienteEntidad cli)
        {
            SqlConnection cn = obtenerBD();
            SqlTransaction trans = cn.BeginTransaction();
            try
            {
                string consulta = @"INSERT INTO Cliente (nombreCliente, apellidoCliente, nroDni, idTipoDni, email) VALUES (@nom, @ape, @nro, @idTipo, @email); SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(consulta, cn, trans);
                cmd.Parameters.AddWithValue(@"nom", cli.nombreCliente);
                cmd.Parameters.AddWithValue(@"ape", cli.apellidoCliente);
                cmd.Parameters.AddWithValue(@"email", cli.email);
                cmd.Parameters.AddWithValue(@"nro", cli.nroDni);
                cmd.Parameters.AddWithValue(@"idTipo", 1);
                cli.idCliente = Convert.ToInt32(cmd.ExecuteScalar());

                consulta = @"INSERT INTO Usuario (nombreUsuario, contrasena, idCliente, idRol) VALUES (@usuario, @pass, @idCli, @idRol)";
                SqlCommand cmd2 = new SqlCommand(consulta, cn, trans);
                cmd2.Parameters.AddWithValue("@usuario", cli.email);
                cmd2.Parameters.AddWithValue("@pass", user.contrasena);
                cmd2.Parameters.AddWithValue("@idCli", cli.idCliente);
                cmd2.Parameters.AddWithValue("@idRol", user.idRol);
                cmd2.ExecuteNonQuery();
            }
            catch
            {
                trans.Rollback();
                cn.Close();
            }
            trans.Commit();
            cn.Close();
        }

        public static void CambiarContraseña(UsuarioEntidad user, string nuevaPass)
        {
            string query = "UPDATE Usuario SET contrasena = @pass WHERE nombreUsuario = @user";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"pass", user.nombreUsuario);
            cmd.Parameters.AddWithValue(@"pass", nuevaPass);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        /// <summary>
        /// FALSO = no existe, TRUE = ya existe
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <returns></returns>
        public static bool VerificarUsuarioYEmailExistente(string nombreUsuario, string email)
        {
            string query = "SELECT COUNT(*) FROM Usuario WHERE nombreUsuario = @nom AND email = @em";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"nom", nombreUsuario);
            cmd.Parameters.AddWithValue(@"em", email);
            if (int.Parse(cmd.ExecuteScalar().ToString()) == 0)
            {
                cmd.Connection.Close();
                return false;
            }
            else
            {
                cmd.Connection.Close();
                return true;
            }
        }

        /// <summary>
        /// Consulta los datos de un usuario y completa con los del cliente
        /// </summary> By Gumer 
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public static UsuarioEntidadQuery ConsultarUnUsuario(int idUsuario)
        {
            UsuarioEntidadQuery usu = new UsuarioEntidadQuery();

            string query = @"SELECT u.idUsuario, u.nombreUsuario, u.contrasena, r.nombreRol, c.nombreCliente, c.apellidoCliente, c.nroDni, t.nombreTipoDNI, c.email
                             FROM Usuario u INNER JOIN Rol r ON u.idRol = r.idRol
                                            INNER JOIN Cliente c ON u.idCLiente = c.idCliente
                                            LEFT JOIN TipoDNI t ON c.idTipoDNI = t.idTipoDNI
                             WHERE u.idusuario = @idUsuario";

            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"idUsuario", idUsuario);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                usu.idUsuario = int.Parse(dr["idUsuario"].ToString());
                usu.nombreUsuario = dr["nombreUsuario"].ToString();
                usu.contrasena = dr["contrasena"].ToString();
                usu.nombreRol = dr["nombreRol"].ToString();
                ClienteEntidadQuery cliente = new ClienteEntidadQuery();
                cliente.nombreCliente = dr["nombreCliente"].ToString();
                cliente.apellidoCliente = dr["apellidoCliente"].ToString();
                cliente.email = dr["email"].ToString();
                usu.clienteQuery = cliente;
            }
            dr.Close();
            cmd.Connection.Close();
            return usu;
        }


        public static int ConsultarIdUsuario(string nombre)
        {
            int id = 0;
            string query = @"SELECT idUsuario FROM Usuario WHERE nombreUsuario = @nombre";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"nombre", nombre);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                id = int.Parse(dr["idUsuario"].ToString());
            }
            dr.Close();
            cmd.Connection.Close();
            return id;
        }

        public static UsuarioEntidadQuery ConsultarUnUsuarioPorNick(string nombreUsuario)
        {
            UsuarioEntidadQuery usu = new UsuarioEntidadQuery();

            string query = @"SELECT u.idUsuario, u.nombreUsuario, u.contrasena, r.nombreRol, c.nombreCliente, c.apellidoCliente, c.nroDni, t.nombreTipoDNI, c.email
                             FROM Usuario u INNER JOIN Rol r ON u.idRol = r.idRol
                                            INNER JOIN Cliente c ON u.idCLiente = c.idCliente
                                            INNER JOIN TipoDNI t ON c.idTipoDNI = t.idTipoDNI
                             WHERE u.nombreUsuario = @nombreUsuario";

            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"nombreUsuario", nombreUsuario);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                usu.idUsuario = int.Parse(dr["idUsuario"].ToString());
                usu.nombreUsuario = dr["nombreUsuario"].ToString();
                usu.contrasena = dr["contrasena"].ToString();
                usu.nombreRol = dr["nombreRol"].ToString();
                ClienteEntidadQuery cliente = new ClienteEntidadQuery();
                cliente.nombreCliente = dr["nombreCliente"].ToString();
                cliente.apellidoCliente = dr["apellidoCliente"].ToString();
                cliente.nroDni = int.Parse(dr["nroDni"].ToString());
                cliente.nombreTipoDNI = dr["nombreTipoDNI"].ToString();
                cliente.email = dr["email"].ToString();
                usu.clienteQuery = cliente;
            }
            dr.Close();
            cmd.Connection.Close();
            return usu;
        }

        public static ClienteEntidadQuery ConsultarUnClienteQuery(int idCliente)
        {
            ClienteEntidadQuery cli = new ClienteEntidadQuery();
            string query = @"SELECT c.idCliente, c.nombreCliente, c.apellidoCliente, c.nroDni, t.idTipoDNI
                             FROM Cliente c INNER JOIN TipoDNI t ON t.idTipoDNI = c.idTipoDNI
                             WHERE c.idCliente = @idCliente";

            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"idCliente", idCliente);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cli.idCliente = int.Parse(dr["idCliente"].ToString());
                cli.nombreCliente = dr["nombreCliente"].ToString();
                cli.apellidoCliente = dr["idCliente"].ToString();
                cli.nroDni = int.Parse(dr["nroDni"].ToString());
                cli.idTipoDNI = int.Parse(dr["idTipoDNI"].ToString());

            }
            dr.Close();
            cmd.Connection.Close();
            return cli;
        }



        //FALTO CERRAR CONEXION

        //public static int IniciarSesion(string email, string pass)
        //{
        //    int idUsuario = 0;
        //    string query = @"SELECT u.idUsuario
        //                     FROM Usuario u 
        //                     WHERE u.nombreUsuario =  @email and u.contrasena = @pass";

        //    SqlCommand cmd = new SqlCommand(query, obtenerBD());
        //    cmd.Parameters.AddWithValue(@"email", email);
        //    cmd.Parameters.AddWithValue(@"pass", pass);
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        idUsuario = int.Parse(dr["idUsuario"].ToString());
        //    }
        //    return idUsuario;
        //}

        public static string ConsultarNombreYApellidoUsuario(string nombreUsuario)
        {
            string cliente = "";

            string query = @"SELECT c.nombreCliente, c.apellidoCliente
                             FROM Usuario u INNER JOIN Cliente c ON u.idCliente = c.idCliente
                             WHERE u.nombreUsuario = @nombreUsuario";

            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"nombreUsuario", nombreUsuario);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cliente = dr["nombreCliente"].ToString() + " " + dr["apellidoCliente"].ToString();
            }

            dr.Close();
            cmd.Connection.Close();
            return cliente;
        }



    }
}
