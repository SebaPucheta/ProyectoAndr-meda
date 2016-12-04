<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="ProyectoAndrómeda.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <link href="css/Carrito/Carrito.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">


    <div class="container recuadroGrande">
        <!--primera fila (titulo)-->
        <div class="row">
            <div class="col-md-12">
                <h2 class="page-header">Carrito de compras</h2>
            </div>
        </div>

        <!--segunda fila (producto)-->
        <div class="row">
            <!--tabla del carrito-->
            <div class="col-md-12">
                <div>

                    <asp:GridView ID="dgv_carrito" runat="server" CssClass="table table-responsive" AutoGenerateColumns="False" OnRowDeleting="dgv_carrito_RowDeleting" OnSelectedIndexChanged="dgv_carrito_SelectedIndexChanged">
                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                        <HeaderStyle BackColor="#CB0014" Font-Bold="True" ForeColor="White" />
                        <EmptyDataRowStyle ForeColor="Red" />

                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Image ID="img" Style="width: 94px; height: 126px;" runat="server" />
                                </ItemTemplate>
                                <ControlStyle Width="40px" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="idProductoCarrito" Visible="true">
                                <ItemStyle CssClass="hidden" />
                                <HeaderStyle CssClass="hidden" />
                            </asp:BoundField>
                            <asp:BoundField DataField="idProducto" Visible="true">
                                <ItemStyle CssClass="hidden" />
                                <HeaderStyle CssClass="hidden" />
                            </asp:BoundField>

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="img_digital" Visible="false" Enabled="false" runat="server"><span class="glyphicon glyphicon glyphicon-phone glyphicon-user" style="color:#CB0014;" aria-hidden="true"></span></asp:LinkButton>
                                </ItemTemplate>
                                <ControlStyle Width="10px" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>

                            <asp:BoundField DataField="nombreProducto" HeaderText="Nombre" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="tipoProducto" HeaderText="Tipo producto" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="precioUnitario" HeaderText="Precio unitario" DataFormatString="{0:c}" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField DataField="cantidad" HeaderText="Cantidad">
                                <ItemStyle CssClass="hidden" />
                                <HeaderStyle CssClass="hidden" />
                            </asp:BoundField>
                            <%--Cantidad con textbox--%>
                            <asp:TemplateField HeaderText="Cantidad">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_cantidad" AutoPostBack="false" runat="server" class="form-control" Style="width: 60px; text-align: right;"></asp:TextBox>
                                </ItemTemplate>
                                <ControlStyle Width="40px" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>

                            <asp:BoundField DataField="subtotal" HeaderText="Subtotal" ApplyFormatInEditMode="False" DataFormatString="{0:C}" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Right" />

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btn_consultarApunte" CommandName="select" runat="server"><span class="glyphicon glyphicon-eye-open" style="color:black" aria-hidden="true"></span></asp:LinkButton>
                                </ItemTemplate>
                                <ControlStyle Width="10px" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btn_eliminarDetalle" CommandName="delete" runat="server"><span class="glyphicon glyphicon-trash" style="color:black" aria-hidden="true"></span></asp:LinkButton>
                                </ItemTemplate>
                                <ControlStyle Width="10px" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <!--total-->
                    <label class="control-label col-md-offset-9 col-md-1">Total: </label>
                    <div>
                        <div class="input-group">
                            <div class="input-group-addon"><span class="glyphicon glyphicon-usd"></span></div>
                            <asp:Label runat="server" CssClass="form-control" ID="lbl_total" />
                        </div>
                    </div>
                    <br />
                    <br />


                    <!--botones-->
                    <br />
                    <div style="height: 1px; background-color: black; text-align: center">
                        <span style="background-color: white; position: relative; top: -0.5em;"></span>
                    </div>
                    <br />
                    <asp:Button runat="server" ID="btn_confirmar" Text="Confirmar" CssClass="btn btn_flat btn_rojo btn_mediano" OnClick="btn_confirmar_Click" OnClientClick="return confirm('Una vez confirmado se registra la transacción. ¿Desea continuar?');" />
                    <asp:Button runat="server" ID="btn_actualizar" Text="Actualizar carrito" CssClass="btn btn_flat btn_rojo btn_mediano" OnClick="btn_actualizar_Click" />
                    <asp:Button runat="server" ID="btn_cancelar" Text="Cancelar" CssClass="btn btn_flat btn_azul btn_mediano" OnClick="btn_cancelar_Click" />

                </div>
            </div>
        </div>

    </div>


</asp:Content>
