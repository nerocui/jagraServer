using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dtos
{
    public class InvitationForCreationDto
    {
        public int OrganizationId { get; set; }
        public int UserId { get; set; }
        public int InvitorId { get; set; }
    }
}
