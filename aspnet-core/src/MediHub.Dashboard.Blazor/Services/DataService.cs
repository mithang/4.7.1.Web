using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MediHub.Dashboard.Blazor.ViewModels;
using Refit;


namespace MediHub.Dashboard.Blazor.Services
{
    public class DataService:IDataServiceInterface
    {
        
        private readonly BeamApiService _apiService;
        public IReadOnlyList<Frequency> Frequencies { get; private set; }
        public IReadOnlyList<Ray> Rays { get; private set; } = new List<Ray>();
        public User CurrentUser { get; set; }

        private int? selectedFrequency;
//        public int SelectedFrequency
//        {
//            get
//            {
//                if (!selectedFrequency.HasValue && Frequencies.Count > 0)
//                {
//                    selectedFrequency = Frequencies.First().Id;
//                }
//                return selectedFrequency ?? 0;
//            }
//            set
//            {
//                selectedFrequency = value;
//                GetRays(value).ConfigureAwait(false);
//            }
//        }
//
//        public DataService(BeamApiService apiService)
//        {
//            _apiService = apiService;
//            if (CurrentUser == null) CurrentUser = new User() { Name = "Anon" + new Random().Next(0, 10) };
//        }
//
//        public event Action UdpatedFrequencies;
//        public event Action UpdatedRays;
//
//        public async Task GetFrequencies()
//        {
//            //Frequencies = await _apiService.FrequencyList(); 
//            UdpatedFrequencies?.Invoke();
//        }
//
//        public async Task GetRays(int FrequencyId)
//        {
//            Rays = new List<Ray>();
//            //Rays = await _apiService.RayList(FrequencyId); 
//            UpdatedRays?.Invoke();
//        }
//
//        public async Task AddFrequency(string Name)
//        {
//            Frequencies = await _apiService.AddFrequency(new Frequency() { Name = Name });  
//            UdpatedFrequencies?.Invoke();
//        }
//
//        public async Task CreateRay(string text)
//        {
//            var ray = new Ray()
//            {
//                FrequencyId = selectedFrequency.Value,
//                Text = text,
//                UserId = CurrentUser.Id
//            };
//
//            if (CurrentUser.Id == 0)
//            {
//                await GetOrCreateUser();
//                ray.UserId = CurrentUser.Id;
//            }
//
//            Rays = await _apiService.AddRay(ray); 
//            UpdatedRays?.Invoke();
//        }
//
//        public async Task GetOrCreateUser(string newName = null)
//        {
//            //CurrentUser = await _apiService.GetOrCreateUser(newName ?? CurrentUser.Name); 
//        }
//
//        public async Task PrismRay(int RayId)
//        {
//            if (CurrentUser.Id == 0) await GetOrCreateUser();
//            Rays = await _apiService.PrismRay(new Prism() { RayId = RayId, UserId = CurrentUser.Id }); 
//            UpdatedRays?.Invoke();
//        }
//
//        public async Task UnPrismRay(int RayId)
//        {
//            if (CurrentUser.Id == 0) await GetOrCreateUser();
//            //Rays = await _apiService.UnPrismRay(RayId, CurrentUser.Id); 
//            UpdatedRays?.Invoke();
//        }
//
//        public async Task<List<Ray>> GetUserRays(string name)
//        {
//            //return await _apiService.UserRays(name ?? CurrentUser.Name);
//            return await Task.FromResult(new List<Ray>());
//        }
//        
        public async Task<List<Role>> GetRoles()
        {
            HttpClient http = new HttpClient();
            var r = http.GetAsync("http://localhost:21021/api/services/app/Role/GetAll");
            //var k = r.Result as List<Role>();
            return await Task.FromResult(new List<Role>());
        }

        public async Task<Todo> GetToDo(int id)
        {
            var gitHubApi = RestService.For<IDataServiceInterface>("https://jsonplaceholder.typicode.com");

            var toDoList = await gitHubApi.GetToDo(id);
            
            return toDoList;
        }

        public async Task<ProductDto> GetProducts()
        {
            
            var gitHubApi = RestService.For<IDataServiceInterface>("http://localhost:21021");

            var toDoList = await gitHubApi.GetProducts();
            
            return toDoList;
        }

        public async Task<ProductItemDto> GetProductById(int id)
        {
            var gitHubApi = RestService.For<IDataServiceInterface>("http://localhost:21021");

            var toDoList = await gitHubApi.GetProductById(id);
            
            return toDoList;
        }
    }
}