using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models; // associates the Movie.cs model to this controller

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random() 
        // Index() is the default controller method that returns ActionResult
        //      we can change the name to any (e.g. Random) -> GET: Movies/Random
        {
            var movie = new Movie() { Name = "Shrek!" }; 
            // the Movie class is the model, this is to create a new instance of the class.

            return View(movie); // pass the instance/data to the view
            // the controller passes data (that formed by the Model -- instance) to the View, 
            //  which has to be the same name as this method, aka. Random.cshtml.
        }
    }
}