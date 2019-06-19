using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        public ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(g => g.Genre).ToList();
            return View(movies);
        }

        public ActionResult ShowDetails(int id)
        {
            return View(_context.Movies.Include(g => g.Genre).SingleOrDefault(m => m.Id == id));
        }
        // GET: Movie
        public ActionResult Random()
        {
            Movie movie = new Movie() {Name = "Matrix"};
            var customers = new List<Customer>()
            {
                new Customer{ Name = "Customer 1"},
                new Customer{Name = "Customer 2"}
            };
            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);

        }
        public ActionResult Save()
        {
            MovieFormViewModel movieFormViewModel = new MovieFormViewModel()
            {
                Genres = _context.Genres.ToList()
            };
            return View("Save", movieFormViewModel);
        }
        [ActionName("SaveEdition")]
        public ActionResult Save(int id)
        {

            MovieFormViewModel movieFormViewModel = new MovieFormViewModel()
            {
                Genres = _context.Genres.ToList(),
                Movie = _context.Movies.Single(m => m.Id == id)
            };
            return View("Save", movieFormViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(MovieFormViewModel movieFormViewModel)
        {
            if (!ModelState.IsValid)
            {
                MovieFormViewModel ViewModel = new MovieFormViewModel()
                {
                    Genres = _context.Genres.ToList()
                };
                return View("Save", ViewModel);
            }
            if (movieFormViewModel.Movie.Id == 0)
            {
                _context.Movies.Add(movieFormViewModel.Movie);
                _context.SaveChanges();
            }
            else
            {
                MovieFormViewModel movieFormViewModelDb = new MovieFormViewModel();
                movieFormViewModelDb.Movie = _context.Movies.Single(x => x.Id == movieFormViewModel.Movie.Id);
                movieFormViewModelDb.Movie.DateAdded = movieFormViewModel.Movie.DateAdded;
                movieFormViewModelDb.Movie.GenreId = movieFormViewModel.Movie.GenreId;
                movieFormViewModelDb.Movie.Name = movieFormViewModel.Movie.Name;
                movieFormViewModelDb.Movie.ReleaseDate = movieFormViewModel.Movie.ReleaseDate;
                movieFormViewModelDb.Movie.Stock = movieFormViewModel.Movie.Stock;
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Movie");
        }
    }
}