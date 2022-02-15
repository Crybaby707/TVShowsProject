using Microsoft.AspNetCore.Mvc;
using TVShows.BL;
using TVShows.Domain;
using TVShows.BL.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TVShows.WEB.Controllers;



[Route("api/[controller]")]
[ApiController]
public class ContentGenreController : ControllerBase
{
    private readonly IContentGenreBL _contentGenreBL;
    private readonly IMapper _mapper;

    public ContentGenreController(IContentGenreBL contentGenreBL, IMapper mapper)
    {
        _contentGenreBL = contentGenreBL;
        _mapper = mapper;
    }


    // GET: api/<ContentGenreController>
    [HttpGet]
    public IEnumerable<ContentGenre> Get()
    {

        return _contentGenreBL.GetAll();
    }

    // GET api/<ContentGenreController>/5
    [HttpGet("{ContentGenreid}")]
    public ContentGenre GetContentGenreById(int contentGenreID)
    {
        return _contentGenreBL.GetContentGenreById(contentGenreID);
    }

    // POST api/<ContentGenreController>
    [HttpPost]
    [Authorize(Roles = "User")]
    public CreateContentGenreDto Post([FromBody] CreateContentGenreDto createContentGenreDto)
    {
        var contentGenre = _mapper.Map<ContentGenre>(createContentGenreDto);

        return _mapper.Map<CreateContentGenreDto>(_contentGenreBL.CreateContentGenre(contentGenre));
    }

    // PUT api/<ContentGenreController>/5
    [HttpPut("{id}")]
    public CreateContentGenreDto Put(int id, [FromBody] CreateContentGenreDto createContentGenreDto)
    {

        var contentGenre = _mapper.Map<ContentGenre>(createContentGenreDto);

        contentGenre.ContentGenreID = id;

        return _mapper.Map<CreateContentGenreDto>(_contentGenreBL.UpdateContentGenre(contentGenre));

    }

    // DELETE api/<ContentGenreController>/5
    [HttpDelete("{ContentGenreId}")]
    [Authorize(Roles = "Admin")]
    public bool Delete(int contentGenreID)
    {
        return _contentGenreBL.DeleteContentGenre(contentGenreID);
    }
}
