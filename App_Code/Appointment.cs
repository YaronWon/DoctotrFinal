using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace DoctorBooking
{
    public class Appointment
    {
        //public string AppoId { get; set; }
        
        public string CustomerID { get; set; }
        public string StartTime { get; set; }
       
        public string EndTime { get; set; }
        public string Date { get; set; }

        public bool Available { get; set; }

        public string Connstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BookingData.mdf;Integrated Security=True;Connect Timeout=30";

        public Appointment()
        {

        }

        public Appointment(string customerID, string startTime, string endTime, string date)
        {
            //AppoId = appoId;
            //DoctorId = doctorId;
            CustomerID = customerID;
            StartTime = startTime;
            //Detail = detail;
            EndTime = endTime;
            Date = date;
        }

        public bool AddAppointment(Appointment A)
        {
            string Query = "insert into Appointment (CustomerID,AppointmentDate,StartTime,EndTime)" +
                $"values(N'{A.CustomerID}',N'{A.Date}',N'{A.StartTime}',N'{A.EndTime}')";
            SqlConnection con = new SqlConnection(Connstr);
            con.Open();
            SqlCommand cmd = new SqlCommand(Query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
        }
    }
}