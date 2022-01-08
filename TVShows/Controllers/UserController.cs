using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TVShows.BL;
using TVShows.BL.Dtos;
using TVShows.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TVShows.WEB.Controllers;


[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserBL _userBL;
    private readonly IMapper _mapper;
    public UserController(IUserBL userBL, IMapper mapper)
    {
        _userBL = userBL;
        _mapper = mapper;
    }

    // GET: api/<ContentController>
    [HttpGet]
    public IEnumerable<User> Get()
    {
        return _userBL.GetAll();
    }

    // GET api/<ContentController>/5
    [HttpGet("{UserId}")]
    public User GetUserById(int userId)
    {
        return _userBL.GetUserById(userId);
    }

    // POST api/<UserController>
    [HttpPost]
    public CreateUserDto Post([FromBody] CreateUserDto createUserDto)
    {
        var user = _mapper.Map<User>(createUserDto);

        return _mapper.Map<CreateUserDto>(_userBL.CreateUser(user));
    }

    // PUT api/<UserController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<UserController>/5
    [HttpDelete("{UserId}")]
    public bool Delete(int userId)
    {
        return _userBL.DeleteUser(userId);
    }
}
