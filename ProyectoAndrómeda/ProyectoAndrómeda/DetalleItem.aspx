<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetalleItem.aspx.cs" Inherits="ProyectoAndrómeda.DetalleItem" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <link href="css/DetalleProducto/DetalleProducto.css" rel="stylesheet" type="text/css" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">

    <div class="container recuadroGrande">
        <!--primera fila (titulo)-->
        <div class="row">
            <div class="col-md-12">
                <h2 class="page-header">Descripción del producto</h2>
            </div>
        </div>

        <!--segunda fila (producto)-->
        <div class="row">
            <!--imagen-->
            <div class="col-md-5">
                <div class="recuadroImagenItem">
                    <asp:Image ID="img_portada" runat="server" style="width:215px; height:307px; " />
                </div>
            </div>
            <!--datos-->
            <div class="col-md-7">
                <div class="recuadroInfo">

                    <table class="table table-responsive">
                        <!--nombre-->
                        <tr>
                            <td>
                                <asp:Label ID="lbl_titulo" style="font-weight:bold;" CssClass="h3" runat="server"></asp:Label>
                                <asp:LinkButton ID="img_digital" Visible="false" Enabled="false" runat="server"><span class="glyphicon glyphicon glyphicon-phone glyphicon-user" style="color:#CB0014;" aria-hidden="true"></span></asp:LinkButton>
                            </td>
                        </tr>
                        <!--precio-->
                        <tr>
                            <td>
                                <asp:Label ID="lbl_precio_titulo" style="color:darkgray;" CssClass="control-label" runat="server" Text="Precio:"></asp:Label>
                                <asp:Label ID="lbl_precio_simbolo" style="font-weight:bold;" CssClass="control-label" runat="server" Text=" AR$ "></asp:Label>
                                <asp:Label ID="lbl_precio" CssClass="control-label" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <!--codigo-->
                        <tr>
                            <td>
                                <asp:Label style="color:darkgray;" ID="lbl_codigo_titulo" runat="server" Text="Código: "></asp:Label>
                                <asp:Label ID="lbl_codigo" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <!--stock-->
                        <tr>
                            <td>
                                <asp:Label ID="lbl_stock_titulo" style="color:darkgray;" runat="server" Text="Stock: "></asp:Label>
                                <asp:Label ID="lbl_stock" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <!--carrito-->
                        <tr>
                            <td>
                                <asp:Label ID="lbl_carrito_titulo" runat="server" Text="Agregar al carrito"></asp:Label>
                                <asp:LinkButton ID="btn_carrito" runat="server" OnClick="btn_carrito_Click"><span class="glyphicon glyphicon-shopping-cart glyphicon-user" style="color:darkred" aria-hidden="true"></span></asp:LinkButton>
                            </td>
                        </tr>

                        <!--descripcion-->
                         <tr>
                            <td>
                                <asp:Label ID="lbl_titulo_descripcion" runat="server" Font-Bold="true" Text="Descripción"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lbl_descripcion" CssClass="control-label" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>

                    </table>
                </div>
            </div>
        </div>



    </div>
    <br />
    <br />
    
</asp:Content>

