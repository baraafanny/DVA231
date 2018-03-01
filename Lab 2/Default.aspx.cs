using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loggedIn"] == null)
        {
            Session["loggedIn"] = false;
        }

        if ((bool)(Session["loggedIn"]) == false)
        {
            LoginButton.Text = "Sign in";
            PosterButton1.Visible = false;
            PosterButton2.Visible = false;
            PosterButton3.Visible = false;
        }
        else if ((bool)(Session["loggedIn"]) == true)
        {
            LoginButton.Text = "Sign out";
            PosterButton1.Visible = true;
            PosterButton2.Visible = true;
            PosterButton3.Visible = true;
        }
        
    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        if ((bool)(Session["loggedIn"]) == false)
        {
            Response.Redirect("LoginPage.aspx");
        }
        else if ((bool)(Session["loggedIn"]) == true)
        {
            Session["loggedIn"] = false;
            Response.Redirect("Default.aspx");
        }
    }

    protected void PosterButton1_Click(object sender, ImageClickEventArgs e)
    {
        Session["Favorite"] = trailerpostertext1.Text;
        Response.Redirect("FavoritePage.aspx");
    }
    protected void PosterButton2_Click(object sender, ImageClickEventArgs e)
    {
        Session["Favorite"] = trailerpostertext2.Text;
        Response.Redirect("FavoritePage.aspx");
    }
    protected void PosterButton3_Click(object sender, ImageClickEventArgs e)
    {
        Session["Favorite"] = trailerpostertext3.Text;
        Response.Redirect("FavoritePage.aspx");
    }
}

