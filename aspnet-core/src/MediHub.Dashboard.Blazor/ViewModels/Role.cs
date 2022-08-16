using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MediHub.Dashboard.Blazor.ViewModels
{
    public class Role
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(200)]
        public string DisplayName { get; set; }

        public string NormalizedName { get; set; }
        
        public string Description { get; set; }

        public List<string> GrantedPermissions { get; set; }
    }
}