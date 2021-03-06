﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" EnableEventValidation="true" Inherits="ProyectoAndrómeda.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <link href="css/Home/Home.css" rel="stylesheet" type="text/css" />
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
                                            <%--<asp:Image ID="Image1" CssClass="slide1-3 animated rollIn" ImageUrl="~/preview/dotnet-templates/Shop-item/img/slide1-3.png" runat="server"></asp:Image>--%>

                                        </div>
                                        <div class="fadein scaleInv anim_8">
                                            <%--<asp:Image ID="Image2" CssClass="slide1-1 animated rollIn" ImageUrl="~/preview/dotnet-templates/Shop-item/img/slide1-1.png" runat="server"></asp:Image>--%>

                                        </div>
                                        <div class="fadein scaleInv anim_5">
                                            <%--<asp:Image ID="Image3" CssClass="slide1-2 animated rollIn" ImageUrl="~/preview/dotnet-templates/Shop-item/img/slide1-2.png" runat="server"></asp:Image>--%>
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
                                    <%--<asp:Image ID="Image4" Style="width: 90%;" ImageUrl="~/preview/dotnet-templates/Shop-item/img/slide1-1.png" runat="server"></asp:Image>--%>

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
                                        <span class="car-largetext">Te ofrecemos <span class="font300">tres</span> características</span><br />
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


    

    <!--Los mas vendidos-->
    <div class="row container-fluid contenedorRecuadro">
        <h1 class="titulo-vendidos">Best-Seller</h1>
       <div class="col-lg-4">
                <div class="recuadro">
                    <div class="contenidoRecuadro">
                        <asp:ImageButton ID="img_itemVendido0" runat="server" OnClick="btn_verItemPopular0_Click" ImageUrl="~/imagenes/PortadaApunte.png" style="width:206px;height:307px;" CssClass="img"/>
                        <asp:Label runat="server" ID="lbl_idItemVendido0" Visible="false" ></asp:Label>
                        <asp:Label runat="server" ID="lbl_tipoItemVendido0" Visible="false" ></asp:Label>
                        <div class:"row">
                        <asp:Label runat="server" CssClass="tituloItem" ID="lbl_nombreItemVendido0" ></asp:Label>
                        </div>
                        <div class:"row">
                        <asp:Label runat="server" CssClass="descripcionItem" ID="lbl_descripcionItemVendido0" ></asp:Label>
                        </div>
                        <div class:"row">
                        <asp:Label runat="server" CssClass="precioItem" ID="lbl_precioItemVendido0" ></asp:Label>
                        </div>
                        <%--<asp:Button runat="server" CssClass="btn-ver" Text="Ver" ID="btn_verItemPopular0" OnClick="btn_verItemPopular0_Click" />--%>
                    </div>
                 </div>
            </div>
            <div class="col-lg-4">
                <div class="recuadro">
                    <div class="contenidoRecuadro">
                        <asp:ImageButton ID="img_itemVendido1" OnClick="btn_verItemPopular1_Click" runat="server" ImageUrl="~/imagenes/PortadaApunte.png" style="width:206px;height:307px;" CssClass="img" />
                        <asp:Label runat="server" ID="lbl_idItemVendido1" Visible="false" ></asp:Label>
                        <asp:Label runat="server" ID="lbl_tipoItemVendido1" Visible="false" ></asp:Label>
                        <div class:"row">
                        <asp:Label runat="server" CssClass="tituloItem" ID="lbl_nombreItemVendido1" ></asp:Label>
                        </div>
                        <div class:"row">
                        <asp:Label runat="server" CssClass="descripcionItem" ID="lbl_descripcionItemVendido1" ></asp:Label>
                        </div>
                        <div class:"row">
                        <asp:Label runat="server" CssClass="precioItem" ID="lbl_precioItemVendido1" ></asp:Label>
                        </div>
                        <%--<asp:Button runat="server" CssClass="btn-ver" Text="Ver" ID="btn_verItemPopular1" OnClick="btn_verItemPopular1_Click" />--%>
                    </div>
                </div>
            </div>
            <div class="col-lg-4">
                <div class="recuadro">
                    <div class="contenidoRecuadro">
                        <asp:ImageButton ID="img_itemVendido2" OnClick="btn_verItemPopular2_Click" runat="server" ImageUrl="~/imagenes/PortadaApunte.png" style="width:206px;height:307px;" CssClass="img" />
                        <div class="row">
                            <asp:Label runat="server" ID="lbl_idItemVendido2" Visible="false" ></asp:Label>
                            <asp:Label runat="server" ID="lbl_tipoItemVendido2" Visible="false" ></asp:Label>
                            <div class:"row">
                            <asp:Label runat="server" CssClass="tituloItem" ID="lbl_nombreItemVendido2" ></asp:Label>
                            </div>
                            <div class:"row">
                            <asp:Label runat="server" CssClass="descripcionItem" ID="lbl_descripcionItemVendido2" ></asp:Label>
                            </div>
                            <div class:"row">
                            <asp:Label runat="server" CssClass="precioItem" ID="lbl_precioItemVendido2" ></asp:Label>
                            </div>
                        </div>
                        
                        <%--<asp:Button runat="server" CssClass="btn-ver" Text="Ver" ID="btn_verItemPopular2" OnClick="btn_verItemPopular2_Click" />--%>
                    </div>
                </div>
            </div>
        </div>

         <!--Los Nuevos-->
        <div class="row container-fluid contenedorRecuadroParallax">
            <h1 class="titulo-nuevos">Nuevos</h1>
           <div class="col-lg-4">
                    <div class="recuadroParallax">
                        <div class="contenidoRecuadro">
                            <asp:ImageButton OnClick="btn_verItemNuevo0_Click" ID="img_itemNuevo0" runat="server" ImageUrl="~/imagenes/PortadaApunte.png" style="width:206px;height:307px;" CssClass="img"/>
                            <asp:Label runat="server" ID="lbl_idItemNuevo0" Visible="false" ></asp:Label>
                            <asp:Label runat="server" ID="lbl_tipoItemNuevo0" Visible="false" ></asp:Label>
                            <div class:"row">
                            <asp:Label runat="server" CssClass="tituloItem" ID="lbl_nombreItemNuevo0" ></asp:Label>
                            </div>
                            <div class:"row">
                            <asp:Label runat="server" CssClass="descripcionItem" ID="lbl_descripcionItemNuevo0" ></asp:Label>
                            </div>
                            <div class:"row">
                            <asp:Label runat="server" CssClass="precioItem" ID="lbl_precioItemNuevo0" ></asp:Label>
                            </div>
                            <%--<asp:Button runat="server" CssClass="btn-ver" Text="Ver" ID="btn_verItemNuevo0" OnClick="btn_verItemNuevo0_Click" />--%>
                        </div>
                     </div>
                </div>
                <div class="col-lg-4">
                    <div class="recuadroParallax">
                        <div class="contenidoRecuadro">
                            <asp:ImageButton OnClick="btn_verItemNuevo1_Click" ID="img_itemNuevo1" runat="server" ImageUrl="~/imagenes/PortadaApunte.png" style="width:206px;height:307px;" CssClass="img" />
                            <div class="row">
                                <asp:Label runat="server" ID="lbl_idItemNuevo1" Visible="false" ></asp:Label>
                                <asp:Label runat="server" ID="lbl_tipoItemNuevo1" Visible="false" ></asp:Label>
                                <div class:"row">
                                <asp:Label runat="server" CssClass="tituloItem" ID="lbl_nombreItemNuevo1" ></asp:Label>
                                </div>
                                <div class:"row">
                                <asp:Label runat="server" CssClass="descripcionItem" ID="lbl_descripcionItemNuevo1" ></asp:Label>
                                </div>
                                <div class:"row">
                                <asp:Label runat="server" CssClass="precioItem" ID="lbl_precioItemNuevo1" ></asp:Label>
                                </div>
                            </div>
                            <%--<asp:Button runat="server" CssClass="btn-ver" Text="Ver" ID="btn_verItemNuevo1" OnClick="btn_verItemNuevo1_Click" />--%>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="recuadroParallax">
                        <div class="contenidoRecuadro">
                            <asp:ImageButton OnClick="btn_verItemNuevo2_Click" ID="img_itemNuevo2" runat="server" ImageUrl="~/imagenes/PortadaApunte.png" style="width:206px;height:307px;" CssClass="img" />
                            <asp:Label runat="server" ID="lbl_idItemNuevo2" Visible="false" ></asp:Label>
                            <asp:Label runat="server" ID="lbl_tipoItemNuevo2" Visible="false" ></asp:Label>
                            <div class="row">
                                <asp:Label CssClass="tituloItem" runat="server" ID="lbl_nombreItemNuevo2" ></asp:Label>
                            </div>
                            <div class="row">
                                <asp:Label runat="server" CssClass="descripcionItem" ID="lbl_descripcionItemNuevo2" ></asp:Label>
                            </div>
                            <div class="row">
                                <asp:Label runat="server" CssClass="precioItem" ID="lbl_precioItemNuevo2" ></asp:Label>
                            </div>
                            <%--<asp:Button runat="server" CssClass="btn-ver" Text="Ver" ID="btn_verItemNuevo2" OnClick="btn_verItemNuevo2_Click" />--%>
                        </div>
                   </div>
                </div>
            </div>
     <!-- Marcas -->
            <div class="row container-fluid contenedorMarcas">
                <div class="col-lg-2 alfaomega">
                <asp:Image ID="Image8" runat="server" ImageUrl="~\css\Home\LogoEditorial/Alfaomega.png" CssClass="img-alfaomega" />
                </div>
                <div class="col-lg-2 az">
                <asp:Image ID="Image9" runat="server" ImageUrl="~\css\Home\LogoEditorial/az.png" CssClass="img-az" />
                </div>
                <div class="col-lg-2 estrada">
                <asp:Image ID="Image10" runat="server" ImageUrl="~\css\Home\LogoEditorial/Estrada.png" CssClass="img-estrada" />
                </div>
                <div class="col-lg-2 educo">
                <asp:Image ID="Image11" runat="server" ImageUrl="~\css\Home\LogoEditorial/LOGO EDUCO.jpg" CssClass="img-educo" />
                </div>
                <div class="col-lg-2 pearson">
                <asp:Image ID="Image12" runat="server" ImageUrl="~\css\Home\LogoEditorial/pearson.png" CssClass="img-pearson" />
                </div>
            </div>  
    <!--container barra lateral-->

    </div>
</asp:Content>
