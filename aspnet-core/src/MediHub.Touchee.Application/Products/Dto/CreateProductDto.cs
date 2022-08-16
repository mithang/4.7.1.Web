using System;
using System.ComponentModel.DataAnnotations;
using Abp.Auditing;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using MediHub.Touchee.Authorization.Users;
using MediHub.Touchee.Products;

namespace MediHub.Touchee.Products.Dto
{
    [AutoMapTo(typeof(Product))]
    public class CreateProductDto
    {
      
        [Required]
        public string Name { get; set; }

        [Required]
        public int Quantity { get; set; }
        
        [Required]
        public string Assignment { get; set; }
        [Required]
        public string ProjectName { get; set; }
        [Required]
        public string Difficulty { get; set; }
        [Required]
        public string UrgentLevel { get; set; }
        [Required]
        public DateTime Checkin { get; set; }
        [Required]
        public DateTime ExpectedCheckout { get; set; }
        [Required]
        public string ExpectedDuration { get; set; }
        [Required]
        public DateTime Checkout { get; set; }
        [Required]
        public string OfftimeOverage { get; set; }
        public bool Overtime { get; set; }
        public float PercentilePerformance { get; set; }
    }
}
