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

using System.IO;
using System.Data;

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


        protected void ConsultarPago()
        {
            MP mp = new MP("3505078557617488", "3J7yHycTVNr1Vkhf8LZLmqqbeuZFP7nq");

            Dictionary<String, String> filters = new Dictionary<String, String>();

            filters.Add("status", "approved");

            Hashtable searchResult = mp.searchPayment(filters, 0, 10);


            Response.Write(searchResult);

            Label1.Text = "";
            foreach(var id in searchResult.Keys)
            {
                Label1.Text = Label1.Text + " / " + searchResult[id].ToString() + " key:" + id.ToString();
            }

           



            //foreach (var id in searchResult.Keys)
            //{
            //    if (searchResult[id] is int)
            //        continue;
            //    Hashtable tabla2 = (System.Collections.Hashtable)searchResult[id];
            //    foreach (var id2 in tabla2.Keys)
            //    {
            //        if (tabla2[id2] is System.Collections.ArrayList)
            //            continue;

            //        Hashtable tabla3 = (System.Collections.Hashtable)tabla2[id2];
            //        foreach(var id3 in tabla3.Keys)
            //        {
            //            Label1.Text = Label1.Text + " / " + tabla2[id2].ToString();
            //        }
            //    }
            //}




            mp.getAccessToken();

            //Response.Write(searchResult);

            //foreach (fila in searchResult)



        }

        protected void GenerarPago()
        {

            //href = "<% Response.Write(((Hashtable)preference["response"])["sandbox_init_point"]); %>"

            MP mp = new MP("3505078557617488", "3J7yHycTVNr1Vkhf8LZLmqqbeuZFP7nq");
            mp.sandboxMode(false);

            string pref = "{\"items\":[{\"title\":\"EDUCOM\",\"quantity\":1,\"currency_id\":\"ARS\",\"unit_price\":" + lbl_totalTotal.Text + "}]}";
            Hashtable preference = mp.createPreference(pref);


            Label1.Text = Request.QueryString["id"].ToString();

            Hashtable payment_info = mp.getPaymentInfo(Request.QueryString["id"]);

            if ((int)payment_info["status"] == 200)
                Response.Write(payment_info["response"]);

        }




    
        protected void btn_pago_Click(object sender, EventArgs e)
        {
            MP mp = new MP("3505078557617488", "3J7yHycTVNr1Vkhf8LZLmqqbeuZFP7nq");
            mp.sandboxMode(true);

            string pref = "{\"items\":[{\"title\":\"EDUCOM\",\"quantity\":1,\"currency_id\":\"ARS\",\"unit_price\":" + lbl_totalTotal.Text + "}]}";
            Hashtable preference = mp.createPreference(pref);

            string url = (((Hashtable)preference["response"])["sandbox_init_point"]).ToString();
            //Response.Write("<script>window.open('" + url + "','Popup','width=800,height=500')</script>");


            string idPago = url;
            string[] urlCortada = idPago.Split('=');
            string idPagoPosta = urlCortada[1];

            Label1.Text = idPagoPosta;


            Hashtable consulta = mp.getPreference(idPagoPosta);
            
            string urlConsulta = (((Hashtable)consulta["response"])["sandbox_init_point"]).ToString();
            //Response.Write("<script>window.open('" + urlConsulta + "','Popup','width=800,height=500')</script>");


            //Consulta
            Hashtable result = mp.refundPayment(idPago);


            //if ((int)payment_info["status"] == 200)
            Response.Write("<script>window.alert('" + result + "')</script>");




            
        }


        protected void verEstado(object sender, EventArgs e)
        {
            
            // Create an instance with your MercadoPago credentials (CLIENT_ID and CLIENT_SECRET): 
            // Argentina: https://www.mercadopago.com/mla/herramientas/aplicaciones 
            // Brasil: https://www.mercadopago.com/mlb/ferramentas/aplicacoes
            MP mp = new MP("3505078557617488", "3J7yHycTVNr1Vkhf8LZLmqqbeuZFP7nq");

            // Sets the filters you want
            Dictionary<String, String> filters = new Dictionary<String, String>();
            filters.Add("site_id", "MLA"); // Argentina: MLA; Brasil: MLB
                        //KEY       //VALUE

            // Search payment data according to filters
            Hashtable searchResult = mp.searchPayment(filters);

            //// Show payment information
            //foreach (Hashtable payment in searchResult.SelectToken("response.results"))
            //{
            //    Response.Write(payment["collection"]["id"]);
            //}


        }
        

       

        protected void Button1_Click(object sender, EventArgs e)
        {
            ConsultarPago();
        }




    }
}
