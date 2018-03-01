using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.Services;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Fill Opening This Week
        var comingMovies = getOpeningThisWeek();

        OpeningThisweekTitle01.InnerHtml = comingMovies[0].title.ToString();
        OpeningThisweekDate01.InnerHtml = comingMovies[0].release_date;

        OpeningThisweekTitle02.InnerHtml = comingMovies[1].title.ToString();
        OpeningThisweekDate02.InnerHtml = comingMovies[1].release_date;

        OpeningThisweekTitle03.InnerHtml = comingMovies[2].title.ToString();
        OpeningThisweekDate03.InnerHtml = comingMovies[2].release_date;

        OpeningThisweekTitle04.InnerHtml = comingMovies[3].title.ToString();
        OpeningThisweekDate04.InnerHtml = comingMovies[3].release_date;

        OpeningThisweekTitle05.InnerHtml = comingMovies[4].title.ToString();
        OpeningThisweekDate05.InnerHtml = comingMovies[4].release_date;

        OpeningThisweekTitle06.InnerHtml = comingMovies[5].title.ToString();
        OpeningThisweekDate06.InnerHtml = comingMovies[5].release_date;

        OpeningThisweekTitle07.InnerHtml = comingMovies[6].title.ToString();
        OpeningThisweekDate07.InnerHtml = comingMovies[6].release_date;

        OpeningThisweekTitle08.InnerHtml = comingMovies[7].title.ToString();
        OpeningThisweekDate08.InnerHtml = comingMovies[7].release_date;

        OpeningThisweekTitle09.InnerHtml = comingMovies[8].title.ToString();
        OpeningThisweekDate09.InnerHtml = comingMovies[8].release_date;

        //Fill Top Rated
        var topRatedMovies = getTopRated();

        TopRatedTitle01.InnerHtml = topRatedMovies[0].title.ToString();
        TopRatedText01.InnerHtml = "Vote avg: " + topRatedMovies[0].vote_average.ToString() + " out of 10";
        TopRatedTitle02.InnerHtml = topRatedMovies[1].title.ToString();
        TopRatedText02.InnerHtml = "Vote avg: " + topRatedMovies[1].vote_average.ToString() + " out of 10";
        TopRatedTitle03.InnerHtml = topRatedMovies[2].title.ToString();
        TopRatedText03.InnerHtml = "Vote avg: " + topRatedMovies[2].vote_average.ToString() + " out of 10";
        TopRatedTitle04.InnerHtml = topRatedMovies[3].title.ToString();
        TopRatedText04.InnerHtml = "Vote avg: " + topRatedMovies[3].vote_average.ToString() + " out of 10";

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
        CheckFavoriteStars();
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
            Session["UsernameInlogged"] = null;
            Response.Redirect("Default.aspx");
        }
    }

    protected void PosterButton1_Click(object sender, ImageClickEventArgs e)
    {/*
        PosterButton1.ImageUrl = "img/star.png";

        if (Session["UsernameInlogged"] != null)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ("Data Source=LAPTOP-Q1VNVFM7\\SQLEXPRESS;Initial Catalog=IMDB;Integrated Security=True");

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
        */
    }
    protected void PosterButton2_Click(object sender, ImageClickEventArgs e)
    {/*

        PosterButton2.ImageUrl = "img/star.png";

        if (Session["UsernameInlogged"] != null)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ("Data Source=LAPTOP-Q1VNVFM7\\SQLEXPRESS;Initial Catalog=IMDB;Integrated Security=True");

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
        }*/
        
    }
    protected void PosterButton3_Click(object sender, ImageClickEventArgs e)
    {/*
        PosterButton3.ImageUrl = "img/star.png";

        if (Session["UsernameInlogged"] != null)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ("Data Source=LAPTOP-Q1VNVFM7\\SQLEXPRESS;Initial Catalog=IMDB;Integrated Security=True");

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
        */
    }
    
    protected void changePosterTimer_Tick(object sender, EventArgs e)
    {
         changePosterTimer.Interval = 5000;
       
         if (Session["i"] == null)
         {
             Session["i"] = 0;
         }

        var popularMovies = getPopularMovies();

        if((int)Session["i"] + 3 > popularMovies.Count)
        {
            Session["i"] = 0;
        }

        Session["Favorite1"] = popularMovies[(int)Session["i"]].id;
        Session["Favorite2"] = popularMovies[(int)Session["i"]+1].id;
        Session["Favorite3"] = popularMovies[(int)Session["i"]+2].id;
        trailerpostertext1.InnerText = popularMovies[(int)Session["i"]].title;
        trailerpostertext2.InnerText = popularMovies[(int)Session["i"]+1].title;
        trailerpostertext3.InnerText = popularMovies[(int)Session["i"]+2].title;
        trailerposterparagraph1.InnerText = popularMovies[(int)Session["i"]].release_date;
        trailerposterparagraph2.InnerText = popularMovies[(int)Session["i"]+1].release_date;
        trailerposterparagraph3.InnerText = popularMovies[(int)Session["i"]+2].release_date;
        trailerinfotext1.InnerText = popularMovies[(int)Session["i"]].overview;
        trailerinfotext2.InnerText = popularMovies[(int)Session["i"]+1].overview;
        trailerinfotext3.InnerText = popularMovies[(int)Session["i"]+2].overview;
        img01.Src = "http://image.tmdb.org/t/p/w500" + popularMovies[(int)Session["i"]].poster_path;
        img02.Src = "http://image.tmdb.org/t/p/w500" + popularMovies[(int)Session["i"] +1].poster_path;
        img03.Src = "http://image.tmdb.org/t/p/w500" + popularMovies[(int)Session["i"] +2].poster_path;

        int oldI = (int)Session["i"];
        Session["i"] = oldI + 3;

        CheckFavoriteStars();
    }

    public void CheckFavoriteStars()
    {
        //Check if favorite exist in database
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ("Data Source=LAPTOP-Q1VNVFM7\\SQLEXPRESS;Initial Catalog=IMDB;Integrated Security=True");

        if (Session["UsernameInlogged"] != null)
        {
            con.Open();

            //ID01
            SqlCommand cmd1 = new SqlCommand("select UserName,MovieID from Favorites where UserName='" + Session["UsernameInlogged"].ToString() + "'and MovieID='" + Session["Favorite1"] + "'", con);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);

            if (dt1.Rows.Count > 0)
            {
                System.Diagnostics.Debug.WriteLine(Session["Favorite1"] + "is Favorite");
                PosterButton1.ImageUrl = "img/star.png";
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(Session["Favorite1"] + "is NOT Favorite");
                PosterButton1.ImageUrl = "img/greystar.png";
            }

            //ID02
            SqlCommand cmd2 = new SqlCommand("select UserName,MovieID from Favorites where UserName='" + Session["UsernameInlogged"].ToString() + "'and MovieID='" + Session["Favorite2"] + "'", con);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);

            if (dt2.Rows.Count > 0)
            {
                System.Diagnostics.Debug.WriteLine(Session["Favorite2"] + "is Favorite");
                PosterButton2.ImageUrl = "img/star.png";
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(Session["Favorite2"] + "is NOT Favorite");
                PosterButton2.ImageUrl = "img/greystar.png";
            }

            //ID03
            SqlCommand cmd3 = new SqlCommand("select UserName,MovieID from Favorites where UserName='" + Session["UsernameInlogged"].ToString() + "'and MovieID='" + Session["Favorite3"] + "'", con);
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);

            if (dt3.Rows.Count > 0)
            {
                System.Diagnostics.Debug.WriteLine(Session["Favorite3"] + "is Favorite");
                PosterButton3.ImageUrl = "img/star.png";
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(Session["Favorite3"] + "is NOT Favorite");
                PosterButton3.ImageUrl = "img/greystar.png";
            }

            con.Close();
           
        }
    }
    public List<Result> getPopularMovies()
    {
        using (var client = new WebClient())
        {
            client.Headers[HttpRequestHeader.Accept] = "application/json";
            string result = client.DownloadString("https://api.themoviedb.org/3/movie/popular?page=1&language=en-US&api_key=85217826c2d89bd0b4cf673c229755f3");

            var popularData = JsonConvert.DeserializeObject<RootObject>(result);

            return popularData.results;
        }
    }
    public List<Result> getOpeningThisWeek()
    {
        using (var client = new WebClient())
        {
            client.Headers[HttpRequestHeader.Accept] = "application/json";
            string result = client.DownloadString("https://api.themoviedb.org/3/movie/upcoming?page=1&language=en-US&api_key=85217826c2d89bd0b4cf673c229755f3");
            var comingData = JsonConvert.DeserializeObject<RootObject>(result);

            return comingData.results;
        }
    }
    public List<Result> getTopRated()
    {
        using (var client = new WebClient())
        {
            client.Headers[HttpRequestHeader.Accept] = "application/json";
            string result = client.DownloadString("https://api.themoviedb.org/3/movie/top_rated?page=1&language=en-US&api_key=85217826c2d89bd0b4cf673c229755f3");

            var topratedData = JsonConvert.DeserializeObject<RootObject>(result);

            return topratedData.results;
        }
    }
    public class Result
    {
        public int vote_count { get; set; }
        public int id { get; set; }
        public bool video { get; set; }
        public double vote_average { get; set; }
        public string title { get; set; }
        public double popularity { get; set; }
        public string poster_path { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public List<int> genre_ids { get; set; }
        public string backdrop_path { get; set; }
        public bool adult { get; set; }
        public string overview { get; set; }
        public string release_date { get; set; }
    }

    public class RootObject
    {
        public int page { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
        public List<Result> results { get; set; }
    }
}

