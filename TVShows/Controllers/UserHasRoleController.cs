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

public class UserHasRoleController : ControllerBase
{
    private readonly IUserHasRoleBL _userHasRoleBL;
    private readonly IMapper _mapper;
    public UserHasRoleController(IUserHasRoleBL userHasRoleBL, IMapper mapper)
    {
        _userHasRoleBL = userHasRoleBL;
        _mapper = mapper;
    }

    // GET: api/<ContentController>
    [HttpGet]
    public IEnumerable<UserHasRole> Get()
    {
        return _userHasRoleBL.GetAll();
    }

    // GET api/<ContentController>/5
    [HttpGet("{userRoleId}")]
    public UserHasRole GetUserRoleById(int userRoleId)
    {
        return _userHasRoleBL.GetUserRoleById(userRoleId);
    }

    // POST api/<UserController>
    [HttpPost]
    public CreateUserHasRoleDto Post([FromBody] CreateUserHasRoleDto createUserHasRoleDto)
    {
        var userRole = _mapper.Map<UserHasRole>(createUserHasRoleDto);

        return _mapper.Map<CreateUserHasRoleDto>(_userHasRoleBL.AddUserRole(userRole));
    }

    // PUT api/<UserController>/5
    [HttpPut("{id}")]
    public CreateUserHasRoleDto Put(int id, [FromBody] CreateUserHasRoleDto createUserHasRoleDto)
    {

        var userHasRole = _mapper.Map<UserHasRole>(createUserHasRoleDto);

        userHasRole.UserRoleID = id;

        return _mapper.Map<CreateUserHasRoleDto>(_userHasRoleBL.UpdateUserRole(userHasRole));

    }

    // DELETE api/<UserController>/5
    [HttpDelete("{UserRoleId}")]
    public bool Delete(int userRoleId)
    {
        return _userHasRoleBL.DeleteUserRole(userRoleId);
    }
}
