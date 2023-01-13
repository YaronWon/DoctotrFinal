using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoctorBooking
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            
            if(Session["UserName"] != null )
            {
                string y = Session["UserName"].ToString() + " "
                    + Session["UserLastName"].ToString() +  "!";
                    
                welcomelit.Text = y;
                MainLog.Visible = false;
                MainReg.Visible = false;
                MainApp.Visible = true;
                Logout.Visible = true;
                Private.Visible = true;


            }
            else
            {
                welcomelit.Text = "שלום אורח!";
                MainLog.Visible = true;
                MainReg.Visible = true;
                MainApp.Visible = false;
                Logout.Visible = false;
                Private.Visible = false;
            }
        }

        protected void LogOut_Click(object sender, EventArgs e)
        {

            Session.RemoveAll();

            Response.Redirect("Default.aspx");
        }

        protected void Logout_Click1(object sender, EventArgs e)
        {
            
        }
    }
}