﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using BaseDeDatos;

namespace ProyectoAndrómeda
{
    public partial class RegistrarUsuarioCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected UsuarioEntidad CargarUsuarioDesdeForm()
        {
            UsuarioEntidad usuario = new UsuarioEntidad();
            usuario.contrasena = pass.Text;
            usuario.idRol = 2;
            return usuario;
        }

        protected ClienteEntidad CargarClienteDesdeForm()
        {
            ClienteEntidad cliente = new ClienteEntidad();
            cliente.apellidoCliente = apellido.Text;
            cliente.nombreCliente = nombre.Text;
            cliente.email = correo.Text;
            cliente.idTipoDNI = 1;
            cliente.nroDni = int.Parse(dni.Text);
            return cliente;
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            if (pass.Text == pass2.Text)
            {
                lbl_info.Text = "";
                UsuarioDao.RegistrarUsuarioCliente(CargarUsuarioDesdeForm(), CargarClienteDesdeForm());
                Response.Redirect("Login.aspx");
            }
            else
            {
                lbl_info.Text = "Las contraseñas ingresadas son diferentes";
                LimpiarForm();
            }
        }

        protected void LimpiarForm()
        {
            nombre.Text = "";
            apellido.Text = "";
            pass.Text = "";
            pass2.Text = "";
            correo.Text = "";
            dni.Text = "";
        }
    }
}