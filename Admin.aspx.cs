using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace DoctorBooking
{
  
    public partial class Admin : System.Web.UI.Page
    {
        public static string ConStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BookingData.mdf;Integrated Security=True;Connect Timeout=30";
        public string Qapp = "select count(AppointmentID) as Apps from Appointment";
        public string Quser = "select count(CustID) as Custs  from Customer";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(DateTime.Now.Hour + 1 > 7 || DateTime.Now.Hour + 1 < 12)
            {
                Welcomelit.Text = "בוקר טוב , אדמין יקר ";
            }
            
            if(DateTime.Now.Hour + 1 > 12 || DateTime.Now.Hour + 1 < 18)
            {
                Welcomelit.Text = "צהריים טובים , אדמין יקר";
            }

            if (DateTime.Now.Hour + 1 > 18 || DateTime.Now.Hour + 1 < 6)
            {
                Welcomelit.Text = "לילה טוב , אדמין יקר";
            }
            
            SqlConnection con = new SqlConnection(ConStr);
            con.Open();
            SqlCommand cmd = new SqlCommand(Qapp, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                AppAmount.Text = dr["Apps"].ToString();
            }
            con.Close();

            SqlConnection con1 = new SqlConnection(ConStr);
            con1.Open();
            SqlCommand cmd1 = new SqlCommand(Quser, con1);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                UserAmount.Text = dr1["Custs"].ToString();
            }
            con1.Close();
        }

       

  

    }
}