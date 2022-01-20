using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TVShows.BL;
using TVShows.BL.Dtos;
using TVShows.Domain;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TVShows.WEB.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GenreController : ControllerBase
{

    private readonly IGenreBL _genreBL;
    private readonly IMapper _mapper;

    public GenreController(IGenreBL genreBL, IMapper mapper)
    {
        _genreBL = genreBL;
        _mapper = mapper;
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
    [Authorize(Roles = "User")]
    public Genre Post([FromBody] Genre genres)
    {
        return _genreBL.CreateGenre(genres);
    }

    // PUT api/<GenreController>/5
    [HttpPut("{id}")]
    public CreateGenreDto Put(int id, [FromBody] CreateGenreDto createGenreDto)
    {

        var genres = _mapper.Map<Genre>(createGenreDto);

        genres.GenreID = id;

        return _mapper.Map<CreateGenreDto>(_genreBL.UpdateGenre(genres));

    }

    // DELETE api/<GenreController>/5
    [HttpDelete("{genreId}")]
    [Authorize(Roles = "Admin")]
    public bool Delete(int genreId)
    {
        return _genreBL.DeleteGenre(genreId);
    }
}
