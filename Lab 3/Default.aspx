<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
		<meta charset="UTF-8">
		<meta name="viewport" content="width=device-width, initial-scale=1"> <!-- FITS ALL SCREENS -->
		<style type="text/css">

		body 
		{
			background-color: #B8B8B4;
		}
		h1
		{
			font-family: Arial;
			color: white;
			font-size: 14px;
			font-weight: normal;
		}
		p
		{
			font-family: Arial;
			color: white;
			font-size: 12px;
		}
		h2
		{
			font-family: Arial;
			color: gold;
			font-size: 14px;
			font-weight: normal;		
		}
		h3
		{
			font-family: Arial;
			color: white;
			font-size: 16px;
			font-weight: normal;		
		}
       .h3
		{
			font-family: Arial;
			color: white;
			font-size: 16px;
			font-weight: normal;		
		}
		h4
		{
			font-family: Arial;
			color: black;
			font-size: 18px;
			font-weight: normal;
		}
		h5
		{
			font-family: Arial;
			color: #424242;
			font-size: 24px;
			font-weight: normal;
		}
		#topborder
		{
			width: 1000px;
			height: 18px;
			position: absolute;
			left: 50%;
			margin-left: -500px;
			top: -5px;
			border-bottom-color: #292929;
			border-bottom-width: 2px;
			border-bottom-style: solid;
			background-color: grey;
		}
		#topbanner 
		{
			width: 1000px;
			height: 82px;
			position: absolute;
			left: 50%;
			margin-left: -500px;
			background: linear-gradient(grey, black);
			top: 15px;
		}
		#searchbar
		{
			width: 435px;
			height: 30px;
			position: absolute;
			left: 140px;
			top: 8px; 
			font-family: Arial;
			font-size: 16px;
		}
		#dropdownsearch
		{
			width: 100px;
			height: 30px;
			position: absolute;
			left: 576px;
			top: 8px;
			font-family: Arial;
			font-size: 16px;
		}
		#topbannerfield1
		{
			left: 140px;
			top: 40px;
			position: absolute;

		}
		#topbannerfield2
		{
			left: 283px;
			top: 40px;
			position: absolute;
		}
		#topbannerfield3
		{
			left: 426px;
			top: 40px;
			position: absolute;

		}
		#topbannerfield4
		{
			left: 569px;
			top: 40px;
			position: absolute;
		}
		#topbannerwatchlist
		{
			top: 10px;
			left: 14px;
			position: absolute;
		}
		.fields
		{
			position: absolute;
			width: 142px;
			height: 42px;
			background-color: transparent;
			border-left-width: 1px;
			border-right-width: 1px;
			border-color: white;
			border-left-style: solid;
			border-right-style: solid;
			border-image: linear-gradient(black, white, black);
			border-image-slice: 1;
		}
		.fieldtext
		{
			margin: 2px;
		}
		#imdblogo
		{
			width: 100px;
			height: 50px;
			position: absolute;
			left: 16px;
			top: 16px;
		}
		.topbannerarrowimg
		{
			width: 10px;
			position: absolute;
			left: 120px;
			top: 18px;
		}
		#searchbuttonimg
		{
			width: 33px;
			position: absolute;
			left: 678px;
			top: 8px;
		}
		#imdbproimg
		{
			width: 65px;
			position: absolute;
			left: 750px;
			top: 12px;
		}
		#imdbproarrowimg
		{
			width: 10px;
			position: absolute;
			left: 806px;
			top: 20px;
		}
		#imdbproimg
		{
			width: 65px;
			position: absolute;
			left: 750px;
			top: 12px;
		}
		#facebookimg
		{
			width: 26px;
			position: absolute;
			left: 890px;
			top: 12px;
		}
		#twitterimg
		{
			width: 28px;
			position: absolute;
			left: 921px;
			top: 12px;
		}
		#instagramimg
		{
			width: 30px;
			position: absolute;
			left: 952px;
			top: 10px;
		}
		#topbannertext
		{
			width: 50px;
			height: 15px;
			position: absolute;
			left: 835px;
			top: 18px;
			border-left-color: white;
			border-right-color: white;
			border-width: 1px;
			border-left-style: solid;
		}
		#topbannertext1
		{
			position: absolute;
			left: 10px;
			top: -10px;
		}
		#signinimg
		{
			width: 160px;
			position: absolute;
			left: 715px;
			top: 35px;
		}
		.topbannertext2
		{
			position: absolute;
			left: 896px;
			top: 54px;
			text-decoration: underline;
            font-family: Arial;
			color: white;
			font-size: 12px;
		}
		#trailerboard
		{
			width: 669px;
			height: 362px;
			position: absolute;
			left: 50%;
			margin-left: -500px;
			top: 97px;
			background-color: #2E2E2E;
		}
		#img01
		{
			width: 204px;
			height: 300px;
		}
		#img02
		{
			width: 204px;
			height: 300px;
		}
		#img03
		{
			width: 204px;
			height: 300px;
		}
		#trailerposter1
		{
			position: absolute;
			left: 20px;
			top: 20px;
		}
		#trailerposter2
		{
			position: absolute;
			left: 233px;
			top: 20px;
		}
		#trailerposter3
		{
			position: absolute;
			left: 446px;
			top: 20px;
		}
		#trailerbordtext1
		{
			position: absolute;
			top: 320px;
			left: 20px;
			color: #63C9FF;
		}
		#trailerbordtextarrow
		{
			position: absolute;
			top: 320px;
			left: 115px;
			color: grey;
		}
		#trailerpostertextbackground1
		{
			position: absolute;
			background-color: rgba(0, 0, 0, 0.5);
			width: 204px;
			height: 65px;
			top: 235px;
		}
		#trailerpostertextbackground1:hover
		{
			position: absolute;
			background-color: rgba(0, 0, 0, 0.5);
			width: 204px;
			height: 300px;
			top: 0px;
		}
		#trailerpostertext1
		{
			position: absolute;
			top: -6px;
			left: 10px;
		}
		#trailerposterparagraph1
		{
			position: absolute;
			left: 10px;
			top: 35px;
		}
		#trailerinfotext1
		{
			position: absolute;
			left: 10px;
			top: 50px;
			color: transparent;
		}
		#trailerpostertextbackground2
		{
			position: absolute;
			background-color: rgba(0, 0, 0, 0.5);
			width: 204px;
			height: 65px;
			top: 235px;
		}
		#trailerpostertextbackground2:hover
		{
			position: absolute;
			background-color: rgba(0, 0, 0, 0.5);
			width: 204px;
			height: 300px;
			top: 0px;
		}
		#trailerpostertext2
		{
			position: absolute;
			left: 10px;
			top: -6px;
		}
		#trailerposterparagraph2
		{
			position: absolute;
			left: 10px;
			top: 35px;
		}
		#trailerpostertextbackground3
		{
			position: absolute;
			background-color: rgba(0, 0, 0, 0.5);
			width: 204px;
			height: 65px;
			top: 235px;
		}
		#trailerpostertextbackground3:hover
		{
			position: absolute;
			background-color: rgba(0, 0, 0, 0.5);
			width: 204px;
			height: 300px;
			top: 0px;
		}
		#trailerinfotext2
		{
			position: absolute;
			left: 10px;
			top: 50px;
			color: transparent;
		}
		#trailerpostertext3
		{
			position: absolute;
			left: 10px;
			top: -6px;
		}
		#trailerposterparagraph3
		{
			position: absolute;
			left: 10px;
			top: 35px;
		}
		#trailerinfotext3
		{
			position: absolute;
			left: 10px;
			top: 50px;
			color: transparent;
		}
		.trailerplayarrow
		{
			position: absolute;
			width: 50px;
			height: 50px;
			left: 75px;
			top: 124px;
		}
        .PosterButton
        {
            position: absolute;
            width: 23px;
            height: 23px;
            left: 88%;
        }
		#rightfield
		{
			width: 327px;
			height: 900px;
			position: absolute;
			left: 50%;
			margin-left: 173px;
			top: 97px;
			background-color: #F0F0F0;
		}
		.tableflagcolumn
		{
			width: 34px;
		}
		.flagicon
		{
			width: 37px;
			text-align: left;
		}
		#OpeningthisweekbackgroundBorder
		{
			width: 288px;
			height: 525px;
			position: absolute;
			left: 20px;
			border-bottom-width: 1px;
			border-bottom-color: grey;
			border-bottom-style: solid;  
		}
		#nowPlayingBackgroundBorder
		{
			width: 288px;
			height: 834px;
			position: absolute;
			left: 20px;
			border-bottom-width: 1px;
			border-bottom-color: grey;
			border-bottom-style: solid; 
		}
		#OpeningThisweekTable
		{
			position: absolute;
			width: 300px;
			left: 18px;
		}
		#NowPlayingTable
		{
			width: 300px;
			position: absolute;
			left: 18px;
			top: 530px;
			line-height: 6px;
		}
		.tableCaptionTitle
		{
			text-align: left;
		}
		.tableTitleText
		{
			color: #136CC0;
			text-align: left;
		}
		.tableStatusText
		{
			color: grey;
			text-align: right;
			font-weight: 100;
		}
		.nowPlayingSmallText
		{
			text-align: left;
			color: grey;
			font-weight: 100;
		}
		#seeMoreOpeningThisWeekText
		{
			position: absolute;
			left: 20px;
			top: 480px;
			color: #136CC0;
		}
		#TextArrow
		{
			position: absolute;
			left: 206px;
			top: 480px;
			color: grey;
		}
		#seeMoreResultText
		{
			position: absolute;
			left: 20px;
			top: 784px;
			color: grey;
		}
		#TextArrowResult
		{
			position: absolute;
			left: 196px;
			top: 784px;
			color: grey;
		}
		.NewsBoard
		{
			width: 669px;
			height: 376px;
			position: absolute;
			left: 50%;
			margin-left: -500px;
			top: 500px;
			background-color: white;
			border-bottom-color: grey;
			border-bottom-style: solid;
			border-bottom-width: 1px;
		}
		#NewsBoard1
		{
			top: 460px;
		}
		.NewsTitleText
		{
			left: 20px;
			position: absolute;
			top: -10px;
		}
		.NewsText
		{
			position: absolute;
			left: 20px;
			top: 60px;
			font-size: 14px;
			color: #424242;
			font-weight: 100;
		}
		#Newsvid1
		{
			position: absolute;
			top: 116px;
			left: 20px;
		}
		#img2
		{
			position: absolute;
			top: 116px;
			left: 340px;
		}
		#seeEntireList
		{
			position: absolute;
			left: 20px;
			top: 342px;
			color: #136CC0;
		}
		#EntireListarrow
		{
			position: absolute;
			left: 134px;
			top: 342px;
			color: grey;
		}
		</style>
	</head>
	<body runat="server">
        <form runat="server">
		<div id="topborder"></div>

		<div id="topbanner">
			<img id="imdblogo" src="img/logo.png"></img>
			<img id="searchbuttonimg" src="img/searchButton.png"></img>
			<img id="imdbproimg" src="img/imdbpro.png"></img>
			<img id="imdbproarrowimg" src="img/arrow.png"></img>
			<img id="facebookimg" src="img/fb.png"></img>
			<img id="twitterimg" src="img/twitter.png"></img>
			<img id="instagramimg" src="img/instagram.png"></img>
			<img id="signinimg" src="img/signin.png"></img>
			
            
                <asp:LinkButton runat="server" ID="LoginButton" CssClass="topbannertext2" Text="Sign in" OnClick="LoginButton_Click"></asp:LinkButton>
			<div id="topbannertext">
				<p id="topbannertext1">Help</p>
			</div>
				<input id="searchbar" type="text" placeholder="Find Movies, TV shows, Celebrities and more..."></input>
				<input id="dropdownsearch" type="text" placeholder="All"></input>
		
			<div id="topbannerfield1" class="fields">
				<h1 class="fieldtext">Movies, TV</h1>
				<h1 class="fieldtext">& Showtimes</h1>
				<img class="topbannerarrowimg" src="img/arrow.png"></img>
			</div>
			<div id="topbannerfield2" class="fields">
				<h1 class="fieldtext">Celebs, Events</h1>
				<h1 class="fieldtext">& Photos</h1>
				<img class="topbannerarrowimg" src="img/arrow.png"></img>
			</div>
			<div id="topbannerfield3" class="fields">
				<h1 class="fieldtext">News &</h1> 
				<h1 class="fieldtext">Community</h1>
				<img class="topbannerarrowimg" src="img/arrow.png"></img>
			</div>
			<div id="topbannerfield4" class="fields">
				<h2 id="topbannerwatchlist" class="fieldtext">Watchlist</h2>
				<img class="topbannerarrowimg" src="img/arrow.png"></img>
			</div>
		</div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
		<div id="trailerboard">
			<div id="trailerposter1">
                <asp:ImageButton runat="server" ID="PosterButton1" CssClass="PosterButton" ImageUrl="img/greystar.png" OnClick="PosterButton1_Click" OnClientClick="addToFavorites1()"/>
				<img runat="server" id="img01" src=""></img>
				<img class="trailerplayarrow" src="img/playVideoArrow.png"></img>

				<div runat="server" id="trailerpostertextbackground1" onmouseover="onHover(1)" onmouseout="onNotHover(1)">

					<h3 runat="server" id="trailerpostertext1">"Braveheart"</h3>
					<p runat="server" id="trailerposterparagraph1">Trailer #1</p>
					<p runat="server" id="trailerinfotext1"></p>

				</div>
			</div>
			<div id="trailerposter2">
                <asp:ImageButton runat="server" ID="PosterButton2" CssClass="PosterButton" ImageUrl="img/greystar.png" OnClick="PosterButton2_Click" OnClientClick="addToFavorites2()"/>
				<img runat="server" id="img02" src=""></img>
				<img class="trailerplayarrow" src="img/playVideoArrow.png"></img>

				<div runat="server" id="trailerpostertextbackground2" onmouseover="onHover(2)" onmouseout="onNotHover(2)">

					<h3 runat="server" id="trailerpostertext2">"Tom Hanks is Forrest Gump"</h3>
					<p runat="server" id="trailerposterparagraph2">Trailer #2</p>
					<p runat="server" id="trailerinfotext2"></p>
				</div>
			</div>
			<div id="trailerposter3">
                <asp:ImageButton runat="server" ID="PosterButton3" CssClass="PosterButton" ImageUrl="img/greystar.png" OnClick="PosterButton3_Click" OnClientClick="addToFavorites3()"/>
				<img runat="server" id="img03" src=""></img>
				<img class="trailerplayarrow" src="img/playVideoArrow.png"></img>

				<div runat="server" id="trailerpostertextbackground3" onmouseover="onHover(3)" onmouseout="onNotHover(3)">

					<h3 runat="server" id="trailerpostertext3">"Fullmetal Alchemist: Brotherhood"</h3>
					<p runat="server" id="trailerposterparagraph3">Season #2 Trailer #1</p>
					<p runat="server" id="trailerinfotext3"></p>
				</div>
			</div>
			<h1 id="trailerbordtext1">Browse trailers</h1>
			<h1 id="trailerbordtextarrow">&#187</h1>
		</div>
        </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="changePosterTimer" EventName="Tick" />
            </Triggers>
        </asp:UpdatePanel>
        <asp:Timer ID="changePosterTimer" runat="server" Interval="200" OnTick="changePosterTimer_Tick"></asp:Timer>

		<div id="rightfield">
			<div id="OpeningthisweekbackgroundBorder"></div>
			<div id="nowPlayingBackgroundBorder"></div>
				<table id="OpeningThisweekTable">
					<caption>
					<h4 class="tableCaptionTitle">Coming soon</h4>
					</caption>
					<tr>
						<th class="tableflagcolumn">
							<img class="flagicon" src="img/flagIcon.png">
						</th>
						<th>
							<h1 runat="server" id="OpeningThisweekTitle01" class="tableTitleText">Seven Deadly Sins</h1>
						</th>
						<th>
							<p runat="server" id="OpeningThisweekDate01" class="tableStatusText"></p>
						</th>
					</tr>
						<tr>
						<th class="tableflagcolumn">
							<img class="flagicon" src="img/flagIcon.png">
						</th>
						<th>
							<h1 runat="server" id="OpeningThisweekTitle02" class="tableTitleText">The Rock</h1>
						</th>
						<th>
							<p runat="server" id="OpeningThisweekDate02" class="tableStatusText">Limited</p>
						</th>
					</tr>
					<tr>
						<th class="tableflagcolumn">
							<img class="flagicon" src="img/flagIcon.png">
						</th>
						<th>
							<h1 runat="server" id="OpeningThisweekTitle03" class="tableTitleText">Home Alone 3</h1>
						</th>
						<th>
							<p runat="server" id="OpeningThisweekDate03" class="tableStatusText">Limited</p>
						</th>
					</tr>
					<tr>
						<th class="tableflagcolumn">
							<img class="flagicon" src="img/flagIcon.png">
						</th>
						<th>
							<h1 runat="server" id="OpeningThisweekTitle04" class="tableTitleText">Kingsman Secret Service</h1>
						</th>
						<th>
							<p runat="server" id="OpeningThisweekDate04" class="tableStatusText">Limited</p>
						</th>
					</tr>
					<tr>
						<th class="tableflagcolumn">
							<img class="flagicon" src="img/flagIcon.png">
						</th>
						<th>
							<h1 runat="server" id="OpeningThisweekTitle05" class="tableTitleText">Pirates Of the Caribbean 2</h1>
						</th>
						<th>
							<p runat="server" id="OpeningThisweekDate05" class="tableStatusText">Limited</p>
						</th>
					</tr>
					<tr>
						<th class="tableflagcolumn">
							<img class="flagicon" src="img/flagIcon.png">
						</th>
						<th>
							<h1 runat="server" id="OpeningThisweekTitle06" class="tableTitleText">Harry Potter and The Cursed Child</h1>
						</th>
						<th>
							<p runat="server" id="OpeningThisweekDate06" class="tableStatusText">Limited</p>
						</th>
					</tr>
					<tr>
						<th class="tableflagcolumn">
							<img class="flagicon" src="img/flagIcon.png">
						</th>
						<th>
							<h1 runat="server" id="OpeningThisweekTitle07" class="tableTitleText">Lord of the Rings 3</h1>
						</th>
						<th>
							<p runat="server" id="OpeningThisweekDate07" class="tableStatusText">Limited</p>
						</th>
					</tr>
					<tr>
						<th class="tableflagcolumn">
							<img class="flagicon" src="img/flagIcon.png">
						</th>
						<th>
							<h1 runat="server" id="OpeningThisweekTitle08" class="tableTitleText">Aragon</h1>
						</th>
						<th>
							<p runat="server" id="OpeningThisweekDate08" class="tableStatusText">Release</p>
						</th>
					</tr>
					<tr>
						<th class="tableflagcolumn">
							<img class="flagicon" src="img/flagIcon.png">
						</th>
						<th>
							<h1 runat="server" id="OpeningThisweekTitle09" class="tableTitleText">Inside</h1>
						</th>
						<th>
							<p runat="server" id="OpeningThisweekDate09" class="tableStatusText">Limited</p>
						</th>
					</tr>
				</table>

				<h1 id="seeMoreOpeningThisWeekText">See more opening this week</h1>
				<h1 id="TextArrow">&#187</h1>

				<table id="NowPlayingTable">
					<caption>
					<h4 class="tableCaptionTitle">Top Rated</h4>
					</caption>
					<tr>
						<th class="tableflagcolumn">
							<img class="flagicon" src="img/flagIcon.png">
						</th>
						<th>
							<h1 runat="server" id="TopRatedTitle01" class="tableTitleText">Assasins Creed</h1>
							<p runat="server" id="TopRatedText01" class="nowPlayingSmallText">&dollar;14.5M</p>
						</th>
					</tr>
					<tr>
						<th class="tableflagcolumn">
							<img class="flagicon" src="img/flagIcon.png">
						</th>
						<th>
							<h1 runat="server" id="TopRatedTitle02" class="tableTitleText">Romeo and Juliet</h1>
							<p runat="server" id="TopRatedText02" class="nowPlayingSmallText">&dollar;20.5M</p>
						</th>
					</tr>
					<tr>
						<th class="tableflagcolumn">
							<img class="flagicon" src="img/flagIcon.png">
						</th>
						<th>
							<h1 runat="server" id="TopRatedTitle03" class="tableTitleText">Avatar</h1>
							<p runat="server" id="TopRatedText03" class="nowPlayingSmallText">&dollar;45.5M</p>
						</th>
					</tr>
					<tr>
						<th class="tableflagcolumn">
							<img class="flagicon" src="img/flagIcon.png">
						</th>
						<th>
							<h1 runat="server" id="TopRatedTitle04" class="tableTitleText">Jesus</h1>
							<p runat="server" id="TopRatedText04" class="nowPlayingSmallText">&dollar;0.5M</p>
						</th>
					</tr>
					<tr>
						<th class="tableflagcolumn">
							<img class="flagicon" src="img/flagIcon.png">
						</th>
						<th>
							<h1 runat="server" id="TopRatedTitle05" class="tableTitleText">Amareto</h1>
							<p runat="server" id="TopRatedText05" class="nowPlayingSmallText">&dollar;4.5M</p>
						</th>
					</tr>
				</table>

				<h1 id="seeMoreResultText">See more Top Rated</h1>
				<h1 id="TextArrowResult">&#187</h1>
		</div>
		<div id="NewsBoard1" class="NewsBoard">
			<h5 class="NewsTitleText">Top 5 Summer Movies From Each of the Past 15 Years</h5>
			<p class="NewsText">With summer movie season coming to a close, look back at the top 5 highest grossing movies at the domestic box office from each of the past 15 years. How did 2017 compare?</p>
			<iframe id="Newsvid1" width="308" height="230" src="https://www.youtube.com/embed/SsWlyce0Fho" frameborder="0" allowfullscreen></iframe>
			<img id="img2" src="img/newsimg/2.jpg"></img>
			<h1 id="seeEntireList">See the entire list</h1>
			<h1 id="EntireListarrow">&#187</h1>
		</div>
        
		<script type="text/javascript">
            function addToFavorites1()
            {
                document.getElementById("PosterButton1").src = "img/star.png";
                var xhttp = new XMLHttpRequest();
                xhttp.onreadystatechange = function ()
                {
                    if (xhttp.readyState == 4 && xhttp.status == 200)
                    {
                        //UpdatePanel();
                    }
                }
                xhttp.open("GET", "addToFavorites.aspx?number=1", true);
                xhttp.send(null);
            }
            function addToFavorites2() {
                document.getElementById("PosterButton2").src = "img/star.png";
                var xhttp = new XMLHttpRequest();
                xhttp.onreadystatechange = function ()
                {
                    if (xhttp.readyState == 4 && xhttp.status == 200)
                    {
                        //UpdatePanel();
                    }
                }
                xhttp.open("GET", "addToFavorites.aspx?number=2", true);
                xhttp.send(null);
            }
            function addToFavorites3()
            {
                document.getElementById("PosterButton3").src = "img/star.png";
                var xhttp = new XMLHttpRequest();
                xhttp.onreadystatechange = function ()
                {
                    if (xhttp.readyState == 4 && xhttp.status == 200)
                    {
                      //UpdatePanel();
                    }
                }
                xhttp.open("GET", "addToFavorites.aspx?number=3", true);
                xhttp.send(null);
            }
			function onHover(posternumber)
			{
				if(posternumber == 1)
				{
					document.getElementById("trailerinfotext1").style.color="white";
				}
				if(posternumber == 2)
				{
					document.getElementById("trailerinfotext2").style.color="white";
				}
				if(posternumber == 3)
				{
					document.getElementById("trailerinfotext3").style.color="white";
				}
			}
			function onNotHover(posternumber)
			{

				if(posternumber==1)
				{
					document.getElementById("trailerinfotext1").style.color="transparent";
				}
				else if(posternumber==2)
				{
					document.getElementById("trailerinfotext2").style.color="transparent";
				}
				else if(posternumber==3)
				{
					document.getElementById("trailerinfotext3").style.color="transparent";
				}
            }
		</script>
        </form>
	</body>
</html>
