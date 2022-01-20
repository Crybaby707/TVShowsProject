using AutoMapper;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TVShows.BL;
using TVShows.BL.Dtos;
using TVShows.WEB.Helpers;
using Microsoft.IdentityModel.Tokens;

namespace TVShows.WEB.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly AppSettings appSettings;
        private readonly IMapper mapper;
        private readonly IUserAuthBL userAuthBL;

        public IdentityService(IOptions<AppSettings> appSettings, IMapper mapper, IUserAuthBL userAuthBL)
        {
            this.appSettings = appSettings.Value;
            this.mapper = mapper;
            this.userAuthBL = userAuthBL;
        }


        public string Authenticate(string email, string password)
        {
            var user = userAuthBL.GetByEmailAndPassword(email, password);
            // return null if user not found
            if (user == null)
            {
                return null;
            }

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            var objUser = JsonConvert.SerializeObject(mapper.Map<AuthUserDto>(user));
            var claims = new List<Claim>() {
                            new Claim(ClaimTypes.Sid, user.UserID.ToString()),
                            new Claim(ClaimTypes.Name, user.Email)
            };
            var roles = user.UserRole.Select(ur => ur.Role);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Code));
            }

            var identity = new ClaimsIdentity(claims);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
