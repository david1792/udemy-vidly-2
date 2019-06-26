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
        public DateTime DateAdded { get; set; }
        //[Validate20Stock]
        [Range(1, 20)]
        public int Stock { get; set; }
        public int GenreId { get; set; }

        public GenreDto Genre { get; set; }

    }
}