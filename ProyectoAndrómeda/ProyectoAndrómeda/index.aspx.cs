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
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btn_filtroSistemas_onClick(object sender, EventArgs e)
    {
        List<ApunteEntidadQuery> listaApuntes = ApunteDao.ConsultarApunteXFiltroCarrera("", "", "", "", CarreraDao.ConsultarCarreraXDescripcion("Sistemas").nombreCarrera);
    }
    protected void btn_filtroQuimica_onClick(object sender, EventArgs e)
    {
        List<ApunteEntidadQuery> listaApuntes = ApunteDao.ConsultarApunteXFiltroCarrera("", "", "", "", CarreraDao.ConsultarCarreraXDescripcion("Quimica").nombreCarrera);
    }
    protected void btn_filtroCivil_onClick(object sender, EventArgs e)
    {
        List<ApunteEntidadQuery> listaApuntes = ApunteDao.ConsultarApunteXFiltroCarrera("", "", "", "", CarreraDao.ConsultarCarreraXDescripcion("Civil").nombreCarrera);
    }
    protected void btn_filtroMecanica_onClick(object sender, EventArgs e)
    {
        List<ApunteEntidadQuery> listaApuntes = ApunteDao.ConsultarApunteXFiltroCarrera("", "", "", "", CarreraDao.ConsultarCarreraXDescripcion("Mecanica").nombreCarrera);
    }
}