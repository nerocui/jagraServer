using System.Collections.Generic;
using System.Threading.Tasks;
using server.Models;

namespace server.data
{
    public interface IOrganizationRepository
    {
        /**
        * Creates an organization with the given organization model, user is admin
        */
        Task<Organization> Create(Organization organization, User user);
        /**
        * After the user click join, they will be added to the organization by this function
        */
        Task<Organization> AddUser(int organizationId, int userId, string role);
        Task<User> RemoveUser(Organization organization, User user);
        Task<bool> DeleteOrganization(Organization organization);
        Task<bool> OrganizationExist(string name);
        Task<bool> OrganizationExist(int id);
        Task<bool> IsAdmin(Organization organization, User user);
        Task<Organization> GetOrganization(int Id);
        Task<IEnumerable<Organization>> GetOrganizationsByUser(int id);
        Task<IEnumerable<Organization>> GetOrganizations();
        Task<Organization> UpdateOrganization(Organization org);
    }
}
