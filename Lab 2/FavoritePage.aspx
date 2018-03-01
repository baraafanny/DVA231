<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FavoritePage.aspx.cs" Inherits="FavoritePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

</head>
<body onload="addFavoriteName()">
    <form id="form1" runat="server">
        <div>

            <h1 id="header"></h1>

        </div>
    </form>

    <script>

        function addFavoriteName() {
            document.getElementById("header").innerHTML = sessionStorage.getItem("addFavorites");
            document.getElementById("header").innerHTML += " has been added to favorites!";
        }

    </script>
</body>
</html>