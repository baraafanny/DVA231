using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

public partial class LoginPage : System.Web.UI.Page
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
    }

    protected void loginButton_Click(object sender, EventArgs e)
    {
        if (regexpName.IsValid && UsernameBox.Text.Length > 0 && PasswordBox.Text.Length > 0)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ("Data Source=LAPTOP-Q1VNVFM7\\SQLEXPRESS;Initial Catalog=IMDB;Integrated Security=True");
            con.Open();

            SqlCommand cmd = new SqlCommand("select UserName, Password FROM Accounts where UserName = '" + UsernameBox.Text + "' and Password = '" + PasswordBox.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                con.Close();
                Session["LoggedIn"] = true;

                Session["UsernameInlogged"] = UsernameBox.Text;
                Response.Redirect("Default.aspx");

            }
            else
            {
                con.Close();
                Response.Write("<scipt>");
                Response.Write("alert('Wrong input');");
                Response.Write("</scipt>");
            }
        }
        
        /*if(UsernameBox.Text == "fanny" && PasswordBox.Text == "fanny")
        {
            Session["loggedIn"] = true;
            Response.Redirect("Default.aspx");
        }
        else
        {
            Response.Write("<scipt>");
            Response.Write("alert('Wrong input'");
            Response.Write("</scipt>");
        }*/
        
    }
}