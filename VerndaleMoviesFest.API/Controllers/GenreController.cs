using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VerndaleMoviesFest.API.DTOs;
using VerndaleMoviesFest.DAL;

namespace VerndaleMoviesFest.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenreController : Controller
    {
        private readonly DBContext db;

        public GenreController(DBContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<GenreDTO>>> Index()
        {
            return await db.Genres.Select(
                s => new GenreDTO
                {
                    IdGenre = s.IdGenre,
                    Name = s.Name
                }
            ).ToListAsync();
        }
    }
}
