using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using VerndaleMoviesFest.API.DTOs;
using VerndaleMoviesFest.DAL;
using VerndaleMoviesFest.DAL.Entities;

namespace VerndaleMoviesFest.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : Controller
    {
        private readonly DBContext db;

        public MovieController(DBContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<MovieDTO>>> Get()
        {
            return await db.Movies.Select(
                s => new MovieDTO
                {
                    IdMovie = s.IdMovie,
                    Name = s.Name,
                    ReleaseDate = s.ReleaseDate,
                    Duration = s.Duration,
                    Synopsis = s.Synopsis,
                    IdGenre = s.IdGenre,
                    NameGenre = s.IdGenreNavigation.Name
                }
            ).ToListAsync();
        }

        [HttpGet("GetMovieById")]
        public async Task<ActionResult<MovieDTO>> GetMovieById(int idMovie)
        {
            return await db.Movies.Select(
                    s => new MovieDTO
                    {
                        IdMovie = s.IdMovie,
                        Name = s.Name,
                        ReleaseDate = s.ReleaseDate,
                        Duration = s.Duration,
                        Synopsis = s.Synopsis,
                        IdGenre = s.IdGenre,
                        NameGenre = s.IdGenreNavigation.Name
                    })
                .FirstOrDefaultAsync(s => s.IdMovie == idMovie);
        }

        [HttpPost("InsertMovie")]
        public async Task<HttpStatusCode> InsertMovie(MovieDTO movie)
        {
            var entity = new Movie()
            {
                IdMovie = movie.IdMovie,
                Name = movie.Name,
                ReleaseDate = movie.ReleaseDate,
                Duration = movie.Duration,
                Synopsis = movie.Synopsis,
                IdGenre = movie.IdGenre
            };

            db.Movies.Add(entity);
            await db.SaveChangesAsync();

            return HttpStatusCode.OK;
        }

        [HttpPut("UpdateMovie")]
        public async Task<HttpStatusCode> UpdateMovie(MovieDTO movie)
        {
            var m = GetMovieById(movie.IdMovie);

            var entity = await db.Movies.FirstOrDefaultAsync(s => s.IdMovie == movie.IdMovie);

            entity.Name = movie.Name;
            entity.ReleaseDate = movie.ReleaseDate;
            entity.Duration = movie.Duration;
            entity.Synopsis = movie.Synopsis;
            entity.IdGenre = movie.IdGenre;

            await db.SaveChangesAsync();
            return HttpStatusCode.OK;
        }

        [HttpDelete("DeleteMovie/{idMovie}")]
        public async Task<HttpStatusCode> DeleteMovie(int idMovie)
        {
            var entity = await db.Movies.FirstOrDefaultAsync(s => s.IdMovie == idMovie);
            db.Movies.Remove(entity);

            await db.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}