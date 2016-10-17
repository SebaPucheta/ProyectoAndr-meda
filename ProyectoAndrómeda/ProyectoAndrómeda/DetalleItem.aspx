<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetalleItem.aspx.cs" Inherits="ProyectoAndrómeda.DetalleItem" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">

    <div class="container">
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
                <div style="background-color: #E9E9E9; padding: 25px; margin: 25px; box-shadow: 2px 2px 10px 2px #000000;">
                    <asp:Image ID="img_portada" runat="server" />
                </div>
            </div>
            <!--datos-->
            <div class="col-md-7">
                <div style="background-color: #E9E9E9; padding: 25px; margin: 25px; box-shadow: 2px 2px 10px 2px #000000;">

                    <table class="table table-responsive">
                        <!--nombre-->
                        <tr>
                            <td>
                                <asp:Label ID="lbl_titulo" style="font-weight:bold;" CssClass="h3" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <!--precio-->
                        <tr>
                            <td>
                                <asp:Label ID="lbl_precio_titulo" style="color:darkgray;" CssClass="control-label" runat="server" Text="Precio:"></asp:Label>
                                <asp:Label ID="lbl_precio_simbolo" style="font-weight:bold;" CssClass="control-label" runat="server" Text=" AR$ "></asp:Label>
                                <asp:Label ID="lbl_precio" CssClass="control-label" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <!--codigo-->
                        <tr>
                            <td>
                                <asp:Label style="color:darkgray;" ID="lbl_codigo_titulo" runat="server" Text="Código: "></asp:Label>
                                <asp:Label ID="lbl_codigo" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <!--stock-->
                        <tr>
                            <td>
                                <asp:Label ID="lbl_stock_titulo" style="color:darkgray;" runat="server" Text="Stock: "></asp:Label>
                                <asp:Label ID="lbl_stock" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <!--carrito-->
                        <tr>
                            <td>
                                <asp:Label ID="lbl_carrito_titulo" runat="server" Text="Agregar al carro"></asp:Label>
                                <asp:LinkButton ID="btn_carrito" runat="server"><span class="glyphicon glyphicon-shopping-cart glyphicon-user" style="color:darkred" aria-hidden="true"></span></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>


        <!--tercera fila (descripcion)-->
        <div class="row">
            <div class="col-md-12">
                <div style="background-color: #E9E9E9; padding: 25px; margin: 25px; box-shadow: 2px 2px 10px 2px #000000;">
                    <asp:Label ID="lbl_descripcion" CssClass="control-label" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
        </div>

    </div>

</asp:Content>

