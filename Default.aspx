<%@ Page Title="דף הבית" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DoctorBooking._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <link rel="stylesheet" href="CSS/Homepage.css" />
 
    <br /><br /><br />
    <div class="container">
        
        <p class="text-center">
             
             <asp:Literal ID="welcomelit" runat="server" />
             
            
            
        </p>
      
        <a href="Register.aspx" class="btn btn-block btn-success" runat="server" id="MainReg"> הרשמה</a>
        <a href="Login.aspx" class="btn btn-block btn-primary" runat="server" id="MainLog"> התחברות</a>
      
        <a href="Scheduler.aspx" class="btn btn-block btn-success" runat="server" id="MainApp"> לקביעת תור</a> <br />
        <a href="PrivateArea.aspx" class="btn btn-block btn-primary" runat="server" id="Private">לאזור האישי</a> <br />
        <asp:Button runat="server" ID="Logout" CssClass="btn btn-block  btn-danger" OnClick="LogOut_Click" Text="התנתקות" />
       
    
    </div>

    
    
</asp:Content>
