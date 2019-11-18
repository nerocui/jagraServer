using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dtos
{
    public class TaskForListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public UserForListDto Creator { get; set; }
        public UserForListDto Assignee { get; set; }
        public ICollection<UserForListDto> Watchers { get; set; }
        public int CreatorId { get; set; }
        public int AssigneeId { get; set; }
        public OrganizationForListDto Organization { get; set; }
        public int OrganizationId { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
        public ICollection<TaskForListDto> Dependers { get; set; }
        public ICollection<TaskForListDto> Dependees { get; set; }
    }
}
