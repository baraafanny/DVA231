<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default2" %>

<asp:Content ID="LoginContent" ContentPlaceHolderID="MainContent" Runat="Server">

    <div class="fadein">
        <%--Addera bilder här ifall ni vill ha andra bilder--%>
        <img src="img/FrontPage/2.jpg" />
        <img src="img/FrontPage/3.jpg" />
        <img src="img/FrontPage/4.jpg" />
        <img src="img/FrontPage/5.jpg" />
        <img src="img/FrontPage/6.jpg" />
        <img src="img/FrontPage/7.jpg" />
    </div>
    <%--<img src="img/MainPic.jpg" id="MainPic" />--%>
    <div>
        
        <p id="LoginText">StudentID</p>
        <asp:TextBox runat="server" ID="UsernameBox" placeholder="Enter StudentID"></asp:TextBox>
        <p id="LoginText">Password</p>
        <asp:TextBox runat="server" ID="PasswordBox" placeholder="Enter Password" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        <button runat="server" class="LoginButton" onserverclick="loginButton_Click">Log in</button>

        <%-- <asp:Button runat="server" ID="LoginButton" Text="Login" OnClick="loginButton_Click" />*/
            <%--<asp:RegularExpressionValidator ID="regexpName" runat="server"     
                                    ErrorMessage="This expression does not validate." 
                                    ControlToValidate="UsernameBox"     
                                    ValidationExpression="^[a-zA-Z'.\s]$" />--%>
    </div>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script>
        $(function changeMainPic() {
            $('.fadein img:gt(0)').hide();
            setInterval(function () {
                $('.fadein :first-child').fadeOut()
                    .next('img').fadeIn()
                    .end().appendTo('.fadein');
            },
                4000);
        });
    </script>

</asp:Content>

