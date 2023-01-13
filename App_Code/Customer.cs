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

namespace DoctorBooking
{
    public class Customer :Person 
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }

        public static string ConStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BookingData.mdf;Integrated Security=True;Connect Timeout=30";

        public ICollection<Appointment> Appointments { get; set; }
    
       public Customer()
        {
             Appointments = new List<Appointment>();
        }

        public Customer(
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
            string passWord)
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
            UserName = userName;
            PassWord = passWord;
            
        }

        public bool AddCustomer(Customer A)
        {
            string Query = $"insert into Customer(IdCard,FirstName,LastName,DateOfBirth,Address,City,Email,Phone,Gender,UserName,UserPassWord)" +
                $" values(N'{A.IdCard}',N'{A.FirstName}',N'{A.LastName}',N'{A.DateOfBirth}',N'{A.Address}',N'{A.City}',N'{A.Email}',N'{A.Phone}',N'{A.Gender}',N'{A.UserName}',N'{A.PassWord}') ";
            SqlConnection con = new SqlConnection(ConStr);
            con.Open();
            SqlCommand cmd = new SqlCommand(Query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
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
            string Query = $"delete from Customer where IdCard = N'{s}'";
            SqlConnection C = new SqlConnection(ConStr);
            C.Open();
            SqlCommand Cmd = new SqlCommand(Query, C);
            Cmd.ExecuteReader();
            C.Close();
        }

      

        public bool LoginCustomer(string s, string a)
        {
            string Query = $"select * from Customer where UserName=N'{s}' and UserPassWord = N'{a}' ";
            SqlConnection C = new SqlConnection(ConStr);
            C.Open();
            SqlCommand Login = new SqlCommand(Query, C);
            SqlDataReader dr = Login.ExecuteReader();
            if (dr.Read())
            {
                Session["UserName"] = dr["FirstName"].ToString();
                Session["UserLastName"] = dr["LastName"].ToString();
                Session["UserIdCard"] = dr["IdCard"].ToString();
                Session["UserEmail"] = dr["Email"].ToString();
                
               
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