using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace MediHub.Touchee.Products.Dto
{
    [AutoMapFrom(typeof(Product))]
    public class ProductDto:EntityDto<int>
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
        public int Quantity { get; set; }
    }
}
