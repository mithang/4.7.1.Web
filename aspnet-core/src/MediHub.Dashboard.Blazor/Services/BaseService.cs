using System.Collections.Generic;
using MediHub.Dashboard.Blazor.ViewModels;

namespace MediHub.Dashboard.Blazor.Services
{


    public class BaseService
    {
        
        public string targetUrl { get; set; }
        public bool success { get; set; }
        public string error { get; set; }
        public bool unAuthorizedRequest { get; set; }
        public bool __abp { get; set; }
        
    }
    public class ListProduct
    {
        public List<Product> items { get; set; }
    }
    public class ProductDto:BaseService
    {
        public ListProduct result { get; set; }
    }
    
    public class ProductItemDto:BaseService{
        public Product result { get; set; }
    }
}