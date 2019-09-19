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

        
    }
}
