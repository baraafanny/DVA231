<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="Messages.aspx.cs" Inherits="Default2" %>

<asp:Content ID="MessagesContent" ContentPlaceHolderID="MainContent" Runat="Server">

    <div runat="server" class="ChatBG">

        <div runat="server" class="ChatField">
            <asp:UpdatePanel ID="ContactUpdatePanel" runat="server" UpdateMode="Conditional"><ContentTemplate>
            <div runat="server" class="ContactsField">
                
                    <asp:Button runat="server" ID="Contact1" Text="" Font-Size="Larger" Font-Bold="true" CssClass="Contacts" OnClick="Contact1_Click" />
                    <asp:Button runat="server" ID="Contact2" Text="" Font-Size="Larger" Font-Bold="true" CssClass="Contacts" OnClick="Contact2_Click" />
                    <asp:Button runat="server" ID="Contact3" Text="" Font-Size="Larger" Font-Bold="true" CssClass="Contacts" OnClick="Contact3_Click" />
                    <asp:Button runat="server" ID="Contact4" Text="" Font-Size="Larger" Font-Bold="true" CssClass="Contacts" OnClick="Contact4_Click" />
                    <asp:Button runat="server" ID="Contact5" Text="" Font-Size="Larger" Font-Bold="true" CssClass="Contacts" OnClick="Contact5_Click" />
                    <asp:Button runat="server" ID="Contact6" Text="" Font-Size="Larger" Font-Bold="true" CssClass="Contacts" OnClick="Contact6_Click" />
                    <asp:Button runat="server" ID="Contact7" Text="" Font-Size="Larger" Font-Bold="true" CssClass="Contacts" OnClick="Contact7_Click" />
                    <asp:Button runat="server" ID="Contact8" Text="" Font-Size="Larger" Font-Bold="true" CssClass="Contacts" OnClick="Contact8_Click" />
                
            </div>

            <div runat="server" class="ActiveContactField">

                <p runat="server" id="ActiveUsernameText" class="ActiveUsernameText"></p>

            </div>
            </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                    </Triggers>
                </asp:UpdatePanel>

            <div runat="server" id="MessageField" class="MessageField">
                <asp:UpdatePanel ID="ChatUpdatePanel" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <ul runat="server" id="ChatMessagesList" class="ChatMessageList" >
                            <!--<li class="ReceiveChatBoxes">Hello?</li>-->
                            <!--<li class="ReceiveChatBoxes">This is just an example!</li>-->
                        </ul>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

            <asp:UpdatePanel ID="CheckUpdatePanel" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                </Triggers>
            </asp:UpdatePanel>

            <asp:Timer ID="Timer1" runat="server" Interval="2000" OnTick="Timer1_Tick"></asp:Timer>

            <div runat="server" class="WriteMessageField">

                <div runat="server" class="WritingBubbleField">

                    <asp:Panel runat="server" ID="WriteBubblePanel" DefaultButton="WriteBubbleSendButton" CssClass="WriteBubblePanel">
                        <asp:TextBox runat="server" ID="WriteBubbleTextBox" CssClass="WriteBubbleTextBox" MaxLength="500" BorderStyle="None" Font-Size="Larger" AutoCompleteType="Disabled"></asp:TextBox>
                        <asp:Button runat="server" ID="WriteBubbleSendButton" CssClass="WriteBubbleSendButton" OnClientClick="SendButton();return false;" Text="Send" Font-Size="Larger" BorderColor="Orange" BackColor="Orange" Font-Bold="true" />
                    </asp:Panel>

                </div>

            </div>

        </div>

    </div>

    <script type="text/javascript">

        function SendButton() {

            var activeChatUser = '<%=Session["ActiveContactId"]%>';

            if (activeChatUser != "")
            {
                //var li = document.createElement("li");
                //li.appendChild(document.createTextNode(document.getElementById().value));
                //li.setAttribute("class", "SendChatBoxes");
                //document.getElementById().appendChild(li);
                //try {
                    //document.getElementById().scrollBy(0, 10000);

                    var xhttp = new XMLHttpRequest();
                    xhttp.onreadystatechange = function () {
                        if (xhttp.readyState == 4 && xhttp.status == 200) {
                            //alert("Sent to server");
                            
                        }
                    }
                    var recievername = document.getElementById("<%=ActiveUsernameText.ClientID%>").innerHTML;
                    var senderid = '<%=Session["UsernameInlogged"]%>';
                    var mess = document.getElementById("<%= WriteBubbleTextBox.ClientID %>").value;

                    xhttp.open("GET", "SendingMessageToDataBase.aspx?Rname=" + recievername + "&Sid=" + senderid + "&M=" + mess, true);
                    xhttp.send(null);

                //}
                //catch (e) {
                
                //}
            }
            document.getElementById("<%= WriteBubbleTextBox.ClientID %>").value = "";
        }

        function KeyDownHandler(event) {
            if (event.keyCode == 13) {
                __doPostBack("<%= WriteBubbleSendButton.ClientID %>", 'OnClientClick');
            }
        }

        function doStuff() {
            //alert("run your code here when time interval is reached");
            document.getElementById('<%=MessageField.ClientID%>').scrollBy(0, 10000);
        }
        var myTimer = setInterval(doStuff, 2000);

    </script>
    
</asp:Content>

