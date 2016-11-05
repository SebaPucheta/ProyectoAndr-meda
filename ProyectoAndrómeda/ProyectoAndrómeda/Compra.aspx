<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Compra.aspx.cs" Inherits="ProyectoAndrómeda.Compra" %>

<%@ Import Namespace="mercadopago" %>
<%@ Import Namespace="System.Collections" %>

    <%
        MP mp = new MP ("CLIENT_ID", "CLIENT_SECRET");

        Hashtable preference = mp.createPreference("{\"items\":[{\"title\":\"sdk-dotnet\",\"quantity\":1,\"currency_id\":\"ARS\",\"unit_price\":10.5}]}");
    %>


<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <title>MercadoPago SDK - Create Preference and Show Checkout Example</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">

    <div class="container">

        <!--primera fila (titulo)-->
        <div class="row">
            <div class="col-md-12">
                <h2 class="page-header">Confirmar compra</h2>
            </div>
        </div>

        <!--segunda fila (producto)-->
        <div class="row">
            <!--tabla del carrito-->
            <div class="col-md-12">

                <a href="<% Response.Write(((Hashtable) preference["response"])["init_point"]); %>" name="MP-Checkout" class="orange-ar-m-sq-arall">Pay</a>
                <script type="text/javascript" src="//resources.mlstatic.com/mptools/render.js"></script>

            </div>
        </div>

    </div>

</asp:Content>
