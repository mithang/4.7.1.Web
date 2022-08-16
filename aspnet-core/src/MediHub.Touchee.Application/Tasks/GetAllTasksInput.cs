using System;
using Abp.Application.Services.Dto;

namespace MediHub.Touchee.Tasks
{
    public class GetAllTasksInput : PagedAndSortedResultRequestDto
    {
        public string Searchkey { get; set; }
    }
}
