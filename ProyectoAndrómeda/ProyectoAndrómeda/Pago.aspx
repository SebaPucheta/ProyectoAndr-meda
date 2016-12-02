<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Pago.aspx.cs" Inherits="ProyectoAndrómeda.Pago" %>

<%@ Import Namespace="mercadopago" %>
<%@ Import Namespace="System.Collections" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <title>Pago</title>
    <link href="css/Pago/Pago.css" rel="stylesheet" type="text/css" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">

    <div class="container recuadroGrande">

        <!--primera fila (titulo)-->
        <div class="row">
            <div class="col-md-12">
                <h2 class="page-header">Proceder al pago</h2>
            </div>
        </div>

        <!--informacion del usuario-->
        <div class="row">
            <div class="col-md-12">

                <div >

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


                        </div>

                        <div class="col-md-4">
                            <!-- algo de MP -->
                            <asp:Image ID="Image1" runat="server" ImageUrl="http://www.fusionstore.com.ar/uploads/images/33563_mercadopago.png" Style="width: 100%;" />

                        </div>

                    </div>


                    <!--boton mercadopago-->
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Button ID="btn_pago" runat="server" Text="Pagar" class="btn btn_flat btn_rojo btn_mediano" OnClick="btn_pago_Click" />



                           <%-- <asp:Button ID="Button1" CssClass="btn btn_flat btn_azul btn_mediano" runat="server" Text="ConsultarPAGO" OnClick="Button1_Click" />

                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>--%>

                 
                        </div>
                    </div>



                    <!-- cajita gris -->
                </div>
            </div>
        </div>



        <!--termina container-->
    </div>

</asp:Content>
