using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Entidades;
using BaseDeDatos;

using System.Collections;
using mercadopago;

using System.IO;


namespace ProyectoAndrómeda
{
    public partial class Pago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Si se llego sin la factura
                if (Request.QueryString.Count < 0)
                {

                }
                MostrarTablaSegunSesion();
                CompletarDatos();
            }
        }

        //Mostrar u ocultar componentes segun si inicie sesion o no
        protected void MostrarTablaSegunSesion()
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                lbl_nombre.Visible = true;
                lbl_apellido.Visible = true;
                lbl_mail.Visible = true;
                txt_nombre.Visible = true;
                txt_apellido.Visible = true;
                txt_mail.Visible = true;

                lbl_total.Visible = true;
                lbl_totalTotal.Visible = true;

                lbl_inicioSesion.Visible = false;
                btn_iniciarSesionLogin.Visible = false;

                btn_pago.Visible = true;
            }
            else
            {
                lbl_nombre.Visible = false;
                lbl_apellido.Visible = false;
                lbl_mail.Visible = false;
                txt_nombre.Visible = false;
                txt_apellido.Visible = false;
                txt_mail.Visible = false;

                lbl_total.Visible = true;
                lbl_totalTotal.Visible = true;

                lbl_inicioSesion.Visible = true;
                btn_iniciarSesionLogin.Visible = true;

                btn_pago.Visible = false;
            }
        }

        //Completar los datos con la factura reciente
        protected void CompletarDatos()
        {
            int idFactura = int.Parse(Request.QueryString["fact"]);
            FacturaEntidadQuery factura = FacturaDao.ConsultarUnaFactura(idFactura);
            txt_nombre.Text = factura.nombreCliente;
            txt_apellido.Text = factura.apellidoCliente;
            txt_mail.Text = factura.mailCliente;
            lbl_totalTotal.Text = factura.total.ToString();
        }


        private void DescargarArchivo(int idApunte)
        {

            string filename = @"C:\Juan\Facultad\Habilitacion Profesional\GitHub - Andromeda\ProyectoAndromeda\ProyectoAndrómeda\ProyectoAndrómeda\archivos\" + idApunte + ".pdf"; ;
            FileInfo fileInfo = new FileInfo(filename);

            if (fileInfo.Exists)
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + fileInfo.Name);
                Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.Flush();
                Response.TransmitFile(fileInfo.FullName);
                Response.End();
            }
        }




        protected void GenerarPago()
        {

            //href = "<% Response.Write(((Hashtable)preference["response"])["sandbox_init_point"]); %>"

            MP mp = new MP("3505078557617488", "3J7yHycTVNr1Vkhf8LZLmqqbeuZFP7nq");
            mp.sandboxMode(false);

            string pref = "{\"items\":[{\"title\":\"EDUCOM\",\"quantity\":1,\"currency_id\":\"ARS\",\"unit_price\":" + lbl_totalTotal.Text + "}]}";
            Hashtable preference = mp.createPreference(pref);

            //Hashtable payment_info = mp.getPaymentInfo(Request["id"]);


            //if ((int)payment_info["status"] == 200)
            //    Response.Write(payment_info["response"]);

        }

        protected void consultarPago(object sender, EventArgs e)
        {
            MP mp = new MP("TEST - 3505078557617488 - 093014 - 425df6acc81bf5469720198d7307c132__LB_LC__ - 147119687");
            //  Hashtable payment = mp.get("/v1/payments/[ID]");

            //  Console.WriteLine(payment.ToString());
        }





        protected void btn_pago_Click(object sender, EventArgs e)
        {
            MP mp = new MP("3505078557617488", "3J7yHycTVNr1Vkhf8LZLmqqbeuZFP7nq");
            mp.sandboxMode(true);

            string pref = "{\"items\":[{\"title\":\"EDUCOM\",\"quantity\":1,\"currency_id\":\"ARS\",\"unit_price\":" + lbl_totalTotal.Text + "}]}";
            Hashtable preference = mp.createPreference(pref);

            string url = (((Hashtable)preference["response"])["sandbox_init_point"]).ToString();





            foreach (DictionaryEntry de in preference)
            {
                string keymercadopago = de.Key.ToString();
                string idmercadopago = de.Value.ToString();
                //Console.WriteLine("\t[{0}]:\t{1}\t{2}", i++, de.Key, de.Value);
                //Console.WriteLine();
            }


            Response.Write("<script>window.open('" + url + "','Popup','width=800,height=500')</script>");



        }

        protected void btn_inicioSesion_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btn_descargar_Click(object sender, EventArgs e)
        {
            List<ProductoCarrito> lista = (List<ProductoCarrito>)Session["carrito"];
            foreach (ProductoCarrito dato in lista)
            {
                if (dato.tipoItem == "Apunte" && ApunteDao.ConsultarTipoApunte(((ApunteEntidad)(dato.item)).idApunte) == "Digital")
                {
                    DescargarArchivo(((ApunteEntidad)(dato.item)).idApunte);
                }
            }

        }

    }
}
