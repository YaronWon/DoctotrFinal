using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using DoctorBooking.App_Code;

namespace DoctorBooking.App_Code
{
    public class Doctor :Person
    {
        public string DocUserName { get; set; }
        public string DocPassword { get; set; }


        public string Connstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ClinicData.mdf;Integrated Security=True;Connect Timeout=30";
          
       public ICollection<Appointment> Appointments { get; set; }
        public Doctor()
        {
            Appointments = new List<Appointment>();
        }
     
      
        public Doctor(
             string idcard,
             string firsname,
             string lastname,
             DateTime date,
             string addRess,
             string city,
             string email,
             string phone,
             string gender,
             string userName,
             string passWord
            )
        {
            IdCard = idcard;
            FirstName = firsname;
            LastName = lastname;
            DateOfBirth = date;
            Address = addRess;
            City = city;
            Email = email;
            Phone = phone;
            Gender = gender;
            DocUserName = userName;
            DocPassword = passWord;

        }

        public bool AddDoctor(Doctor A)
        {
            string Query = $"insert into Doctor(IdCard,FirstName,LastName,DateOfBirth,Address,City,Email,Phone,Gender,DocUserName,DocPassWord)" +
                $" values(N'{A.IdCard}',N'{A.FirstName}',N'{A.LastName}',N'{A.DateOfBirth}',N'{A.Address}',N'{A.City}',N'{A.Email}',N'{A.Phone}',N'{A.Gender}',N'{A.DocUserName}',N'{A.DocPassword}') ";
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

        public void DeleteCustomer(string s)
        {
            string Query = $"delete from Doctor where IdCard = N'{s}'";
            SqlConnection C = new SqlConnection(Connstr);
            C.Open();
            SqlCommand Cmd = new SqlCommand(Query, C);
            Cmd.ExecuteReader();
            C.Close();
        }

        public bool LoginDoctor(string s, string a)
        {
            string Query = $"select * from Doctor where DocUserName=N'{s}' and DocPassWord = N'{a}' ";
            SqlConnection C = new SqlConnection(Connstr);
            C.Open();
            SqlCommand Login = new SqlCommand(Query, C);
            SqlDataReader dr = Login.ExecuteReader();
            if (dr.Read())
            {
                Session["DocName"] = dr["FirstName"].ToString();
                Session["DocLastName"] = dr["LastName"].ToString();
                Session["DocID"] = dr["IdCard"].ToString();
                C.Close();
                return true;
            }
            else
            {
                C.Close();
                return false;
            }

        }

    }
}