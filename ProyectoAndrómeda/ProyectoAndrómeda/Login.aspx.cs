using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaseDeDatos;
using Entidades;
using System.Web.Security;


namespace ProyectoAndrómeda
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        

        protected void lbt_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistrarUsuarioCliente.aspx");
        }

        protected void log_in_Authenticate(object sender, AuthenticateEventArgs e)
        {
            if (LoginDao.Autenticar(log_in.UserName, log_in.Password))
                FormsAuthentication.RedirectFromLoginPage(log_in.UserName, log_in.RememberMeSet);
        }
    }
}