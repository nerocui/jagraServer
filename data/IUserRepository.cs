using System.Collections.Generic;
using System.Threading.Tasks;
using server.Models;

namespace server.data
{
    public interface IUserRepository
    {
        Task<User> GetUser(int id);
        Task<bool> UserExist(int id);
        Task<IEnumerable<User>> GetUsers();
        Task<IEnumerable<User>> GetUsersByOrganization(int organizationId);
    }
}
