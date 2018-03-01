<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="MainPage.aspx.cs" Inherits="Default2" %>

<asp:Content ID="MainPageContent" ContentPlaceHolderID="MainContent" Runat="Server">

    <div class="LoggedInAs">
        <!--<h1>You are now logged in as <%Response.Write(Session["UsernameInlogged"]);%></h1>-->
        <asp:Label runat="server" ID="WelcomeText" CssClass="WelcomeText" Text="Welcome" />
    </div>


        <asp:Timer ID="ShowNewMessUpdateTimer" runat="server" Interval="1000" ></asp:Timer>
        <asp:UpdatePanel ID="ShowNewMessUpdatePanel" runat="server" UpdateMode="Conditional"><ContentTemplate>
                  <h1 runat="server" id="ShowNewMessages" class="NewMessages"></h1>
         </ContentTemplate>
           <Triggers>
               <asp:AsyncPostBackTrigger ControlID="ShowNewMessUpdateTimer" EventName="Tick" />
            </Triggers>
          </asp:UpdatePanel>

    <div class="SlideshowMP">
        <img src="img/f1.png" />
        <img  src="img/f2.jpg" />
        <img src="img/f3.png" />
        <img  src="img/f4.png" />
        <img src="img/f5.png" />
        <img  src="img/f6.png" />
     </div>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script>
        $(function changeMainPic() {
            $('.SlideshowMP img:gt(0)').hide();
            setInterval(function () {
                $('.SlideshowMP :first-child').fadeOut(2000)
                    .next('img').fadeIn(2000)
                    .end().appendTo('.SlideshowMP');
            },
                4000);
        });
    </script>

</asp:Content>

