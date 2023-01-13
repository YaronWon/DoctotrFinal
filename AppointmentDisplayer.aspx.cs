using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Web.Http;
using GemBox.Pdf;
using GemBox.Pdf.Content;

namespace DoctorBooking
{
    public partial class AppointmentDisplayer : System.Web.UI.Page
    {
        public static string ConStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BookingData.mdf;Integrated Security=True;Connect Timeout=30";
        public string QCustAppList = "select  distinct Customer.FirstName,Customer.LastName,Appointment.AppointmentDate, Appointment.StartTime,Appointment.EndTime ,Appointment.AppointmentID as AppID from Appointment inner join Customer on " +
        "Appointment.CustomerID = Customer.IdCard where Appointment.CustomerID = Customer.IdCard order by Appointment.AppointmentDate";
        public class AppitemList
        {
            public int AppID { get; set; }
            public string FirstN { get; set; }
            public string LastN { get; set; }
            public string AppDate { get; set; }
            public string Start { get; set; }
            public string End { get; set; }
            public string Status { get; set; }

        }
         public List<AppitemList> AppList = new List<AppitemList>();
        protected void Page_Load(object sender, EventArgs e)
        {
         

            string Q = QCustAppList.ToString();
            SqlConnection Con = new SqlConnection(ConStr);
            Con.Open();
            SqlCommand Com = new SqlCommand(Q, Con);
            SqlDataReader dr = Com.ExecuteReader();
            while (dr.Read())
            {
                
                AppitemList tmp = new AppitemList();
                tmp.FirstN = dr["FirstName"].ToString();
                tmp.LastN = dr["LastName"].ToString();
                tmp.AppDate = dr["AppointmentDate"].ToString();
                DateTime a = DateTime.ParseExact(tmp.AppDate, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                DateTime b = DateTime.ParseExact(DateTime.UtcNow.ToString("dd.MM.yyyy"), "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
      
                if(a > b)
                {
                    tmp.Status = "ממתין";
                    
                }
                else
                {
                    tmp.Status = "עבר";
                }
                
                tmp.Start = dr["StartTime"].ToString();
                tmp.End = dr["EndTime"].ToString();
                tmp.AppID = int.Parse(dr["AppID"].ToString())  ;
                AppList.Add(tmp);
            }

            Con.Close();

            AppRep.DataSource = AppList;
            AppRep.DataBind();


            //CellColor()
            ClientScript.RegisterStartupScript(GetType(), "Javascript", "CellColor(); ", true);
        }

      

        protected void PdfCreator_Click(object sender, EventArgs e)
        {
            using (MemoryStream ms = new MemoryStream())
            {



                string Hebrew_TFF = Path.Combine(@"C:\Users\yaron\source\repos\DoctorBooking\DoctorBooking\fonts", "NotoSansHebrew_ExtraCondensed-Regular.ttf");
                Document Doc = new Document(PageSize.A3, 25, 25, 30, 30);
                BaseFont bf = BaseFont.CreateFont(Hebrew_TFF, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font f = new iTextSharp.text.Font(bf, 12);
                iTextSharp.text.Font DynamicCell = new iTextSharp.text.Font(bf, 12);
                DynamicCell.Color = BaseColor.BLACK;
                f.Color = BaseColor.WHITE;
                PdfWriter writer = PdfWriter.GetInstance(Doc, ms);
                writer.SetLanguage("he-IL");
                writer.Open();
                var image = iTextSharp.text.Image.GetInstance(@"C:\Users\yaron\source\repos\DoctorBooking\DoctorBooking\Images\icons8-clinic-64.png");
                string FontH = Path.Combine(@"C:\Users\yaron\source\repos\DoctorBooking\DoctorBooking", "ARIAL.TTF");
                image.Alignment = Element.ALIGN_CENTER;

                Doc.Open();
                Doc.AddLanguage("he-IL");
                Doc.Add(image);

                PdfPTable table = new PdfPTable(5);
                table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;

                Paragraph header = new Paragraph(DateTime.UtcNow.ToString("dd.MM.yyyy"));
                Doc.Add(header);
               
  

                PdfPCell DateS = new PdfPCell(new Phrase("תאריך ", f));
                DateS.BackgroundColor = BaseColor.BLACK;
                DateS.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                DateS.BorderWidthBottom = 1f;
                DateS.BorderWidthTop = 1f;
                DateS.BorderWidthLeft = 1f;
                DateS.BorderWidthRight = 1f;
                DateS.HorizontalAlignment = Element.ALIGN_CENTER;
                DateS.VerticalAlignment = Element.ALIGN_CENTER;
                table.AddCell(DateS);

               
                
                PdfPCell FnCell = new PdfPCell(new Phrase("שם פרטי", f));
                FnCell.BackgroundColor = BaseColor.BLACK;
                FnCell.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                FnCell.BorderWidthBottom = 1f;
                FnCell.BorderWidthTop = 1f;
                FnCell.BorderWidthLeft = 1f;
                FnCell.BorderWidthRight = 1f;
                FnCell.HorizontalAlignment = Element.ALIGN_CENTER;
                FnCell.VerticalAlignment = Element.ALIGN_CENTER;
                table.AddCell(FnCell);

                PdfPCell LnCell = new PdfPCell(new Phrase("שם משפחה", f));
                LnCell.BackgroundColor = BaseColor.BLACK;
                LnCell.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                LnCell.BorderWidthBottom = 1f;
                LnCell.BorderWidthTop = 1f;
                LnCell.BorderWidthLeft = 1f;
                LnCell.BorderWidthRight = 1f;
                LnCell.HorizontalAlignment = Element.ALIGN_CENTER;
                LnCell.VerticalAlignment = Element.ALIGN_CENTER;
                table.AddCell(LnCell);


                PdfPCell StartCell = new PdfPCell(new Phrase("התחלה", f));

                StartCell.BackgroundColor = BaseColor.BLACK;
                StartCell.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                StartCell.BorderWidthBottom = 1f;
                StartCell.BorderWidthTop = 1f;
                StartCell.BorderWidthLeft = 1f;
                StartCell.BorderWidthRight = 1f;
                StartCell.HorizontalAlignment = Element.ALIGN_CENTER;
                StartCell.VerticalAlignment = Element.ALIGN_CENTER;
                table.AddCell(StartCell);


                PdfPCell EndCell = new PdfPCell(new Phrase("סוף משוער", f));
                EndCell.BackgroundColor = BaseColor.BLACK;
                EndCell.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                EndCell.BorderWidthBottom = 1f;
                EndCell.BorderWidthTop = 1f;
                EndCell.BorderWidthLeft = 1f;
                EndCell.BorderWidthRight = 1f;
                EndCell.HorizontalAlignment = Element.ALIGN_CENTER;
                EndCell.VerticalAlignment = Element.ALIGN_CENTER;
                table.AddCell(EndCell);

                foreach (AppitemList c in AppList)
                {
                    PdfPCell AppDate = new PdfPCell(new Phrase(c.AppDate.ToString(), DynamicCell));
                    PdfPCell AppFN = new PdfPCell(new Phrase(c.FirstN.ToString(), DynamicCell));
                    PdfPCell AppLN = new PdfPCell(new Phrase(c.LastN.ToString(), DynamicCell));
                    PdfPCell AppStart = new PdfPCell(new Phrase(c.Start.ToString(), DynamicCell));
                    PdfPCell AppEnd = new PdfPCell(new Phrase(c.End.ToString(), DynamicCell));


                    AppDate.HorizontalAlignment = Element.ALIGN_CENTER;

                    AppFN.HorizontalAlignment = Element.ALIGN_CENTER;
                    AppLN.HorizontalAlignment = Element.ALIGN_CENTER;
                    AppStart.HorizontalAlignment = Element.ALIGN_CENTER;
                    AppEnd.HorizontalAlignment = Element.ALIGN_CENTER;
                    

                    table.AddCell(AppDate);
                    table.AddCell(AppFN);
                    table.AddCell(AppLN);
                    table.AddCell(AppStart);
                    table.AddCell(AppEnd);
                   




                }


                Doc.Add(table);


                var constant = ms.ToArray();
                string R = "טבלת פגישות - " + DateTime.UtcNow.ToString("dd.MM.yyyyy") + ".pdf";


                Doc.Close();
                byte[] bytes = ms.ToArray();
                ms.Close();
                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + R);
                Response.ContentType = "application/pdf";
                Response.Buffer = true;
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(bytes);
                Response.End();
                Response.Close();

            }


            MailSender();
      
        }

        public void MailSender()
        {
            MailMessage mail = new MailMessage();
            mail.To.Add("yaron712@gmail.com");
            mail.From = new MailAddress("digitalbro10@gmail.com");
            mail.Subject = "טבלת פגישות - " + DateTime.UtcNow.ToString("dd.MM.yyyyy");
            mail.Body = DateTime.UtcNow.ToString("dd.MM.yyyyy") + "היי ,<br/> ירון ועדן מאפליקציית רופא בזמן ,<br/>מצורף למייל טבלת הפגישות העדכנית ל";

            mail.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new System.Net.NetworkCredential("digitalbro10@gmail.com", "clpqmjuassfztflm");
            smtp.Send(mail);
        }
    }
}