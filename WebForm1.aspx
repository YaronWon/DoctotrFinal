<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="DoctorBooking.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
    @import url('https://fonts.googleapis.com/css2 ?family=Poppins:wght@100;300;400;500;600; 700;800;900&display=swap');
   *{
       margin: 0; 
       padding: 0; 
       box-sizing: border-box;
       font-family: 'Poppins', sans-serif;

   }
        .container {
            width: 100%;
            min-height: 100vh;
            display: flex;
            justify-content: flex-start;
            align-items: center;
            background: #3d4152;
        }
.navigation { 
    position: fixed; 
    inset: 20px 0 20px 20px; width: 75px; 
    min-height: 500px;
    background: #fff;
    transition: 0.5s; 
    display: flex; 
    justify-content: center;
    align-items: center;

}

    </style>
 <div class="container">
 <div class="navigation">
 <div class="menu-toggle"></div>
 <ul class="list">
 <li class="list-item active" style="--color:#f44336">
<a href="#">
 <span class="icon">
<ion-icon name="home-outline"></ion-icon> 
</span> 
<span class="text">Home</span> </a>
</li>
<li class="list-item" style="--color:#ffal17">
<a href="#"> <span class="icon">
<ion-icon name="alert-outline"></ion-icon> </span> 
<span class="text">About</span> </a></li>
 <li class="list-item" style="--color:#0fc70f">
<a href="#"> <span class="icon">
<ion-icon name="call-outline">
</ion-icon> 
</span>
 <span class="text">Contact</span> </a>
</li>
 <li class="list-item" style="--color:#2196f3">
<a href="#"> <span class="icon">
<ion-icon name="grid-outline"></ion-icon> </span> 
<span class="text">Portfolio</span> </a>
</li>
 <li class="list-item" style="--color:#b145e9">
<a href="#"> 
    <span class="icon">
    <ion-icon name="pencil-outline"></ion-icon>
    </span>
 <span class="text">Blog</span>
</a></li> </ul> </div> </div>

</asp:Content>
