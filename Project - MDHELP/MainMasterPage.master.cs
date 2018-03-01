using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MainMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((bool)Session["TopBarMessageButtonNewMessage"] == true)
        {
            TopBarMessageButton.InnerHtml = "Messages (NEW)";
        }
        else
        {
            TopBarMessageButton.InnerHtml = "Messages";
        }
    }

    protected void SignOutButton_Click(object sender, EventArgs e)
    {
        if ((bool)(Session["loggedIn"]) == true)
        {
            Session["loggedIn"] = false;
            Session["UsernameInlogged"] = null;
            Response.Redirect("Default.aspx");
        }
    }

}
