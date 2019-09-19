using System;
using Abp.Application.Services;

namespace MediHub.Touchee.Tasks
{
    public interface ITaskAppService : IAsyncCrudAppService<TaskDto>
    {

    }
}
