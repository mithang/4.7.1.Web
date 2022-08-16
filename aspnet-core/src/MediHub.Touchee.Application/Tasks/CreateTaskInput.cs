using System;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;

namespace MediHub.Touchee.Tasks
{
    [AutoMapTo(typeof(Task))]
    public class CreateTaskInput
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

    }
}
