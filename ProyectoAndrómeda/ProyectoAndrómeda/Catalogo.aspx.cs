using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaseDeDatos;
using Entidades;
using System.Data;
using System.Drawing;

namespace ProyectoAndrómeda
{
    public partial class Catalogo : System.Web.UI.Page
    {

        /////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////PAGINADO APUNTE////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////
        readonly PagedDataSource _pgsource = new PagedDataSource();
        int _firstIndex, _lastIndex;
        private int _pageSize = 6;
        private int CurrentPage
        {
            get
            {
                if (ViewState["CurrentPage"] == null)
                {
                    return 0;
                }
                return ((int)ViewState["CurrentPage"]);
            }
            set
            {
                ViewState["CurrentPage"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                return;


            Session["listaApuntes"] = ApunteDao.ConsultarApuntesSinFiltros();
            Session["listaLibros"] = LibroDao.ConsultarLibros();
            BindDataIntoRepeater((List<ApunteEntidadQuery>)Session["listaApuntes"]);
            BindDataIntoRepeater2((List<LibroEntidadQuery>)Session["listaLibros"]);
            //Filtro
            CargarComboUniversidad();


        }

        private void cargarPortadas()
        {
            //ImageUrl='<%# Eval("idApunte", "imagenes/apunte/{0}.jpg") %>'
            foreach (RepeaterItem dato in repeater_apuntes.Items)
            {
                int id = int.Parse(((TextBox)dato.FindControl("txt_id")).Text);
                string path = ApunteDao.ConsultarRutaPortada(id);
                if (path != "")
                {
                    ((System.Web.UI.WebControls.Image)dato.FindControl("rep_imagen")).ImageUrl = path;
                }
                else
                {
                    ((System.Web.UI.WebControls.Image)dato.FindControl("rep_imagen")).ImageUrl = "imagenes/sinPortada.png";
                }
            }

            //ImageUrl='<%# Eval("idApunte", "imagenes/apunte/{0}.jpg") %>'
            foreach (RepeaterItem dato in repeater_libros.Items)
            {
                int id = int.Parse(((TextBox)dato.FindControl("txt_id")).Text);
                string path = LibroDao.ConsultarRutaPortada(id);
                if (path != "")
                {
                    ((System.Web.UI.WebControls.Image)dato.FindControl("rep_imagen")).ImageUrl = path;
                }
                else
                {
                    ((System.Web.UI.WebControls.Image)dato.FindControl("rep_imagen")).ImageUrl = "imagenes/sinPortada.png";
                }
            }
        }

        // Bind PagedDataSource into Repeater
        private void BindDataIntoRepeater(List<ApunteEntidadQuery> lista)
        {
            _pgsource.DataSource = lista;
            _pgsource.AllowPaging = true;
            // Number of items to be displayed in the Repeater
            _pgsource.PageSize = _pageSize;
            _pgsource.CurrentPageIndex = CurrentPage;
            // Keep the Total pages in View State
            ViewState["TotalPages"] = _pgsource.PageCount;
            // Example: "Page 1 of 10"
            lblpage.Text = "Page " + (CurrentPage + 1) + " of " + _pgsource.PageCount;
            // Enable First, Last, Previous, Next buttons
            lbPrevious.Enabled = !_pgsource.IsFirstPage;
            lbNext.Enabled = !_pgsource.IsLastPage;
            lbFirst.Enabled = !_pgsource.IsFirstPage;
            lbLast.Enabled = !_pgsource.IsLastPage;

            // Bind data into repeater
            repeater_apuntes.DataSource = _pgsource;
            repeater_apuntes.DataBind();

            foreach (RepeaterItem item in repeater_apuntes.Items)
            {
                TextBox txtid = (TextBox)item.FindControl("txt_id");
                int idIdentificado = int.Parse(txtid.Text);
                if(ApunteDao.ConsultarTipoApunte(idIdentificado) == "Digital" )
                {
                    LinkButton img = (LinkButton)item.FindControl("img_digital");
                    img.Visible = true;
                }
            }

            // Call the function to do paging
            HandlePaging();
        }

        private void HandlePaging()
        {
            var dt = new DataTable();
            dt.Columns.Add("PageIndex"); //Start from 0
            dt.Columns.Add("PageText"); //Start from 1

            _firstIndex = CurrentPage - 5;
            if (CurrentPage > 5)
                _lastIndex = CurrentPage + 5;
            else
                _lastIndex = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_lastIndex > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _lastIndex = Convert.ToInt32(ViewState["TotalPages"]);
                _firstIndex = _lastIndex - 10;
            }

            if (_firstIndex < 0)
                _firstIndex = 0;

            // Now creating page number based on above first and last page index
            for (var i = _firstIndex; i < _lastIndex; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }

            rptPaging.DataSource = dt;
            rptPaging.DataBind();
        }

        protected void lbFirst_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            BindDataIntoRepeater((List<ApunteEntidadQuery>)Session["listaApuntes"]);
        }
        protected void lbLast_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            BindDataIntoRepeater((List<ApunteEntidadQuery>)Session["listaApuntes"]);
        }
        protected void lbPrevious_Click(object sender, EventArgs e)
        {
            CurrentPage -= 1;
            BindDataIntoRepeater((List<ApunteEntidadQuery>)Session["listaApuntes"]);
        }
        protected void lbNext_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            BindDataIntoRepeater((List<ApunteEntidadQuery>)Session["listaApuntes"]);
        }

        protected void rptPaging_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            BindDataIntoRepeater((List<ApunteEntidadQuery>)Session["listaApuntes"]);
        }

        protected void rptPaging_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            var lnkPage = (LinkButton)e.Item.FindControl("lbPaging");
            if (lnkPage.CommandArgument != CurrentPage.ToString()) return;
            lnkPage.Enabled = false;
            lnkPage.BackColor = Color.FromName("#BDBDBD");
        }

        /////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////PAGINADO LIBRO/////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////
        readonly PagedDataSource _pgsource2 = new PagedDataSource();
        int _firstIndex2, _lastIndex2;
        private int _pageSize2 = 6;
        private int CurrentPage2
        {
            get
            {
                if (ViewState["CurrentPage2"] == null)
                {
                    return 0;
                }
                return ((int)ViewState["CurrentPage2"]);
            }
            set
            {
                ViewState["CurrentPage2"] = value;
            }
        }

        // Bind PagedDataSource into Repeater
        private void BindDataIntoRepeater2(List<LibroEntidadQuery> lista)
        {
            _pgsource2.DataSource = lista;
            _pgsource2.AllowPaging = true;
            // Number of items to be displayed in the Repeater
            _pgsource2.PageSize = _pageSize2;
            _pgsource2.CurrentPageIndex = CurrentPage2;
            // Keep the Total pages in View State
            ViewState["TotalPages2"] = _pgsource2.PageCount;
            // Example: "Page 1 of 10"
            lblpage2.Text = "Page " + (CurrentPage2 + 1) + " of " + _pgsource2.PageCount;
            // Enable First, Last, Previous, Next buttons
            lbPrevious2.Enabled = !_pgsource2.IsFirstPage;
            lbNext2.Enabled = !_pgsource2.IsLastPage;
            lbFirst2.Enabled = !_pgsource2.IsFirstPage;
            lbLast2.Enabled = !_pgsource2.IsLastPage;

            // Bind data into repeater
            repeater_libros.DataSource = _pgsource2;
            repeater_libros.DataBind();

            // Call the function to do paging
            HandlePaging2();
        }

        private void HandlePaging2()
        {
            var dt2 = new DataTable();
            dt2.Columns.Add("PageIndex"); //Start from 0
            dt2.Columns.Add("PageText"); //Start from 1

            _firstIndex2 = CurrentPage2 - 5;
            if (CurrentPage2 > 5)
                _lastIndex2 = CurrentPage2 + 5;
            else
                _lastIndex2 = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_lastIndex2 > Convert.ToInt32(ViewState["TotalPages2"]))
            {
                _lastIndex2 = Convert.ToInt32(ViewState["TotalPages2"]);
                _firstIndex2 = _lastIndex2 - 10;
            }

            if (_firstIndex2 < 0)
                _firstIndex2 = 0;

            // Now creating page number based on above first and last page index
            for (var i = _firstIndex2; i < _lastIndex2; i++)
            {
                var dr2 = dt2.NewRow();
                dr2[0] = i;
                dr2[1] = i + 1;
                dt2.Rows.Add(dr2);
            }

            rptPaging2.DataSource = dt2;
            rptPaging2.DataBind();
        }

        protected void lbFirst2_Click(object sender, EventArgs e)
        {
            CurrentPage2 = 0;
            BindDataIntoRepeater2((List<LibroEntidadQuery>)Session["listaLibros"]);
        }
        protected void lbLast2_Click(object sender, EventArgs e)
        {
            CurrentPage2 = (Convert.ToInt32(ViewState["TotalPages2"]) - 1);
            BindDataIntoRepeater2((List<LibroEntidadQuery>)Session["listaLibros"]);
        }
        protected void lbPrevious2_Click(object sender, EventArgs e)
        {
            CurrentPage2 -= 1;
            BindDataIntoRepeater2((List<LibroEntidadQuery>)Session["listaLibros"]);
        }
        protected void lbNext2_Click(object sender, EventArgs e)
        {
            CurrentPage2 += 1;
            BindDataIntoRepeater2((List<LibroEntidadQuery>)Session["listaLibros"]);
        }

        protected void rptPaging2_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage2 = Convert.ToInt32(e.CommandArgument.ToString());
            BindDataIntoRepeater2((List<LibroEntidadQuery>)Session["listaLibros"]);
        }

        protected void rptPaging2_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            var lnkPage2 = (LinkButton)e.Item.FindControl("lbPaging2");
            if (lnkPage2.CommandArgument != CurrentPage2.ToString()) return;
            lnkPage2.Enabled = false;
            lnkPage2.BackColor = Color.FromName("#BDBDBD");
        }


        ///////////////////////////////////////////////////////////////////////////////////// ^
        ///////////////////////////CATALOGO APUNTE/////////////////////////////////////////// |
        ///////////////////////////////////////////////////////////////////////////////////// |

        //Eventos de clic en boton "Ver" y el "Carrtio de compras"
        protected void repeater_apuntes_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "ver":
                    int id = int.Parse(((TextBox)e.Item.FindControl("txt_id")).Text);
                    string dir = "DetalleItem.aspx?idLibro=0&idApunte=" + id.ToString();
                    Response.Redirect(dir);
                    break;

                case "carrito":
                    int idCarrito = int.Parse(((TextBox)e.Item.FindControl("txt_id")).Text);
                    string dirCarrito = "Carrito.aspx?idLibro=0&idApunte=" + idCarrito.ToString();
                    Response.Redirect(dirCarrito);
                    break;
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////// ^
        ///////////////////////////CATALOGO LIBRO//////////////////////////////////////////// |
        ///////////////////////////////////////////////////////////////////////////////////// |

        //Eventos de clic en boton "Ver" y el "Carrtio de compras" de libro
        protected void repeater_libros_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "ver":
                    int id = int.Parse(((TextBox)e.Item.FindControl("txt_id")).Text);
                    string dir = "DetalleItem.aspx?idApunte=0&idLibro=" + id.ToString();
                    Response.Redirect(dir);
                    break;

                case "carrito":
                    int idCarrito = int.Parse(((TextBox)e.Item.FindControl("txt_id")).Text);
                    string dirCarrito = "Carrito.aspx?idApunte=0&idLibro=" + idCarrito.ToString();
                    Response.Redirect(dirCarrito);
                    break;
            }
        }




        ///////////////////////////////////////////////////////////////////////////////////// ^
        ///////////////////////////FILTROS/////////////////////////////////////////////////// |
        ///////////////////////////////////////////////////////////////////////////////////// |

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

        protected void btn_filtroSistemas_onClick(object sender, EventArgs e)
        {
            List<ApunteEntidadQuery> listaApuntes = ApunteDao.ConsultarApunteXFiltroCarrera("", "", "", "", CarreraDao.ConsultarCarreraXDescripcion("Sistemas").nombreCarrera);
            repeater_apuntes.DataSource = listaApuntes;
            repeater_apuntes.DataBind();
        }
        protected void btn_filtroQuimica_onClick(object sender, EventArgs e)
        {
            List<ApunteEntidadQuery> listaApuntes = ApunteDao.ConsultarApunteXFiltroCarrera("", "", "", "", CarreraDao.ConsultarCarreraXDescripcion("Quimica").nombreCarrera);
            repeater_apuntes.DataSource = listaApuntes;
            repeater_apuntes.DataBind();
        }
        protected void btn_filtroCivil_onClick(object sender, EventArgs e)
        {
            List<ApunteEntidadQuery> listaApuntes = ApunteDao.ConsultarApunteXFiltroCarrera("", "", "", "", CarreraDao.ConsultarCarreraXDescripcion("Civil").nombreCarrera);
            repeater_apuntes.DataSource = listaApuntes;
            repeater_apuntes.DataBind();
        }
        protected void btn_filtroMecanica_onClick(object sender, EventArgs e)
        {
            List<ApunteEntidadQuery> listaApuntes = ApunteDao.ConsultarApunteXFiltroCarrera("", "", "", "", CarreraDao.ConsultarCarreraXDescripcion("Mecanica").nombreCarrera);
            repeater_apuntes.DataSource = listaApuntes;
            repeater_apuntes.DataBind();
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
            Session["listaApuntes"] = new List<ApunteEntidadQuery>();
            Session["listaLibros"] = new List<LibroEntidadQuery>();

            List<int> listaIdMateria = new List<int>();
            listaIdMateria.AddRange(ListarIdMateriaSeleccionada(dgv_primero));
            listaIdMateria.AddRange(ListarIdMateriaSeleccionada(dgv_segundo));
            listaIdMateria.AddRange(ListarIdMateriaSeleccionada(dgv_tercero));
            listaIdMateria.AddRange(ListarIdMateriaSeleccionada(dgv_cuarto));
            listaIdMateria.AddRange(ListarIdMateriaSeleccionada(dgv_quinto));
            listaIdMateria.AddRange(ListarIdMateriaSeleccionada(dgv_sexto));

            //Limpio las grillas
            repeater_apuntes.DataSource = null;
            repeater_apuntes.DataBind();
            repeater_libros.DataSource = null;
            repeater_libros.DataBind();

            if (chk_apunte.Checked)
            {
                List<ApunteEntidadQuery> listaApunte = ListarApuntesXMaterias(listaIdMateria);
                Session["listaApuntes"] = listaApunte;
                BindDataIntoRepeater((List<ApunteEntidadQuery>)Session["listaApuntes"]);
            }
            if (chk_libro.Checked)
            {
                List<LibroEntidadQuery> listaLibro = ListarLibroXMaterias(listaIdMateria);
                Session["listaLibros"] = listaLibro;
                BindDataIntoRepeater2((List<LibroEntidadQuery>)Session["listaLibros"]);
            }
        }

        protected List<int> ListarIdMateriaSeleccionada(GridView grilla)
        {
            List<int> listaIdMateria = new List<int>();
            foreach (GridViewRow fila in grilla.Rows)
            {
                int indice = fila.RowIndex;
                CheckBox seleccion = ((CheckBox)fila.FindControl("chk_seleccionado"));
                if (seleccion.Checked)
                {
                    listaIdMateria.Add((Int32)grilla.DataKeys[indice].Value);
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
