using MovieAPIProject.Models;
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
                ViewBag.SearchResults = TempData["SearchResults"];
            }
            return View();
        }

        public ActionResult SearchDatabase(string searchQuery)
        {
            TempData["SearchResults"] = MovieDAL.GetMovieAPI($"s={searchQuery}");
            return RedirectToAction("Index");
        }
    }
}