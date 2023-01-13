<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetailChanger.aspx.cs" Inherits="DoctorBooking.DetailChanger" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .container{
            margin:auto;
            margin-top:25px;
        }
    </style>
    <div class="container">
        <asp:TextBox runat="server" ID="OldPass" CssClass="form-control" placeholder="הקלד סיסמא ישנה"/><br />
        <asp:TextBox runat="server" ID="NewPass" CssClass="form-control" placeholder="הקלד סיסמא חדשה"/><br />
        <asp:TextBox runat="server" ID="ValNewPass" CssClass="form-control" placeholder="אימות סיסמא חדשה"/>
        <br />
        <asp:Button runat="server" CssClass="btn btn-primary" ID="PassChanger" Text="אישור" OnClick="SubBtn_Click"/><br />
        <p>
            <asp:Label runat="server" ID="ErrorLabel" style="color:orangered;"/>
        </p>

    </div>
</asp:Content>
