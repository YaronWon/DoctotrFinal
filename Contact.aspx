<%@ Page Title="צור קשר" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="DoctorBooking.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        #MassBody{
            margin:auto;
        }  
        .container{
            margin:auto;
        }
    </style>

    
    <h2 class="text-center">דף יצירת קשר</h2>

    <div class="container">
        <asp:DropDownList runat="server" ID="Subject" CssClass="form-control">
            <asp:ListItem Value="שירות לקוחות">שירות לקוחות</asp:ListItem>
            <asp:ListItem Value="שיפור השירות">שיפור השירות</asp:ListItem>
            <asp:ListItem Value="הצעות ייעול">הצעות ייעול</asp:ListItem>
            <asp:ListItem Value="אחר">אחר</asp:ListItem>
        </asp:DropDownList><br />
         <textarea runat="server" id="MassBody" style="resize:none;width:350px;height:250px;" placeholder="אנא הקלד פה את מבוקשך"></textarea><br />
         <asp:Button runat="server" ID="SendBtn" OnClick="SendBtn_Click" CssClass="btn btn-primary" Text="שליחה"/>
    </div>
   

   
</asp:Content>
