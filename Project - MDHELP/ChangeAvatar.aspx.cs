using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class ChangeAvatar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadImgChoice();
    }

    protected void LoadImgChoice()
    {
        if (!Page.IsPostBack)
        {
            MySqlConnection con = new MySqlConnection("Database=MDHELP_Database;Data Source=188.166.11.232;Port=3306;Uid=fanny;Pwd=fannythebunny;");
            con.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT ImageUrl FROM MentorProfile WHERE StudentID = @StudentID", con);
            cmd.Parameters.AddWithValue("@StudentID", Session["UsernameInlogged"]);

            MySqlDataReader reader1 = cmd.ExecuteReader();
            var ImgUrl = "";
            while (reader1.Read())
            {
                ImgUrl = reader1.GetString("ImageUrl");
            }
            reader1.Close();

            if (ImgUrl == avatar1.Value)
            {
                avatar1.Checked = true;
            }
            else if (ImgUrl == avatar2.Value)
            {
                avatar2.Checked = true;
            }
            else if (ImgUrl == avatar3.Value)
            {
                avatar3.Checked = true;
            }
            else if (ImgUrl == avatar4.Value)
            {
                avatar4.Checked = true;
            }
            else if (ImgUrl == avatar5.Value)
            {
                avatar5.Checked = true;
            }
            else if (ImgUrl == avatar6.Value)
            {
                avatar6.Checked = true;
            }
            else if (ImgUrl == avatar7.Value)
            {
                avatar7.Checked = true;
            }
            else if (ImgUrl == avatar8.Value)
            {
                avatar8.Checked = true;
            }
            else if (ImgUrl == avatar9.Value)
            {
                avatar9.Checked = true;
            }
            else if (ImgUrl == avatar10.Value)
            {
                avatar10.Checked = true;
            }



            con.Close();
        }
    }
    protected void SaveAvatar_Click(object sender, EventArgs e)
    {
        string ImgUrl = "";

        MySqlConnection con = new MySqlConnection("Database=MDHELP_Database;Data Source=188.166.11.232;Port=3306;Uid=fanny;Pwd=fannythebunny;");
        con.Open();
        
       
        if (avatar1.Checked)
        {
            ImgUrl = avatar1.Value;
        }
        else if(avatar2.Checked)
        {
            ImgUrl = avatar2.Value;
        }
        else if(avatar3.Checked)
        {
            ImgUrl = avatar3.Value;
        }
        else if(avatar4.Checked)
        {
            ImgUrl = avatar4.Value;
        }
        else if(avatar5.Checked)
        {
            ImgUrl = avatar5.Value;
        }
        else if(avatar6.Checked)
        {
            ImgUrl = avatar6.Value;
        }
        else if(avatar7.Checked)
        {
            ImgUrl = avatar7.Value;
        }
        else if(avatar8.Checked)
        {
            ImgUrl = avatar8.Value;
        }
        else if(avatar9.Checked)
        {
            ImgUrl = avatar9.Value;
        }
        else if(avatar10.Checked)
        {
            ImgUrl = avatar10.Value;
        }

         MySqlCommand cmd = new MySqlCommand("UPDATE MentorProfile SET ImageUrl= @ImgUrl WHERE StudentID = @StudentID",con);
        cmd.Parameters.AddWithValue("@ImgUrl", ImgUrl);
        cmd.Parameters.AddWithValue("@StudentID", Session["UsernameInlogged"]);
       

        cmd.ExecuteNonQuery();
        con.Close();
    }
    
}