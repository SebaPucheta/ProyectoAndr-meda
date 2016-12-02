<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProyectoAndrómeda.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <link rel="stylesheet" href="css/Login/reset.css" />
    <link rel='stylesheet prefetch' href='http://fonts.googleapis.com/css?family=Roboto:400,100,300,500,700,900|RobotoDraft:400,100,300,500,700,900' />
    <link rel='stylesheet prefetch' href='http://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css' />
    <link rel="stylesheet" href="css/Login/style.css" />
    
      
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <br /><br /><br /><br /><br /><br /><br />
            <br />
            <!-- Form Module-->
            <div class="module form-module">
              <div class="toggle" id="toggle"><i class="fa fa-times fa-pencil"></i>
                <div class="tooltip">Click Me</div>
              </div>
              <div class="form">
                <h2>Iniciar sesión</h2>
                
                  <asp:TextBox runat="server" type="text"  ID="txt_email" placeholder="Correo"/>
                  <asp:TextBox runat="server" type="password" ID="txt_pass" placeholder="Contraseña"/>
                  <asp:Button runat="server" id="btn_login" CssClass="btnlogin" text="Iniciar" OnClick="btn_login_onclick" />
                
              </div>
              <div class="form">
                <h2>Registrarse </h2>
                
                  <asp:TextBox runat="server" type="text" ID="txt_nombre" placeholder="Nombre"/>
                  <asp:TextBox runat="server" type="text" ID="txt_apellido" placeholder="Apellido"/>
                  <asp:TextBox runat="server" type="email" ID="txt_emailNuevo" placeholder="Correo"/>
                  <asp:TextBox runat="server" type="password" ID="txt_passNuevo" placeholder="Contraseña"/>
                  <asp:TextBox runat="server" type="password" ID="txt_passNuevo2" placeholder="Repetir contraseña"/>
                  <asp:Button runat="server" text="Registrarse" CssClass="btnlogin" ID="btn_registrar" OnClick="btn_registrar_onclick" />
                
              </div>
             <%-- <div class="cta"><a href="http://andytran.me">Forgot your password?</a></div>--%>
            </div>

       <br /><br /><br /><br /><br /><br /><br />
            <br /> <br /><br /><br /><br /><br /><br /><br />
            <br /> <br /><br />
            
        
</asp:Content>
