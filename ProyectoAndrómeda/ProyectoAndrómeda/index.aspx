<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" EnableEventValidation="false" Inherits="preview_dotnet_templates_with_out_masterpages_Shop_item_index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>EDUCOM</title>
    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- Custom CSS -->
    <link href="css/shop-item.css" rel="stylesheet" type="text/css" />
    <link href="css/animated.css" rel="stylesheet" type="text/css" />
    <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:300,400italic,700italic,400,700"
        rel="stylesheet" type="text/css" />
    <link href="http://maxcdn.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css"
        rel="stylesheet" type="text/css" />
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body id="page-top" data-spy="scroll" data-target=".navbar-fixed-top">
    <form id="form1" runat="server">
        <!-- Navigation -->
        <nav id="custom-bootstrap-menu" class="navbar navbar-default navbar-fixed-top" role="navigation">
        <div class="container">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header page-scroll">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand page-scroll" href="#page-top">EDUCOM</a>
            </div>
            <!-- Collect the nav links, forms, and other content for toggling -->
           <div class="collapse navbar-collapse navbar-menubuilder" id="bs-example-navbar-collapse-1">
            <ul class="nav navbar-nav navbar-right">
                <li class="active"><a class="page-scroll" href="#home">Home</a>
                </li>
                <li><a class="page-scroll" href="#galeria">Galeria</a>
                </li>
                <li><a class="page-scroll" href="#contact">Contacto</a>
                </li>
            </ul>
        </div>
            <!-- /.navbar-collapse -->
        </div>
        <!-- /.container -->
    </nav>
        <!-- Slider -->
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
								<i class="icon-ok"></i> Apuntes Digitales
							</p>
						</div>
						<div class="fadein scaleInv anim_3">
							<p class="carouselText3">
								<i class="icon-ok"></i> Pagos y reservas de libros
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
                    <asp:Image ID="Image4" style="width:90%;" ImageUrl="~/preview/dotnet-templates/Shop-item/img/slide1-1.png" runat="server"></asp:Image>
					
					</div>
					<div class="col-md-6 animated fadeInDown  notransition topspace30 text-right">
						<div class="car-highlight1 animated fadeInLeftBig">
							 EDUCOM Web
						</div>
						<br>
						<div class="car-highlight2 animated fadeInRightBig notransition">
							 Perfil personalizable
						</div>
						<br>
						<div class="car-highlight3 animated fadeInUpBig notransition">
							 Libros, Apuntes impresos de EDUCO
						</div>
						<br>
						<div class="car-highlight4 animated flipInX notransition">
							 Ahora podes tenerlos en formato digital
						</div>
						<br>
						<div class="car-highlight5 animated rollIn notransition">
							 Consulta los <span class="font100">Apuntes según</span><br>
							<span class="font100" style="font-size:20px;">tu carrera </span> en el catálogo<br>
						</div>
					</div>
				</div>
			</div>
		</div>
		<div class="item" >
			<div class="container">
				<div class="row">
					<div class="col-md-12 text-center">
						<br>
						<br>
						<div class="animated fadeInDownBig notransition">
							<span class="car-largetext">Te ofrecemos <span class="font300">tres</span> características</span><br>
						</div>
						<br>
						<br>
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
                                <asp:Button runat="server" ID="btn_filtroSistemas" CssClass="liCustom" OnClick="btn_filtroSistemas_onClick" Text="Sistemas" />
                                <asp:Button runat="server" ID="btn_filtroQuimica" CssClass="liCustom" OnClick="btn_filtroQuimica_onClick" Text="Quimica" />
                                <asp:Button runat="server" ID="btn_filtroCivil" CssClass="liCustom" OnClick="btn_filtroCivil_onClick" Text="Civil" />
                                <asp:Button runat="server" ID="btn_filtroMecanica" CssClass="liCustom" OnClick="btn_filtroMecanica_onClick" Text="Mecanica" />
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
                <div class="col-md-9">
                    <!-- Contenido al lado de la categoria -->
                    <!--                 
                       ACÁ JUANCHI RE: LMAO
                -->

                    <table style="width: 100%;">
                        <tr>
                            <td style="font-weight: 700; text-align: center">Listado de libros</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="dgv_libros" runat="server" AllowPaging="True" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="GridView1_PageIndexChanging" Width="100%" AutoGenerateColumns="False">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Libro">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <table class="table table-responsive">
                                                    <tr>
                                                        <td width="75%"><b>Código</b>:&nbsp;
                                    <asp:Label ID="lbl_codigo" runat="server" Text='<%# Eval("idApunte") %>'></asp:Label>
                                                            <br />
                                                        </td>
                                                        <td rowspan="4" align="right" width="25%">
                                                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("idApunte", "imagenes/{0}.jpg") %>' />
                                                            <br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td><b>Nombre</b>:&nbsp;
                                    <asp:Label ID="lbl_nombre" runat="server" Text='<%# Eval("nombreApunte") %>'></asp:Label>
                                                            <br />
                                                        </td>
                                                    </tr>


                                                    <%--<tr>
                                                        <td><b>Autor</b>:&nbsp;
                                    <asp:Label ID="lbl_autor" runat="server" Text='<%# Eval("autorLibro") %>'></asp:Label>
                                                            <br />
                                                        </td>
                                                    </tr>--%>


                                                    <tr>
                                                        <td><b>Precio</b>: $&nbsp;
                                    <asp:Label ID="lbl_precio" runat="server" Text='<%# Eval("precioApunte") %>'></asp:Label>
                                                            <br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="Button1" runat="server" Text="Ver" class="btn btn-group-lg" />
                                                            <asp:LinkButton ID="btn_seleccionar" CommandName="select" runat="server"><span class="glyphicon glyphicon-shopping-cart" aria-hidden="true"></span></asp:LinkButton>
                                                        </td>
                                                    </tr>

                                                </table>




                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#CCCC99" />
                                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                    <RowStyle BackColor="#F7F7DE" />
                                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                    <SortedAscendingHeaderStyle BackColor="#848384" />
                                    <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                    <SortedDescendingHeaderStyle BackColor="#575357" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>




                </div>
                <div class="clearfix">
                </div>
                <div id="product">
                </div>
            </div>
        </div>

        <%-- <div class="page-header">
                <div class="container">
                    <div class="row">
                        <h1>
                            Product</h1>
                    </div>
                </div>
            </div>--%>
        <%--  <!-- Plans -->
            <section id="plans">
        <div class="container">
            <div class="row">

                <!-- item -->
                <div class="col-md-4 text-center">
                    <div class="panel panel-danger panel-pricing">
                        <div class="panel-heading">
                            <i class="fa fa-desktop"></i>
                            <h3>Plan 1</h3>
                        </div>
                        <div class="panel-body text-center">
                            <p><strong>$100 / Month</strong></p>
                        </div>
                        <ul class="list-group text-center">
                            <li class="list-group-item"><i class="fa fa-check"></i> Personal use</li>
                            <li class="list-group-item"><i class="fa fa-check"></i> Unlimited projects</li>
                            <li class="list-group-item"><i class="fa fa-check"></i> 27/7 support</li>
                        </ul>
                        <div class="panel-footer">
                            <a class="btn btn-lg btn-block btn-danger" href="#">BUY NOW!</a>
                        </div>
                    </div>
                </div>
                <!-- /item -->

                <!-- item -->
                <div class="col-md-4 text-center">
                    <div class="panel panel-warning panel-pricing">
                        <div class="panel-heading">
                            <i class="fa fa-desktop"></i>
                            <h3>Plan 2</h3>
                        </div>
                        <div class="panel-body text-center">
                            <p><strong>$200 / Month</strong></p>
                        </div>
                        <ul class="list-group text-center">
                            <li class="list-group-item"><i class="fa fa-check"></i> Personal use</li>
                            <li class="list-group-item"><i class="fa fa-check"></i> Unlimited projects</li>
                            <li class="list-group-item"><i class="fa fa-check"></i> 27/7 support</li>
                        </ul>
                        <div class="panel-footer">
                            <a class="btn btn-lg btn-block btn-warning" href="#">BUY NOW!</a>
                        </div>
                    </div>
                </div>
                <!-- /item -->

                <!-- item -->
                <div class="col-md-4 text-center">
                    <div class="panel panel-success panel-pricing">
                        <div class="panel-heading">
                            <i class="fa fa-desktop"></i>
                            <h3>Plan 3</h3>
                        </div>
                        <div class="panel-body text-center">
                            <p><strong>$300 / Month</strong></p>
                        </div>
                        <ul class="list-group text-center">
                            <li class="list-group-item"><i class="fa fa-check"></i> Personal use</li>
                            <li class="list-group-item"><i class="fa fa-check"></i> Unlimited projects</li>
                            <li class="list-group-item"><i class="fa fa-check"></i> 27/7 support</li>
                        </ul>
                        <div class="panel-footer">
                            <a class="btn btn-lg btn-block btn-success" href="#">BUY NOW!</a>
                        </div>
                    </div>
                </div>
                <!-- /item -->

            </div>
        </div>
    </section>
            <!-- /Plans -->--%>
        <%-- <br />
            <br />
            <div id="gallery">
            </div>
            <div class="page-header">
                <div class="container">
                    <h1>
                        Gallery</h1>
                </div>
            </div>
            <!-- Projects Row -->
            <div class="row">
                <div class="col-md-4 portfolio-item">
                    <a href="#">
                        <img class="img-responsive" src="http://placehold.it/700x400" alt="">
                    </a>
                    <h3>
                        <a href="#">Project Name</a>
                    </h3>
                    <p>
                        So whether you are shopping for your wife’s birthday gift or looking for a new suit
                        to wear for that important meeting you know what to do.</p>
                </div>
                <div class="col-md-4 portfolio-item">
                    <a href="#">
                        <img class="img-responsive" src="http://placehold.it/700x400" alt="">
                    </a>
                    <h3>
                        <a href="#">Project Name</a>
                    </h3>
                    <p>
                        So whether you are shopping for your wife’s birthday gift or looking for a new suit
                        to wear for that important meeting you know what to do.</p>
                </div>
                <div class="col-md-4 portfolio-item">
                    <a href="#">
                        <img class="img-responsive" src="http://placehold.it/700x400" alt="">
                    </a>
                    <h3>
                        <a href="#">Project Name</a>
                    </h3>
                    <p>
                        So whether you are shopping for your wife’s birthday gift or looking for a new suit
                        to wear for that important meeting you know what to do.</p>
                </div>
            </div>
            <!-- /.row -->
            <!-- Projects Row -->
            <div class="row">
                <div class="col-md-4 portfolio-item">
                    <a href="#">
                        <img class="img-responsive" src="http://placehold.it/700x400" alt="">
                    </a>
                    <h3>
                        <a href="#">Project Name</a>
                    </h3>
                    <p>
                        So whether you are shopping for your wife’s birthday gift or looking for a new suit
                        to wear for that important meeting you know what to do.</p>
                </div>
                <div class="col-md-4 portfolio-item">
                    <a href="#">
                        <img class="img-responsive" src="http://placehold.it/700x400" alt="">
                    </a>
                    <h3>
                        <a href="#">Project Name</a>
                    </h3>
                    <p>
                        So whether you are shopping for your wife’s birthday gift or looking for a new suit
                        to wear for that important meeting you know what to do.</p>
                </div>
                <div class="col-md-4 portfolio-item">
                    <a href="#">
                        <img class="img-responsive" src="http://placehold.it/700x400" alt="">
                    </a>
                    <h3>
                        <a href="#">Project Name</a>
                    </h3>
                    <p>
                        So whether you are shopping for your wife’s birthday gift or looking for a new suit
                        to wear for that important meeting you know what to do.</p>
                </div>
            </div>
            <br />
            <br />
            <div class="well">
                <div class="text-right">
                    <a class="btn btn-success">Leave a Review</a>
                </div>
                <hr>
                <div class="row">
                    <div class="col-md-12">
                        <span class="glyphicon glyphicon-star"></span><span class="glyphicon glyphicon-star">
                        </span><span class="glyphicon glyphicon-star"></span><span class="glyphicon glyphicon-star">
                        </span><span class="glyphicon glyphicon-star-empty"></span>Anonymous <span class="pull-right">
                            10 days ago</span>
                        <p>
                            This product was great in terms of quality. I would definitely buy another!</p>
                    </div>
                </div>
                <hr>
                <div class="row">
                    <div class="col-md-12">
                        <span class="glyphicon glyphicon-star"></span><span class="glyphicon glyphicon-star">
                        </span><span class="glyphicon glyphicon-star"></span><span class="glyphicon glyphicon-star">
                        </span><span class="glyphicon glyphicon-star-empty"></span>Anonymous <span class="pull-right">
                            12 days ago</span>
                        <p>
                            I've alredy ordered another one!</p>
                    </div>
                </div>
                <hr>
                <div class="row">
                    <div class="col-md-12">
                        <span class="glyphicon glyphicon-star"></span><span class="glyphicon glyphicon-star">
                        </span><span class="glyphicon glyphicon-star"></span><span class="glyphicon glyphicon-star">
                        </span><span class="glyphicon glyphicon-star-empty"></span>Anonymous <span class="pull-right">
                            15 days ago</span>
                        <p>
                            I've seen some better than this, but not at this price. I definitely recommend this
                            item.</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <section>--%>

        <div id="contact" class="footer">
            <div class="container animated fadeInUpNow notransition">
                <div class="row">
                    <div class="col-md-3">
                        <h1 class="footerbrand">EDUCOM</h1>
                        <p>
                            Página de venta de apuntes impresos y digitales y venta de libros
                        </p>
                        <p>
                            Sumamente profesionales.
                        </p>

                    </div>
                    <div class="col-md-3">
                        <h1 class="title"><span class="colortext">E</span>ncuéntranos </h1>
                        <div class="footermap">
                            <p>
                                <strong>Direccion: </strong>Maestro M. Lopez esq. Cruz Roja
                            </p>
                            <p>
                                <strong>Teléfono: </strong>03514321231
                            </p>
                            <p>
                                <strong>Fax: </strong>03514351232
                            </p>
                            <p>
                                <strong>Correo: </strong>domingo@gmail.com
                            </p>

                        </div>
                    </div>

                    <div class="col-md-3">
                        <h1 class="title"><span class="colortext">M</span>ensaje <span class="font100">rápido</span></h1>
                        <div class="done">
                            <div class="alert alert-success">
                                <button type="button" class="close" data-dismiss="alert">×</button>
                                Tu mensaje ha sido enviado, muchas gracias.
                            </div>
                        </div>
                        <form method="post" action="contact.php" id="contactform">
                            <div class="form">
                                <input class="col-md-6" type="text" name="name" placeholder="Name">
                                <input class="col-md-6" type="text" name="email" placeholder="E-mail">
                                <textarea class="col-md-12" name="comment" rows="4" placeholder="Message"></textarea>
                                <input type="submit" id="submit" class="btn" value="Send">
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>


        </section>
    <!-- /footer section end-->
        <!-- jQuery -->
        <script src="js/jquery.js"></script>
        <!-- Bootstrap Core JavaScript -->
        <script src="js/bootstrap.min.js"></script>
        <script src="js/scrolling-nav.js" type="text/javascript"></script>
        <script src="js/jquery.easing.min.js" type="text/javascript"></script>
        <script type="text/javascript">
            jQuery(document).ready(function () {
                var offset = 220;
                var duration = 500;
                jQuery(window).scroll(function () {
                    if (jQuery(this).scrollTop() > offset) {
                        jQuery('.back-to-top').fadeIn(duration);
                    } else {
                        jQuery('.back-to-top').fadeOut(duration);
                    }
                });

                jQuery('.back-to-top').click(function (event) {
                    event.preventDefault();
                    jQuery('html, body').animate({ scrollTop: 0 }, duration);
                    return false;
                })
            });
        </script>
        <a href="#" class="back-to-top">UP</a>
    </form>
</body>
</html>
