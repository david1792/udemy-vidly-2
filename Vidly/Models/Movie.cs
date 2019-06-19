using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Vidly.Models.CustomValidations;

namespace Vidly.Models
{
    public class Movie
    {

        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        [Display(Name = "Released date")]
        public DateTime ReleaseDate { get; set; }
        [Required]
        [Display(Name = "Released date")]
        public DateTime DateAdded { get; set; }
        [Required]
        [Validate20Stock]
        public int Stock { get; set; }
        public Genre Genre { get; set; }
        [Required]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }    

    }
}