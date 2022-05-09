using MyIoTService.Entities;
using MyIoTService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyIoTService.Repository
{
    public interface IEndUserRepository
    {
        Task<IEnumerable<UserModel>> GetUsers();
        Task<UserModel> GetUser(int id);
        Task<UserModel> AddUser(UserModel endUser);
        Task<UserModel> UpdateUser(UserModel endUser);
        Task<UserModel> DeleteUser(int id);
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
    }
}
