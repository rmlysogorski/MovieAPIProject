using MovieAPIProject.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieAPIProject.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            if(TempData["SearchResults"] != null)
            {
                JObject jData = (JObject)TempData["SearchResults"];
                List<MovieDisplayContent> movies = new List<MovieDisplayContent>();
                for(int i = 0; i < jData["Search"].Count(); i++)
                {                    
                    MovieDisplayContent newMovie = new MovieDisplayContent((JObject)jData["Search"][i]);
                    movies.Add(newMovie);
                    if (i >= 4)
                    {
                        return View(movies);
                    }

                }
                return View(movies);
            }
            return View();
        }

        public ActionResult SearchDatabase(string searchQuery, string searchYear)
        {
            string options = string.Empty;
            if(searchQuery != null)
            {
                options += $"&s={searchQuery}";
            }
            if(searchYear != null)
            {
                options += $"&y={searchYear}";
            }
            JObject jData = MovieDAL.GetMovieAPI(options);
            TempData["SearchResults"] = jData;
            return RedirectToAction("Index");
        }
    }
}