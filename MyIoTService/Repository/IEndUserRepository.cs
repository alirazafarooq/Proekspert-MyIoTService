using MyIoTService.Entities;
using MyIoTService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyIoTService.Repository
{
    public interface IEndUserRepository
    {
        Task<IEnumerable<EndUser>> GetUsers();
        Task<EndUser> GetUser(int id);
        Task<EndUser> AddUser(EndUser endUser);
        Task<EndUser> UpdateUser(EndUser endUser);
        Task DeleteUser(int id);
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
    }
}
