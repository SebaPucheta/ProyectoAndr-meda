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
                CargarNuevos(ItemDao.DevolverUltimoIngresos());
                CargarBestSellers(ItemDao.DevolverMasVendidos());
            }
        }

        private void CargarNuevos(List<ItemEntidad> listaItem)
        {
            CargarItem(listaItem, "img_itemNuevo","lbl_idItemNuevo","lbl_tipoItemNuevo", "lbl_nombreItemNuevo", "lbl_descripcionItemNuevo", "lbl_precioItemNuevo");
        }

        private void CargarBestSellers(List<ItemEntidad> listaItem)
        {
            CargarItem(listaItem, "img_itemVendido", "lbl_idItemVendido", "lbl_tipoItemVendido", "lbl_nombreItemVendido", "lbl_descripcionItemVendido", "lbl_precioItemVendido");
        }

        protected void CargarItem(List<ItemEntidad> listaItem,string img,string nombreLblId,string nombreLblTipo, string nombreLblNombre, string nombreLblDescripcion, string nombreLblPrecio)
        {
            for(int i=0;i<listaItem.Count;i++)
            {
                Image aspImg = (Image)DevolverControlPorID(img + i.ToString());
                Label lblId = (Label)DevolverControlPorID(nombreLblId + i.ToString());
                Label lblTipo = (Label)DevolverControlPorID(nombreLblTipo + i.ToString());
                Label lblNombre = (Label)DevolverControlPorID(nombreLblNombre + i.ToString());
                Label lblDescripcion = (Label)DevolverControlPorID(nombreLblDescripcion + i.ToString());
                Label lblPrecio = (Label)DevolverControlPorID(nombreLblPrecio + i.ToString());
                
                if ( listaItem[i] is ApunteEntidad)
                {
                    CargarApunte((ApunteEntidad)listaItem[i],aspImg,lblId,lblTipo, lblNombre, lblDescripcion, lblPrecio);
                }
                else
                {
                    CargarLibro((LibroEntidad)listaItem[i], aspImg, lblId, lblTipo, lblNombre, lblDescripcion, lblPrecio);
                }
                if(i==2)
                { break; }
            }
        }

        protected void CargarApunte(ApunteEntidad apunte, Image img,Label lblId, Label lblTipo, Label lblNombre,Label lblDescripcion, Label lblPrecio)
        {
            if (apunte.imagenApunte.Equals(DBNull.Value) || apunte.imagenApunte.Trim().Equals(""))
            {
                img.ImageUrl = "~/imagenes/PortadaApunte.png";
            }
            else
            {
                img.ImageUrl = apunte.imagenApunte;
            }
            lblId.Text = apunte.idApunte.ToString();
            lblTipo.Text = "Apunte";
            lblNombre.Text = apunte.nombreApunte;
            lblDescripcion.Text = apunte.descripcionApunte;
            lblPrecio.Text = "Precio: AR$" + apunte.precioApunte.ToString();
        }

        protected void CargarLibro(LibroEntidad libro, Image img, Label lblId,Label lblTipo, Label lblNombre, Label lblDescripcion, Label lblPrecio)
        {
            if (libro.imagenLibro.Equals(DBNull.Value) || libro.imagenLibro.Trim().Equals(""))
            {
                img.ImageUrl = "~/imagenes/PortadaApunte.png";
            }
            else
            {
                img.ImageUrl = libro.imagenLibro;
            }
            lblId.Text = libro.idLibro.ToString();
            lblTipo.Text = "Libro";
            lblNombre.Text = libro.nombreLibro;
            lblDescripcion.Text = libro.descripcionLibro;
            lblPrecio.Text = "Precio: AR$" + libro.precioLibro.ToString();
        }

        //Metodos para buscar los label y los image
        private Control DevolverBody()
        {
            Control Body;
            foreach (Control c in Page.Controls)
            {
                foreach (Control childc in c.Controls)
                {
                    if (childc.GetType().ToString().Equals("System.Web.UI.HtmlControls.HtmlForm"))
                    {
                        foreach (Control chi in childc.Controls)
                        {
                            if (chi.GetType().ToString().Equals("System.Web.UI.WebControls.ContentPlaceHolder"))
                            { return Body = chi; }
                        }
                    }
                }
            }
            return null;
        }

        private Control DevolverControlPorID(string idControl)
        {
            string tipo;
            foreach (Control c in DevolverBody().Controls)
            {
                tipo = c.GetType().ToString();
                if (c.GetType().ToString().Equals("System.Web.UI.WebControls.ImageButton") || c.GetType().ToString().Equals("System.Web.UI.WebControls.Label"))
                {
                    if (c.ID.Equals(idControl))
                    {
                        return c;
                    }
                }
            }
            return null;
        }

        protected void btn_verItemPopular0_Click(object sender, EventArgs e)
        {
            Redirigir(int.Parse(lbl_idItemVendido0.Text), lbl_tipoItemVendido0.Text);
        }

        protected void btn_verItemPopular1_Click(object sender, EventArgs e)
        {
            Redirigir(int.Parse(lbl_idItemVendido1.Text), lbl_tipoItemVendido1.Text);
        }

        protected void btn_verItemPopular2_Click(object sender, EventArgs e)
        {
            Redirigir(int.Parse(lbl_idItemVendido2.Text), lbl_tipoItemVendido2.Text);
        }

        protected void btn_verItemNuevo0_Click(object sender, EventArgs e)
        {
            Redirigir(int.Parse(lbl_idItemNuevo0.Text), lbl_tipoItemNuevo0.Text);
        }

        protected void btn_verItemNuevo1_Click(object sender, EventArgs e)
        {
            Redirigir(int.Parse(lbl_idItemNuevo1.Text), lbl_tipoItemNuevo1.Text);
        }

        protected void btn_verItemNuevo2_Click(object sender, EventArgs e)
        {
            Redirigir(int.Parse(lbl_idItemNuevo2.Text), lbl_tipoItemNuevo2.Text);
        }

        private void Redirigir(int idItem, string tipoItem)
        {
            string dir;
            if (tipoItem.Equals("Apunte"))
            {
                dir = "DetalleItem.aspx?idApunte=" + idItem + "&idLibro=0";
            }
            else
            {
                dir = "DetalleItem.aspx?idApunte=0&idLibro=" + idItem;
            }
            Response.Redirect(dir);
        }
    }
}