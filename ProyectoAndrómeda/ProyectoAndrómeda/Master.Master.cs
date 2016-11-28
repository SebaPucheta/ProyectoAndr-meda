using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BaseDeDatos;

namespace ProyectoAndrómeda
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_nombreUsuario.Text = UsuarioDao.ConsultarNombreYApellidoUsuario(HttpContext.Current.User.Identity.Name);
        }


    }
}
