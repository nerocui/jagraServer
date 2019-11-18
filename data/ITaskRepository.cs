using System.Collections.Generic;
using System.Threading.Tasks;
using server.Models;
using Task = server.Models.Task;

namespace server.data
{
    public interface ITaskRepository
    {
        Task<Task> Add(Task task);
        Task<Task> Delete(Task task);
        Task<Task> Assign(Task task, User user);
        Task<Task> Unassign(Task task);
        Task<Task> Watch(int taskId, int userId);
        Task<Task> Unwatch(Task task, User user);
        Task<Task> Modify(Task task);
        Task<Task> GetTask(int taskId);
        Task<IEnumerable<Task>> GetTasksByOrganization(int OrganizationId);
    }
}
