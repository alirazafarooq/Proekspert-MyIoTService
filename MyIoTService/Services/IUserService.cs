using System.Collections.Generic;
using MyIoTService.Entities;
using MyIoTService.Models;

namespace MyIoTService.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<EndUser> GetAll();
        EndUser GetById(int id);
    }
}
