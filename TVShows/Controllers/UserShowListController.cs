using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TVShows.BL;
using TVShows.BL.Dtos;
using TVShows.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TVShows.WEB.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserShowListController : ControllerBase
{
    private readonly IUserShowListBL _userShowListBL;
    private readonly IMapper _mapper;
    public UserShowListController(IUserShowListBL userShowListBL, IMapper mapper)
    {
        _userShowListBL = userShowListBL;
        _mapper = mapper;
    }

    // GET: api/<ValuesController>
    [HttpGet]
    public IEnumerable<UserShowList> Get()
    {
        return _userShowListBL.GetAll();
    }

    // GET api/<ValuesController>/5
    [HttpGet("{userShowListId}")]
    public UserShowList GetUserRoleById(int userShowListId)
    {
        return _userShowListBL.GetUserShowListById(userShowListId);
    }

    // POST api/<ValuesController>
    [HttpPost]
    public AddUserShowListDto Post([FromBody] AddUserShowListDto addUserShowListDto)
    {
        var userShowList = _mapper.Map<UserShowList>(addUserShowListDto);

        return _mapper.Map<AddUserShowListDto>(_userShowListBL.AddUserShowList(userShowList));
    }

    // PUT api/<ValuesController>/5
    [HttpPut("{id}")]
    public AddUserShowListDto Put(int id, [FromBody] AddUserShowListDto addUserShowListDto)
    {

        var userShowList = _mapper.Map<UserShowList>(addUserShowListDto);

        userShowList.UserShowListID = id;

        return _mapper.Map<AddUserShowListDto>(_userShowListBL.UpdateUserShowList(userShowList));

    }

    // DELETE api/<ValuesController>/5
    [HttpDelete("{userShowListId}")]
    public bool Delete(int userShowListId)
    {
        return _userShowListBL.DeleteUserShowList(userShowListId);
    }
}

