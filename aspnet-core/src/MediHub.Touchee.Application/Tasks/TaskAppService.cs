using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;

namespace MediHub.Touchee.Tasks
{
    public class TaskAppService : AsyncCrudAppService<Task, TaskDto, int, GetAllTasksInput, CreateTaskInput, UpdateTaskInput>
    {
        public TaskAppService(IRepository<Task> repository)
            : base(repository)
        {
            //CreatePermissionName = "MyTaskCreationPermission";
        }

        protected override IQueryable<Task> CreateFilteredQuery(GetAllTasksInput input)
        {
            return (System.Linq.IQueryable<MediHub.Touchee.Tasks.Task>)base.CreateFilteredQuery(input)
                .WhereIf(input.Searchkey.Length > 0, t => t.Title == input.Searchkey);
        }
    }
}
