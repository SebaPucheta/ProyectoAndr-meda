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

        //protected void log_in_Authenticate(object sender, AuthenticateEventArgs e)
        //{
        //    if (LoginDao.Autenticar(log_in.UserName, log_in.Password))
        //        FormsAuthentication.RedirectFromLoginPage(log_in.UserName, log_in.RememberMeSet);
        //}

        protected void btn_login_onclick(object sender, EventArgs e)
        {
            int idUsuario = UsuarioDao.IniciarSesion(txt_email.Text, txt_pass.Text);
            if(idUsuario==0)
            {

            }
            else
            {
                Session["idUsuario"] = idUsuario;
                UsuarioEntidadQuery usuario = UsuarioDao.ConsultarUnUsuario(idUsuario);
                Session["nombreUsuario"] = usuario.clienteQuery.nombreCliente;
                Response.Redirect("Home.aspx");
            }
        }

        protected void btn_registrar_onclick(object sender, EventArgs e)
        {
            UsuarioDao.RegistrarUsuarioCliente(CargarUsuario(), CargarCliente());
        }

        private UsuarioEntidad CargarUsuario()
        {
            UsuarioEntidad nuevoUsuario = new UsuarioEntidad();
            nuevoUsuario.nombreUsuario = txt_emailNuevo.Text;
            nuevoUsuario.contrasena = txt_passNuevo.Text;
            nuevoUsuario.idRol = 2;
            return nuevoUsuario;
        }

        private ClienteEntidad CargarCliente()
        {
            ClienteEntidad nuevoCliente = new ClienteEntidad();
            nuevoCliente.nombreCliente = txt_nombre.Text;
            nuevoCliente.apellidoCliente = txt_apellido.Text;
            nuevoCliente.email = txt_emailNuevo.Text;
            return nuevoCliente;
        }
    }
}