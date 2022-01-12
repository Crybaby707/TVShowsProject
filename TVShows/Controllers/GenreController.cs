using Microsoft.AspNetCore.Mvc;
using TVShows.BL;
using TVShows.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TVShows.WEB.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GenreController : ControllerBase
{

    private readonly IGenreBL _genreBL;

    public GenreController(IGenreBL genreBL)
    {
        _genreBL = genreBL;
    }



    // GET: api/<GenreController>
    [HttpGet]
    public IEnumerable<Genre> Get()
    {
        return _genreBL.GetAll();
    }


    // GET api/<GenreController>/5
    [HttpGet("{genreId}")]
    public Genre GetGenreById(int genreId)
    {
        return _genreBL.GetGenreById(genreId);
    }

    // POST api/<GenreController>
    [HttpPost]
    public Genre Post([FromBody] Genre genres)
    {
        return _genreBL.CreateGenre(genres);
    }

    // PUT api/<GenreController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {

    }

    // DELETE api/<GenreController>/5
    [HttpDelete("{genreId}")]
    public bool Delete(int genreId)
    {
        return _genreBL.DeleteGenre(genreId);
    }
}
