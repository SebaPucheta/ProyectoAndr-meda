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
                <div class="row">
                    <asp:Button ID="brn_datos" runat="server" Text="Mis datos" class="btn" Style="width: 100%;" OnClick="brn_datos_Click" />
                </div>
                <div class="row">
                    <br />
                    <asp:Button ID="btn_pedidos" runat="server" Text="Mis pedidos" class="btn" Style="width: 100%;" OnClick="btn_pedidos_Click" />
                </div>
            </div>

            <!--cuerpo del panel-->
            <div class="col-md-7" style="background-color: #E9E9E9; padding: 25px; margin: 25px; box-shadow: 2px 2px 10px 2px #000000;">

                <!--informacion de usuario-->
                <div class="row">
                    <div class="col-md-6">
                        <!--usuario-->
                        <asp:Label ID="lbl_usuario" class="control-label" runat="server" Text="Nombre de usuario"></asp:Label>
                        <asp:TextBox ID="txt_usuario" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-6">
                        <!--nombre-->
                        <asp:Label ID="lbl_nombre" class="control-label" runat="server" Text="Nombre"></asp:Label>
                        <asp:TextBox ID="txt_nombre" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-6">
                        <!--apellido-->
                        <asp:Label ID="lbl_apellido" class="control-label" runat="server" Text="Apellido"></asp:Label>
                        <asp:TextBox ID="txt_apellido" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-12">
                    <!--email-->
                    <asp:Label ID="lbl_email" class="control-label" runat="server" Text="Correo electrónico"></asp:Label>
                    <asp:TextBox ID="txt_email" class="form-control" runat="server"></asp:TextBox>
                        </div>
                </div>

                <div class="row">
                    <div class="col-md-6">
                        <!--dni-->
                        <asp:Label ID="lbl_dni" class="control-label" runat="server" Text="Número de documento"></asp:Label>
                        <asp:TextBox ID="txt_dni" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-6">
                        <!-- -->
                    </div>
                </div>



                <!--mis pedidos-->
                <!--detalle factura-->
                <div class="row">
                    <asp:Label ID="hdetalle" CssClass="h3 page-header" runat="server" Text="Detalle de la compra" Visible="false"></asp:Label>
                </div>

                <div class="row">
                    <br />
                    <asp:GridView ID="dgv_detalle" runat="server" AutoGenerateColumns="false" class="table table-responsive">

                        <HeaderStyle BackColor="#CB0014" Font-Bold="True" ForeColor="White" />
                        <EmptyDataRowStyle ForeColor="Red" />
                        <Columns>

                            <asp:BoundField DataField="idProductoCarrito" HeaderText="Nro." />
                            <asp:BoundField DataField="nombreItem" HeaderText="Nombre" />
                            <asp:BoundField DataField="tipoItem" HeaderText="Tipo producto" />
                            <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                            <asp:BoundField DataField="subtotal" HeaderText="Subtotal" ApplyFormatInEditMode="False" DataFormatString="{0:C}" />

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btn_consultarDetalle" CommandName="select" runat="server"><span class="glyphicon glyphicon-eye-open" style="color:#CB0014" aria-hidden="true"></span></asp:LinkButton>
                                </ItemTemplate>
                                <ControlStyle Width="10px" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                </div>

                <!--factura-->
                <div class="row">
                    <asp:Label ID="hfactura" CssClass="h3 page-header" runat="server" Text="Compras realizadas" Visible="false"></asp:Label>
                </div>

                <div class="row">
                    <br />
                    <asp:GridView ID="dgv_factura" runat="server" AutoGenerateColumns="false" class="table table-responsive"
                        OnSelectedIndexChanged="btn_consultarFactura_SelectedIndexChanged">
                        <HeaderStyle BackColor="#CB0014" Font-Bold="True" ForeColor="White" />

                        <EmptyDataRowStyle ForeColor="Red" />
                        <Columns>
                            <asp:BoundField DataField="idFactura" HeaderText="Nro." />
                            <asp:BoundField DataField="fecha" HeaderText="Fecha" />
                            <asp:BoundField DataField="total" HeaderText="Total" DataFormatString="{0:c}" />
                            <asp:BoundField DataField="nombreEstadopago" HeaderText="Estado" ItemStyle-Font-Bold="true" />
                            <asp:BoundField DataField="idFacturaMP" Visible="false" />
                            <asp:BoundField DataField="idUsuario" Visible="false" />

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btn_consultarFactura" CommandName="select" runat="server"><span class="glyphicon glyphicon-eye-open" style="color:#CB0014" aria-hidden="true"></span></asp:LinkButton>
                                </ItemTemplate>
                                <ControlStyle Width="10px" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                </div>

            </div>
        </div>
        <!--termina container-->

    </div>

</asp:Content>
