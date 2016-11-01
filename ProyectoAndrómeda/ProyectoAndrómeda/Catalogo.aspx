<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="ProyectoAndrómeda.Catalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">

    <!--el tamaño de la imagen es el 5% de una A4 (124*176)px - original(3508*2480)px -->


    <div class="container">
        <!--encabezado-->
        <div class="row">
            <div class="col-sm-12">
                <h2 class="page-header">Catálogo</h2>
            </div>
        </div>

        <!--cuerpo de página-->
        <div class="row">

            <!--panel izquierdo (filtros)-->
            <div class="col-md-3" style="margin-bottom:100%;">
                <div class="sidebar topspace30">
                    <div class="wowwidget">

                        <h4>Categorias</h4>
                        <ul class="categories">
                            <li>
                                <asp:CheckBox runat="server" ID="chk_apunte" Text="Apunte" />
                            </li>
                            <li>
                                <asp:CheckBox runat="server" ID="chk_libro" Text="Libro" />
                            </li>

                            <li>
                                <asp:Label runat="server" Text="Universidad"></asp:Label>
                                <asp:DropDownList runat="server" ID="ddl_universidad" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddl_universidad_SelectedIndexChanged" />
                            </li>
                            <li>
                                <asp:Label runat="server" Text="Facultad"></asp:Label>
                                <asp:DropDownList runat="server" ID="ddl_facultad" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddl_facultad_SelectedIndexChanged" />
                            </li>
                            <li>
                                <asp:Label runat="server" Text="Carrera"></asp:Label>
                                <asp:DropDownList runat="server" ID="ddl_carrera" CssClass="form-control"></asp:DropDownList>
                            </li>

                            <asp:Button runat="server" ID="btn_primero" CssClass="liCustom" Text="Primer Año" OnClick="btn_primero_Click"></asp:Button>

                            <li>
                                <asp:GridView runat="server" ID="dgv_primero" AutoGenerateColumns="False" GridLines="None" ShowHeader="False" CssClass="sinBordes">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk_seleccionado" runat="server" DataField="df_chk_seleccionado" EnableViewState="true" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="20px"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="nombreMateria" InsertVisible="False" ReadOnly="True" SortExpression="CustomerID">
                                            <ItemStyle HorizontalAlign="Center" Width="100%"></ItemStyle>
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>

                            </li>

                            <asp:Button runat="server" ID="btn_segundo" CssClass="liCustom" Text="Segundo Año" OnClick="btn_segundo_Click"></asp:Button>

                            <li>
                                <asp:GridView runat="server" ID="dgv_segundo" AutoGenerateColumns="False" GridLines="None" ShowHeader="false" CssClass="sinBordes">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10px">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk_seleccionado" runat="server" DataField="df_chk_seleccionado" EnableViewState="true" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="nombreMateria" InsertVisible="False" ReadOnly="True" SortExpression="CustomerID" ControlStyle-Width="70px">
                                            <ControlStyle Width="70px"></ControlStyle>
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </li>

                            <asp:Button runat="server" ID="btn_tercero" CssClass="liCustom" Text="Tercer Año" OnClick="btn_tercero_Click"></asp:Button>

                            <li>
                                <asp:GridView runat="server" ID="dgv_tercero" AutoGenerateColumns="False" GridLines="None" ShowHeader="false" CssClass="sinBordes">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10px">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk_seleccionado" runat="server" DataField="df_chk_seleccionado" EnableViewState="true" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="nombreMateria" InsertVisible="False" ReadOnly="True" SortExpression="CustomerID" ControlStyle-Width="70px">
                                            <ControlStyle Width="70px"></ControlStyle>
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </li>

                            <asp:Button runat="server" ID="btn_cuarto" CssClass="liCustom" Text="Cuarto Año" OnClick="btn_cuarto_Click"></asp:Button>

                            <li>
                                <asp:GridView runat="server" ID="dgv_cuarto" AutoGenerateColumns="False" GridLines="None" ShowHeader="false" CssClass="sinBordes">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10px">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk_seleccionado" runat="server" DataField="df_chk_seleccionado" EnableViewState="true" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="nombreMateria" InsertVisible="False" ReadOnly="True" SortExpression="CustomerID" ControlStyle-Width="70px">
                                            <ControlStyle Width="70px"></ControlStyle>
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </li>

                            <asp:Button runat="server" ID="btn_quinto" CssClass="liCustom" Text="Quinto Año" OnClick="btn_quinto_Click"></asp:Button>

                            <li>
                                <asp:GridView runat="server" ID="dgv_quinto" AutoGenerateColumns="False" GridLines="None" ShowHeader="false" CssClass="sinBordes">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10px">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk_seleccionado" runat="server" DataField="df_chk_seleccionado" EnableViewState="true" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="nombreMateria" InsertVisible="False" ReadOnly="True" SortExpression="CustomerID" ControlStyle-Width="70px">
                                            <ControlStyle Width="70px"></ControlStyle>
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </li>

                            <asp:Button runat="server" ID="btn_sexto" CssClass="liCustom" Text="Sexto Año" OnClick="btn_sexto_Click"></asp:Button>

                            <li>
                                <asp:GridView runat="server" ID="dgv_sexto" AutoGenerateColumns="False" GridLines="None" ShowHeader="false" CssClass="sinBordes">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10px">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk_seleccionado" runat="server" DataField="df_chk_seleccionado" EnableViewState="true" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="nombreMateria" InsertVisible="False" ReadOnly="True" SortExpression="CustomerID" ControlStyle-Width="70px">
                                            <ControlStyle Width="70px"></ControlStyle>
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </li>
                            <asp:Button runat="server" ID="btn_filtrar" CssClass="liCustom" Text="Filtrar" OnClick="btn_filtrar_Click"></asp:Button>
                        </ul>
                    </div>
                </div>
            </div>

            <!-- ============= -->
            <!--catálogo apunte-->
            <div class="col-sm-9">
                <h3 class="page-header">Apuntes</h3>
            </div>

            <div class="col-md-9">
                <asp:Repeater ID="repeater_apuntes" runat="server" EnableTheming="true" OnItemCommand="repeater_apuntes_ItemCommand">
                    <ItemTemplate>
                        <div class="col-sm-4 col-xs-6">

                            <div style="background-color: #E9E9E9; text-align: center; margin: 10px; padding: 20px; width: 100%; height: 375px; box-shadow: 2px 2px 10px 2px #000000;">
                                <table class="table table-responsive" style="width: 100%; height: 100%;">
                                    <tr style="height: 50%;">
                                        <td>
                                            <%--<asp:Image ID="rep_imagen" runat="server" ImageUrl='<%# Eval("idApunte", "imagenes/{0}.jpg") %>' style="width:124px; height:176px;" />--%>
                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/imagenes/PortadaApunte.png" style="width:124px; height:176px;" />
                                        </td>
                                    </tr>
                                    <tr style="height: 30%;">
                                        <td>
                                            <asp:Label ID="rep_nombre" runat="server" Text='<%# Eval("nombreApunte") %>' Font-Bold="True"></asp:Label>
                                            <asp:TextBox ID="txt_id" runat="server" Text='<%# Eval("idApunte") %>' Visible="false" ></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr style="height: 15%;">
                                        <td>
                                            <asp:Label ID="rep_precioLabel" runat="server" Text="Precio: AR$"></asp:Label>
                                            <asp:Label ID="rep_precio" runat="server" Text='<%# Eval("precioApunte") %>' Font-Bold="True"></asp:Label>
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

            <!-- paginado apunte-->
            <div class="col-sm-9" style="margin-top: 20px;">
                <table class="table" style="height: 100%; text-align: center;">
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


            <!-- ============= -->
            <!--catálogo libro-->
            <div class="col-sm-9">
                <h3 class="page-header">Libros</h3>
            </div>

            <div class="col-md-9">
                <asp:Repeater ID="repeater_libros" runat="server" EnableTheming="true" OnItemCommand="repeater_libros_ItemCommand">
                    <ItemTemplate>
                        <div class="col-sm-4 col-xs-6">

                            <div style="background-color: #E9E9E9; text-align: center; margin: 10px; padding: 20px; width: 100%; height: 375px; box-shadow: 2px 2px 10px 2px #000000;">
                                <table class="table" style="width: 100%; height: 100%;">
                                    <tr style="height: 50%;">
                                        <td>
                                            <%--<asp:Image ID="rep_imagen" runat="server" ImageUrl='<%# Eval("idLibro", "imagenes/{0}.jpg") %>' style="width:124px; height:176px;" />--%>
                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/imagenes/PortadaApunte.png" style="width:124px; height:176px;"/>
                                        </td>
                                    </tr>
                                    <tr style="height: 30%;">
                                        <td>
                                            <asp:Label ID="rep_nombre" runat="server" Text='<%# Eval("nombreLibro") %>' Font-Bold="True"></asp:Label>
                                            <asp:TextBox ID="txt_id" runat="server" Text='<%# Eval("idLibro") %>' Visible="false" ></asp:TextBox>
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

            <!-- paginado libro-->
            <div class="col-sm-9" style="margin-top: 20px;">
                <table class="table text-center" style="height: 100%; text-align: center;">
                    <tr>
                        <td>
                            <asp:LinkButton ID="lbFirst2" runat="server" OnClick="lbFirst2_Click" CssClass="label" Style="color: black;">Inicio</asp:LinkButton>
                        </td>
                        <td>
                            <asp:LinkButton ID="lbPrevious2" runat="server" OnClick="lbPrevious2_Click"><span class="glyphicon glyphicon-menu-left" style="color:black" aria-hidden="true"></span></asp:LinkButton>
                        </td>
                        <td>
                            <asp:DataList ID="rptPaging2" runat="server"
                                OnItemCommand="rptPaging2_ItemCommand"
                                OnItemDataBound="rptPaging2_ItemDataBound" RepeatDirection="Horizontal">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbPaging2" runat="server" CssClass="label" Style="color: black;"
                                        CommandArgument='<%# Eval("PageIndex") %>' CommandName="newPage"
                                        Text='<%# Eval("PageText") %> ' Width="20px"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:DataList>
                        </td>
                        <td>
                            <asp:LinkButton ID="lbNext2" runat="server" OnClick="lbNext2_Click"><span class="glyphicon glyphicon-menu-right" style="color:black" aria-hidden="true"></span></asp:LinkButton>
                        </td>
                        <td>
                            <asp:LinkButton ID="lbLast2" runat="server" OnClick="lbLast2_Click" CssClass="label" Style="color: black;">Última</asp:LinkButton>
                        </td>
                        <td>
                            <asp:Label ID="lblpage2" runat="server" Text="" CssClass="label"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>

        <!--fin del row-->
        </div>


        <!-- div container -->
    </div>
</asp:Content>



