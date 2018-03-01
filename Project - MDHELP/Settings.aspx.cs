using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadCourses();
        LoadUserData();
        LoadDays();
        //This is the page Load
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
        if (!Page.IsPostBack)
        {
            MySqlConnection con = new MySqlConnection("Database=MDHELP_Database;Data Source=188.166.11.232;Port=3306;Uid=fanny;Pwd=fannythebunny;");
            con.Open();

            //********************************** Mentor delen ************//
            MySqlCommand cmd = new MySqlCommand("SELECT Coursename from CompletedCourses WHERE StudentID = '" + Session["UsernameInlogged"] + "'", con);
            MySqlDataAdapter adpt = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            CompletedCourses.DataSource = dt;
           // CompletedCourses.DataBind();
            CompletedCourses.DataTextField = "Coursename";              //Loads everything into the mentordropdown
            CompletedCourses.DataValueField = "Coursename";
            CompletedCourses.DataBind();
            CompletedCourses.Items.Insert(0, new ListItem("Select Course", "0"));
            CompletedCourses.Items[0].Selected = true;
            CompletedCourses.Items[0].Attributes["disabled"] = "disabled";
            con.Close();


        }
    }

    protected void LoadDays()

    {
        if (!Page.IsPostBack)
        {
            MySqlConnection con2 = new MySqlConnection("Database=MDHELP_Database;Data Source=188.166.11.232;Port=3306;Uid=fanny;Pwd=fannythebunny;");
            con2.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT Weekdays from Days", con2);
            MySqlDataAdapter adpt = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            AvailableDaysDrop.DataSource = dt;
           // AvailableDaysDrop.DataBind();
            AvailableDaysDrop.DataTextField = "Weekdays";                   //Loads everything into the AvailabledaysDroplist
            AvailableDaysDrop.DataValueField = "Weekdays";
            AvailableDaysDrop.DataBind();
            AvailableDaysDrop.Items.Insert(0, new ListItem("Select Days", "0"));
            AvailableDaysDrop.Items[0].Selected = true;
            AvailableDaysDrop.Items[0].Attributes["disabled"] = "disabled";
            con2.Close();
        }
    }
	protected void LoadUserData()
	{
          //THIS METHOD LOADS ALL THE USERS INFORMATION FROM THE DB ON PAGELOAD
		if (!Page.IsPostBack)
		{
			MySqlConnection con = new MySqlConnection("Database=MDHELP_Database;Data Source=188.166.11.232;Port=3306;Uid=fanny;Pwd=fannythebunny;");
			con.Open();
			// Student och Mentor Checkboxar
			byte StudentStatus = 0;
			byte MentorStatus = 0;
			MySqlCommand cmd = new MySqlCommand("Select Student, Mentor FROM ProfileStatus where StudentID = '" + Session["UsernameInlogged"] + "'", con);
			MySqlDataReader reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				StudentStatus = reader.GetByte("Student");
				MentorStatus = reader.GetByte("Mentor");
			}

			if (StudentStatus == 1)
			{
				StudentCheckbox.Checked = true;
			}
			if (MentorStatus == 1)
			{
				MentorCheckbox.Checked = true;
			}

			reader.Close();
            // Fyller i Infoboxen


            MySqlCommand cmd1 = new MySqlCommand("Select City FROM FakeLadok WHERE StudentID = '" + Session["UsernameInlogged"] + "'", con);
            MySqlDataReader reader1 = cmd1.ExecuteReader();
            var city = "";
            while (reader1.Read())
            {
               city = reader1.GetString("City");
            }

            if (city == "Västerås/")
            {
                Västerås.Checked = true;
            }
            if (city == "/Eskilstuna")
            {
                Eskilstuna.Checked = true;
            }
            if(city == "Västerås/Eskilstuna")
            {
                Västerås.Checked = true;
                Eskilstuna.Checked = true;
            }
            reader1.Close();
            string MentorInfo = "";
			MySqlCommand cmd2 = new MySqlCommand("Select Info FROM MentorProfile where StudentID = '" + Session["UsernameInlogged"] + "'", con);
			MySqlDataReader reader2 = cmd2.ExecuteReader();
			int count = reader2.FieldCount;
			while (reader2.Read())
			{
				for (int i = 0; i < count; i++)
				{
					MentorInfo = reader2.GetString("Info");
				}

			}
			infobox.Text = MentorInfo;
			reader2.Close();


            MySqlCommand cmd3 = new MySqlCommand("Select Coursename FROM CompletedCourses where StudentID = '" + Session["UsernameInlogged"] + "' AND Mentoring = 1", con);
            MySqlDataReader reader3 = cmd3.ExecuteReader();
            while (reader3.Read())
            {
                MChosenCourses.Items.Add(reader3.GetString("Coursename"));
            }

            reader3.Close();


            MySqlCommand cmd4 = new MySqlCommand("Select Availabledays FROM MentorAvailability where StudentID = '" + Session["UsernameInlogged"] + "'", con);
            MySqlDataReader reader4 = cmd4.ExecuteReader();
            while (reader4.Read())
            {
                AvailableDaysBox.Items.Add(reader4.GetString("Availabledays"));
            }
            reader4.Close();

            con.Close();
        }
    }
    protected void AddMentorCourseBtn_Click(object sender, EventArgs e)
    {
        //ADDS A COURSE TO THE LISTBOX, ERROR HANDELING IS INCLUDED
        string Mtext = CompletedCourses.SelectedItem.Text;
        string Mvalue = CompletedCourses.SelectedItem.Value;

        ListItem MItem = new ListItem(Mtext, Mvalue);
        if (Mtext == "Select Course" || Mvalue == "Select Course" || MChosenCourses.Items.Contains(MItem)) 
        {
            MItem.Enabled = false;
        }
        else
            MChosenCourses.Items.Add(MItem);
    }

    protected void SaveChangesBtn_Click(object sender, EventArgs e)
    {
        //SAVES EVERYTHING TO THE DATABASE
        UpdatePanel.Update();
        MySqlConnection con = new MySqlConnection("Database=MDHELP_Database;Data Source=188.166.11.232;Port=3306;Uid=fanny;Pwd=fannythebunny;");
        con.Open();
        var tbl_name = "ProfileStatus";
        var StudentStatus = 0;
        var MentorStatus = 0;
        var City = "";
        var City1 = "";
        var City2 = "";
        var info = infobox.Text;

        //********************************** Student/Mentor delen ************//

        if (StudentCheckbox.Checked)
            StudentStatus = 1;
        if (MentorCheckbox.Checked)
            MentorStatus = 1;

        MySqlCommand cmd = new MySqlCommand("UPDATE `ProfileStatus` SET `Student`=?StudentStatus, `Mentor`=?MentorStatus WHERE `StudentID`=?StudentID", con);
        MySqlCommand cmd1337 = new MySqlCommand("UPDATE `MentorProfile` SET `Info`=?info WHERE `StudentID`=?StudentID", con);

        cmd.Parameters.Add(new MySqlParameter("tbl_name", tbl_name));
        cmd.Parameters.Add(new MySqlParameter("StudentStatus", StudentStatus));
        cmd.Parameters.Add(new MySqlParameter("MentorStatus", MentorStatus));
        cmd.Parameters.Add(new MySqlParameter("StudentID", Session["UsernameInlogged"]));
        cmd1337.Parameters.Add(new MySqlParameter("info", info));
        cmd1337.Parameters.Add(new MySqlParameter("StudentID", Session["UsernameInlogged"]));
        cmd.ExecuteNonQuery();
        cmd1337.ExecuteNonQuery();

        /*****************  Citydelen ***********/
        if (Västerås.Checked)
            City1 = Västerås.Value;

        City += City1;
        City += "/";
        if (Eskilstuna.Checked)
            City2 = Eskilstuna.Value;
        City += City2;
        tbl_name = "FakeLadok";
        MySqlCommand cmd1 = new MySqlCommand("UPDATE `FakeLadok` SET `City` = ?City WHERE `StudentID` = ?StudentID", con);
        cmd1.Parameters.AddWithValue("tbl_name", tbl_name);
        cmd1.Parameters.AddWithValue("StudentID", Session["UsernameInlogged"]);
        cmd1.Parameters.AddWithValue("City", City);

        cmd1.ExecuteNonQuery();
        /**************** Kursdel ***************/
        int i = 0;
        tbl_name = "CompletedCourses";
        MySqlCommand cmd2 = new MySqlCommand("UPDATE `CompletedCourses` set `Mentoring` = '1' WHERE `StudentID` = @StudentID AND `Coursename`= @Course", con);
        cmd2.Parameters.AddWithValue("@tbl_name", tbl_name);
        cmd2.Parameters.AddWithValue("@StudentID", Session["UsernameInlogged"]);
        cmd2.Parameters.AddWithValue("@Course", "");

        for (i = 0; i < MChosenCourses.Items.Count; i++)
        {
            cmd2.Parameters[2].Value = MChosenCourses.Items[i].Value;       // Iterates though the listbox and updates all the values to db
            cmd2.ExecuteNonQuery();
        }
        /*Dag delen*/
        MySqlCommand cmd3 = new MySqlCommand("INSERT INTO `MentorAvailability` (StudentID,Availabledays) VALUES( @StudentID, @Day )", con);
        cmd3.Parameters.AddWithValue("@StudentID", Session["UsernameInlogged"]);
        cmd3.Parameters.AddWithValue("@Day", "");


        MySqlCommand removeAllDays = new MySqlCommand("DELETE FROM `MentorAvailability` WHERE `StudentID`=@StudentID ", con);
        removeAllDays.Parameters.AddWithValue("@StudentID", Session["UsernameInlogged"]);
        removeAllDays.ExecuteNonQuery();

        for (i = 0; i < AvailableDaysBox.Items.Count; i++)
        {
            cmd3.Parameters[1].Value = AvailableDaysBox.Items[i].Value; 
            cmd3.ExecuteNonQuery();
        }

        con.Close();
    }

    protected void RemoveMentorCourseBtn_Click(object sender, EventArgs e)
    {

        MySqlConnection con = new MySqlConnection("Database=MDHELP_Database;Data Source=188.166.11.232;Port=3306;Uid=fanny;Pwd=fannythebunny;");
        con.Open();
        MySqlCommand cmd3 = new MySqlCommand("UPDATE `CompletedCourses` set `Mentoring` = '0' WHERE `StudentID` = @StudentID AND `Coursename` = @Course ", con);
        cmd3.Parameters.AddWithValue("@StudentID", Session["UsernameInlogged"]);
        cmd3.Parameters.AddWithValue("@Course", MChosenCourses.SelectedItem);
        MChosenCourses.Items.Remove(MChosenCourses.SelectedItem);

        cmd3.ExecuteNonQuery();
        con.Close();
    }

    protected void AddWeekdayBtn_Click(object sender, EventArgs e)
    {
        //ADDS A DAY TO THE LISTBOX
        string string1 = AvailableDaysDrop.SelectedItem.Text;
        string string2 = AvailableDaysDrop.SelectedItem.Value;

        ListItem item = new ListItem(string1, string2);

        if (string1 == "Select Days" || string2 == "Select Days" || AvailableDaysBox.Items.Contains(item))
        {
            item.Enabled = false;
        }
        else
        {
            AvailableDaysBox.Items.Add(item);
        }
    }


    protected void RemoveAvailableDay_Click(object sender, EventArgs e)
    {

        //REMOVES A DAY FROM DATABASE ANDLISTBOX
        MySqlConnection con = new MySqlConnection("Database=MDHELP_Database;Data Source=188.166.11.232;Port=3306;Uid=fanny;Pwd=fannythebunny;");
        con.Open();
        MySqlCommand cmd3 = new MySqlCommand("DELETE FROM `MentorAvailability` WHERE `Availabledays` =?day AND `StudentID` =?StudentID", con);
        cmd3.Parameters.AddWithValue("StudentID", Session["UsernameInlogged"]);
        cmd3.Parameters.AddWithValue("Day", AvailableDaysBox.SelectedItem);
        AvailableDaysBox.Items.Remove(AvailableDaysBox.SelectedItem);

        cmd3.ExecuteNonQuery();
        con.Close();

    }
}
    