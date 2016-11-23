using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Datos
using Entidades;
using BaseDeDatos;
//Manejo de grillas
using System.Data;
//Descarga apuntes
using System.IO;

using System.Web.UI.WebControls;

namespace ProyectoAndrómeda
{
    public partial class PanelUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cargarGrillaFactura()
        {
            int idUsuario = int.Parse(Session["idUsuario"].ToString());
            dgv_factura.DataSource = FacturaDao.ConsultarFacturasQueryXUsuario(idUsuario);
            dgv_factura.DataKeyNames = new string[] { "idFactura" };
            dgv_factura.DataBind();
        }



        protected void cargarGrillaDetalleFactura(int idFactura)
        {
            List<ProductoCarritoQuery> lista = FacturaDao.ConsultarDetalleDeFactura(idFactura);

            DataTable tabla = new DataTable();
            DataRow fila;

            //Creo las columnas de la tabla
            tabla.Columns.Add("idProductoCarrito", typeof(int));
            tabla.Columns.Add("nombreItem", typeof(string));
            tabla.Columns.Add("tipoItem", typeof(string));
            tabla.Columns.Add("cantidad", typeof(int));
            tabla.Columns.Add("subtotal", typeof(float));
            tabla.Columns.Add("idItem", typeof(int));


            foreach (ProductoCarrito dato in lista)
            {
                if (dato.tipoItem == "Apunte")
                {
                    fila = tabla.NewRow();

                    ApunteEntidad apunte = new ApunteEntidad();
                    apunte = (ApunteEntidad)dato.item;
                    fila[0] = dato.idProductoCarrito;
                    fila[1] = apunte.nombreApunte;
                    fila[2] = dato.tipoItem;
                    fila[3] = dato.cantidad;
                    fila[4] = dato.subtotal;
                    fila[5] = apunte.idApunte;

                    tabla.Rows.Add(fila);
                }

                if (dato.tipoItem == "Libro")
                {
                    fila = tabla.NewRow();

                    LibroEntidad libro = new LibroEntidad();
                    libro = (LibroEntidad)dato.item;
                    fila[0] = dato.idProductoCarrito;
                    fila[1] = libro.nombreLibro;
                    fila[2] = dato.tipoItem;
                    fila[3] = dato.cantidad;
                    fila[4] = dato.subtotal;
                    fila[5] = libro.idLibro;

                    tabla.Rows.Add(fila);
                }
            }

            DataView dataView = new DataView(tabla);

            dgv_detalle.DataKeyNames = new string[] { "idProductoCarrito" };
            dgv_detalle.DataSource = dataView;
            dgv_detalle.DataBind();

            foreach (GridViewRow row in dgv_detalle.Rows)
            {
                if (row.Cells[2].Text == "Apunte")
                {
                    if (ApunteDao.ConsultarTipoApunte(int.Parse(row.Cells[5].Text)) == "Digital")
                        row.FindControl("btn_descargar").Visible = true;
                }

            }

        }


        //PANEL USUARIO

        protected void ocultarInformacionDeUsuario()
        {
            lbl_misdatos.Visible = false;
            lbl_nombre.Visible = false;
            txt_nombre.Visible = false;
            lbl_apellido.Visible = false;
            txt_apellido.Visible = false;
            lbl_usuario.Visible = false;
            txt_usuario.Visible = false;
            lbl_email.Visible = false;
            txt_email.Visible = false;
            lbl_dni.Visible = false;
            txt_dni.Visible = false;
        }

        protected void mostrarInformaciónDeUsuario()
        {
            lbl_misdatos.Visible = true;
            lbl_nombre.Visible = true;
            txt_nombre.Visible = true;
            lbl_apellido.Visible = true;
            txt_apellido.Visible = true;
            lbl_usuario.Visible = true;
            txt_usuario.Visible = true;
            lbl_email.Visible = true;
            txt_email.Visible = true;
            lbl_dni.Visible = true;
            txt_dni.Visible = true;

            hdetalle.Visible = false;
            hfactura.Visible = false;
            dgv_detalle.Visible = false;
            dgv_factura.Visible = false;
        }

        private void DescargarArchivo(int idApunte)
        {
            string filename = @"C:\Juan\Facultad\Habilitacion Profesional\GitHub - Andromeda\ProyectoAndromeda\ProyectoAndrómeda\ProyectoAndrómeda\archivos\" + idApunte + ".pdf"; ;
            FileInfo fileInfo = new FileInfo(filename);

            if (fileInfo.Exists)
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + fileInfo.Name);
                Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.Flush();
                Response.TransmitFile(fileInfo.FullName);
                Response.End();
            }
        }



        ///////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////EVENTOS//////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////

        //Boton panel "Mis pedidos"
        protected void btn_pedidos_Click(object sender, EventArgs e)
        {
            cargarGrillaFactura();
            hfactura.Visible = true;
            ocultarInformacionDeUsuario();
        }

        protected void btn_consultarFactura_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarGrillaDetalleFactura((int)dgv_factura.SelectedDataKey.Value);
            hdetalle.Visible = true;
        }

        //Boton panel "Mis datos"
        protected void brn_datos_Click(object sender, EventArgs e)
        {
            mostrarInformaciónDeUsuario();
        }

        //Botones de la grilla de detalle
        protected void dgv_detalle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "select":
                    foreach (GridViewRow fila in dgv_detalle.Rows)
                    {
                        if (fila.Cells[2].Text.Equals("Apunte"))
                        {
                            //APUNTE
                            string direccion = "DetalleItem.aspx?idLibro=0&idApunte=" + fila.Cells[5].Text.ToString();
                            Response.Redirect(direccion);
                            break;
                        }
                        else
                        {
                            //LIBRO
                            string direccion = "DetalleItem.aspx?idApunte=0&idLibro=" + fila.Cells[5].Text.ToString();
                            Response.Redirect(direccion);
                            break;
                        }
                    }
                    break;

                case "download":

                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = dgv_detalle.Rows[index];

                    DescargarArchivo(int.Parse(row.Cells[5].Text));
                    break;

            }
        }




    }
}