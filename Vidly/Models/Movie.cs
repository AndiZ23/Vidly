using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(225)]
        public string Name { get; set; }

        public Genre Genre { get; set; }
        public byte GenreId { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        public int NumInStock { get; set; }
        // This model will function in the /movies/random 
        // aka. random method inside the MoviesController
    }
}