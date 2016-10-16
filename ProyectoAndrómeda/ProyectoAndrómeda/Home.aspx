<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" EnableEventValidation="true" Inherits="ProyectoAndrómeda.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div id="home">
        <div id="slidernet">
            <section class="carousel carousel-fade slide home-slider" id="c-slide" data-ride="carousel"
                data-interval="4500" data-pause="false">
                <ol class="carousel-indicators">
                    <li data-target="#c-slide" data-slide-to="0" class="active"></li>
                    <li data-target="#c-slide" data-slide-to="1" class=""></li>
                    <li data-target="#c-slide" data-slide-to="2" class=""></li>
                </ol>
                <div class="carousel-inner">
                    <div class="item active">
                        <div class="container">
                            <div class="row">
                                <div class="col-md-6 fadein scaleInv anim_1">
                                    <div class="fadein scaleInv anim_2">
                                        <h1 class="carouselText1 animated fadeInUpBig">Bienvenidos a <span class="colortext">EDUCOM</span></h1>
                                    </div>
                                    <div class="fadein scaleInv anim_1">
                                        <p class="carouselText2 animated fadeInLeft">
                                            Apuntes y Libros
                                        </p>
                                    </div>
                                    <div class="fadein scaleInv anim_2">
                                        <p class="carouselText3">
                                            <i class="icon-ok"></i>Apuntes Digitales
                                        </p>
                                    </div>
                                    <div class="fadein scaleInv anim_3">
                                        <p class="carouselText3">
                                            <i class="icon-ok"></i>Pagos y reservas de libros
                                        </p>
                                    </div>
                                </div>
                                <div class="col-md-6 text-center fadein scaleInv anim_2">
                                    <div class="text-center">
                                        <div class="fadein scaleInv anim_3">
                                            <asp:Image ID="Image1" CssClass="slide1-3 animated rollIn" ImageUrl="~/preview/dotnet-templates/Shop-item/img/slide1-3.png" runat="server"></asp:Image>

                                        </div>
                                        <div class="fadein scaleInv anim_8">
                                            <asp:Image ID="Image2" CssClass="slide1-1 animated rollIn" ImageUrl="~/preview/dotnet-templates/Shop-item/img/slide1-1.png" runat="server"></asp:Image>

                                        </div>
                                        <div class="fadein scaleInv anim_5">
                                            <asp:Image ID="Image3" CssClass="slide1-2 animated rollIn" ImageUrl="~/preview/dotnet-templates/Shop-item/img/slide1-2.png" runat="server"></asp:Image>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="item">
                        <div class="container">
                            <div class="row">
                                <div class="col-md-6 animated fadeInUp notransition">
                                    <asp:Image ID="Image4" Style="width: 90%;" ImageUrl="~/preview/dotnet-templates/Shop-item/img/slide1-1.png" runat="server"></asp:Image>

                                </div>
                                <div class="col-md-6 animated fadeInDown  notransition topspace30 text-right">
                                    <div class="car-highlight1 animated fadeInLeftBig">
                                        EDUCOM Web
                                    </div>
                                    <br />
                                    <div class="car-highlight2 animated fadeInRightBig notransition">
                                        Perfil personalizable
                                    </div>
                                    <br />
                                    <div class="car-highlight3 animated fadeInUpBig notransition">
                                        Libros, Apuntes impresos de EDUCO
                                    </div>
                                    <br />
                                    <div class="car-highlight4 animated flipInX notransition">
                                        Ahora podes tenerlos en formato digital
                                    </div>
                                    <br />
                                    <div class="car-highlight5 animated rollIn notransition">
                                        Consulta los <span class="font100">Apuntes según</span><br />
                                        <span class="font100" style="font-size: 20px;">tu carrera </span>en el catálogo<br />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="item">
                        <div class="container">
                            <div class="row">
                                <div class="col-md-12 text-center">
                                    <br />
                                    <br />
                                    <div class="animated fadeInDownBig notransition">
                                        <span class="car-largetext">Te ofrecemos <span class="font300">tres</span> características</span><br>
                                    </div>
                                    <br />
                                    <br />
                                    <div class="car-widecircle animated fadeInLeftBig notransition">
                                        <span>Seguridad</span>
                                    </div>
                                    <div class="car-middlecircle animated fadeInUpBig notransition">
                                        <span>Eficiencia</span>
                                    </div>
                                    <div class="car-smallcircle animated fadeInRightBig notransition">
                                        <span>Rapidez</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- /.carousel-inner -->
                <a class="left carousel-control animated fadeInLeft" href="#c-slide" data-slide="prev"><i class="glyphicon glyphicon-arrow-left"></i></a>
                <a class="right carousel-control animated fadeInRight" href="#c-slide" data-slide="next"><i class="glyphicon glyphicon-arrow-right"></i></a>
            </section>
            <!-- /.carousel end-->
        </div>
    </div>

    <!-- Page Content -->
    <div id="galeria" class="container">
        <div class="row">
            <div class="col-md-3">
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
                    <div class="wowwidget">
                        <div class="tabs">
                            <ul class="nav nav-tabs">
                                <li class="active"><a href="#popularPosts" data-toggle="tab"><i class="icon icon-star"></i>Popular</a></li>
                                <li><a href="#recentPosts" data-toggle="tab">Recientes</a></li>
                            </ul>
                            <div class="tab-content">
                                <div class="tab-pane active" id="popularPosts">
                                    <ul class="unstyled">
                                        <li>
                                            <div class="tabbedwidget">
                                                <a href="#">
                                                    <asp:Image ID="Image5" ImageUrl="~/preview/dotnet-templates/Shop-item/img/01.jpg"
                                                        runat="server" />
                                                </a>
                                            </div>
                                            <div class="post-info">
                                                <a href="#">Analisis I</a>
                                                <div class="post-meta">
                                                    Dec 12, 2013
                                                </div>
                                            </div>
                                        </li>
                                        <li>
                                            <div class="tabbedwidget">
                                                <a href="#">
                                                    <asp:Image ID="Image6" ImageUrl="~/preview/dotnet-templates/Shop-item/img/01.jpg"
                                                        runat="server" />
                                                </a>
                                            </div>
                                            <div class="post-info">
                                                <a href="#">Algebra</a>
                                                <div class="post-meta">
                                                    Jan 16, 2014
                                                </div>
                                            </div>
                                        </li>
                                        <li>
                                            <div class="tabbedwidget">
                                                <a href="#">
                                                    <asp:Image ID="Image7" ImageUrl="~/preview/dotnet-templates/Shop-item/img/01.jpg"
                                                        runat="server" />
                                                </a>
                                            </div>
                                            <div class="post-info">
                                                <a href="#">Fisica I</a>
                                                <div class="post-meta">
                                                    Sep 28, 2014
                                                </div>
                                            </div>
                                        </li>
                                    </ul>
                                </div>
                                <div class="tab-pane" id="recentPosts">
                                    <ul class="unstyled">
                                        <li>
                                            <div class="tabbedwidget">
                                                <a href="#">
                                                    <asp:Image ID="Image8" ImageUrl="~/preview/dotnet-templates/Shop-item/img/01.jpg"
                                                        runat="server" />
                                                </a>
                                            </div>
                                            <div class="post-info">
                                                <a href="#">Principios de la química</a>
                                                <div class="post-meta">
                                                    Jan 10, 2014
                                                </div>
                                            </div>
                                        </li>
                                        <li>
                                            <div class="tabbedwidget">
                                                <a href="#">
                                                    <asp:Image ID="Image9" ImageUrl="~/preview/dotnet-templates/Shop-item/img/01.jpg"
                                                        runat="server" />
                                                </a>
                                            </div>
                                            <div class="post-info">
                                                <a href="#">Teoria de control</a>
                                                <div class="post-meta">
                                                    Feb 13, 2014
                                                </div>
                                            </div>
                                        </li>
                                        <li>
                                            <div class="tabbedwidget">
                                                <a href="#">
                                                    <asp:Image ID="Image10" ImageUrl="~/preview/dotnet-templates/Shop-item/img/01.jpg"
                                                        runat="server" />
                                                </a>
                                            </div>
                                            <div class="post-info">
                                                <a href="#">Matemática superior</a>
                                                <div class="post-meta">
                                                    Aug 25, 2014
                                                </div>
                                            </div>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--container barra lateral-->



</asp:Content>
