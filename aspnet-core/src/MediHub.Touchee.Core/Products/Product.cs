using System;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using MediHub.Touchee.Authorization.Users;

namespace MediHub.Touchee.Products
{
    												
    public class Product : Entity<int>
    {
        public string Name { get; set; }
        public string Assignment { get; set; }
        public string ProjectName { get; set; }
        public string Difficulty { get; set; }
        public string UrgentLevel { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime ExpectedCheckout { get; set; }
        public string ExpectedDuration { get; set; }
        public DateTime Checkout { get; set; }
        public string OfftimeOverage { get; set; }
        public bool Overtime { get; set; }
        public float PercentilePerformance { get; set; }
        
        //ProjectID
    }

    //Khong dung IFullAudited trong entity nay
    //public class Product:Entity<int>,IFullAudited<User>
    //{
    //    public string Name { get; set; }
    //    public int Quantity { get; set; }

    //    //Implement các thuộc tinh, Kế thừa từ IFullAudited<User>
    //    public User CreatorUser { get ; set ; }
    //    public User LastModifierUser { get ; set ; }
    //    public long? CreatorUserId { get ; set ; }
    //    public DateTime CreationTime { get ; set ; }
    //    public long? LastModifierUserId { get ; set ; }
    //    public DateTime? LastModificationTime { get ; set ; }
    //    public User DeleterUser { get ; set ; }
    //    public long? DeleterUserId { get ; set ; }
    //    public DateTime? DeletionTime { get ; set ; }
    //    public bool IsDeleted { get ; set ; }
    //}
}
