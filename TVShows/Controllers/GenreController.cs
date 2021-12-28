using Microsoft.AspNetCore.Mvc;
using TVShows.BL;
using TVShows.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TVShows.WEB.Controllers
{
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
        public IEnumerable<Genres> Get()
        {
            return _genreBL.GetAll();
        }


        // GET api/<GenreController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GenreController>
        [HttpPost]
        public IList<Genres> Post([FromBody] Genres genres)
        {
            return _genreBL.CreateGenre(genres);
        }

        // PUT api/<GenreController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<GenreController>/5
        [HttpDelete("{id}")]
        public IList<Genres> Delete(int GenreId)
        {
            return _genreBL.DeleteGenre(GenreId);
        }
    }
}
