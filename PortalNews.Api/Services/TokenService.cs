using Microsoft.IdentityModel.Tokens;
using PortalNews.Domain;
using PortalNews.Infratructure.Persistences.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PortalNews.Api.Services
{
    public class TokenService
    {
        private IRoleRepository _roleRepository;
        private string keyJwt { get;}

        public TokenService(IConfiguration configuration , IRoleRepository roleRepository)
        {
            keyJwt = configuration["JWT_KEY"];
            _roleRepository = roleRepository;
        }

        //passar no parametro um objeto do tipo user 
        public string GenerateToken(User user)
        {
            Role roleName = (Role) _roleRepository.GetById(user.RoleId);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(keyJwt);

            var tokenDescription = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name , user.Name),
                    new Claim(ClaimTypes.Email , user.Email),
                    new Claim(ClaimTypes.Role , roleName.Name),
                   
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key) ,
                    SecurityAlgorithms.HmacSha256Signature)
             };

            var token = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(token);
        }


    }
}
