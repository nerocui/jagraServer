using System.Collections.Generic;
using System.Threading.Tasks;
using server.Models;

namespace server.data
{
    public interface IInvitationRepository
    {
        Task<Invitation> Add(Invitation invitation);
        bool Delete(Invitation invitation);
        Task<bool> InvitationExist(int organizationId, int userId);
        Task<IEnumerable<Invitation>> GetInvitationsByOrganization(int organizationId);
        Task<IEnumerable<Invitation>> GetInvitationsByUser(int userId);
    }
}
