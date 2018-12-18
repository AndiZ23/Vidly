﻿using System;
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

        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        [Display(Name="Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name="Date Added")]
        public DateTime DateAdded { get; set; }

        [Display(Name="Number In Stock")]
        public int NumInStock { get; set; }
        // This model will function in the /movies/random 
        // aka. random method inside the MoviesController
    }
}