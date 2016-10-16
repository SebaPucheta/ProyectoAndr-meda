using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaseDeDatos;
using Entidades;
using System.Data;
namespace ProyectoAndrómeda
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Listar los libros
                //dgv_libros.DataSource = ApunteDao.ConsultarTodosLosApuntes();
                //dgv_libros.DataBind();
                CargarComboUniversidad();
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        //Metodos para cargar los combos y grilla
        //Cargar combo Universidad
        protected void CargarComboUniversidad()
        {
            ddl_universidad.DataSource = UniversidadDao.ConsultarUniversidad();
            ddl_universidad.DataTextField = "nombreUniversidad";
            ddl_universidad.DataValueField = "idUniversidad";
            ddl_universidad.DataBind();
            ddl_universidad.Items.Insert(0, new ListItem("(Universidad)", "0"));
            ddl_universidad.SelectedIndex = 0;

        }

        //Cargar combo Facultad apartir de la universidad selecionada
        protected void CargarComboFacultad(int idUniversidad)
        {
            ddl_facultad.DataSource = FacultadDao.ConsultarFacultadXUniversidad(idUniversidad);
            ddl_facultad.DataTextField = "nombreFacultad";
            ddl_facultad.DataValueField = "idFacultad";
            ddl_facultad.DataBind();
            ddl_facultad.Items.Insert(0, new ListItem("(Facultad)", "0"));
            ddl_facultad.SelectedIndex = 0;
        }

        //Cargar combo Materia apartir de la facultad seleccionada
        protected void CargarComboCarrera(int idFacultad)
        {
            ddl_carrera.DataSource = CarreraDao.ConsultarCarreraXFacultad(idFacultad);
            ddl_carrera.DataTextField = "nombreCarrera";
            ddl_carrera.DataValueField = "idCarrera";
            ddl_carrera.DataBind();
            ddl_carrera.Items.Insert(0, new ListItem("(Carrera)", "0"));
            ddl_carrera.SelectedIndex = 0;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        //Metodos de eventos
        //Metodo de evento de seleccion de un item de un combo
        //Seleccion de un item del combo Universidad
        protected void ddl_universidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarComboFacultad(Convert.ToInt32(ddl_universidad.SelectedValue));
        }

        //Seleccion de un item del combo Facultad
        protected void ddl_facultad_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarComboCarrera(Convert.ToInt32(ddl_facultad.SelectedValue));
        }







        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ////Al cambiar de página del paginado
            //dgv_libros.PageIndex = e.NewPageIndex;
            ////Listar
            //dgv_libros.DataSource = LibroDao.ConsultarLibros();
            //dgv_libros.DataBind();
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
            //List<ApunteEntidadQuery> listaApuntes = ApunteDao.ConsultarApunteXFiltroCarrera("", "", "", "", CarreraDao.ConsultarCarreraXDescripcion("Sistemas").nombreCarrera);
            //dgv_libros.DataSource = listaApuntes;
            //dgv_libros.DataBind();
        }
        protected void btn_filtroQuimica_onClick(object sender, EventArgs e)
        {
            //List<ApunteEntidadQuery> listaApuntes = ApunteDao.ConsultarApunteXFiltroCarrera("", "", "", "", CarreraDao.ConsultarCarreraXDescripcion("Quimica").nombreCarrera);
            //dgv_libros.DataSource = listaApuntes;
            //dgv_libros.DataBind();
        }
        protected void btn_filtroCivil_onClick(object sender, EventArgs e)
        {
            //List<ApunteEntidadQuery> listaApuntes = ApunteDao.ConsultarApunteXFiltroCarrera("", "", "", "", CarreraDao.ConsultarCarreraXDescripcion("Civil").nombreCarrera);
            //dgv_libros.DataSource = listaApuntes;
            //dgv_libros.DataBind();
        }
        protected void btn_filtroMecanica_onClick(object sender, EventArgs e)
        {
            //List<ApunteEntidadQuery> listaApuntes = ApunteDao.ConsultarApunteXFiltroCarrera("", "", "", "", CarreraDao.ConsultarCarreraXDescripcion("Mecanica").nombreCarrera);
            //dgv_libros.DataSource = listaApuntes;
            //dgv_libros.DataBind();
        }

        protected void btn_primero_Click(object sender, EventArgs e)
        {
            List<MateriaEntidad> listaMateria = MateriaDao.ConsultarMateriaXCarreraXNivelCursado(int.Parse(ddl_carrera.SelectedValue), 1);
            DataTable tabla = new DataTable();
            DataRow fila;

            //Creo las columnas de la tabla
            tabla.Columns.Add("idMateria", typeof(int));
            tabla.Columns.Add("nombreMateria", typeof(string));

            foreach (MateriaEntidad materia in listaMateria)
            {
                fila = tabla.NewRow();

                fila[0] = materia.idMateria;
                fila[1] = materia.nombreMateria;

                tabla.Rows.Add(fila);
            }

            DataView dataView = new DataView(tabla);

            dgv_primero.DataKeyNames = new string[] { "idMateria" };
            dgv_primero.DataSource = dataView;
            dgv_primero.DataBind();
        }


        protected void btn_segundo_Click(object sender, EventArgs e)
        {
            List<MateriaEntidad> listaMateria = MateriaDao.ConsultarMateriaXCarreraXNivelCursado(int.Parse(ddl_carrera.SelectedValue), 2);
            DataTable tabla = new DataTable();
            DataRow fila;

            //Creo las columnas de la tabla
            tabla.Columns.Add("idMateria", typeof(int));
            tabla.Columns.Add("nombreMateria", typeof(string));

            foreach (MateriaEntidad materia in listaMateria)
            {
                fila = tabla.NewRow();

                fila[0] = materia.idMateria;
                fila[1] = materia.nombreMateria;

                tabla.Rows.Add(fila);
            }

            DataView dataView = new DataView(tabla);

            dgv_segundo.DataKeyNames = new string[] { "idMateria" };
            dgv_segundo.DataSource = dataView;
            dgv_segundo.DataBind();
        }

        protected void btn_tercero_Click(object sender, EventArgs e)
        {
            List<MateriaEntidad> listaMateria = MateriaDao.ConsultarMateriaXCarreraXNivelCursado(int.Parse(ddl_carrera.SelectedValue), 3);
            DataTable tabla = new DataTable();
            DataRow fila;

            //Creo las columnas de la tabla
            tabla.Columns.Add("idMateria", typeof(int));
            tabla.Columns.Add("nombreMateria", typeof(string));

            foreach (MateriaEntidad materia in listaMateria)
            {
                fila = tabla.NewRow();

                fila[0] = materia.idMateria;
                fila[1] = materia.nombreMateria;

                tabla.Rows.Add(fila);
            }

            DataView dataView = new DataView(tabla);

            dgv_tercero.DataKeyNames = new string[] { "idMateria" };
            dgv_tercero.DataSource = dataView;
            dgv_tercero.DataBind();
        }

        protected void btn_cuarto_Click(object sender, EventArgs e)
        {
            List<MateriaEntidad> listaMateria = MateriaDao.ConsultarMateriaXCarreraXNivelCursado(int.Parse(ddl_carrera.SelectedValue), 4);
            DataTable tabla = new DataTable();
            DataRow fila;

            //Creo las columnas de la tabla
            tabla.Columns.Add("idMateria", typeof(int));
            tabla.Columns.Add("nombreMateria", typeof(string));

            foreach (MateriaEntidad materia in listaMateria)
            {
                fila = tabla.NewRow();

                fila[0] = materia.idMateria;
                fila[1] = materia.nombreMateria;

                tabla.Rows.Add(fila);
            }

            DataView dataView = new DataView(tabla);

            dgv_cuarto.DataKeyNames = new string[] { "idMateria" };
            dgv_cuarto.DataSource = dataView;
            dgv_cuarto.DataBind();
        }

        protected void btn_quinto_Click(object sender, EventArgs e)
        {
            List<MateriaEntidad> listaMateria = MateriaDao.ConsultarMateriaXCarreraXNivelCursado(int.Parse(ddl_carrera.SelectedValue), 5);
            DataTable tabla = new DataTable();
            DataRow fila;

            //Creo las columnas de la tabla
            tabla.Columns.Add("idMateria", typeof(int));
            tabla.Columns.Add("nombreMateria", typeof(string));

            foreach (MateriaEntidad materia in listaMateria)
            {
                fila = tabla.NewRow();

                fila[0] = materia.idMateria;
                fila[1] = materia.nombreMateria;

                tabla.Rows.Add(fila);
            }

            DataView dataView = new DataView(tabla);

            dgv_quinto.DataKeyNames = new string[] { "idMateria" };
            dgv_quinto.DataSource = dataView;
            dgv_quinto.DataBind();
        }

        protected void btn_sexto_Click(object sender, EventArgs e)
        {
            List<MateriaEntidad> listaMateria = MateriaDao.ConsultarMateriaXCarreraXNivelCursado(int.Parse(ddl_carrera.SelectedValue), 6);
            DataTable tabla = new DataTable();
            DataRow fila;

            //Creo las columnas de la tabla
            tabla.Columns.Add("idMateria", typeof(int));
            tabla.Columns.Add("nombreMateria", typeof(string));

            foreach (MateriaEntidad materia in listaMateria)
            {
                fila = tabla.NewRow();

                fila[0] = materia.idMateria;
                fila[1] = materia.nombreMateria;

                tabla.Rows.Add(fila);
            }

            DataView dataView = new DataView(tabla);

            dgv_sexto.DataKeyNames = new string[] { "idMateria" };
            dgv_sexto.DataSource = dataView;
            dgv_sexto.DataBind();
        }

        protected void btn_filtrar_Click(object sender, EventArgs e)
        {
            List<int> listaIdMateria = new List<int>();
            listaIdMateria.AddRange(ListarIdMateriaSeleccionada(dgv_primero));
            listaIdMateria.AddRange(ListarIdMateriaSeleccionada(dgv_segundo));
            listaIdMateria.AddRange(ListarIdMateriaSeleccionada(dgv_tercero));
            listaIdMateria.AddRange(ListarIdMateriaSeleccionada(dgv_cuarto));
            listaIdMateria.AddRange(ListarIdMateriaSeleccionada(dgv_quinto));
            listaIdMateria.AddRange(ListarIdMateriaSeleccionada(dgv_sexto));

            if (chk_apunte.Checked)
            {
                List<ApunteEntidadQuery> listaApunte = ListarApuntesXMaterias(listaIdMateria);
            }
            if (chk_libro.Checked)
            {
                List<LibroEntidadQuery> listaLibro = ListarLibroXMaterias(listaIdMateria);
            }
        }

        protected List<int> ListarIdMateriaSeleccionada(GridView grilla)
        {
            List<int> listaIdMateria = new List<int>();
            foreach (GridViewRow fila in grilla.Rows)
            {

                CheckBox seleccion = ((CheckBox)fila.FindControl("chk_seleccionado"));
                if (seleccion.Checked)
                {
                    listaIdMateria.Add(Convert.ToInt32(fila.Cells[0].Text));
                }
            }

            return listaIdMateria;
        }

        protected List<ApunteEntidadQuery> ListarApuntesXMaterias(List<int> listaMateria)
        {
            List<ApunteEntidadQuery> listaApunte = new List<ApunteEntidadQuery>();

            foreach (int idMateria in listaMateria)
            {
                listaApunte.Add(ApunteDao.ConsultarApunteXMateria(idMateria));
            }

            return listaApunte;
        }
        protected List<LibroEntidadQuery> ListarLibroXMaterias(List<int> listaMateria)
        {
            List<LibroEntidadQuery> listaLibro = new List<LibroEntidadQuery>();

            foreach (int idMateria in listaMateria)
            {
                listaLibro.Add(LibroDao.ConsultarLibroXMateria(idMateria));
            }

            return listaLibro;
        }
    }
}