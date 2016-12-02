using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BaseDeDatos;
using Entidades;

using System.Data;

namespace ProyectoAndrómeda
{
    public partial class Comprobante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id;
                if (Request.QueryString.Count > 0)
                {
                    id = int.Parse(Request.QueryString["id"]);
                    cargarFactura(id);
                    cargarDetalleFactura(id);
                    cargarFecha();
                    cargarCódigoBarra(id);
                    cargarInfoDeUsuario();
                    calcularTotal();
                }
                //Entrar al comprobante pero no desde el panel de usuario
            }
        }

        protected void cargarFactura(int id)
        {
            int idUsuario = UsuarioDao.ConsultarIdUsuario(HttpContext.Current.User.Identity.Name);
            List<FacturaEntidadQuery> lista = new List<FacturaEntidadQuery>();
            lista.Add(FacturaDao.ConsultarUnaFactura(id));
            dgv_factura.DataSource = lista;
            dgv_factura.DataKeyNames = new string[] { "idFactura" };
            dgv_factura.DataBind();
        }

        protected void cargarDetalleFactura(int idFactura)
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
                        row.FindControl("img_digital").Visible = true;
                }

            }

        }

        protected void cargarFecha()
        {
            lbl_fechaImpresion.Text = DateTime.Today.ToLongDateString();
        }

        protected void cargarCódigoBarra(int id)
        {
            string numeroFactura = id.ToString();
            string url1 = @"http://barcode.tec-it.com/barcode.ashx?translate-esc=off&data=";
            string url2 = @"&code=Code128&unit=Fit&dpi=96&imagetype=Gif&rotation=0&color=000000&bgcolor=FFFFFF&qunit=Mm&quiet=0";
            string urlTotal = url1 + numeroFactura + url2;

            img_codigoBarra.ImageUrl = urlTotal;
        }

        protected void cargarInfoDeUsuario()
        {
            string user = HttpContext.Current.User.Identity.Name;
            lbl_nombreUsuario.Text = user;
            UsuarioEntidadQuery usuario = UsuarioDao.ConsultarUnUsuarioPorNick(user);
            lbl_nombreApellido.Text = UsuarioDao.ConsultarNombreYApellidoUsuario(user);
        }

        protected void calcularTotal()
        {
            float sumador = 0;
            foreach (GridViewRow row in dgv_detalle.Rows)
                sumador = sumador + float.Parse(row.Cells[4].Text.Replace("$", ""));
            lbl_total.Text = lbl_total.Text + sumador.ToString();
        }

    }
}