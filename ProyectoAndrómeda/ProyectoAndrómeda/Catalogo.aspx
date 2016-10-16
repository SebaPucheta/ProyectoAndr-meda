<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="ProyectoAndrómeda.Catalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">




    <div class="container">

        <div class="row">
            <div class="col-sm-12">
                <h2 class="page-header">Catalogo de libros</h2>
            </div>
        </div>

        <div class="row">
            <asp:Repeater ID="repeater_libros" runat="server" EnableTheming="true" OnItemCommand="repeater_libros_ItemCommand">
                <ItemTemplate>
                    <div class="col-sm-3 col-xs-6">

                        <div style="background-color: #E9E9E9; text-align: center; margin: 10px; padding: 20px; width: 100%; height: 350px;">
                            <table style="width: 100%; height: 100%;">
                                <tr style="height: 50%;">
                                    <td>
                                        <asp:Image ID="rep_imagen" runat="server" ImageUrl='<%# Eval("idLibro", "imagenes/{0}.jpg") %>' />
                                    </td>
                                </tr>
                                <tr style="height: 30%;">
                                    <td>
                                        <hr style="border-top: 1px solid #ccc;" />
                                        <asp:Label ID="rep_nombre" runat="server" Text='<%# Eval("nombreLibro") %>' Font-Bold="True"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="height: 15%;">
                                    <td>
                                        <asp:Label ID="rep_precioLabel" runat="server" Text="Precio: AR$"></asp:Label>
                                        <asp:Label ID="rep_precio" runat="server" Text='<%# Eval("precioLibro") %>' Font-Bold="True"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:LinkButton ID="btn_ver" runat="server" CommandName="ver" CssClass="btn btn-danger">Ver</asp:LinkButton>
                                        <asp:LinkButton ID="btn_carrito" CommandName="carrito" runat="server"><span class="glyphicon glyphicon-shopping-cart glyphicon-user" style="color:black" aria-hidden="true"></span></asp:LinkButton>

                                    </td>
                                </tr>
                            </table>
                        </div>


                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <!-- paginado -->
        <div class="row">
            <div class="col-sm-12" style="margin-top: 20px;">
                <table class="table" style="width: 50%; height:100%; text-align :center;">
                    <tr>
                        <td>
                            <asp:LinkButton ID="lbFirst" runat="server" OnClick="lbFirst_Click" CssClass="label" Style="color: black;">Inicio</asp:LinkButton>
                        </td>
                        <td>
                            <asp:LinkButton ID="lbPrevious" runat="server" OnClick="lbPrevious_Click"><span class="glyphicon glyphicon-menu-left" style="color:black" aria-hidden="true"></span></asp:LinkButton>
                        </td>
                        <td>
                            <asp:DataList ID="rptPaging" runat="server"
                                OnItemCommand="rptPaging_ItemCommand"
                                OnItemDataBound="rptPaging_ItemDataBound" RepeatDirection="Horizontal">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbPaging" runat="server" CssClass="label" Style="color: black;"
                                        CommandArgument='<%# Eval("PageIndex") %>' CommandName="newPage"
                                        Text='<%# Eval("PageText") %> ' Width="20px"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:DataList>
                        </td>
                        <td>
                            <asp:LinkButton ID="lbNext" runat="server" OnClick="lbNext_Click"><span class="glyphicon glyphicon-menu-right" style="color:black" aria-hidden="true"></span></asp:LinkButton>
                        </td>
                        <td>
                            <asp:LinkButton ID="lbLast" runat="server" OnClick="lbLast_Click" CssClass="label" Style="color: black;">Última</asp:LinkButton>
                        </td>
                        <td>
                            <asp:Label ID="lblpage" runat="server" Text="" CssClass="label"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>

    <!-- div container -->
    </div>
</asp:Content>



