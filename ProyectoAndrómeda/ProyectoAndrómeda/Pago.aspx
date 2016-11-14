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
                <h2 class="page-header">Confirmar compra</h2>
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
                            <table class="table table-responsive">
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_nombre" runat="server" Text="Nombre"></asp:Label>
                                        <asp:TextBox ID="txt_nombre" runat="server" CssClass="form-control"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_apellido" runat="server" Text="Apellido"></asp:Label>
                                        <asp:TextBox ID="txt_apellido" runat="server" CssClass="form-control"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="lbl_mail" runat="server" Text="Correo electrónico"></asp:Label>
                                        <asp:TextBox ID="txt_mail" runat="server" CssClass="form-control"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_total" runat="server" Text="Total a pagar"></asp:Label>
                                        <div class="input-group">
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
                                        <asp:Label ID="lbl_inicioSesion" runat="server" Text="Primero de iniciar sesión"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btn_inicioSesion" runat="server" Text="Iniciar Sesion" class="btn btn-danger" OnClick="btn_pago_Click" />
                                    </td>
                                </tr>
                            </table>



                        </div>
                    </div>


                    <div class="col-md-4">
                        <!-- algo de MP -->
                    </div>




                    <!--boton mercadopago-->
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Button ID="btn_pago" runat="server" Text="Pagar" class="btn btn-danger" OnClick="btn_pago_Click" />

                            <%--<script type="text/javascript" src="//resources.mlstatic.com/mptools/render.js"></script>--%>
                            <%-- <a  id="a_pago" name="MP-Checkout" class="red">Pagar</a>
                        <script type="text/javascript" src="//resources.mlstatic.com/mptools/render.js"></script>--%>
                        </div>
                    </div>

                    <!-- cajita gris -->
                </div>
            </div>
        </div>



    <!--termina container-->
    </div>

</asp:Content>
