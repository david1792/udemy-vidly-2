using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using AutoMapper;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        [Authorize(Roles = RoleName.CanManageMovie)]//this overwrite the global authorize filter, we can pass multiple rols separates by comma
        public IEnumerable<MovieDto> GetMovies()
        {
            var movies = _context.Movies
                .Include(m => m.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);
            return movies;
        }
        [Authorize(Roles = RoleName.CanManageMovie)]//this overwrite the global authorize filter, we can pass multiple rols separates by comma
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }
        [Authorize(Roles = RoleName.CanManageMovie)]//this overwrite the global authorize filter, we can pass multiple rols separates by comma
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }
        [Authorize(Roles = RoleName.CanManageMovie)]//this overwrite the global authorize filter, we can pass multiple rols separates by comma
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
                return NotFound();
            Mapper.Map(movieDto, movieInDb);
            movieInDb.Id = id;
            _context.SaveChanges();
            return Ok(Mapper.Map<Movie, MovieDto>(movieInDb));
        }
        [Authorize(Roles = RoleName.CanManageMovie)]//this overwrite the global authorize filter, we can pass multiple rols separates by comma
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
                return BadRequest();
            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
            return Ok(Mapper.Map<Movie, MovieDto>(movieInDb));
        }
    }
}
