using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NecFlixApp.API.Data;
using NecFlixApp.API.Models.Movies;

namespace NecFlixApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MoviesAppDatabaseContext _context;

        public MoviesController(MoviesAppDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetMovies()
        {
            if (_context.Movies == null)
            {
                return NotFound();
            }
            var movies = _context.Movies.Include(x => x.Category).ToList();

            var movieDtos = new List<MovieDto>();

            foreach (var item in movies)
            {
                var movieDto = new MovieDto
                {
                    MovieId = item.MovieId,
                    MovieName = item.MovieName,
                    MovieRate = item.MovieRate,
                    Description = item.Description,
                    Director = item.Director,
                    Img = item.Img,
                    IsStatus = item.IsStatus,
                    Trailer = item.Trailer,
                    CategoryId = item.Category.CategoryId,
                    CategoryName = item.Category.CategoryName,


                    // Diğer özellikler
                };

                movieDtos.Add(movieDto);
            }

            return Ok(movieDtos);
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDto>> GetMovie(int id)
        {
            if (_context.Movies == null)
            {
                return NotFound();
            }
            var movie = _context.Movies.Include(x => x.Category).FirstOrDefault(x => x.MovieId == id);
            List<Comment> movieComments = _context.Comments.Where(x => x.MovieId == id).ToList();

            if (movie == null)
            {
                return NotFound();
            }
            var movieDto = new MovieDto
            {
                MovieId = movie.MovieId,
                MovieName = movie.MovieName,
                MovieRate = movie.MovieRate,
                Description = movie.Description,
                Director = movie.Director,
                Img = movie.Img,
                IsStatus = movie.IsStatus,
                Trailer = movie.Trailer,
                CategoryId = movie.Category.CategoryId,
                CategoryName = movie.Category.CategoryName,
                Comments = movieComments.Select(c => c.Content).ToList(),


            // Diğer özellikler
        };

            return Ok(movieDto);
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.MovieId)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            if (_context.Movies == null)
            {
                return Problem("Entity set 'MoviesAppDatabaseContext.Movies'  is null.");
            }
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = movie.MovieId }, movie);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            if (_context.Movies == null)
            {
                return NotFound();
            }
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieExists(int id)
        {
            return (_context.Movies?.Any(e => e.MovieId == id)).GetValueOrDefault();
        }
    }
}
