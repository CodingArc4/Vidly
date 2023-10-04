using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.Dtos;
using System.Data.Entity;

namespace Vidly.Controllers.Api
{
    
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //getting the list of movies
        public IHttpActionResult GetMovies(string Query = null)
        {
            var MovieQuery = _context.Movies
                .Include(c => c.Genre);

            if (!String.IsNullOrWhiteSpace(Query))
                MovieQuery = MovieQuery.Where(m => m.Name.Contains(Query));

            var MovieDto = MovieQuery
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);

            return Ok(MovieQuery);
        }

        //getting a movie by id
        public IHttpActionResult GetMovieByID(int id)
        {
            var movies = _context.Movies.SingleOrDefault(x => x.Id == id);

            if (movies == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Movie, MovieDto>(movies));
        }

        //adding a new movie to the list
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovie)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            //movie.DateAdded = DateTime.Now;
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        //updating a movie
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovie)]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movies.SingleOrDefault(x => x.Id == id);

            if (movieInDb == null)
                return NotFound();

            Mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();

            return Ok();
        }

        //deleting a movie
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovie)]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(x => x.Id == id);

            if (movieInDb == null)
                return NotFound();

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}