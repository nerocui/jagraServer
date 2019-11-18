using System;
using System.Collections.Generic;

namespace server.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Email { get; set; }
        public DateTime Created { get; set; }
        public string KnownAs { get; set; }
        public ICollection<Task> CreatedTasks { get; set; }
        public ICollection<Task> AssignedTasks { get; set; }
        public ICollection<TaskWatch> WatchedTasks { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<OrganizationUser> Organizations { get; set; }
        public ICollection<Invitation> Invitations { get; set; }
    }
}
