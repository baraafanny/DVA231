using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        

        if (Session["TopBarMessageButtonNewMessage"] == null)
        {
            Session["TopBarMessageButtonNewMessage"] = false;
        }

        string Username = Session["UsernameInlogged"].ToString();
        string lastname = "hej";
        MySqlConnection con = new MySqlConnection("Database=MDHELP_Database;Data Source=188.166.11.232;Port=3306;Uid=fanny;Pwd=fannythebunny;");
        con.Open();

        MySqlCommand cmd = new MySqlCommand("select Firstname, Lastname FROM FakeLadok where StudentID = '" + Username + "'", con);
        MySqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read()) {
            Username = reader.GetString("Firstname");
            lastname = reader.GetString("Lastname");

        }

        WelcomeText.Text = string.Format("Logged in as {0} {1}.", Username, lastname);

        con.Close();

        //See if new messages from database
        con.Open();

        MySqlCommand cmd1 = new MySqlCommand("select Sender FROM Messages where Reciever = '" + Session["UsernameInlogged"] + "' AND Opened = 0", con);
        MySqlDataAdapter da = new MySqlDataAdapter(cmd1);
        DataTable dt = new DataTable();
        da.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            ShowNewMessages.Style.Add("color", "darkorange");
            ShowNewMessages.InnerHtml = "You have NEW messages";
            Session["TopBarMessageButtonNewMessage"] = true;
        }
        else
        {
            ShowNewMessages.InnerHtml = "No new messages";
            Session["TopBarMessageButtonNewMessage"] = false;
        }

        
        con.Close();
    }
}