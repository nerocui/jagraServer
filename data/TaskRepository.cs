using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Models;
using Task = server.Models.Task;

namespace server.data
{
	public class TaskRepository : ITaskRepository
	{
		private readonly DataContext _context;
		public TaskRepository(DataContext context)
		{
			_context = context;
		}
		public async Task<Task> Add(Task task)
		{
            var taskTracker = await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            var taskToReturn = await Watch(task.Id, task.CreatorId);
            if (taskTracker.Entity.CreatorId != taskTracker.Entity.AssigneeId)
            {
                taskToReturn = await Watch(task.Id, task.AssigneeId);
            }
            return taskToReturn;
        }

		public Task<Task> Assign(Task task, User user)
		{
			throw new System.NotImplementedException();
		}

		public Task<Task> Delete(Task task)
		{
			throw new System.NotImplementedException();
		}

        public async Task<Task> GetTask(int taskId)
        {
            var task = await _context.Tasks
                .Include(x => x.Watchers)
                .Include(x => x.Creator)
                .Include(x => x.Assignee)
                .FirstOrDefaultAsync(x => x.Id == taskId);
            return task;
        }

        public async Task<IEnumerable<Task>> GetTasksByOrganization(int OrganizationId)
        {
            var tasks = await _context.Tasks
                .Where(x => x.OrganizationId == OrganizationId)
                .Include(x => x.Watchers)
                .OrderByDescending(x => x.Created)
                .ToListAsync();
            return tasks;
        }

        public Task<Task> Modify(Task task)
		{
			throw new System.NotImplementedException();
		}

		public Task<Task> Unassign(Task task)
		{
			throw new System.NotImplementedException();
		}

		public Task<Task> Unwatch(Task task, User user)
		{
			throw new System.NotImplementedException();
		}

		public async Task<Task> Watch(int taskId, int userId)
		{
            await _context.TaskWatches.AddAsync(new TaskWatch { TaskId = taskId, UserId = userId });
            await _context.SaveChangesAsync();
            return await GetTask(taskId);
		}
	}
}
