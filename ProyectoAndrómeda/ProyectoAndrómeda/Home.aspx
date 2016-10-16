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
    </div>

    <!-- Page Content -->
    <div id="galeria" class="container">
        <div class="row">


        </div>
    </div>
    <!--container barra lateral-->



</asp:Content>
