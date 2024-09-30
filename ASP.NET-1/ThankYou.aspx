<%@ Page Language="C#" Inherits="ASP.NET1.ThankYou" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thank You</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align:center; margin-top:50px;">
            <h1>Thank You!</h1>
            <asp:Label ID="lblDisplayMessage" runat="server" FontSize="Large"></asp:Label>
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Go back" OnClick="goBack_Click" />
        </div>
    </form>
</body>
</html>
