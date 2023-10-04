using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        public DateTime RelaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Range(1,20,ErrorMessage = "The number of stock must be between 1 and 20")] 
        public byte NumberInStock { get; set; }

        public Genre Genre { get; set; }
        public int GenreId { get; set; }

        public byte NumberAvaliable { get; set; }
    }
}