<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="ChangeAvatar.aspx.cs" Inherits="ChangeAvatar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">



    <div class="UserOptionsBox">
        <ul>
            <li><a href="settings.aspx">Edit Profile</a></li>
            <li>Change Avatar</li>
        </ul>
   </div>

    <img class="Avatar" src="img/avatarer/avatar1.png" /> <input type="radio" class="regular-checkbox" name="avatar" value="img/avatarer/avatar1.png" runat="server" id="avatar1"/>
    <img class="Avatar" src="img/avatarer/avatar2.png" /> <input type="radio" class="regular-checkbox" name="avatar" value="img/avatarer/avatar2.png" runat="server" id="avatar2"/>
    <img class="Avatar" src="img/avatarer/avatar3.png" /> <input type="radio" class="regular-checkbox" name="avatar" value="img/avatarer/avatar3.png" runat="server" id="avatar3"/>
    <img class="Avatar" src="img/avatarer/avatar4.png" /> <input type="radio" class="regular-checkbox" name="avatar" value="img/avatarer/avatar4.png" runat="server" id="avatar4"/>
    <img class="Avatar" src="img/avatarer/avatar5.png" /> <input type="radio" class="regular-checkbox" name="avatar" value="img/avatarer/avatar5.png" runat="server" id="avatar5"/>
    <img class="Avatar" src="img/avatarer/avatar6.png" /> <input type="radio" class="regular-checkbox" name="avatar" value="img/avatarer/avatar6.png" runat="server" id="avatar6"/>
    <img class="Avatar" src="img/avatarer/avatar7.png" /> <input type="radio" class="regular-checkbox" name="avatar" value="img/avatarer/avatar7.png" runat="server" id="avatar7"/>
    <img class="Avatar" src="img/avatarer/avatar8.png" /> <input type="radio" class="regular-checkbox" name="avatar" value="img/avatarer/avatar8.png" runat="server" id="avatar8"/>
    <img class="Avatar" src="img/avatarer/avatar9.png" /> <input type="radio" class="regular-checkbox" name="avatar" value="img/avatarer/avatar9.png" runat="server" id="avatar9"/>
    <img class="Avatar" src="img/avatarer/avatar10.png" /> <input type="radio" class="regular-checkbox" name="avatar" value="img/avatarer/avatar10.png" runat="server" id="avatar10"/>
    
    
    <asp:Button ID="SaveChangesBtn" type="submit" runat="server" Text="Save Avatar" cssclass="SaveAvatar" OnClick="SaveAvatar_Click"/>






</asp:Content>

