<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="Settings.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <div class="UserOptionsBox">
        <ul>
            <li>Edit Profile</li>
            <li><a href="ChangeAvatar.aspx">Change Avatar </a></li>
        </ul>
    </div>
        <div class="SettingsBox">
           <h3 class="InfoHeadline">Info:</h3>
              <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional">
                  <ContentTemplate>
                      <asp:Textbox runat="server" ID="infobox" class="SettingsInfo" placeholder="Short description of 50 tecken"></asp:Textbox>
                  </ContentTemplate>
            </asp:UpdatePanel>
            <div class="Settings">
                <div class="Box1">
                    <h3>I want to be seen as a:</h3>
                    <label for="Student">Student</label>    
                    <input type="checkbox" class="regular-checkbox" name="Student" value="1" runat="server" id="StudentCheckbox"/>
                    <br />
                    <label for="Mentor">Mentor</label>
                    <input type="checkbox" class="regular-checkbox" name="Mentor"  value="1" runat="server" id="MentorCheckbox"/>
                </div>
                <div class="Box2">
                    <h3>I could meet up in:</h3>
                    <label for="City">Västerås</label>
                    <input type="checkbox" class="regular-checkbox" name="City" value="Västerås" runat="server" id="Västerås"/>
                    <br />
                    <label for="City">Eskilstuna</label>
                    <input type="checkbox" class="regular-checkbox" name="City"  value="Eskilstuna" runat="server" id="Eskilstuna"/>
                 </div>
                 <br /><br />
                 <div class="MentorList" runat="server" id="MentorList">
                    <h3> I want to mentor these courses:</h3>
                    <asp:DropDownList ID="CompletedCourses" runat="server" class="DropDownStyle"></asp:DropDownList>
                    <asp:Button ID="AddMentorCourseBtn" runat="server" OnClick="AddMentorCourseBtn_Click" Text="Add" CssClass="AddMentorCourseBtn"/>
                    <div class="MentorCourses">
                         <asp:ListBox ID="MChosenCourses"  runat="server" class="ListBoxStyle"></asp:ListBox>
                         <asp:Button ID="RemoveMentorCourseBtn" runat="server" OnClick="RemoveMentorCourseBtn_Click" Text="Remove" CssClass="RemoveMentorCourseBtn" />                        
                    </div>
                 </div>
                 <div class="AvailableDays">
                    <h3> I am available these days:</h3>
                    <asp:DropDownList ID="AvailableDaysDrop" runat="server" class="AvailableDaysDrop"></asp:DropDownList>
                    <asp:Button ID="AddWeekdayBtn" runat="server" OnClick="AddWeekdayBtn_Click" Text="Add" CssClass="AddWeekdayBtn"/>

                    <div class="InsideAvailableDays">
                    <asp:ListBox ID="AvailableDaysBox"  runat="server" class="AvailableDaysBox"></asp:ListBox>
                    <asp:Button ID="RemoveAvailableDays" runat="server" OnClick="RemoveAvailableDay_Click" Text="Remove" CssClass="RemoveAvailableDaysBtn" />                        

                    </div>
                 </div>


            </div>
        </div>
             


            <asp:Button ID="SaveChangesBtn" type="submit" runat="server" Text="Save changes" cssclass="SaveChangesBtn" OnClick="SaveChangesBtn_Click" />

        </>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
 <script type = "text/javascript">

	 
	 $("#<%=MentorCheckbox.ClientID%>").click(function () {


		 if ($("#<%=MentorCheckbox.ClientID%>").is(":checked")) {
             $('.MentorList').css('visibility', 'visible').show();
             $('.AvailableDays').css('visibility', 'visible').show();
			 }
         else
         {
             $('.MentorList').css('visibility', 'hidden').hide()

				$('.AvailableDays').css('visibility', 'hidden').hide()
	     }
	 });  


</script>
</asp:Content>