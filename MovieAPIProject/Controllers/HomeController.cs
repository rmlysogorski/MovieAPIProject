using MovieAPIProject.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieAPIProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            JObject jData = MovieDAL.GetMovieAPI();
            return View(jData);
        }
       
    }
}