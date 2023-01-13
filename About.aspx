﻿<%@ Page Title="אודות" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="DoctorBooking.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="Container-contect">
   
    <h2 class="text-center"> 
       מערכת לניהול תורים <br />
  
    </h2>
        <h3 class="text-center">
                   מבצעים: 
        ירון וונדה
        עדן שמשון<br />
        </h3>
        <h4 class="text-center">
               מרצה :
        ירון לפידות
        </h4>
       
     
   
        תפקיד המערכת לעזור לרופאים לנהל את הפגישות עם הלקוחות שלהם.<br />
        
       תיאור תוכנת המערכת:<br />
המערכת היא מערכת WEB, המערכת תעבוד בסביבת אינטרנט על גבי שרת אינטרנט מקומי בארגון.<br />
        המערכת כוללת רשימת עובדים בארגון מסוים, כל עובד יקבל הרשאות בהתאם לתפקידו וכך יוכל לצפות במידע הנוגע אליו.<br />
        מנהל יוכל לבצע את כל הפעולות הנדרשות ואילו עובד יוכל לראות את נתוניו בהתאם למה שנתונים שכתב במערכת בכל יום.<br />

<p class="text-center">
    תיאור המערכת:
</p>
המערכת תחשב את הזנת נתוני העובד ותעביר אותו למערכת לאחר אימות מול מנהלו הישיר.<br />

כלי התוכנה לפיתוח המערכת:<br />
שפת C# בשילוב טכנולוגיית jQuery, bootstrap, html, css.<br />
תיאור פונקציות המערכת:<br />
פונקציות שליפה, עדכון, הוספה, מחיקה ושמירה מול בסיס הנתונים.<br />
ברמת מנהל:<br />
•	הוספה / עדכון / מחיקת משתמשים.<br />
•	אימות נתוני מכירות שהוזנו ע"י המשתמשים. (אישור עמלות)<br />
•	אימות נתוני נוכחות שהוזנו ע"י המשתמשים. (תשלום שכר שעתי)<br />
•	תצוגה עדכנית מי העובד המוביל ברמה חודשית.<br />
ברמת עובד:<br />
•	הזנת נתוני מכירות ברמה יומית.<br />
•	הזנת נתוני נוכחות ברמה יומית.<br />
•	חישוב של הנתונים לאחר אימות המנהל ותצוגה של השכר הצפוי.<br />


זרימת המידע המערכת:<br />
•	זרימת המידע מצד העובד – כתיבה של נתונים, הנתונים מועברים למנהל המערכת ע"מ לאשר את הנתונים.<br />
•	זרימת המידע מצד המנהל – כתיבה של הנתונים והם מאושרים באותו הרגע.<br />

        

       
    </div>
    
 
</asp:Content>
