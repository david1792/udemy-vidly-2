using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Vidly.Models.CustomValidations;

namespace Vidly.DTOs
{
    public class MovieDto
    {

        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        //[Validate20Stock]
        public int Stock { get; set; }
        [Required]
        public int GenreId { get; set; }    

    }
}