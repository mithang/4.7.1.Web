using System.ComponentModel.DataAnnotations;

namespace MediHub.Dashboard.Blazor.ViewModels
{
    public class Product
    {
        [Required]
        public string name { get; set; }
        [Required]
        public int quantity { get; set; }
        [Required]
        
        public int id { get; set; }
    }
}   