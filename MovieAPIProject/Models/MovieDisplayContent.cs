using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieAPIProject.Models
{
    public class MovieDisplayContent
    {
        public string Title { get; set; }   
        public string Year { get; set; }
        public string Rated { get; set; }
        public string Genre { get; set; }
        public string Plot { get; set; }
        public string Poster { get; set; }
        public string MCRating { get; set; }

        public MovieDisplayContent(JObject jData)
        {
            Title = jData["Title"].ToString();
            JObject movieInfo = MovieDAL.GetMovieAPI($"&t={Title}");            
            Year = jData["Year"].ToString();
            Rated = movieInfo["Rated"].ToString();
            Genre = movieInfo["Genre"].ToString();
            Plot = movieInfo["Plot"].ToString();
            Poster = jData["Poster"].ToString();
            foreach(JObject j in movieInfo["Ratings"])
            {
                if(j["Source"].ToString() == "Metacritic")
                {
                    MCRating = j["Value"].ToString();
                    break;
                }
            }            

        }
    }
}