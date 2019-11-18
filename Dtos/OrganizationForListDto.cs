using System.Collections.Generic;
using server.Models;

namespace server.Dtos
{
    public class OrganizationForListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public ICollection<UserForListDto> Users { get; set; }
        public ICollection<TaskForListDto> Tasks { get; set; }
        public ICollection<InvitationForListDto> Invitations { get; set; }
    }
}
