<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Pago.aspx.cs" Inherits="ProyectoAndrómeda.Pago" %>

<%@ Import Namespace="mercadopago" %>
<%@ Import Namespace="System.Collections" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <title>Pago</title>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">

    <div class="container">

        <!--primera fila (titulo)-->
        <div class="row">
            <div class="col-md-12">
                <h2 class="page-header">Proceder al pago</h2>
            </div>
        </div>

        <!--informacion del usuario-->
        <div class="row">
            <div class="col-md-12">

                <div style="background-color: #E9E9E9; padding: 25px; margin: 25px; box-shadow: 2px 2px 10px 2px #000000;">

                    <!--row de las tablas-->
                    <div class="row">
                        <div class="col-md-8">

                            <!--tabla con los datos-->
                            <table id="tab_datos" class="table table-responsive">
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_nombre" runat="server" Text="Nombre"></asp:Label>
                                        <asp:TextBox ID="txt_nombre" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_apellido" runat="server" Text="Apellido"></asp:Label>
                                        <asp:TextBox ID="txt_apellido" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="lbl_mail" runat="server" Text="Correo electrónico"></asp:Label>
                                        <asp:TextBox ID="txt_mail" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_total" runat="server" Text="Total a pagar"></asp:Label>
                                        <div class="input-group col-md-5">
                                            <div class="input-group-addon"><span class="glyphicon glyphicon-usd"></span></div>
                                            <asp:Label runat="server" CssClass="form-control" ID="lbl_totalTotal" />
                                        </div>
                                    </td>
                                </tr>
                            </table>

                            <!-- tabla inicio de sesion-->
                            <table class="table table-responsive">
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_inicioSesion" runat="server" Text="Primero debe iniciar sesión"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:LoginStatus ID="btn_iniciarSesionLogin" CssClass="btn btn-danger" runat="server" LogoutText="Log out" LoginText="Iniciar Sesión" LogoutPageUrl="Home.aspx" />
                                    </td>
                                </tr>
                            </table>

                        </div>

                        <div class="col-md-4">
                            <!-- algo de MP -->
                            <asp:Image ID="Image1" runat="server" ImageUrl="http://www.fusionstore.com.ar/uploads/images/33563_mercadopago.png" style="width:100%; height:100%;" />
                            
                        </div>

                    </div>


                    <!--boton mercadopago-->
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Button ID="btn_pago" runat="server" Text="Pagar" class="btn btn-danger" OnClick="btn_pago_Click" />

                            <asp:Button ID="btn_descargar" runat="server" Text="Descargar" class="btn btn-danger" OnClick="btn_descargar_Click" />
                            
                        </div>
                    </div>

                    <!-- cajita gris -->
                </div>
            </div>
        </div>



        <!--termina container-->
    </div>

</asp:Content>
