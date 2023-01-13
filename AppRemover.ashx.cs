using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace DoctorBooking
{
    /// <summary>
    /// Summary description for AppRemover
    /// </summary>
    public class AppRemover : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            
            string c = context.Request.QueryString["id"].ToString();
           // string Admin = context.Request.QueryString["IsAdmin"].ToString();
            // int y = Int32.Parse(c);
            int i = 0;
          

            string ConStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BookingData.mdf;Integrated Security=True;Connect Timeout=30";
            string Query = $"delete from Appointment where AppointmentID= {c}";
            string a =  Query.Replace("{", "");
            string b = a.Replace("}", "");


            SqlConnection con = new SqlConnection(ConStr);
            con.Open();
            SqlCommand cmd = new SqlCommand( b , con);
            SqlDataReader dr = cmd.ExecuteReader();
            if(Admin == "1")
            {
                context.Response.Redirect("AppointmentDisplayer.aspx");
            }
            else
            {
                context.Response.Redirect("PrivateArea.aspx");
            }
           

        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}

    
  
