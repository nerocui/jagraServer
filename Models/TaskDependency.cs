namespace server.Models
{
    public class TaskDependency
    {
        public Task Depender { get; set; }
        public int DependerId { get; set; }
        public Task Dependee { get; set; }
        public int DependeeId { get; set; }
    }
}