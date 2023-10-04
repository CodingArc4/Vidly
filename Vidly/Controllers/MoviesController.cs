using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;
using System;
using System.Web.ModelBinding;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //Show the list of Movies
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovie))
                return View("List");
            
            return View("ReadOnlyList");
        }

        //Show detials about the movie
        public ActionResult Details(int id)
        {
            var detail = _context.Movies.Include(c => c.Genre).FirstOrDefault(x => x.Id == id);
            return View(detail);
        }

        //New Movie View Form
        [Authorize(Roles = RoleName.CanManageMovie)]
        public ActionResult NewMovie()
        {
            var viewModel = new MovieViewModel
            {
                Genres = _context.Genres.ToList()
            };
            
            return View(viewModel);
        }

        //Action result to save new movie to database and also edit the exisiting movie data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewmodel = new MovieViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("NewMovie", viewmodel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var MovieInDb = _context.Movies.Single(c => c.Id == movie.Id);

                MovieInDb.Name = movie.Name;
                MovieInDb.RelaseDate = movie.RelaseDate;
                MovieInDb.GenreId = movie.GenreId;
                MovieInDb.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index","Movies");
        }

        //this action result grab the deatils of the movie and show it on the EditForm view
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieViewModel(movie) {
                Genres = _context.Genres.ToList()
            };

            return View("EditForm",viewModel);

        }
    }
}