<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailDisplayer.aspx.cs" Inherits="DoctorBooking.DetailDisplayer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Detail User Displayer</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-Zenh87qX5JnK2Jl0vWa8Ck2rdkQ2Bzep5IDxbcnCeuOxjzrPF/et3URy9Bv1WTRi" crossorigin="anonymous" />
    <style>
        .table table-striped table-hover th {
            color:white;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" >
        <div>
            <asp:table runat="server" ID="MainTab" style=" width: 100%; height: 650px;">
                <asp:TableRow >
                    <asp:TableCell >
                        <table style="width:60%;margin:auto;">
                            <tr style="width:80%;height:80px;align-items:center;">
                                <td>
                                   
                                </td>
                                <td>
                                    <a runat="server" href="Admin.aspx" class="btn btn-danger" style="width:150px;" >חזרה לדף אדמין</a>
                                </td>
                                <td></td>
                            </tr>
                             <tr style="width:80%;height:80px;align-items:center;">
                                 <td></td>
                                <td>
                                    <a runat="server" href="AppointmentDisplayer.aspx" class="btn btn-success" style="width:150px;">לטבלת הפגישות</a>
                                </td>
                                 <td></td>
                            </tr>
                             <tr style="width:80%;height:80px;align-items:center;">
                                 <td></td>
                                <td>
                                    <asp:Button runat="server" ID="MailSender" Text="PDF יצירת" CssClass="btn btn-primary" style="width:150px;" OnClick="MailSender_Click"/>
                                </td>
                                 <td></td>
                            </tr>
                        </table>
                    </asp:TableCell>

                    <asp:TableCell style=" width: 65%;">
                        <asp:Repeater ID="AppRep" runat="server">
                            <%--"margin-bottom:590px;height:auto;margin-left:500px;"--%>
                            <HeaderTemplate>
                                <table cellspacing="1" rules="all" border="1" style="width: 100%; margin-bottom: 600px;" class="table table-striped table-hover "> 
                                    <tr style="background-color: #0077C0; color: aliceblue;">
                                        <th scope="col" style="text-align:center;color:white;" <%--style="width:12%;"--%>>שם משתמש
                                        </th>
                                        <th scope="col" style="text-align:center;color:white;" <%--style="width:12%;"--%>>מין
                                        </th>
                                        <th scope="col" style="text-align:center;color:white;" <%--style="width:12%;"--%>>תאריך לידה
                                        </th>
                                        <th scope="col" style="text-align:center;color:white;" <%--style="width:12%;"--%>>שם פרטי
                                        </th>
                                        <th scope="col" style="text-align:center;color:white;" <%--style="width: 12%;"--%>>שם משפחה
                                        </th>
                                        <th scope="col" style="text-align:center;color:white;" <%--style="width: 12%;"--%>>ת.ז משתמש
                                        </th>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr <%--style="text-align: center;"--%>>

                                    <td style="text-align:center;">
                                        <asp:Label ID="Label5" runat="server" Text='<%# DataBinder.Eval( Container.DataItem ,"Uname" ) %>' />

                                        <%--<asp:Label ID="lblCountry" runat="server" Text='<%# Eval("Country") %>' />--%>
                                    </td>
                                    <td style="text-align:center;">
                                        <asp:Label ID="Label4" runat="server" Text='<%# DataBinder.Eval( Container.DataItem ,"Gen" ) %>' />

                                        <%--<asp:Label ID="lblCountry" runat="server" Text='<%# Eval("Country") %>' />--%>
                                    </td>
                                    <td style="text-align:center;">
                                        <asp:Label ID="Label3" runat="server" Text='<%# DataBinder.Eval( Container.DataItem ,"BirthDate" ) %>' />
                                        <%--<asp:Label ID="lblCountry" runat="server" Text='<%# Eval("Country") %>' />--%>
                                    </td>

                                    <td style="text-align:center;">
                                        <asp:Label ID="lblCustomerId" runat="server" Text='<%# DataBinder.Eval( Container.DataItem ,"FirstN" ) %>' />
                                    </td>
                                    <td style="text-align:center;">
                                        <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval( Container.DataItem ,"LastN" ) %>' />

                                    </td>
                                    <td style="text-align:center;">
                                        <asp:Label ID="Label2" runat="server" Text='<%# DataBinder.Eval( Container.DataItem ,"UserID" ) %>' />
                                        <%--<asp:Label ID="lblCountry" runat="server" Text='<%# Eval("Country") %>' />--%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </asp:TableCell>
                </asp:TableRow>

            </asp:table>

            <br />
               
         </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-OERcA2EqjJCMA+/3y+gxIOqMEjwtxJY7qPCqsdltbNJuaOe923+mo//f6V8Qbsw3" crossorigin="anonymous"></script>
</body>
</html>
