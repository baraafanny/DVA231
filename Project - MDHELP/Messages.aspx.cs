using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.UI.HtmlControls;
using System.Drawing;

public partial class Default2 : System.Web.UI.Page
{
    public DataTable dt;
    public static int activeContactNumber = 999;
    public static int lastChatSize = 0;
    public static string Contact1ID = "";
    public static string Contact2ID = "";
    public static string Contact3ID = "";
    public static string Contact4ID = "";
    public static string Contact5ID = "";
    public static string Contact6ID = "";
    public static string Contact7ID = "";
    public static string Contact8ID = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        
        //This is used in SendingMessageToDatabase.aspx
        if (Session["ActiveContactId"] == null)
        {
            Session["ActiveContactId"] = "";
        }
        //This is used in BrowseMentor.aspx
        if (Session["AddNewContactID"] == null)
        {
            Session["AddNewContactID"] = "";
        }

        //Load contacts from database
        MySqlConnection con = new MySqlConnection("Database=MDHELP_Database;Data Source=188.166.11.232;Port=3306;Uid=fanny;Pwd=fannythebunny;");
        con.Open();

        MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT Firstname, StudentID FROM FakeLadok, Messages WHERE (FakeLadok.StudentID = Messages.Reciever OR FakeLadok.StudentID = Messages.Sender) AND (Messages.Reciever = @UsernameInlogged OR Messages.Sender = @UsernameInlogged) AND (FakeLadok.StudentID != @UsernameInlogged)", con);
        cmd.Parameters.AddWithValue("@UsernameInlogged", Session["UsernameInlogged"].ToString());

        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        dt = new DataTable();
        da.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            //Add contacts that existed, Och texten på knappen
            
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                if (Contact1.Text == "") { Contact1.Text = dt.Rows[i]["Firstname"].ToString() + " " + dt.Rows[i]["StudentID"].ToString(); Contact1ID = dt.Rows[i]["StudentID"].ToString(); }
                else if (Contact2.Text == "") { Contact2.Text = dt.Rows[i]["Firstname"].ToString() + " " + dt.Rows[i]["StudentID"].ToString(); Contact2ID= dt.Rows[i]["StudentID"].ToString(); }
                else if (Contact3.Text == "") { Contact3.Text = dt.Rows[i]["Firstname"].ToString() + " " + dt.Rows[i]["StudentID"].ToString(); Contact3ID = dt.Rows[i]["StudentID"].ToString(); }
                else if (Contact4.Text == "") { Contact4.Text = dt.Rows[i]["Firstname"].ToString() + " " + dt.Rows[i]["StudentID"].ToString(); Contact4ID = dt.Rows[i]["StudentID"].ToString(); }
                else if (Contact5.Text == "") { Contact5.Text = dt.Rows[i]["Firstname"].ToString() + " " + dt.Rows[i]["StudentID"].ToString(); Contact5ID = dt.Rows[i]["StudentID"].ToString(); }
                else if (Contact6.Text == "") { Contact6.Text = dt.Rows[i]["Firstname"].ToString() + " " + dt.Rows[i]["StudentID"].ToString(); Contact6ID = dt.Rows[i]["StudentID"].ToString(); }
                else if (Contact7.Text == "") { Contact7.Text = dt.Rows[i]["Firstname"].ToString() + " " + dt.Rows[i]["StudentID"].ToString(); Contact7ID = dt.Rows[i]["StudentID"].ToString(); }
                else if (Contact8.Text == "") { Contact8.Text = dt.Rows[i]["Firstname"].ToString() + " " + dt.Rows[i]["StudentID"].ToString(); Contact8ID = dt.Rows[i]["StudentID"].ToString(); }
            }
        }

        if(dt.Rows.Count > 0 && (string)Session["ActiveContactId"] == "")
        {
            if (dt.Rows[0]["StudentID"].ToString() != "")
            {
                Session["ActiveContactId"] = dt.Rows[0]["StudentID"].ToString();
            }
        }

        //Add New Contact if clicked from browse mentor ********* NEED TO CHECK IF ALREADY IN LIST BEFORE ADDING TWICE ****************
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (Session["AddNewContactID"].ToString() == dt.Rows[i]["StudentID"].ToString())
            {
                Session["AddNewContactID"] = "";
            }
        }

        if ((string)Session["AddNewContactID"] != "")
        {
            MySqlCommand cmd7 = new MySqlCommand("SELECT Firstname FROM FakeLadok WHERE StudentID = @ID", con);
            cmd7.Parameters.AddWithValue("@ID", Session["AddNewContactID"].ToString());

            MySqlDataAdapter da7 = new MySqlDataAdapter(cmd7);
            DataTable dt7 = new DataTable();
            da7.Fill(dt7);

            if (Contact1.Text == "") { Contact1.Text = dt7.Rows[0]["Firstname"].ToString() + " " + Session["AddNewContactID"].ToString(); Contact1ID = Session["AddNewContactID"].ToString(); }
            else if (Contact2.Text == "") { Contact2.Text = dt7.Rows[0]["Firstname"].ToString() + " " + Session["AddNewContactID"].ToString(); Contact2ID = Session["AddNewContactID"].ToString(); }
            else if (Contact3.Text == "") { Contact3.Text = dt7.Rows[0]["Firstname"].ToString() + " " + Session["AddNewContactID"].ToString(); Contact3ID = Session["AddNewContactID"].ToString(); }
            else if (Contact4.Text == "") { Contact4.Text = dt7.Rows[0]["Firstname"].ToString() + " " + Session["AddNewContactID"].ToString(); Contact4ID = Session["AddNewContactID"].ToString(); }
            else if (Contact5.Text == "") { Contact5.Text = dt7.Rows[0]["Firstname"].ToString() + " " + Session["AddNewContactID"].ToString(); Contact5ID = Session["AddNewContactID"].ToString(); }
            else if (Contact6.Text == "") { Contact6.Text = dt7.Rows[0]["Firstname"].ToString() + " " + Session["AddNewContactID"].ToString(); Contact6ID = Session["AddNewContactID"].ToString(); }
            else if (Contact7.Text == "") { Contact7.Text = dt7.Rows[0]["Firstname"].ToString() + " " + Session["AddNewContactID"].ToString(); Contact7ID = Session["AddNewContactID"].ToString(); }
            else if (Contact8.Text == "") { Contact8.Text = dt7.Rows[0]["Firstname"].ToString() + " " + Session["AddNewContactID"].ToString(); Contact8ID = Session["AddNewContactID"].ToString(); }

            Session["ActiveContactId"] = Session["AddNewContactID"].ToString();
        }

        //Ifall man klickat på en person som har skickat ett meddelande sätter man den till 1 för öppnat
        MySqlCommand cmd2 = new MySqlCommand("UPDATE Messages SET Opened = 1 WHERE Reciever = @UsernameInlogged AND Sender = @ActiveContactId AND Opened = 0", con);
        cmd2.Parameters.AddWithValue("@UsernameInlogged", Session["UsernameInlogged"].ToString());
        cmd2.Parameters.AddWithValue("@ActiveContactId", Session["ActiveContactId"].ToString());
        cmd2.ExecuteNonQuery();

        //Kollar vilka som inte öppnat meddelanden
        MySqlCommand cmd5 = new MySqlCommand("SELECT Sender FROM Messages WHERE Reciever = @UsernameInlogged AND Opened = 0", con);
        cmd5.Parameters.AddWithValue("@UsernameInlogged", Session["UsernameInlogged"].ToString());
        MySqlDataAdapter da5 = new MySqlDataAdapter(cmd5);
        DataTable dt5 = new DataTable();
        da5.Fill(dt5);

        //Gör de oöppnade meddelandena till orangea(knapparna)
        if(dt5.Rows.Count > 0)
        {
            for(int i = 0; i < dt5.Rows.Count; i++)
            {
                if(dt5.Rows[i]["Sender"].ToString() == Contact1ID)
                {
                    Contact1.BackColor = Color.Orange;
                }
                if (dt5.Rows[i]["Sender"].ToString() == Contact2ID)
                {
                    Contact2.BackColor = Color.Orange;
                }
                if (dt5.Rows[i]["Sender"].ToString() == Contact3ID)
                {
                    Contact3.BackColor = Color.Orange;
                }
                if (dt5.Rows[i]["Sender"].ToString() == Contact4ID)
                {
                    Contact4.BackColor = Color.Orange;
                }
                if (dt5.Rows[i]["Sender"].ToString() == Contact5ID)
                {
                    Contact5.BackColor = Color.Orange;
                }
                if (dt5.Rows[i]["Sender"].ToString() == Contact6ID)
                {
                    Contact6.BackColor = Color.Orange;
                }
                if (dt5.Rows[i]["Sender"].ToString() == Contact7ID)
                {
                    Contact7.BackColor = Color.Orange;
                }
                if (dt5.Rows[i]["Sender"].ToString() == Contact8ID)
                {
                    Contact8.BackColor = Color.Orange;
                }
            }
        }

        //Stänger av så Topbaren inte visar NEW Message
        Session["TopBarMessageButtonNewMessage"] = false;


        //Dont show empty contact buttons
        if (Contact1.Text == "") { Contact1.Visible = false; }
        if (Contact2.Text == "") { Contact2.Visible = false; }
        if (Contact3.Text == "") { Contact3.Visible = false; }
        if (Contact4.Text == "") { Contact4.Visible = false; }
        if (Contact5.Text == "") { Contact5.Visible = false; }
        if (Contact6.Text == "") { Contact6.Visible = false; }
        if (Contact7.Text == "") { Contact7.Visible = false; }
        if (Contact8.Text == "") { Contact8.Visible = false; }

        Session["AddNewContactID"] = "";

        con.Close();

        ChatUpdate();
        ChatUpdatePanel.Update();

    }

    protected void Contact1_Click(object sender, EventArgs e)
    {
        ActiveUsernameText.InnerHtml = Contact1.Text;
        activeContactNumber = 1;
        Session["ActiveContactId"] = Contact1ID;
        lastChatSize = 0;
        ActiveUsernameText.InnerHtml = Contact1.Text;
        Contact1.BackColor = Color.White;
        ChatUpdate();
        ChatUpdatePanel.Update();
    }

    protected void Contact2_Click(object sender, EventArgs e)
    {
        
        ActiveUsernameText.InnerHtml = Contact2.Text;
        activeContactNumber = 2;
        Session["ActiveContactId"] = Contact2ID;
        lastChatSize = 0;
        ActiveUsernameText.InnerHtml = Contact2.Text;
        Contact2.BackColor = Color.White;
        ChatUpdate();
        ChatUpdatePanel.Update();
    }

    protected void Contact3_Click(object sender, EventArgs e)
    {
        ActiveUsernameText.InnerHtml = Contact3.Text;
        activeContactNumber = 3;
        Session["ActiveContactId"] = Contact3ID;
        lastChatSize = 0;
        ActiveUsernameText.InnerHtml = Contact3.Text;
        Contact3.BackColor = Color.White;
        ChatUpdate();
        ChatUpdatePanel.Update();
    }

    protected void Contact4_Click(object sender, EventArgs e)
    {
        ActiveUsernameText.InnerHtml = Contact4.Text;
        activeContactNumber = 4;
        Session["ActiveContactId"] = Contact4ID;
        lastChatSize = 0;
        ActiveUsernameText.InnerHtml = Contact4.Text;
        Contact4.BackColor = Color.White;
        ChatUpdate();
        ChatUpdatePanel.Update();
    }

    protected void Contact5_Click(object sender, EventArgs e)
    {
        ActiveUsernameText.InnerHtml = Contact5.Text;
        activeContactNumber = 5;
        Session["ActiveContactId"] = Contact5ID;
        lastChatSize = 0;
        ActiveUsernameText.InnerHtml = Contact5.Text;
        Contact5.BackColor = Color.White;
        ChatUpdate();
        ChatUpdatePanel.Update();
    }

    protected void Contact6_Click(object sender, EventArgs e)
    {
        ActiveUsernameText.InnerHtml = Contact6.Text;
        activeContactNumber = 6;
        Session["ActiveContactId"] = Contact6ID;
        lastChatSize = 0;
        ActiveUsernameText.InnerHtml = Contact6.Text;
        Contact6.BackColor = Color.White;
        ChatUpdate();
        ChatUpdatePanel.Update();
    }

    protected void Contact7_Click(object sender, EventArgs e)
    {
        ActiveUsernameText.InnerHtml = Contact7.Text;
        activeContactNumber = 7;
        Session["ActiveContactId"] = Contact7ID;
        lastChatSize = 0;
        ActiveUsernameText.InnerHtml = Contact7.Text;
        Contact7.BackColor = Color.White;
        ChatUpdate();
        ChatUpdatePanel.Update();
    }

    protected void Contact8_Click(object sender, EventArgs e)
    {
        ActiveUsernameText.InnerHtml = Contact8.Text;
        activeContactNumber = 8;
        Session["ActiveContactId"] = Contact8ID;
        lastChatSize = 0;
        ActiveUsernameText.InnerHtml = Contact8.Text;
        Contact8.BackColor = Color.White;
        ChatUpdate();
        ChatUpdatePanel.Update();
    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        MySqlConnection con = new MySqlConnection("Database=MDHELP_Database;Data Source=188.166.11.232;Port=3306;Uid=fanny;Pwd=fannythebunny;");
        con.Open();
        //KOLlar ifall man fått ett meddelande från Activeuser
        MySqlCommand cmd4 = new MySqlCommand("SELECT Reciever, Sender, Message FROM Messages WHERE (Reciever = @UsernameInlogged AND Sender = @ActiveContactId) OR (Reciever = @ActiveContactId AND Sender = @UsernameInlogged)", con);
        cmd4.Parameters.AddWithValue("@UsernameInlogged", Session["UsernameInlogged"].ToString());
        cmd4.Parameters.AddWithValue("@ActiveContactId", Session["ActiveContactId"].ToString());
        MySqlDataAdapter da4 = new MySqlDataAdapter(cmd4);
        DataTable dt4 = new DataTable();
        da4.Fill(dt4);

        //Ifall chattstorleken är större än senaste gången man var inne
        if (lastChatSize < dt4.Rows.Count)
        {
            lastChatSize = dt4.Rows.Count;
            ChatUpdate();
            ChatUpdatePanel.Update();
        }

        MySqlCommand cmd6 = new MySqlCommand("SELECT Sender FROM Messages WHERE Reciever = @UsernameInlogged AND Opened = 0", con);
        cmd6.Parameters.AddWithValue("@UsernameInlogged", Session["UsernameInlogged"].ToString());
        MySqlDataAdapter da6 = new MySqlDataAdapter(cmd6);
        DataTable dt6 = new DataTable();
        da6.Fill(dt6);

        //Sätter dem till orangea ifall vi hinner få ett nytt meddelande innan pageload
        if (dt6.Rows.Count > 0)
        {
            for (int i = 0; i < dt6.Rows.Count; i++)
            {
                if (dt6.Rows[i]["Sender"].ToString() == Contact1ID)
                {
                    Contact1.BackColor = Color.Orange;
                }
                if (dt6.Rows[i]["Sender"].ToString() == Contact2ID)
                {
                    Contact2.BackColor = Color.Orange;
                }
                if (dt6.Rows[i]["Sender"].ToString() == Contact3ID)
                {
                    Contact3.BackColor = Color.Orange;
                }
                if (dt6.Rows[i]["Sender"].ToString() == Contact4ID)
                {
                    Contact4.BackColor = Color.Orange;
                }
                if (dt6.Rows[i]["Sender"].ToString() == Contact5ID)
                {
                    Contact5.BackColor = Color.Orange;
                }
                if (dt6.Rows[i]["Sender"].ToString() == Contact6ID)
                {
                    Contact6.BackColor = Color.Orange;
                }
                if (dt6.Rows[i]["Sender"].ToString() == Contact7ID)
                {
                    Contact7.BackColor = Color.Orange;
                }
                if (dt.Rows[i]["Sender"].ToString() == Contact8ID)
                {
                    Contact8.BackColor = Color.Orange;
                }
            }
        }

        con.Close();
    }

    public void ChatUpdate()
    {
        //IFall det inte finns någon i kontaktlistan så får man lägga till en
        if (Contact1.Text == "")
        {
            ActiveUsernameText.InnerHtml = "Add contact to message!";
        }
        else // Visar namnet ovanför chatten
        {
            if(activeContactNumber == 999)
            {
                activeContactNumber = 1;
            }

            if(activeContactNumber == 1)
            {
                ActiveUsernameText.InnerHtml = Contact1.Text;
            }
            else if (activeContactNumber == 2)
            {
                ActiveUsernameText.InnerHtml = Contact2.Text;
            }
            else if (activeContactNumber == 3)
            {
                ActiveUsernameText.InnerHtml = Contact3.Text;
            }
            else if (activeContactNumber == 4)
            {
                ActiveUsernameText.InnerHtml = Contact4.Text;
            }
            else if (activeContactNumber == 5)
            {
                ActiveUsernameText.InnerHtml = Contact5.Text;
            }
            else if (activeContactNumber == 6)
            {
                ActiveUsernameText.InnerHtml = Contact6.Text;
            }
            else if (activeContactNumber == 7)
            {
                ActiveUsernameText.InnerHtml = Contact7.Text;
            }
            else if (activeContactNumber == 8)
            {
                ActiveUsernameText.InnerHtml = Contact8.Text;
            }
        }

        //Load Chat Content and Insert Bubbles From History, Hämtar alla gamla meddelanden 
        if ((string)Session["ActiveContactId"] != "")
        {
            MySqlConnection con = new MySqlConnection("Database=MDHELP_Database;Data Source=188.166.11.232;Port=3306;Uid=fanny;Pwd=fannythebunny;");
            con.Open();

            MySqlCommand cmd3 = new MySqlCommand("SELECT Reciever, Sender, Message FROM Messages WHERE (Reciever = @UsernameInlogged AND Sender = @ActiveContactId) OR (Reciever = @ActiveContactId AND Sender = @UsernameInlogged)", con);
            cmd3.Parameters.AddWithValue("@UsernameInlogged", Session["UsernameInlogged"].ToString());
            cmd3.Parameters.AddWithValue("@ActiveContactId", Session["ActiveContactId"].ToString());
            MySqlDataAdapter da3 = new MySqlDataAdapter(cmd3);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);

            con.Close();

            ChatMessagesList.Controls.Clear(); 

            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                if (dt3.Rows[i]["Sender"].ToString() == (string)Session["UsernameInlogged"])
                {
                    HtmlGenericControl li = new HtmlGenericControl("li");
                    li.Attributes.Add("class", "SendChatBoxes");
                    li.InnerText = dt3.Rows[i]["Message"].ToString();

                    ChatMessagesList.Controls.Add(li);
                }
                else
                {
                    HtmlGenericControl li = new HtmlGenericControl("li");
                    li.Attributes.Add("class", "ReceiveChatBoxes");
                    li.InnerText = dt3.Rows[i]["Message"].ToString();

                    ChatMessagesList.Controls.Add(li);
                }

            }
            
        }
    }
}