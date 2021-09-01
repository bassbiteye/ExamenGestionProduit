using ExamenGestionProduit.Helpers;
using ExamenGestionProduit.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ExamenGestionProduit.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        User GetById(int id);  
    }

    public class UserService : IUserService
    {
        private readonly ExamenContext _context;



        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        /*   private List<User> _users = new List<User>
           {
               new User { Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test" }

           };*/


        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings, ExamenContext context)
        {
            _appSettings = appSettings.Value;
            _context = context;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var   user  = _context.users.Where(x => x.Username == model.Username && x.Password == model.Password).FirstOrDefault();
            
            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

      

        public User GetById(int id)
        {
            return _context.users.FirstOrDefault(x => x.Id == id);
        }
     


        // helper methods

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
