using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaseDeDatos;
using Entidades;

namespace ProyectoAndrómeda
{
    public partial class DetalleItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id;
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

        protected void cargarApunte(int id)
        {
            ApunteEntidad apunte = new ApunteEntidad();
            apunte = ApunteDao.ConsultarApunte(id);
            lbl_titulo.Text = apunte.nombreApunte;
            lbl_precio.Text = apunte.precioApunte.ToString();
            lbl_stock.Text = apunte.stock.ToString();
            lbl_codigo.Text = apunte.codigoBarraApunte.ToString();
            lbl_descripcion.Text = apunte.descripcionApunte;
        }

        protected void cargarLibro(int id)
        {

        }


    }
}