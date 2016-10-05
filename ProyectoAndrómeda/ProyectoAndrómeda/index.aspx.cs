using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaseDeDatos;
using Entidades;

public partial class preview_dotnet_templates_with_out_masterpages_Shop_item_index : System.Web.UI.Page
{

    //ItemEntidad libro = new ();

    protected void Page_Load(object sender, EventArgs e)
    {
        //Si la pagina no ha ido al servidor
        if (!IsPostBack)
        {
            //Listar los libros
            //dgv_libros.DataSource = ApunteDao.ConsultarTodosLosApuntes();
            //dgv_libros.DataBind();
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //Al cambiar de página del paginado
        dgv_libros.PageIndex = e.NewPageIndex;
        //Listar
        dgv_libros.DataSource = LibroDao.ConsultarLibros();
        dgv_libros.DataBind();
    }

    protected void btn_seleccionar_Click(object sender, EventArgs e)
    {
        ////Capturo la celda seleccionada
        //DataControlFieldCell f = (DataControlFieldCell)((Control)sender).Parent;
        ////Capturar cada uno de los valores de sus labels
        //string cod = (f.FindControl("lbl_codigo") as Label).Text;
        //string nom = (f.FindControl("lbl_nombre") as Label).Text;
        //string aut = (f.FindControl("lbl_autor") as Label).Text;
        //string pre = (f.FindControl("lbl_precio") as Label).Text;

        ////Cookie que envie datos
        //HttpCookie dato = new HttpCookie("dato");
        //dato.Values["codigo"] = cod;
        //dato.Values["nombre"] = nom;
        //dato.Values["autor"] = aut;
        //dato.Values["precio"] = pre;
        ////Enviar al cookie
        //Response.Cookies.Add(dato);
       

        ////Publicar
        //lbl_codigo.Text = Request.Cookies["dato"].Values["codigo"];
        //lbl_nombre.Text = Request.Cookies["dato"].Values["nombre"];
        //lbl_autor.Text = Request.Cookies["dato"].Values["autor"];
        //lbl_precio.Text = Request.Cookies["dato"].Values["precio"];

        ////Imagen
        //Image1.ImageUrl = string.Format("imagenes/{0}.jpg", lbl_codigo.Text);

    }

    protected void btn_filtroSistemas_onClick(object sender, EventArgs e)
    {
        List<ApunteEntidadQuery> listaApuntes = ApunteDao.ConsultarApunteXFiltroCarrera("", "", "", "", CarreraDao.ConsultarCarreraXDescripcion("Sistemas").nombreCarrera);
        dgv_libros.DataSource = listaApuntes;
        dgv_libros.DataBind();
    }
    protected void btn_filtroQuimica_onClick(object sender, EventArgs e)
    {
        List<ApunteEntidadQuery> listaApuntes = ApunteDao.ConsultarApunteXFiltroCarrera("", "", "", "", CarreraDao.ConsultarCarreraXDescripcion("Quimica").nombreCarrera);
        dgv_libros.DataSource = listaApuntes;
        dgv_libros.DataBind();
    }
    protected void btn_filtroCivil_onClick(object sender, EventArgs e)
    {
        List<ApunteEntidadQuery> listaApuntes = ApunteDao.ConsultarApunteXFiltroCarrera("", "", "", "", CarreraDao.ConsultarCarreraXDescripcion("Civil").nombreCarrera);
        dgv_libros.DataSource = listaApuntes;
        dgv_libros.DataBind();
    }
    protected void btn_filtroMecanica_onClick(object sender, EventArgs e)
    {
        List<ApunteEntidadQuery> listaApuntes = ApunteDao.ConsultarApunteXFiltroCarrera("", "", "", "", CarreraDao.ConsultarCarreraXDescripcion("Mecanica").nombreCarrera);
        dgv_libros.DataSource = listaApuntes;
        dgv_libros.DataBind();
    }
}