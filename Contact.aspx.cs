using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;


namespace DoctorBooking
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SendBtn_Click(object sender, EventArgs e)
        {
            //clpqmjuassfztflm - AppPassWord
            //digitalbro10@gmail.com - AppUsername
            MailMessage mail = new MailMessage();
            mail.To.Add("yaron712@gmail.com");
            mail.From = new MailAddress("digitalbro10@gmail.com");
            mail.Subject = Subject.SelectedValue.ToString();
            mail.Body = MassBody.InnerText;
            
            mail.IsBodyHtml = false;

           // Scheduler scheduler = new Scheduler();
           //// scheduler.
            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new System.Net.NetworkCredential("digitalbro10@gmail.com", "clpqmjuassfztflm");
            smtp.Send(mail);

            //SmtpClient C = new SmtpClient();
            //C.Port = 587;
            //C.EnableSsl = true;
            //C.UseDefaultCredentials = false;
            //C.Host = "smtp.gmail.com";
            //C.Credentials = new System.Net.NetworkCredential("digitalbro10@gmail.com", "clpqmjuassfztflm");
            //Response.Redirect("Default.aspx");
        }
    }
}