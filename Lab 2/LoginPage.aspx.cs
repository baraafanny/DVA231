using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LoginPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
    }

    protected void loginButton_Click(object sender, EventArgs e)
    {
        if(UsernameBox.Text == "fanny" && PasswordBox.Text == "fanny")
        {
            Session["loggedIn"] = true;
            Response.Redirect("Default.aspx");
        }
        else
        {
            Response.Write("<scipt>");
            Response.Write("alert('Wrong input'");
            Response.Write("</scipt>");
        }
    }
}