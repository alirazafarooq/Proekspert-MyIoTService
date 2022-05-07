using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyIoTService.Database;
using MyIoTService.Entities;
using MyIoTService.Helpers;
using MyIoTService.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace MyIoTService.Repository
{
    public class EndUserRepository : IEndUserRepository
    {
        private readonly AppSettings _appSettings;
        private readonly IoTServiceDBContext _myDbContext;
        public EndUserRepository(IOptions<AppSettings> appSettings, IoTServiceDBContext myDBContext)
        {
            _appSettings = appSettings.Value;
            _myDbContext = myDBContext;
        }
        public async Task<UserModel> AddUser(UserModel endUser)
        {
            _myDbContext.Add(endUser);
            await _myDbContext.SaveChangesAsync();
            return endUser;
        }

        public async Task DeleteUser(int id)
        {
            var user = await _myDbContext.EndUsers.FindAsync(id);
            if (user != null)
            {
                _myDbContext.EndUsers.Remove(user);
                await _myDbContext.SaveChangesAsync();
            }
        }

        public async Task<UserModel> GetUser(int id)
        {
            var user = await _myDbContext.EndUsers.FirstOrDefaultAsync(c => c.Id == id);
            return new UserModel(user);
        }

        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            return await _myDbContext.EndUsers.Select(u => new UserModel(u)).ToListAsync();
        }

        public async Task<UserModel> UpdateUser(UserModel endUser)
        {
            if (endUser != null)
            {
                _myDbContext.Update(endUser.EndUserEntity());
                await _myDbContext.SaveChangesAsync();
            }
            return endUser;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            var user = await _myDbContext.EndUsers.FirstOrDefaultAsync(c => c.Username == model.Username && c.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        // helper method
        private string generateJwtToken(EndUser user)
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
