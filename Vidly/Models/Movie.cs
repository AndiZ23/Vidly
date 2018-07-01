using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // This model will function in the /movies/random 
        // aka. random method inside the MoviesController
    }
}