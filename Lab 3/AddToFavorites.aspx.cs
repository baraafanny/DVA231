using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Net;

public partial class AddToFavorites : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Get javascript variables
        string numberClicked;
        numberClicked = Request.QueryString["number"].ToString();

        //Add to database
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ("Data Source=LAPTOP-Q1VNVFM7\\SQLEXPRESS;Initial Catalog=IMDB;Integrated Security=True");

        if (numberClicked == "1")
        {
            if (Session["UsernameInlogged"] != null)
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("select UserName,MovieID from Favorites where UserName='" + Session["UsernameInlogged"].ToString() + "'and MovieID='" + Session["Favorite1"] + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    System.Diagnostics.Debug.WriteLine("Already a favorite");
                }
                else
                {
                    SqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "insert into Favorites values('" + Session["UsernameInlogged"] + "','" + Session["Favorite1"] + "')";
                    cmd2.ExecuteNonQuery();
                }

                con.Close();
            }
        }
        else if (numberClicked == "2")
        {
            if (Session["UsernameInlogged"] != null)
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("select UserName,MovieID from Favorites where UserName='" + Session["UsernameInlogged"].ToString() + "'and MovieID='" + Session["Favorite2"] + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    System.Diagnostics.Debug.WriteLine("Already a favorite");
                }
                else
                {
                    SqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "insert into Favorites values('" + Session["UsernameInlogged"] + "','" + Session["Favorite2"] + "')";
                    cmd2.ExecuteNonQuery();
                }

                con.Close();
            }
        }
        else if (numberClicked == "3")
        {
            if (Session["UsernameInlogged"] != null)
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("select UserName,MovieID from Favorites where UserName='" + Session["UsernameInlogged"].ToString() + "'and MovieID='" + Session["Favorite3"] + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    System.Diagnostics.Debug.WriteLine("Already a favorite");
                }
                else
                {
                    SqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "insert into Favorites values('" + Session["UsernameInlogged"] + "','" + Session["Favorite3"] + "')";
                    cmd2.ExecuteNonQuery();
                }

                con.Close();
            }
        }
    }
    }