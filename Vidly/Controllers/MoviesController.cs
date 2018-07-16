using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models; // associates the Movie.cs model to this controller
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        public ViewResult Index()
        {
            var movies = GetMovies();

            return View(movies);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie {Id =1, Name="Shrek"},
                new Movie {Id =2, Name="Wall-e"}
            };
        }
        
        // GET: Movies/Random
        public ActionResult Random() 
        // Index() is the default controller method that returns ActionResult
        //      we can change the name to any (e.g. Random) -> GET: Movies/Random
        {
            var movie = new Movie() { Name = "Shrek!" };
            // the Movie class is the model, this is to create a new instance of the class.


            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1"},
                new Customer { Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel); // pass the instance/data to the view
                                // the controller passes data (that formed by the Model -- instance) to the View, 
                                //  which has to be the same name as this method, aka. Random.cshtml.

            /*  Examples of different ActionResults   */
            //return Content("Hello World!");   // empty page with the plain text on it.
            //return HttpNotFound();    // 404 page
            //return new EmptyResult(); // a empty blank page
            //return RedirectToAction("Index","Home", new {page = 1. sortBy="name"});
            // parameters: 1st. the name of the action; 2nd. destination page of the redirction; 
            //             3rd. the data passing during the redirect. 
            // Output: redirect to Home page, with page=1&sortBy=name on the url (like GET data)

        }

        public ActionResult Edit(int id)
        {
            /*
             * pass parameter through url (.../movies/edit/1, the "1" is assigned to id 
             * because in RouteConfig's MapRoute, we configured url: {controller}/{action}/{id}
             */
            return Content("id=" + id); 
        }

        // /movies
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue) // on default, showing page 1
        //        pageIndex = 1;

        //    if (string.IsNullOrWhiteSpace(sortBy)) // on default, sort by "name"
        //        sortBy = "Name";

        //    return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));  //{0} the first parameter, {1} the second parameter
        //}

        //// apply a route attribute here; rhe colon is for adding constraints for the attr
        //[Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        //public ActionResult ByReleaseDate(int year, int month)
        //{
        //    return Content(year + "/" + month);
        //}
    }
}
// ActionResult:
//      The base class for all action resolves in ASP.NET MVC
//      One of the subclass: ViewResult
//          Alternatively, the return can change to: return new ViewResult();
//      But since ActionResult is the parent class, so by using this, we can return any of its subtypes.

// All ActionResult's alternatives:
//      Type                    Helper Method           function
//      ViewResult              View()                  To return a View
//      PartialViewResult       PartialView()           To return a partial view
//      ContentResult           Content()               To return simple text redirect result
//      RedirectResult          Redirect()              To redirect the user to a url
//      RedirectToRouteResult   RedirectToAction()      To redirect to an action instead of a url
//      JsonResult              Json()                  To return a json object
//      FileResult              File()                  To return a file
//      HttpNotFoundResult      HttpNotFound()          To return an error or 404
//      EmptyResult             N/A                     No return needed