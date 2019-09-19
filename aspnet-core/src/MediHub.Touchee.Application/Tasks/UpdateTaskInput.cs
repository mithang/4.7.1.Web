using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace MediHub.Touchee.Tasks
{
    [AutoMapTo(typeof(Task))]
    public class UpdateTaskInput : CreateTaskInput, IEntityDto
    {
        public int Id { get; set; }

    }
}
