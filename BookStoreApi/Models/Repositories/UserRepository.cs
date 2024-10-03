using BookStoreApi.Models.Jwt;
using BookStoreProject.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookStoreApi.Models.Repositories
{


    public class UserRepository : IUserRepository
    {
        private readonly BooksStoreDbContext2 _appDB;
        private readonly JwtOptions _jwtOptions;
        public UserRepository(BooksStoreDbContext2 appDB, JwtOptions jwtOptions)
        {
            this._appDB = appDB;
            this._jwtOptions = jwtOptions;
        }

        public string AuthenticateAdmin(string username, string password)
        {
            var user = _appDB.Users.FirstOrDefault(m => m.UserName == username && m.Password == password);
            if (user == null)
            {
                return null;
            }
            // var userRole = _appDB.User.FirstOrDefault(m => m. == user.ID); 
            var IsAdmin = _appDB.Roles.FirstOrDefault(m => m.UserID == user.ID);
            if (IsAdmin != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Issuer = _jwtOptions.Issuer,
                    Audience = _jwtOptions.Audience,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Signingkey)),
                    SecurityAlgorithms.HmacSha256),
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new (ClaimTypes.Name,user.UserName),
                        //  new (ClaimTypes.Role,user) 

                    })
                };
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var accessToken = tokenHandler.WriteToken(securityToken);
                return accessToken;

            }
            return null;


        }


        public string AuthenticateUser(string username, string password)
        {
            var user = _appDB.Users.FirstOrDefault(m => m.UserName == username && m.Password == password);

            if (user == null)
            {
                return null;
            }
            // var userRole = _appDB.User.FirstOrDefault(m => m. == user.ID); 

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _jwtOptions.Issuer,
                Audience = _jwtOptions.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Signingkey)),
                SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new (ClaimTypes.Name,user.UserName), 
                 //  new (ClaimTypes.Role,user) 
 
                })
            };
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = tokenHandler.WriteToken(securityToken);
            return accessToken;

        }

    }




}
