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
            if (!IsPostBack)
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

                //Cargar el total del carrito
                calcularTotal();

            }

        }

        protected void cargarApunte(int id)
        {
            ApunteEntidad apunte = new ApunteEntidad();
            apunte = ApunteDao.ConsultarApunte(id);
            List<ProductoCarrito> lista = (List<ProductoCarrito>)Session["carrito"];

            //Verifico cada producto del carrito para no agregar el mismo dos veces
            foreach (ProductoCarrito dato in lista)
            {
                //Como aca es solo cargar apunte, verifico de apuntes solo
                if (dato.tipoItem == "Apunte")
                {
                    //Creo el objeto Apunte de la lista para verificar y lo comparo con el que cree afuera
                    ApunteEntidad apunteVerificacion = new ApunteEntidad();
                    apunteVerificacion = (ApunteEntidad)dato.item;

                    //Si son iguales, salgo del metodo
                    if (apunte.idApunte == apunteVerificacion.idApunte)
                    {
                        return;
                    }
                }
            }

            //Paso la verificación, no hay nada igual
            ProductoCarrito nuevoProducto = new ProductoCarrito();
            nuevoProducto.idProductoCarrito = lista.Count + 1;
            nuevoProducto.item = apunte;
            nuevoProducto.tipoItem = "Apunte";
            nuevoProducto.cantidad = 1;
            nuevoProducto.subtotal = nuevoProducto.cantidad * apunte.precioApunte;
            lista.Add(nuevoProducto);
            Session["carrito"] = lista;
            cargarGrilla();

        }

        protected void cargarLibro(int id)
        {
            LibroEntidad libro = new LibroEntidad();
            libro = LibroDao.ConsultarLibro(id);
            List<ProductoCarrito> lista = (List<ProductoCarrito>)Session["carrito"];

            //Verifico cada producto del carrito para no agregar el mismo dos veces
            foreach (ProductoCarrito dato in lista)
            {
                //Como aca es solo cargar libros, verifico libros solo
                if (dato.tipoItem == "Libro")
                {
                    //Creo el objeto Apunte de la lista para verificar y lo comparo con el que cree afuera
                    LibroEntidad libroVerificacion = new LibroEntidad();
                    libroVerificacion = (LibroEntidad)dato.item;

                    //Si son iguales, salgo del metodo
                    if (libro.idLibro == libroVerificacion.idLibro)
                    {
                        return;
                    }
                }
            }

            //Paso la verificación, no hay nada igual
            ProductoCarrito nuevoProducto = new ProductoCarrito();
            nuevoProducto.idProductoCarrito = lista.Count + 1;
            nuevoProducto.item = libro;
            nuevoProducto.tipoItem = "Libro";
            nuevoProducto.cantidad = 1;
            nuevoProducto.subtotal = nuevoProducto.cantidad * libro.precioLibro;
            lista.Add(nuevoProducto);
            Session["carrito"] = lista;
            cargarGrilla();
        }

        //[0] img
        //[1] idProductoCarrito
        //[2] idProducto
        //[3] nombreProducto
        //[4] tipoProducto
        //[5] precioUnitario
        //[6] cantidad
        //[..] nuevaCantindad
        //[7] subtotal

        protected void cargarGrilla()
        {
            List<ProductoCarrito> lista = (List<ProductoCarrito>)Session["carrito"];
            DataTable tabla = new DataTable();
            DataRow fila;

            //Creo las columnas de la tabla
            tabla.Columns.Add("img", typeof(string));
            tabla.Columns.Add("idProductoCarrito", typeof(int));
            tabla.Columns.Add("idProducto", typeof(int));
            tabla.Columns.Add("nombreProducto", typeof(string));
            tabla.Columns.Add("tipoProducto", typeof(string));
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
                    //fila[0] = "~/imagenes/PortadaApunte.png";
                    fila[1] = dato.idProductoCarrito;
                    fila[2] = apunte.idApunte;
                    fila[3] = apunte.nombreApunte;
                    fila[4] = dato.tipoItem;
                    fila[5] = apunte.precioApunte;
                    fila[6] = dato.cantidad;
                    fila[7] = dato.subtotal;

                    tabla.Rows.Add(fila);
                }

                if (dato.tipoItem == "Libro")
                {
                    fila = tabla.NewRow();

                    LibroEntidad libro = new LibroEntidad();
                    libro = (LibroEntidad)dato.item;
                    //fila[0] = "~/imagenes/PortadaApunte.png";
                    fila[1] = dato.idProductoCarrito;
                    fila[2] = libro.idLibro;
                    fila[3] = libro.nombreLibro;
                    fila[4] = dato.tipoItem;
                    fila[5] = libro.precioLibro;
                    fila[6] = dato.cantidad;
                    fila[7] = dato.subtotal;

                    tabla.Rows.Add(fila);
                }
            }

            DataView dataView = new DataView(tabla);

            dgv_carrito.DataKeyNames = new string[] { "idProductoCarrito" };
            dgv_carrito.DataSource = dataView;
            dgv_carrito.DataBind();
        }


        protected void calcularTotal()
        {
            float acumulador = 0;
            List<ProductoCarrito> lista = (List<ProductoCarrito>)Session["carrito"];
            foreach (ProductoCarrito dato in lista)
            {
                acumulador = acumulador + dato.subtotal;
            }
            lbl_total.Text = acumulador.ToString("0.00");
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////EVENTOS////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////

        protected void btn_actualizar_Click(object sender, EventArgs e)
        {
            List<ProductoCarrito> lista = (List<ProductoCarrito>)Session["carrito"];
            foreach (GridViewRow row in dgv_carrito.Rows)
            {
                //Veo si tiene el txtbox le pusieron una cantidad sino salteo al otro item
                if (((TextBox)row.Cells[7].FindControl("txt_cantidad")).Text == "")
                    continue;

                //Si le ingresaron una nueva cantidad, procedo
                int nuevaCantidad = int.Parse(((TextBox)row.Cells[7].FindControl("txt_cantidad")).Text);
                int idActual = int.Parse(dgv_carrito.DataKeys[row.RowIndex].Value.ToString());

                foreach (ProductoCarrito dato in lista)
                {
                    if (dato.idProductoCarrito == idActual)
                    {
                        if (dato.tipoItem == "Apunte")
                        {
                            ApunteEntidad apunte = new ApunteEntidad();
                            apunte = (ApunteEntidad)dato.item;
                            dato.cantidad = nuevaCantidad;
                            dato.subtotal = dato.cantidad * apunte.precioApunte;
                        }

                        if(dato.tipoItem == "Libro")
                        {
                            LibroEntidad libro = new LibroEntidad();
                            libro = (LibroEntidad)dato.item;
                            dato.cantidad = nuevaCantidad;
                            dato.subtotal = dato.cantidad * libro.precioLibro;
                        }
                    }
                }
            }
            cargarGrilla();
            calcularTotal();
        }


        protected void dgv_carrito_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ((List<ProductoCarrito>)Session["carrito"]).RemoveAt(e.RowIndex);
            cargarGrilla();
        }


        protected void dgv_carrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProducto = (int)dgv_carrito.SelectedDataKey.Value;
            int indice = (int)dgv_carrito.SelectedIndex;
            string tipo = dgv_carrito.Rows[indice].Cells[4].Text;

            List<ProductoCarrito> lista = ((List<ProductoCarrito>)Session["carrito"]);
            foreach (ProductoCarrito dato in lista)
            {
                if(idProducto == dato.idProductoCarrito)
                {
                    if (tipo == "Apunte")
                    {
                        ApunteEntidad apunte = new ApunteEntidad();
                        apunte = (ApunteEntidad)dato.item;
                        int id = apunte.idApunte;
                        string dir = "DetalleItem.aspx?idLibro=0&idApunte=" + id.ToString();
                        Response.Redirect(dir);
                        break;
                    }

                    if(tipo == "Libro")
                    {
                        LibroEntidad libro = new LibroEntidad();
                        libro = (LibroEntidad)dato.item;
                        int id = libro.idLibro;
                        string dir = "DetalleItem.aspx?idApunte=0&idLibro=" + id.ToString();
                        Response.Redirect(dir);
                        break;
                    }
                }
            }            
            
        }
    }


}
