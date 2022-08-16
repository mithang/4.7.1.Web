using System;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;

namespace MediHub.Touchee.Tasks
{
    public class Task : Entity, IHasCreationTime
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreationTime { get; set; }


        public Task()
        {
            CreationTime = Clock.Now;
        }

      
    }
}
