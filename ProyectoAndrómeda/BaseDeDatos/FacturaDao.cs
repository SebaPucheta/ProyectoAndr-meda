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
                //EN LA WEB EL ID USUARIO ES IDUSUARIOCLIENTE -- SON LOS CLIENTES
                string query1 = "INSERT INTO Factura(fecha, total, idUsuarioCliente, idEstadoPago, idFacturaMP, idTipoPago) VALUES (@fecha, @total, @idUsuarioCliente, @idEstadoPago, @idFacturaMP, @idTipoPago); select scope_identity()";
                SqlCommand cmd1 = new SqlCommand(query1, cnn, trans);
                cmd1.Parameters.AddWithValue(@"fecha", DateTime.Now);
                cmd1.Parameters.AddWithValue(@"total", factura.total);
                cmd1.Parameters.AddWithValue(@"idUsuarioCliente", factura.idUsuario);
                cmd1.Parameters.AddWithValue(@"idEstadoPago", 2); //Registro en pendiente | 1="Aprobado" | 2="Pendiente" | 3="Cancelado"
                cmd1.Parameters.AddWithValue(@"idFacturaMP", factura.idFacturaMP);
                cmd1.Parameters.AddWithValue(@"idTipoPago", 2); //1="Ventanilla" | 2="Web"
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
                        if (ApunteDao.ConsultarTipoApunte(((ApunteEntidad)(detalleFactura.item)).idApunte) == "Impreso")
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
            string query = @"SELECT f.idFactura, f.fecha, f.total, f.idUsuarioCliente, f.idEstadoPago, f.idFacturaMP, f.idEstadoPago, tp.descripcion, c.nombreCliente, c.apellidoCliente, c.email
                             FROM Factura f INNER JOIN Usuario u ON f.idUsuarioCliente = u.idUsuario
                                            INNER JOIN Cliente c ON u.idCliente = c.idCliente
                                            INNER JOIN TipoPago tp ON tp.idTipoPago = f.idTipoPago
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
                factura.idUsuario = int.Parse(dr["idUsuarioCliente"].ToString());
                factura.nombreCliente = dr["nombreCliente"].ToString();
                factura.apellidoCliente = dr["apellidoCliente"].ToString();
                factura.mailCliente = dr["email"].ToString();

                factura.idEstadoPago = int.Parse(dr["idEstadoPago"].ToString());
                factura.idFacturaMP = dr["idFacturaMP"].ToString();
                factura.nombreTipoPago = dr["descripcion"].ToString();
            }

            dr.Close();
            cmd.Connection.Close();
            return factura;

        }


        public static List<FacturaEntidadQuery> ConsultarFacturasQueryXUsuario(int id)
        {
            string query = @"SELECT f.idFactura, f.fecha, f.total, f.idUsuarioCliente, ep.descripcion, f.idFacturaMP, f.idTipoPago
                             FROM Factura f INNER JOIN EstadoPago ep ON (f.idEstadoPago = ep.idEstadoPago)
                             WHERE f.idUsuarioCliente = @id";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", id);
            SqlDataReader dr = cmd.ExecuteReader();

            List<FacturaEntidadQuery> lista = new List<FacturaEntidadQuery>();

            while (dr.Read())
            {
                FacturaEntidadQuery factura = new FacturaEntidadQuery();
                factura.idFactura = int.Parse(dr["idFactura"].ToString());
                factura.fecha = DateTime.Parse(dr["fecha"].ToString());
                factura.total = float.Parse(dr["total"].ToString());
                factura.idUsuario = int.Parse(dr["idUsuarioCliente"].ToString());
                factura.idTipoPago = int.Parse(dr["idTipoPago"].ToString());
                if (dr["descripcion"] != DBNull.Value)
                    factura.nombreEstadoPago = dr["descripcion"].ToString();
                if (dr["idFacturaMP"] != DBNull.Value)
                    factura.idFacturaMP = dr["idFacturaMP"].ToString();
                lista.Add(factura);
            }

            dr.Close();
            cmd.Connection.Close();
            return lista;
        }

        public static List<ProductoCarritoQuery> ConsultarDetalleDeFactura(int id)
        {
            string query = @"SELECT idDetalleFactura, idItem, cantidad, subtotal, idTipoItem
                             FROM DetalleFactura
                             WHERE idFactura = @id";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", id);
            SqlDataReader dr = cmd.ExecuteReader();

            List<ProductoCarritoQuery> lista = new List<ProductoCarritoQuery>();

            while (dr.Read())
            {
                ProductoCarritoQuery prod = new ProductoCarritoQuery();
                prod.idProductoCarrito = int.Parse(dr["idDetalleFactura"].ToString());
                int idProducto = int.Parse(dr["idItem"].ToString());
                prod.cantidad = int.Parse(dr["cantidad"].ToString());
                prod.subtotal = float.Parse(dr["subtotal"].ToString());
                //Consulto el Item

                if (int.Parse(dr["idTipoItem"].ToString()) == 2)
                {
                    //APUNTE
                    prod.item = ApunteDao.ConsultarApunte(idProducto);
                    prod.nombreItem = ((ApunteEntidad)prod.item).nombreApunte;
                    prod.tipoItem = "Apunte";
                }
                else
                {
                    //LIBRO
                    prod.item = LibroDao.ConsultarLibro(idProducto);
                    prod.nombreItem = ((LibroEntidad)prod.item).nombreLibro;
                    prod.tipoItem = "Libro";
                }

                lista.Add(prod);
            }

            dr.Close();
            cmd.Connection.Close();
            return lista;
        }

        public static bool FacturaPagada(int id)
        {
            string query = @"SELECT ep.descripcion
                             FROM Factura f INNER JOIN EstadoPago ep ON (f.idEstadoPago = ep.idEstadoPago)
                             WHERE idFactura = @id";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", id);

            bool resultado = false;

            //Verifico que no sea nulo
            var firstColumn = cmd.ExecuteScalar();
            if (firstColumn != null)
            {
                if (cmd.ExecuteScalar().ToString() == "Aprobado" || cmd.ExecuteScalar().ToString() == "Entregado")
                    resultado = true;
            }
            cmd.Connection.Close();
            return resultado;
        }

        //ESTE METODO ES PARA CAMBIAR EL ESTADO DE LA FACTURA A "APROBADO" CUANDO
        public static void CambiarEstadoFacturaAPagado(int id)
        {
            string query = @"UPDATE Factura SET idEstadoPago = @nuevoEstado
                             WHERE idFactura = @id";
            SqlCommand cmd = new SqlCommand(query, obtenerBD());
            cmd.Parameters.AddWithValue(@"id", id);
            cmd.Parameters.AddWithValue(@"nuevoEstado", 1); //1="Aprobado"

            cmd.ExecuteNonQuery();
           
            cmd.Connection.Close();
        }


    }
}
