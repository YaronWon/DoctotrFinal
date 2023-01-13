<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppointmentDisplayer.aspx.cs" Inherits="DoctorBooking.AppointmentDisplayer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Appointment Displayer</title>
     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-Zenh87qX5JnK2Jl0vWa8Ck2rdkQ2Bzep5IDxbcnCeuOxjzrPF/et3URy9Bv1WTRi" crossorigin="anonymous" />
    <style>
        .table table-striped table-hover th {
            color:white;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 100%; height: 650px;">
                <tr>
                    <td style="width: 35%;">
                        <table style="width:60%;margin:auto;/*margin-bottom:450px;*/">
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
                                    <a runat="server" href="DetailDisplayer.aspx" class="btn btn-success" style="width:150px;">לטבלת משתמשים</a>
                                </td>
                                 <td></td>
                            </tr>
                             <tr style="width:80%;height:80px;align-items:center;">
                                 <td></td>
                                <td>
                                    <asp:Button runat="server" ID="PdfCreator" Text="PDF יצירת" CssClass="btn btn-primary" style="width:150px;" OnClick="PdfCreator_Click"/>
                                </td>
                                 <td></td>
                            </tr>
                        </table>
                    </td>

                    <td style=" width: 65%;">
                        <asp:Repeater ID="AppRep" runat="server" >
                            <%--"margin-bottom:590px;height:auto;margin-left:500px;"--%>
                            <HeaderTemplate>
                                <table cellspacing="1" rules="all" border="1" style="width: 100%; margin-bottom: 600px;" class="table table-striped table-hover " id="MainTable" onload="CellColor()"> 
                                    <tr style="background-color: #0077C0; color: aliceblue;">
                                        <th scope="col" style="text-align:center;color:white;" id="StatusCol">סטטוס
                                        </th>
                                         <th scope="col" style="text-align:center;color:white;">ביטול הפגישה
                                        </th>
                                        <th scope="col" style="text-align:center;color:white;">שעת סיום
                                        </th>
                                        <th scope="col" style="text-align:center;color:white;" >שעת התחלה
                                        </th>
                                        <th scope="col" style="text-align:center;color:white;">תאריך הפגישה
                                        </th>
                                        <th scope="col" style="text-align:center;color:white;" >שם משפחה
                                        </th>
                                        <th scope="col" style="text-align:center;color:white;">שם פרטי
                                        </th>
                                    
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr <%--style="text-align: center;"--%>>
                                    <td style="text-align:center;" id="StatusCell" >
                                        <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval( Container.DataItem ,"Status" ) %>' />
                                        </td>
                                      <td style="text-align:center;">
                                        <a href="AppRemover.ashx?IsAdmin=1&id=<%# DataBinder.Eval( Container.DataItem ,"AppID" ) %>"   > בטל פגישה</a>

                                    </td>

                                    <td style="text-align:center;">
                                        <asp:Label ID="EndApp" runat="server" Text='<%# DataBinder.Eval( Container.DataItem ,"End" ) %>' />

                                        <%--<asp:Label ID="lblCountry" runat="server" Text='<%# Eval("Country") %>' />--%>
                                    </td>
                                    <td style="text-align:center;">
                                        <asp:Label ID="StartApp" runat="server" Text='<%# DataBinder.Eval( Container.DataItem ,"Start" ) %>' />

                                        <%--<asp:Label ID="lblCountry" runat="server" Text='<%# Eval("Country") %>' />--%>
                                    </td>
                                    <td style="text-align:center;">
                                        <asp:Label ID="DateApp" runat="server" Text='<%# DataBinder.Eval( Container.DataItem ,"AppDate" ) %>' />
                                        <%--<asp:Label ID="lblCountry" runat="server" Text='<%# Eval("Country") %>' />--%>
                                    </td>

                                    <td style="text-align:center;">
                                        <asp:Label ID="FnApp" runat="server" Text='<%# DataBinder.Eval( Container.DataItem ,"LastN" ) %>' />
                                    </td>
                                    <td style="text-align:center;">
                                        <asp:Label ID="LnApp" runat="server" Text='<%# DataBinder.Eval( Container.DataItem ," FirstN" ) %>' />

                                    </td>
                                   
                                    
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </td>
                </tr>

            </table>

            <br />
        </div>
    </form>
    <script>
        var cell = document.getElementsByTagName("td");
        for (let index = 0; index < cell.length; index++) {
            if (cell.item(index).id === "StatusCell") {
                if (cell.item(index).innerText === "עבר") {
                    cell.item(index).style.backgroundColor = "red";
                } else {
                    cell.item(index).style.backgroundColor = "yellow";
                }



            }
        }
        function CellColor() {
            
        }
       
        
       
    </script>
</body>
</html>
