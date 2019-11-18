namespace server.Models
{
    public class TaskWatch
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public Task Task { get; set; }
        public int TaskId { get; set; }
    }
}