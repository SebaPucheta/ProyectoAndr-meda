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

                    <table class="table table-responsive">
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Apellido"></asp:Label>
                                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Label3" runat="server" Text="Correo electrónico"></asp:Label>
                                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Label4" runat="server" Text="Total a pagar"></asp:Label>
                                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>

                   
                  
                    <!--boton mercadopago-->
                    <div>
                        <%
                            
                            MP mp = new MP("3505078557617488", "3J7yHycTVNr1Vkhf8LZLmqqbeuZFP7nq");
                            Hashtable preference = mp.createPreference("{\"items\":[{\"title\":\"EDUCOM\",\"quantity\":1,\"currency_id\":\"ARS\",\"unit_price\":123}]}");
                        %>

                        <a href="<% Response.Write(((Hashtable)preference["response"])["init_point"]); %>" name="MP-Checkout" class="red">Pagar</a>
                        <script type="text/javascript" src="//resources.mlstatic.com/mptools/render.js"></script>
                    </div>

                </div>
            </div>
        </div>



        <!--termina container-->
    </div>

</asp:Content>
