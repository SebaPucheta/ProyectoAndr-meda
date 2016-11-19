using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Entidades;
using BaseDeDatos;

using System.Data;

namespace ProyectoAndrómeda
{
    public partial class PanelUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cargarGrillaFactura()
        {
            int idUsuario = UsuarioDao.ConsultarIdUsuario(HttpContext.Current.User.Identity.Name);
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
            tabla.Columns.Add("precioUnitario", typeof(float));
            tabla.Columns.Add("cantidad", typeof(int));
            tabla.Columns.Add("subtotal", typeof(float));


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
                    fila[3] = apunte.precioApunte;
                    fila[4] = dato.cantidad;
                    fila[5] = dato.subtotal;

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
                    fila[3] = libro.precioLibro;
                    fila[4] = dato.cantidad;
                    fila[5] = dato.subtotal;

                    tabla.Rows.Add(fila);
                }
            }

            DataView dataView = new DataView(tabla);

            dgv_detalle.DataKeyNames = new string[] { "idProductoCarrito" };
            dgv_detalle.DataSource = dataView;
            dgv_detalle.DataBind();
        }


        //<!--informacion de usuario-->
        //               <!--usuario-->
        //               <!--nombre-->
        //               <!--apellido-->
        //               <!--email-->
        //               <!--dni-->

        protected void ocultarInformacionDeUsuario()
        {
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
    }
}