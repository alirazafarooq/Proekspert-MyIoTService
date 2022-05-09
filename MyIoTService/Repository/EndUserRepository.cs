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
        private readonly IoTServiceDBContext ioTServiceDbContext;
        public EndUserRepository(IOptions<AppSettings> appSettings, IoTServiceDBContext dBContext)
        {
            _appSettings = appSettings.Value;
            ioTServiceDbContext = dBContext;
        }
        public async Task<UserModel> AddUser(UserModel endUser)
        {
            try
            {
                var result = await ioTServiceDbContext.EndUsers.AddAsync(endUser.EndUserEntity());
                await ioTServiceDbContext.SaveChangesAsync();
                return new UserModel(result.Entity);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<UserModel> DeleteUser(int id)
        {
            var user = await ioTServiceDbContext.EndUsers.FindAsync(id);
            if (user != null)
            {
                try
                {
                    var result = ioTServiceDbContext.EndUsers.Remove(user);
                    await ioTServiceDbContext.SaveChangesAsync();
                    return new UserModel(result.Entity);
                }
                catch (Exception)
                {
                    return null;
                }
            }
            else return null;
        }

        public async Task<UserModel> GetUser(int id)
        {
            var user = await ioTServiceDbContext.EndUsers.FirstOrDefaultAsync(c => c.Id == id);
            if (user != null)
            {
                return new UserModel(user);
            }
            else return null;
        }

        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            return await ioTServiceDbContext.EndUsers.Select(u => new UserModel(u)).ToListAsync();
        }

        public async Task<UserModel> UpdateUser(UserModel endUser)
        {
            try
            {
                var result = ioTServiceDbContext.EndUsers.Update(endUser.EndUserEntity());
                await ioTServiceDbContext.SaveChangesAsync();
                return new UserModel(result.Entity);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            try
            {
                var user = await ioTServiceDbContext.EndUsers.FirstOrDefaultAsync(c => c.Username == model.Username && c.Password == model.Password);

                if (user != null)
                {
                    var token = generateJwtToken(user);
                    return new AuthenticateResponse(user, token);
                }
                else return null;
            }
            catch (Exception)
            {
                return null;
            }
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
