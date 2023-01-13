<%@ Page Title="דף אדמין" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="DoctorBooking.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<style>
		.card{
			margin:auto;
            width:450px;
            height:auto;
            box-shadow:6px 6px 29px -4px rgba(0,0,0,0.75);
            text-align:center;
            position:relative;
            border-radius:50px;
            text-align:center;
		}
	</style>
   <br /><br /><br />
	<div class="card">
		<table>
		<tr>
			<td></td>
			<td style="width:180px;">
				<p>
					<asp:Literal runat="server" ID="Welcomelit" />
				</p>
			</td>
			<td></td>
		</tr>
		<tr>
			<td > כמות משתמשים כללית<br />
				<a id="users" href="DetailDisplayer.aspx"><asp:Literal runat="server" ID="UserAmount" /></a>
					 <p id="UserDisplayer" style="display:none;text-align:center;">
			     לפירוט המשתמשים
		        </p>
				
				
			</td>
			<td></td>
			<td>  
				כמות פגישות <br />
		 <a id="Apps"  href="AppointmentDisplayer.aspx"><asp:Literal runat="server" ID="AppAmount" /></a>	
		 <p id="AppsDisplayer" style="display:none;text-align:center;">
			 לפירוט הפגישות
		 </p>
		</td>
			
		</tr>
	</table>
			<br /><br />
	 
		
	</div>
	<script>
		var a = document.getElementById("UserDisplayer");
		var b = document.getElementById("users");
		b.addEventListener("mouseover", function () {
			a.style.display = "flex";
		});
        b.addEventListener("mouseout", function () {
            a.style.display = "none";
        });

		var x = document.getElementById("Apps");
        var y = document.getElementById("AppsDisplayer");
		x.addEventListener("mouseover", function () {
			y.style.display = "flex";
		});
		x.addEventListener("mouseout", function () {
            y.style.display = "none";
        });
    </script>
   
</asp:Content>
