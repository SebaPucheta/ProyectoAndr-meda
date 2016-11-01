using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Del form
using BaseDeDatos;
using System.Data;
using Entidades;
using Negocio;

namespace ProyectoAndrómeda
{
    public partial class Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id;
            if (Request.QueryString.Count > 0)
            {
                if (int.Parse(Request.QueryString["idApunte"]) != 0)
                {
                    id = int.Parse(Request.QueryString["idApunte"]);
                    cargarApunte(id);
                }
                if (int.Parse(Request.QueryString["idLibro"]) != 0)
                {
                    id = int.Parse(Request.QueryString["idLibro"]);
                    cargarLibro(id);
                }
            }
            //Entrar a "Carrito" pero no desde el catálogo
            cargarGrilla();
        }

        protected void cargarApunte(int id)
        {
            ApunteEntidad apunte = new ApunteEntidad();
            apunte = ApunteDao.ConsultarApunte(id);
            List<ProductoCarrito> lista = (List<ProductoCarrito>)Session["carrito"];
            ProductoCarrito nuevoProducto = new ProductoCarrito();
            nuevoProducto.idProductoCarrito = lista.Count + 1;
            nuevoProducto.item = apunte;
            nuevoProducto.idTipoItem = 1;
            nuevoProducto.cantidad = 1;
            lista.Add(nuevoProducto);
            Session["carrito"] = lista;
            cargarGrilla();
        }

        protected void cargarLibro(int id)
        {
            LibroEntidad libro = new LibroEntidad();
            libro = LibroDao.ConsultarLibro(id);
            List<ProductoCarrito> lista = (List<ProductoCarrito>)Session["carrito"];
            ProductoCarrito nuevoProducto = new ProductoCarrito();
            nuevoProducto.item = libro;
            nuevoProducto.idTipoItem = 2;
            nuevoProducto.cantidad = 1;
            ((List<ProductoCarrito>)Session["carrito"]).Add(nuevoProducto);
            cargarGrilla();
        }

        //[0] img
        //[1] idProducto
        //[2] nombreProducto
        //[3] tipoProducto
        //[4] precioUnitario
        //[5] cantidad
        //[6] subtotal

        protected void cargarGrilla()
        {
            List<ProductoCarrito> lista = (List<ProductoCarrito>)Session["carrito"];
            DataTable tabla = new DataTable();
            DataRow fila;

            //Creo las columnas de la tabla
            tabla.Columns.Add("idProductoCarrito", typeof(int));
            tabla.Columns.Add("idProducto", typeof(int));
            tabla.Columns.Add("nombreProducto", typeof(string));
            tabla.Columns.Add("tipoProducto", typeof(string));
            tabla.Columns.Add("precioUnitario", typeof(string));
            tabla.Columns.Add("cantidad", typeof(string));
            tabla.Columns.Add("subtotal", typeof(string));
            tabla.Columns.Add("img", typeof(string));

            foreach (ProductoCarrito dato in lista)
            {
                if (dato.idTipoItem == 1)
                {
                    fila = tabla.NewRow();

                    ApunteEntidad apunte = new ApunteEntidad();
                    apunte = (ApunteEntidad)dato.item;
                    fila[0] = dato.idProductoCarrito;
                    fila[1] = apunte.idApunte;
                    fila[2] = apunte.nombreApunte;
                    fila[3] = dato.idTipoItem;
                    fila[4] = apunte.precioApunte;
                    fila[5] = dato.cantidad;
                    fila[6] = dato.subtotal;
                    //fila[7] = imagen;
                    tabla.Rows.Add(fila);
                }

                if (dato.idTipoItem == 2)
                {
                    fila = tabla.NewRow();

                    LibroEntidad libro = new LibroEntidad();
                    libro = (LibroEntidad)dato.item;
                    fila[0] = dato.idProductoCarrito;
                    fila[1] = libro.idLibro;
                    fila[2] = libro.nombreLibro;
                    fila[3] = dato.idTipoItem;
                    fila[4] = libro.precioLibro;
                    fila[5] = dato.cantidad;
                    fila[6] = dato.subtotal;
                    //fila[7] = imagen;
                    tabla.Rows.Add(fila);
                }
            }

            DataView dataView = new DataView(tabla);

            dgv_carrito.DataKeyNames = new string[] { "idProductoCarrito" };
            dgv_carrito.DataSource = dataView;
            dgv_carrito.DataBind();
        }


    }


}
