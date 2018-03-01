using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;


public partial class BrowseMentor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            LoadCourses();
         
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
    protected void LoadCourses()
    {

        MySqlConnection con = new MySqlConnection("Database=MDHELP_Database;Data Source=188.166.11.232;Port=3306;Uid=fanny;Pwd=fannythebunny;");
        con.Open();

        MySqlCommand cmd = new MySqlCommand("SELECT * FROM Courses", con);

        ddlCourses.DataSource = cmd.ExecuteReader();
        ddlCourses.DataTextField = "Coursename";
        ddlCourses.DataValueField = "Coursecode";
        ddlCourses.DataBind();
        ddlCourses.Items.Insert(0, new ListItem("Select Course, find a Yoda", string.Empty));

        con.Close();
    }

    protected void MessageMentor_ServerClick(object sender, EventArgs e)
    {

           /*
            Response.Write("<script>alert('" + Variabelnamn[bajskorv] + "')</script>");
            Response.Write("<script>alert('" + Session["AddNewContactID"] + "')</script>");
            */

            Response.Redirect("Messages.aspx");  
    }

    
    protected void FillMentorTable(object sender, EventArgs e)
    {
        string SelectedCourse = ddlCourses.SelectedItem.Text;

        MySqlConnection con = new MySqlConnection("Database=MDHELP_Database;Data Source=188.166.11.232;Port=3306;Uid=fanny;Pwd=fannythebunny;");
        con.Open();

        MySqlCommand cmd = new MySqlCommand("SELECT distinct StudentID, Firstname, Info FROM CompleteMentorProfile3 where Coursename = '" + SelectedCourse + "' AND StudentID != '" + Session["UsernameInlogged"] +"' AND Mentor='1'", con);
        GridView1.DataSource = cmd.ExecuteReader();
        GridView1.DataBind();
        con.Close();
    }
  
    protected void Firstname_ValueChanged(object sender, EventArgs e)
    {
      
        string StudentiD = StudentID.Value;
        Session["AddNewContactID"] = StudentiD;
        GetAvailabledays();
        GetMentorProfilePicture();
        MySqlConnection con = new MySqlConnection("Database=MDHELP_Database;Data Source=188.166.11.232;Port=3306;Uid=fanny;Pwd=fannythebunny;");
        con.Open();
        MySqlCommand cmd = new MySqlCommand("SELECT Firstname FROM CompleteMentorProfile3 where StudentID = '" + StudentiD + "'", con);

        Session["AddNewContactFirstname"] = cmd.ExecuteScalar().ToString();
        
        con.Close();
    }


    public void GetAvailabledays()
    {
        List<string> Availabledayslist = new List<string>();

        MySqlConnection con = new MySqlConnection("Database=MDHELP_Database;Data Source=188.166.11.232;Port=3306;Uid=fanny;Pwd=fannythebunny;");
        con.Open();
        MySqlCommand cmd2 = new MySqlCommand("SELECT Availabledays FROM MentorAvailability where StudentID = '" + Session["AddNewContactID"] + "'", con);
        MySqlDataReader reader2 = cmd2.ExecuteReader();
        int count = reader2.FieldCount;
        while (reader2.Read())
        {
            for (int i = 0; i < count; i++)
                Availabledayslist.Add(reader2[i].ToString());

        }
    
     
        ProfileInfo.InnerHtml = string.Join(",", Availabledayslist);
        con.Close();
    }
    public void GetMentorProfilePicture()
    {
        string MentorImageUrl = "";

        MySqlConnection con = new MySqlConnection("Database=MDHELP_Database;Data Source=188.166.11.232;Port=3306;Uid=fanny;Pwd=fannythebunny;");
        con.Open();
        MySqlCommand cmd = new MySqlCommand("SELECT ImageUrl FROM MentorProfile where StudentID = '" + Session["AddNewContactID"] + "'", con);
        MySqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            MentorImageUrl = reader.GetString("ImageUrl");

        }

        MentorProfilePic.Attributes["src"] = MentorImageUrl;
        con.Close();
        UpdatePanel2.Update();
    }

}









