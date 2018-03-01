<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p class="LoginText">Username</p>
            <asp:TextBox runat="server" ID="UsernameBox"></asp:TextBox>
            <br />
            <p class="LoginText">Password</p>
            <asp:TextBox runat="server" ID="PasswordBox" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Button runat="server" ID="loginButton" Text="Login" OnClick="loginButton_Click" />
            <asp:RegularExpressionValidator ID="regexpName" runat="server"     
                                    ErrorMessage="This expression does not validate." 
                                    ControlToValidate="UsernameBox"     
                                    ValidationExpression="^[a-zA-Z'.\s]{1,40}$" />
        </div>
    </form>
</body>
</html>
