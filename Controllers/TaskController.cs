using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.data;
using server.Dtos;
using server.Models;
using Task = server.Models.Task;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _repo;
        private readonly IUserRepository _users;
        private readonly IOrganizationRepository _organizations;
        private readonly IMapper _mapper;

        public TaskController(ITaskRepository repo, IUserRepository users, IOrganizationRepository organizations, IMapper mapper)
        {
            _repo = repo;
            _users = users;
            _organizations = organizations;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(TaskForCreationDto task)
        {
            if (!await _users.UserExist(task.CreatorId) || !await _users.UserExist(task.AssigneeId) || !await _organizations.OrganizationExist(task.OrganizationId))
            {
                return BadRequest("Bad request data, data don't exist.");
            }
            var taskToCreate = new Task
            {
                Title = task.Title,
                Description = task.Description,
                CreatorId = task.CreatorId,
                AssigneeId = task.AssigneeId,
                OrganizationId = task.OrganizationId,
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
            };
            var taskCreated = await _repo.Add(taskToCreate);
            var taskToReturn = _mapper.Map<TaskForListDto>(taskCreated);
            return Ok(taskToReturn);
        }

        [HttpGet("byorg")]
        public async Task<IActionResult> GetTasksByOrganization(int OrganizationId)
        {
            if (!await _organizations.OrganizationExist(OrganizationId))
            {
                return BadRequest("Organization does not exist.");
            }
            var tasks = await _repo.GetTasksByOrganization(OrganizationId);
            var tasksToReturn = new List<TaskForListDto>();
            foreach (var task in tasks)
            {
                var watchers = new List<UserForListDto>();
                foreach (var watcher in task.Watchers)
                {
                    watchers.Add(_mapper.Map<UserForListDto>(await _users.GetUser(watcher.UserId)));
                }
                var taskToReturn = _mapper.Map<TaskForListDto>(task);
                taskToReturn.Watchers = watchers;
                tasksToReturn.Add(taskToReturn);
            }
            return Ok(tasksToReturn);
        }
    }
}