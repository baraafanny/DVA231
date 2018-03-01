<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMasterPage.master" AutoEventWireup="true" CodeFile="AboutUs.aspx.cs" Inherits="Default2" %>

<asp:Content ID="AboutUsContent" ContentPlaceHolderID="MainContent" Runat="Server">

    <h1 class="AboutUsBox">We are the creators </h1>
    <span class="AboutUsBox">This is a project for the course DVA231 founded in 2017. The main idea is to gather students helping other students getting along with courses they have yet not finished. </span>
    <br />
    <div class="AboutUsList">
        <ul>
            <li onclick="showDiv('erika')">Erika</li>
            <li onclick="showDiv('fanny')">Fanny</li>
            <li onclick="showDiv('jonathan')">Jonathan</li>
            <li onclick="showDiv('linus')">Linus</li>
            <li onclick="showDiv('viktor')">Viktor</li>
        </ul>
    </div>
    <div id="THEDIV" class="AboutDiv">

        <img class="AboutUsImage" style="display: none;" id="AboutImg" />
        <h1 id="AboutHeader"></h1>
        <p id="AboutText"></p>

    </div>



    <script type="text/javascript">


        function showDiv(name) {
           
            if (name == 'erika') {
                AboutImg.style = "display: show";
                document.getElementById("AboutImg").src = "img/ewr15001.jpg";
                document.getElementById("AboutHeader").innerHTML = "Erika Weilander";
                document.getElementById("AboutText").innerHTML = "Project leader";
            }
            if (name == 'fanny') {
                AboutImg.style = "display: show";
                document.getElementById("AboutImg").src = "img/fdn16001.jpg";
                document.getElementById("AboutHeader").innerHTML = "Fanny Danielsson";
                document.getElementById("AboutText").innerHTML = "Database handler and Software developer";
            }
            if (name == 'jonathan') {
                AboutImg.style = "display: show";
                document.getElementById("AboutImg").src = "img/jmr16009.jpg";
                document.getElementById("AboutHeader").innerHTML = "Jonathan Major";
                document.getElementById("AboutText").innerHTML = "Software developer with child";
            }
            if (name == 'linus') {
                AboutImg.style = "display: show";
                document.getElementById("AboutImg").src = "img/lis16001.jpg";
                document.getElementById("AboutHeader").innerHTML = "Linus Sens Ingels";
                document.getElementById("AboutText").innerHTML = "Software developer without children";
            }
            if (name == 'viktor') {
                AboutImg.style = "display: show";
                document.getElementById("AboutImg").src = "img/vbn16001.jpg";
                document.getElementById("AboutHeader").innerHTML = "Viktor";
                document.getElementById("AboutText").innerHTML = "Graphical Designer/UX Designer";
            }
        }

    </script>

</asp:Content>

