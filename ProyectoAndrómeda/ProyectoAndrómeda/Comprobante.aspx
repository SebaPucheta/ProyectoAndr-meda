<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Comprobante.aspx.cs" Inherits="ProyectoAndrómeda.Comprobante" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <!-- bootstrap -->
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/Form/Form.css" rel="stylesheet" type="text/css" />
    <script src="js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>



            <div class="container">

                <div class="row">
                    <div class="col-md-12">
                        <asp:Label ID="lbl_titulo" class="page-header h3" runat="server" Text="Comprobante de pago"></asp:Label>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-12">
                        <br />
                        <asp:Label ID="lbl_nombreUsuario_titulo" runat="server" Text="Nombre de usuario: "></asp:Label>
                        <asp:Label ID="lbl_nombreUsuario" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lbl_nombreYApellido_titulo" runat="server" Text="Nombre y apellido: "></asp:Label>
                        <asp:Label ID="lbl_nombreApellido" runat="server" Text=""></asp:Label>
                        <br />
                        <br />
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-12">
                        <asp:Label ID="lbl_factura_titulo" class="page-header h3" runat="server" Text="Número y fecha del pedido"></asp:Label>
                        <br />
                        <br />
                        <asp:GridView ID="dgv_factura" runat="server" AutoGenerateColumns="false" class="table table-responsive">
                            <HeaderStyle BackColor="#CB0014" Font-Bold="True" ForeColor="White" />
                            <EmptyDataRowStyle ForeColor="Red" />
                            <Columns>
                                <asp:BoundField DataField="idFactura" HeaderText="Nro." />
                                <asp:BoundField DataField="fecha" HeaderText="Fecha" />
                                <asp:BoundField DataField="total" HeaderText="Total" DataFormatString="{0:c}" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>


                <div class="row">
                    <div class="col-md-12">
                        <asp:Label ID="lbl_detalle_titulo" class="page-header h3" runat="server" Text="Detalle del pedido"></asp:Label>
                        <br />
                        <br />
                        <asp:GridView ID="dgv_detalle" runat="server" AutoGenerateColumns="false" class="table table-responsive">
                            <HeaderStyle BackColor="#CB0014" Font-Bold="True" ForeColor="White" />
                            <EmptyDataRowStyle ForeColor="Red" />
                            <Columns>

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="img_digital" Visible="false" Enabled="false" runat="server"><span class="glyphicon glyphicon glyphicon-phone glyphicon-user" style="color:#CB0014;" aria-hidden="true"></span></asp:LinkButton>
                                    </ItemTemplate>
                                    <ControlStyle Width="10px" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>

                                <asp:BoundField DataField="nombreItem" HeaderText="Nombre" />
                                <asp:BoundField DataField="tipoItem" HeaderText="Tipo producto" />
                                <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                                <asp:BoundField DataField="subtotal" HeaderText="Subtotal" ApplyFormatInEditMode="False" DataFormatString="{0:C}" />
                                <asp:BoundField DataField="idItem">
                                    <ItemStyle CssClass="hidden" />
                                    <HeaderStyle CssClass="hidden" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-offset-10">
                        <asp:Label runat="server" class="page-header h3" ID="lbl_total" Text="Total: $" Style="font: bold"></asp:Label>
                        <br />
                        <br />
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-offset-10">
                        <table>
                            <tr>
                                <td style="text-align: center">
                                    <asp:Image ID="img_codigoBarra" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_tec" runat="server" Text="Generado por tec-it.com"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <br />
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-12">
                        <asp:Label ID="lbl_aclaracion" class="label-control" runat="server" Text="Debe imprimir este comprobante desde el navegador y mostrarselo al responsable de ventas en el local de EDUCO"></asp:Label>
                        <br />
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-12">
                        <asp:Label ID="lbl_fechaImpresion_titulo" class="page-header" runat="server" Text="Fecha de comprobante: "></asp:Label>
                        <asp:Label ID="lbl_fechaImpresion" class="label-control" runat="server" Text=""></asp:Label>
                    </div>
                </div>

            </div>
        </div>
    </form>
</body>
</html>
