namespace server.Models
{
    public class OrganizationUser
    {
        public User User { get; set; }
        public int UserId { get; set; }
        public string Role { get; set; }
        public Organization Organization { get; set; }
        public int OrganizationId { get; set; }
    }
}