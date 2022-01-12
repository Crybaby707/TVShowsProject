using Microsoft.AspNetCore.Mvc;
using System.Net;
using TVShows.BL.Dtos;
using TVShows.WEB.Errors;
using TVShows.WEB.Services;

namespace TVShows.WEB.Controllers
{
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IIdentityService userService;

        public AuthController(IIdentityService userService)
        {
            this.userService = userService;
        }



        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(TokenDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestMessage), (int)HttpStatusCode.BadRequest)]
        public IActionResult Post([FromBody] LoginDto userParam)
        {
            var token = userService.Authenticate(userParam.Email, userParam.Password);

            if (token == null)
            {
                return BadRequest(new BadRequestMessage()
                {
                    Message = "Username or password is incorrect"
                });
            }

            return Ok(new TokenDto()
            {
                Token = token
            });
        }
    }
}
