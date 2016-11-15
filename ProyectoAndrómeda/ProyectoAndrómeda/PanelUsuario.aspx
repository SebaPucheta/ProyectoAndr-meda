<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PanelUsuario.aspx.cs" Inherits="ProyectoAndrómeda.PanelUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">

    <div class="container">
        <!--primera fila (titulo)-->
        <div class="row">
            <div class="col-md-12">
                <h2 class="page-header">Panel de usuario</h2>
            </div>
        </div>

        <!--segunda fila (producto)-->
        <div class="row">
            <!--panel izquierdo-->
            <div class="col-md-3" style="background-color: #E9E9E9; padding: 25px; margin: 25px; box-shadow: 2px 2px 10px 2px #000000;">
                <asp:Button ID="Button1" runat="server" Text="Mis datos" />
                <br />
                <asp:Button ID="Button2" runat="server" Text="Mis pedidos" />
            </div>

            <!--cuerpo del panel-->
            <div class="col-md-7" style="background-color: #E9E9E9; padding: 25px; margin: 25px; box-shadow: 2px 2px 10px 2px #000000;">
                
                

            </div>
        </div>
        <!--termina container-->

    </div>

</asp:Content>
