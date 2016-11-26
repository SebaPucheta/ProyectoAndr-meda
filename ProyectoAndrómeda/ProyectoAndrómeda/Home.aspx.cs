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
    public partial class Home : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void CargarNuevosItem(List<ItemEntidad> listaItem)
        {
            for(int i=1;i<4;i++)
            {
                string nombreLblNombre = "lbl_nombreItemNuevo" + i;
                Label lblNombre = Controls.OfType<Label>().FirstOrDefault(x => x.ID == nombreLblNombre);
                string nombreLblPrecio = "lbl_precioItemNuevo" + i;
                Label lblPrecio = Controls.OfType<Label>().FirstOrDefault(x => x.ID == nombreLblPrecio);
                if ( listaItem[i-1] is ApunteEntidad)
                {
                    CargarApunteNuevo((ApunteEntidad)listaItem[i - 1], lblNombre, lblPrecio);
                }
                else
                {
                    CargarLibroNuevo((LibroEntidad)listaItem[i - 1], lblNombre, lblPrecio);
                }
            }
        }


        protected void CargarApunteNuevo(ApunteEntidad apunte, Label lblNombre, Label lblPrecio)
        {
            lblNombre.Text = apunte.nombreApunte;
            lblPrecio.Text = "Precio: $" + apunte.precioApunte.ToString();
        }
        protected void CargarLibroNuevo(LibroEntidad libro, Label lblNombre, Label lblPrecio)
        {
            lblNombre.Text = libro.nombreLibro;
            lblPrecio.Text = "Precio: $" + libro.precioLibro.ToString();
        }
    }
}