using MovieAPIProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieAPIProject.Controllers
{
    public class UserController : Controller
    {
        private MovieAPIUsersEntities ORM = new MovieAPIUsersEntities();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Movies()
        {
            List<Movy> movies = ORM.Movies.ToList();
            return View(movies);
        }
       
        public ActionResult RemoveFavorite(int Id)
        {
            Movy found = ORM.Movies.Find(Id);
            ORM.Movies.Remove(ORM.Movies.Find(Id));
            ORM.SaveChanges();
            return RedirectToAction("Movies");
        }


        //public ActionResult UserMovieList()
        //{
        //    string userId = User.Identity.GetUserId();
        //    List<UserMovy> userMovie = ORM.UserMovies.Where(x => x.UserId == userId).ToList();
        //    return View(userMovie);
        //}

        //            public ActionResult SaveUserMovie(int movieId)
        //{
        //    string userId = User.Identity.GetUserId();
        //    UserMovy newMovie = new UserMovy();
        //    newMovie.MovieId = movieId;
        //    newMovie.UserId = userId;
        //    ORM.UserMovies.Add(newMovie);
        //    ORM.SaveChanges();
        //    return RedirectToAction("UserMovieList");
        //}
        //public ActionResult SaveUserMovie(int movieId)
        //{
        //    string userId = User.Identity.GetUserId();
        //    UserMovy newMovie = new UserMovy();
        //    newMovie.MovieId = movieId;
        //    newMovie.UserId = userId;
        //    ORM.UserMovies.Add(newMovie);
        //    ORM.SaveChanges();
        //    return RedirectToAction("UserMovieList");
        //}





    }
}