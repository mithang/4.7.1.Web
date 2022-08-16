using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;

namespace MediHub.Touchee.Tasks
{
    [AutoMap(typeof(Task))]
    public class TaskDto : EntityDto, IHasCreationTime
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreationTime { get; set; }


        public string AssignedPersonName { get; set; }
    }
}
