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
    public partial class DetailDisplayer : System.Web.UI.Page
    {

        public static string ConStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BookingData.mdf;Integrated Security=True;Connect Timeout=30";


        public class UseritemList
        {
            public string UserID { get; set; }
            public string FirstN { get; set; }
            public string LastN { get; set; }
            public string BirthDate { get; set; }
            public string Gen { get; set; }

            public string Uname { get; set; }



        }


       
        public string QCustList = "select Customer.IdCard , Customer.FirstName , Customer.LastName , Customer.DateOfBirth , Customer.Gender , Customer.UserName "
            +"from Customer";
        List<UseritemList> UserList = new List<UseritemList>();
        protected void Page_Load(object sender, EventArgs e)
        {
            
           
      
                string Q = QCustList.ToString();
                SqlConnection Con = new SqlConnection(ConStr);
                Con.Open();
                SqlCommand Com = new SqlCommand(Q, Con);
                SqlDataReader dr = Com.ExecuteReader();
                while (dr.Read())
                {
                    UseritemList tmp = new UseritemList();
                    tmp.FirstN = dr["FirstName"].ToString();
                    tmp.LastN = dr["LastName"].ToString();
                    tmp.BirthDate = Convert.ToDateTime(dr["DateOfBirth"].ToString()).ToString("dd.MM.yyyy");
                    tmp.UserID = dr["IdCard"].ToString();
                    tmp.Gen = dr["Gender"].ToString();
                    tmp.Uname = dr["UserName"].ToString();


                    UserList.Add(tmp);
                }

                Con.Close();
                AppRep.DataSource = UserList;
                AppRep.DataBind();

        }

     

        protected void MailSender_Click(object sender, EventArgs e)
        {


            using (MemoryStream ms = new MemoryStream())
            {



                //ARIAL 
                //glyphicons-halflings-regular.ttf
                //C:\Users\yaron\source\repos\DoctorBooking\DoctorBooking\fonts\glyphicons-halflings-regular.ttf

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
                
                PdfPTable table = new PdfPTable(6);
                table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                Paragraph header = new Paragraph(DateTime.UtcNow.ToString("dd.MM.yyyy"));
                Doc.Add(header);
                PdfPCell IdCell = new PdfPCell(new Phrase("תעודת זהות ",f));
                IdCell.BackgroundColor = BaseColor.BLACK;
                IdCell.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                IdCell.BorderWidthBottom = 1f;
                IdCell.BorderWidthTop = 1f;
                IdCell.BorderWidthLeft = 1f;
                IdCell.BorderWidthRight = 1f;
                IdCell.HorizontalAlignment = Element.ALIGN_CENTER;
                IdCell.VerticalAlignment = Element.ALIGN_CENTER;
                table.AddCell(IdCell);

                PdfPCell FnCell = new PdfPCell(new Phrase("שם פרטי",f));
                FnCell.BackgroundColor = BaseColor.BLACK;
                FnCell.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                FnCell.BorderWidthBottom = 1f;
                FnCell.BorderWidthTop = 1f;
                FnCell.BorderWidthLeft = 1f;
                FnCell.BorderWidthRight = 1f;
                FnCell.HorizontalAlignment = Element.ALIGN_CENTER;
                FnCell.VerticalAlignment = Element.ALIGN_CENTER;
                table.AddCell(FnCell);

                PdfPCell LnCell = new PdfPCell(new Phrase(@"שם משפחה", f));
                LnCell.BackgroundColor = BaseColor.BLACK;
                LnCell.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                LnCell.BorderWidthBottom = 1f;
                LnCell.BorderWidthTop = 1f;
                LnCell.BorderWidthLeft = 1f;
                LnCell.BorderWidthRight = 1f;
                LnCell.HorizontalAlignment = Element.ALIGN_CENTER;
                LnCell.VerticalAlignment = Element.ALIGN_CENTER;
                table.AddCell(LnCell);


                PdfPCell GenCell = new PdfPCell(new Phrase("מין", f));

                GenCell.BackgroundColor = BaseColor.BLACK;
                GenCell.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                GenCell.BorderWidthBottom = 1f;
                GenCell.BorderWidthTop = 1f;
                GenCell.BorderWidthLeft = 1f;
                GenCell.BorderWidthRight = 1f;
                GenCell.HorizontalAlignment = Element.ALIGN_CENTER;
                GenCell.VerticalAlignment = Element.ALIGN_CENTER;
                table.AddCell(GenCell);


                PdfPCell BirCell = new PdfPCell(new Phrase("תאריך לידה", f));
                BirCell.BackgroundColor = BaseColor.BLACK;
                BirCell.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                BirCell.BorderWidthBottom = 1f;
                BirCell.BorderWidthTop = 1f;
                BirCell.BorderWidthLeft = 1f;
                BirCell.BorderWidthRight = 1f;
                BirCell.HorizontalAlignment = Element.ALIGN_CENTER;
                BirCell.VerticalAlignment = Element.ALIGN_CENTER;
                table.AddCell(BirCell);

                PdfPCell UnCell = new PdfPCell(new Phrase("שם משתמש", f));
                UnCell.BackgroundColor = BaseColor.BLACK;
                UnCell.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                UnCell.BorderWidthBottom = 1f;
                UnCell.BorderWidthTop = 1f;
                UnCell.BorderWidthLeft = 1f;
                UnCell.BorderWidthRight = 1f;
                UnCell.HorizontalAlignment = Element.ALIGN_CENTER;
                UnCell.VerticalAlignment = Element.ALIGN_CENTER;
                table.AddCell(UnCell);


             




           




              



            


                foreach (UseritemList c in UserList)
                {
                    PdfPCell Uname = new PdfPCell(new Phrase(c.Uname.ToString(), DynamicCell));
                    PdfPCell Ubirth = new PdfPCell(new Phrase(c.BirthDate.ToString() , DynamicCell));
                    PdfPCell Ugen = new PdfPCell(new Phrase(c.Gen.ToString(), DynamicCell));
                    PdfPCell uid = new PdfPCell(new Phrase(c.UserID.ToString(), DynamicCell));
                    PdfPCell UName = new PdfPCell(new Phrase(c.FirstN.ToString(), DynamicCell));
                    PdfPCell ULName = new PdfPCell(new Phrase(c.LastN.ToString(), DynamicCell));

                    Uname.HorizontalAlignment = Element.ALIGN_CENTER;
                    
                    Ubirth.HorizontalAlignment = Element.ALIGN_CENTER;
                    Ugen.HorizontalAlignment = Element.ALIGN_CENTER;
                    uid.HorizontalAlignment = Element.ALIGN_CENTER;
                    UName.HorizontalAlignment = Element.ALIGN_CENTER;
                    ULName.HorizontalAlignment = Element.ALIGN_CENTER;

                    table.AddCell(uid);
                    table.AddCell(UName);
                    table.AddCell(ULName);
                    table.AddCell(Ugen);
                    table.AddCell(Ubirth);
                    table.AddCell(Uname);
                    
                    
                    
                    
                }


                Doc.Add(table);
               
                
                var constant = ms.ToArray();
                string R =  "טבלת משתמשים - "+ DateTime.UtcNow.ToString("dd.MM.yyyyy") + ".pdf";


                Doc.Close();
                byte[] bytes = ms.ToArray();
                ms.Close();
                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", "attachment; filename="+ R);
                Response.ContentType = "application/pdf";
                Response.Buffer = true;
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(bytes);
                Response.End();
                Response.Close();


            }







































            //SqlConnection Con = new SqlConnection(ConStr);
            //Con.Open();
            //SqlCommand Com = new SqlCommand(QCustList, Con);
            //SqlDataAdapter DA = new SqlDataAdapter(Com);
            //DataTable DT = new DataTable();
            //DT.Columns.Add("ת.ז משתמש");
            //DT.Columns.Add("שם פרטי");
            //DT.Columns.Add("שם משפחה");
            //DT.Columns.Add("תאריך לידה");
            //DT.Columns.Add("מין");
            //DT.Columns.Add("שם משתמש");

            //foreach(UseritemList U in UserList)
            //{
            //    DT.Rows.Add(U.UserID , U.FirstN , U.LastN , U.BirthDate , U.Gen , U.Uname);
            //}
            //DataSet ds = new DataSet();
            //DA.Fill(ds);

            //SqlDataReader dr = Com.ExecuteReader();
            //Con.Close();








            //MailMessage mail = new MailMessage();
            //mail.To.Add(Session["UserEmail"].ToString());
            //mail.From = new MailAddress("digitalbro10@gmail.com");
            //mail.Subject = "רשימת משתמשים";
            //mail.Body = "";

            //mail.IsBodyHtml = false;

            //// Scheduler scheduler = new Scheduler();
            ////// scheduler.
            //SmtpClient smtp = new SmtpClient();
            //smtp.Port = 587;
            //smtp.EnableSsl = true;
            //smtp.UseDefaultCredentials = false;
            //smtp.Host = "smtp.gmail.com";
            //smtp.Credentials = new System.Net.NetworkCredential("digitalbro10@gmail.com", "clpqmjuassfztflm");
            //smtp.Send(mail);

            //SmtpClient C = new SmtpClient();
            //C.Port = 587;
            //C.EnableSsl = true;
            //C.UseDefaultCredentials = false;
            //C.Host = "smtp.gmail.com";
            //C.Credentials = new System.Net.NetworkCredential("digitalbro10@gmail.com", "clpqmjuassfztflm");
        }


    }
}