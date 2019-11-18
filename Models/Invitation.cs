namespace server.Models
{
    public class Invitation
    {
        public Organization Organization { get; set; }
        public int OrganizationId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
