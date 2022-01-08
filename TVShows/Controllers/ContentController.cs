using Microsoft.AspNetCore.Mvc;
using TVShows.BL;
using TVShows.Domain;
using TVShows.BL.Dtos;
using AutoMapper;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TVShows.WEB.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ContentController : ControllerBase
{

    private readonly IContentBL _contentBL;
    private readonly IMapper _mapper;
    public ContentController(IContentBL contentBL, IMapper mapper)
    {
        _contentBL = contentBL;
        _mapper = mapper;
    }



    // GET: api/<ContentController>
    [HttpGet]
    public IEnumerable<Content> Get()
    {
        return _contentBL.GetAll();
    }

    // GET api/<ContentController>/5
    [HttpGet("{ContentId}")]
    public Content GetContentById(int contentId)
    {
        return _contentBL.GetContentById(contentId);
    }

    // POST api/<ContentController>
    [HttpPost]
    public CreateContentDto Post([FromBody] CreateContentDto createContentDto)
    {
        var content = _mapper.Map<Content>(createContentDto);

        return _mapper.Map<CreateContentDto>(_contentBL.CreateContent(content));
    }

    // PUT api/<ContentController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<ContentController>/5
    [HttpDelete("{ContentId}")]
    public bool Delete(int contentId)
    {
        return _contentBL.DeleteContent(contentId);
    }
}
