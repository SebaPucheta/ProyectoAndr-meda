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
    public class FacturaDao : Conexion
    {
        public static int RegistrarFactura(FacturaEntidad factura)
        {
            SqlConnection cnn = obtenerBD();
            SqlTransaction trans = cnn.BeginTransaction();
            int idFactura = 0;
            try
            {

                string query1 = "INSERT INTO Factura(fecha, total, idUsuario, idEstadoPago) VALUES (@fecha, @total, @idUsuario, @idEstadoPago); select scope_identity()";
                SqlCommand cmd1 = new SqlCommand(query1, cnn, trans);
                cmd1.Parameters.AddWithValue(@"fecha", DateTime.Now);
                cmd1.Parameters.AddWithValue(@"total", factura.total);
                cmd1.Parameters.AddWithValue(@"idUsuario", factura.idUsuario);
                cmd1.Parameters.AddWithValue(@"idEstadoPago", factura.idEstadoPago);
                idFactura = int.Parse(cmd1.ExecuteScalar().ToString());

                foreach (ProductoCarrito detalleFactura in factura.listaProductoCarrito)
                {
                    string query2 = "INSERT INTO DetalleFactura (idItem, cantidad, subtotal, idFactura, idTipoItem) VALUES (@idItem, @cantidad, @subtotal, @idFactura, @idTipoItem)";
                    SqlCommand cmd2 = new SqlCommand(query2, cnn, trans);
                    cmd2.Parameters.AddWithValue(@"cantidad", detalleFactura.cantidad);
                    cmd2.Parameters.AddWithValue(@"subtotal", detalleFactura.subtotal);
                    cmd2.Parameters.AddWithValue(@"idFactura", idFactura);
                    if (detalleFactura.item is ApunteEntidad)//Apunte
                    {
                        cmd2.Parameters.AddWithValue(@"idTipoItem", 2);
                        cmd2.Parameters.AddWithValue(@"idItem", ((ApunteEntidad)(detalleFactura.item)).idApunte);
                        cmd2.ExecuteNonQuery();

                        //Restar la cantidad de stock al apunte SI ES IMPRESO
                        if (  ApunteDao.ConsultarTipoApunte( ((ApunteEntidad)(detalleFactura.item)).idApunte )  == "Impreso")
                        {
                            string query3 = "UPDATE Apunte SET stock = stock - @cantidad";
                            SqlCommand cmd3 = new SqlCommand(query3, cnn, trans);
                            cmd3.Parameters.AddWithValue(@"cantidad", detalleFactura.cantidad);
                            cmd3.ExecuteNonQuery();
                        }
                    }
                    else//Libro
                    {
                        cmd2.Parameters.AddWithValue(@"idTipoItem", 1);
                        cmd2.Parameters.AddWithValue(@"idItem", ((LibroEntidad)(detalleFactura.item)).idLibro);
                        cmd2.ExecuteNonQuery();
                        //Restar la cantidad de stock al libro
                        string query3 = "UPDATE Libro SET stock = stock - @cantidad";
                        SqlCommand cmd3 = new SqlCommand(query3, cnn, trans);
                        cmd3.Parameters.AddWithValue(@"cantidad", detalleFactura.cantidad);
                        cmd3.ExecuteNonQuery();
                    }

                }
                //--- Commit
                trans.Commit();
            }
            catch (Exception)
            {
                trans.Rollback();
            }
            finally { cnn.Close(); }
            return idFactura;
        }

        public static FacturaEntidadQuery ConsultarUnaFactura(int id)
        {
            string query = @"SELECT f.idFactura, f.fecha, f.total, f.idUsuario, c.nombreCliente, c.apellidoCliente, c.email
                             FROM Factura f INNER JOIN Usuario u ON f.idUsuario = u.idUsuario
                                            INNER JOIN Cliente c ON u.idCliente = c.idCliente
                             WHERE f.idFactura = @id";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", id);
            SqlDataReader dr = cmd.ExecuteReader();

            FacturaEntidadQuery factura = new FacturaEntidadQuery();

            while (dr.Read())
            {
                factura.idFactura = int.Parse(dr["idFactura"].ToString());
                factura.fecha = DateTime.Parse(dr["fecha"].ToString());
                factura.total = float.Parse(dr["total"].ToString());
                factura.idUsuario = int.Parse(dr["idUsuario"].ToString());
                factura.nombreCliente = dr["nombreCliente"].ToString();
                factura.apellidoCliente = dr["apellidoCliente"].ToString();
                factura.mailCliente = dr["email"].ToString();
            }

            dr.Close();
            cmd.Connection.Close();
            return factura;

        }


    }
}
