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
using NUnit.Framework;
using System.Net;

using System.IO;
using System.Data;

//Para consultar estados cURL
using System.Net;


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
                //MostrarTablaSegunSesion();
                CompletarDatos();
            }
        }

        protected MP getMP()
        {
            //Pongo CLIENT_ID y CLIENT_SECRET -- Aplicacion: 233620557 -- mp-app-233620557
            MP mp = new MP("4180047074500934", "oTJvHcjBcmbO73LsYTNseZhUmzaNYkx1");
            mp.sandboxMode(true); //RECORDAR QUE ESTA EN CARRITO.CS
            return mp;
            
            //Claves en Modo SANDBOX
            //Public key: TEST-3211f4aa-1933-4df1-9522-61746d226942
            //Access token: TEST-3505078557617488-093014-425df6acc81bf5469720198d7307c132__LB_LC__-147119687
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

        protected string getNumeroIDMercadoPago()
        {
            MP mp = getMP();

            //Busco la id de la factura de MP en la base de datos
            int idFacturaAConsultar = int.Parse(Request.QueryString["fact"]);
            string idMP = (FacturaDao.ConsultarUnaFactura(idFacturaAConsultar)).idFacturaMP;

            return idMP;
        }

        protected void ConsultarPago()
        {
            MP mp = getMP();
            string idMP = getNumeroIDMercadoPago();

            //Consulto la preferencia del id de Mercado Pago de la factura
            Hashtable preference = mp.getPreference(idMP);

            //Para abrir la ventana de la boleta para pagar
            string url = (((Hashtable)preference["response"])["sandbox_init_point"]).ToString();

            //Abrir en una ventana par apagar por Mercado Pago
            Response.Write("<script>window.open('" + url + "','Popup','width=800,height=500')</script>");
        }

        

        protected void VerEstado()
        {
            MP mp = new MP("TEST-3505078557617488-093014-425df6acc81bf5469720198d7307c132__LB_LC__-147119687");

            ////Prueba 1
            string id = getNumeroIDMercadoPago();
            //Hashtable payment = mp.get("/v1/payments/" + id, true);
            //Response.Write("<script>window.alert('" + ((Hashtable)((Hashtable)payment["response"])["payments"])["status"] + "')</script>");


            Dictionary<String, String> filters = new Dictionary<String, String>();
            filters.Add("status", "approved");

            Hashtable resultado = mp.get("/v1/payments/" + id, filters);

            //ESTO NO ANDA
            //Response.Write("<script>window.alert('" + (((Hashtable)resultado["response"])["external_reference"]).ToString() + "')</script>");
        }


        //////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////EVENTOS/////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////

        //Boton de "Pagar"
        protected void btn_pago_Click(object sender, EventArgs e)
        {
            ConsultarPago();
        }


        //Boton de "Consultar pago" que NO VA EN REALIDAD
        protected void Button1_Click(object sender, EventArgs e)
        {
            VerEstado();
        }




    }
}
