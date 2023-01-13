using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace DoctorBooking
{
    public partial class DetailChanger : System.Web.UI.Page
    {
        public string Query=string.Empty;
        public static string ConStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BookingData.mdf;Integrated Security=True;Connect Timeout=30";

        protected void Page_Load(object sender, EventArgs e)
        {
           
      
        }
        protected void Subject_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
        }


        protected void SubBtn_Click(object sender, EventArgs e)
        {
            Query = $"select * from customer where UserPassWord={OldPass.Text} and IdCard={Session["UserIdCard"].ToString()}";
            SqlConnection con = new SqlConnection(ConStr);
            con.Open();
            SqlCommand cmd = new SqlCommand(Query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if(NewPass.Text == ValNewPass.Text)
                {
                    string y = $"update Customer set UserPassWord={NewPass.Text} where IdCard={Session["UserIdCard"].ToString()}";
                    SqlConnection con2 = new SqlConnection(ConStr);
                    con2.Open();
                    SqlCommand cmd2 = new SqlCommand(y, con2);
                    SqlDataReader dr2 = cmd2.ExecuteReader();
                    if(dr2.Read())
                    {
                        ErrorLabel.Text = "הסיסמא שונתה בהצלחה , מיד תועבר לדיף הבית";
                        con2.Close();
                        
                        Response.Redirect("PrivateArea.aspx");
                        Thread.Sleep(20000);
                    }
                    
                }
                else
                {
                    ErrorLabel.Text = "סיסמא או אימות סיסמא לא תואמים";
                }
            }
            else
            {
                ErrorLabel.Text = "הסיסמא הישנה שגויה";
            }
            
            
            
            
            con.Close();
        }




    }
    





   
}
