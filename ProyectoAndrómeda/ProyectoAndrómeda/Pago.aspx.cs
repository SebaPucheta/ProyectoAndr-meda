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



namespace ProyectoAndrómeda
{
    public partial class Pago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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


            // Response.Redirect(url);



        }

    }
}