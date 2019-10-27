using System.Collections.Generic;
using System.Threading.Tasks;
using MediHub.Dashboard.Blazor.ViewModels;
using Refit;

namespace MediHub.Dashboard.Blazor.Services
{
    public interface IDataServiceInterface
    {
        
            [Get("/todos/{id}")]
            Task<Todo> GetToDo(int id);
            [Get("/api/services/app/Products/GetAllProduct")]
            Task<ProductDto> GetProducts();
            [Get("/api/services/app/Products/GetProduct?Id={id}")]
            Task<ProductItemDto> GetProductById(int id);


    }
}