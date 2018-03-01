using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Configuration;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string JQueryVer = "3.2.1";
        ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
        {
            Path = "~/Scripts/jquery-" + JQueryVer + ".min.js",
            DebugPath = "~/Scripts/jquery-" + JQueryVer + ".js",
            CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-" + JQueryVer + ".min.js",
            CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-" + JQueryVer + ".js",
            CdnSupportsSecureConnection = true,
            LoadSuccessExpression = "window.jQuery"
        });


        //Check if logged in
        if(Session["LoggedIn"] != null)
        {
            if ((bool)Session["LoggedIn"] == true)
            {
                Response.Redirect("MainPage.aspx", false);
            }
        }
    }


    protected void loginButton_Click(object sender, EventArgs e)
    {
        if (UsernameBox.Text.Length > 0 && PasswordBox.Text.Length > 0)
        {

            MySqlConnection con = new MySqlConnection("Database=MDHELP_Database;Data Source=188.166.11.232;Port=3306;Uid=fanny;Pwd=fannythebunny;");

            con.ClearAllPoolsAsync();

            con.Open();

            MySqlCommand cmd = new MySqlCommand("select Username, Password FROM Accounts where Username = '" + UsernameBox.Text + "' and Password = '" + PasswordBox.Text + "'", con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                con.Close();
                Session["LoggedIn"] = true;

                Session["UsernameInlogged"] = UsernameBox.Text;
                Response.Redirect("MainPage.aspx");

            }
            else
            {
                con.Close();
                Response.Write("<script>");
                Response.Write("alert('Wrong username or password');");
                Response.Write("</script>");
            }
        }
        
    }
}