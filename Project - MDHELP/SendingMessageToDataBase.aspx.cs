using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

public partial class SendingMessageToDataBase : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Rname = Request.QueryString["Rname"].ToString();
        string Sid = Request.QueryString["Sid"].ToString();
        string Mess = Request.QueryString["M"].ToString();

        string Rid = Session["ActiveContactId"].ToString();

        System.Diagnostics.Debug.WriteLine(Rid);

        MySqlConnection con = new MySqlConnection("Database=MDHELP_Database;Data Source=188.166.11.232;Port=3306;Uid=fanny;Pwd=fannythebunny;");
        MySqlCommand cmdInsertMesssage = new MySqlCommand("INSERT INTO Messages ( Reciever, Sender, Message, Opened) VALUES (@param1, @param2, @param3, @param4)", con);
        cmdInsertMesssage.Parameters.AddWithValue("@param1", Rid);
        cmdInsertMesssage.Parameters.AddWithValue("@param2", Sid);
        cmdInsertMesssage.Parameters.AddWithValue("@param3", Mess);
        cmdInsertMesssage.Parameters.AddWithValue("@param4", 0);
        try
        {
            con.Open();
            cmdInsertMesssage.ExecuteNonQuery();
            con.Close();
        }
        catch
        {
            //Error
        }
    }
}