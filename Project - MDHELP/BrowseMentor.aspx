<%@ Page Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="BrowseMentor.aspx.cs" Inherits="BrowseMentor" %>



<asp:Content ID="BrowseMentor" ContentPlaceHolderID="MainContent" Runat="Server">

    <h1 id="HeadingText">Search For Mentors</h1>
  
        <div class="background"> 
                                      
        <div id="SearchMentor"> 
        <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional" >
                 <ContentTemplate>    

                             <asp:DropDownList ID="ddlCourses" class="ddlCourses" runat="server" AutoPostBack="True" OnSelectedIndexChanged="FillMentorTable">
                              </asp:DropDownList>                         
                     
                             <asp:GridView class="GridTable" ID="GridView1" runat="server" autopostback="true" onclick="SelectedMentor()" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" RowStyle-CssClass="row">
                                  
                             </asp:GridView>
                                                                                                                                                  
                 </ContentTemplate>  
               
         </asp:UpdatePanel> 
         </div> 
        

	
			<div id="Mentorbackgroud">
            <div id="Mentorname"> </div>
           <a runat="server" class="MessageLink" id="MessageLink" href="Messages.aspx" onserverclick="MessageMentor_ServerClick"><p id="MessageMentor">Message this Mentor</p></a>
			<p id="hoverme">hover me!</p>
			
			<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" >
			<ContentTemplate> 
					<img ID="MentorProfilePic" class="MentorProfilePic" src="img/Fanny.jpg" runat="server"/>	
					<p ID="ProfileInfo" class="ProfileInfo" runat="server"></p>     
				</ContentTemplate>  
            </asp:UpdatePanel>  
			
				<p class="AvailableText">I'm Available:</p>
			</div>   
   
        <asp:hiddenfield ID ="StudentID" runat="server" OnValueChanged="Firstname_ValueChanged" ></asp:hiddenfield>       
    
              
   </div>


<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
<script type = "text/javascript">
   

    function SelectedMentor() { 
                     
		  $("#<%=GridView1.ClientID%> tr").click (function () { 
            
                var SelectedMentor = $(this).find("td:first").html(); 
                var Firstname = $(this).find("td:nth-child(2)").html();
				
				if (SelectedMentor == undefined)
                {
                    return false;
                }
              
				document.getElementById("<%=StudentID.ClientID%>").value = SelectedMentor; //Skicka StudID till hiddenfield
				$('.MentorProfilePic').stop().css('visibility', 'visible').hide().fadeIn(800);	
				$("#Mentorname").text(Firstname);
               // $("#ProfileInfo").text(SelectedMentor);
               // MentorProfilePic.src = "img/" + SelectedMentor + ".jpg";				
                $('#Mentorname').css('visibility', 'visible').hide().fadeIn(400);
				$('#MessageMentor').css('visibility', 'visible').hide().fadeIn(1400);
				$('#hoverme').css('visibility', 'visible').hide().fadeIn(1600);
                $('.littleme').css('visibility', 'visible').hide().fadeIn(2000);        
				Mentorbackgroud.style.visibility = "visible"; 
				});
	};   
	
	$("#Mentorbackgroud").on('mouseenter', function () {
				 
				$(this).stop().animate({ height: "400" }, 100);
				$('#hoverme').stop().css('visibility', 'visible').hide().fadeOut(300);
				$('.MentorProfilePic').stop().css('visibility', 'visible').hide().fadeIn(800);		
				$('.AvailableText').stop().css('visibility', 'visible').hide().fadeIn(1000);
				$('.ProfileInfo').stop().css('visibility', 'visible').hide().fadeIn(1500);
			
	   }).on('mouseleave', function () {
			
		   $('.MentorProfilePic').stop().css('visibility', 'visible').hide().fadeOut(1000);
		   $('.AvailableText').stop().css('visibility', 'visible').hide().fadeOut(800);
		   $('.ProfileInfo').stop().css('visibility', 'visible').hide().fadeOut(600);
		   $('#hoverme').stop().css('visibility', 'visible').hide().fadeIn(200);	
		   $(this).stop().animate({ height: "170" }, 100); 
			
		   }).children().mouseover(function () {
				 return false;
			 });
		
 </script>

</asp:Content>



