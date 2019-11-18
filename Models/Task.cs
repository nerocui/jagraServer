using System;
using System.Collections.Generic;

namespace server.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public User Creator { get; set; }
        public User Assignee { get; set; }
        public ICollection<TaskWatch> Watchers { get; set; }
        public int CreatorId { get; set; }
        public int AssigneeId { get; set; }
        public Organization Organization { get; set; }
        public int OrganizationId { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
        public ICollection<TaskDependency> Dependers { get; set; }
        public ICollection<TaskDependency> Dependees { get; set; }
    }
}