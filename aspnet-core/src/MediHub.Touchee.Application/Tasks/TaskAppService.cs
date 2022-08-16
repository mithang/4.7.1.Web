using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Net.Mail;
using Abp.Runtime.Caching;
using Castle.Core.Logging;
using MediHub.Touchee.Core.Emails;
using MediHub.Touchee.Products;
using MediHub.Touchee.Products.Dto;

namespace MediHub.Touchee.Tasks
{
    public class TaskAppService : AsyncCrudAppService<Task, TaskDto, int, GetAllTasksInput, CreateTaskInput, UpdateTaskInput>
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Task> _taskRepository;

        public ILogger Logger { get; set; }

        private readonly ICacheManager _cacheManager;
        

        public TaskAppService(ICacheManager cacheManager,IRepository<Task> repository, IUnitOfWorkManager unitOfWorkManager, IRepository<Product> productRepository)
            : base(repository)
        {
            //CreatePermissionName = "MyTaskCreationPermission";
            _unitOfWorkManager = unitOfWorkManager;
            _productRepository = productRepository;
            _taskRepository = repository;

            Logger = NullLogger.Instance;

            _cacheManager = cacheManager;
            

        }

        protected override IQueryable<Task> CreateFilteredQuery(GetAllTasksInput input)
        {
            return (System.Linq.IQueryable<MediHub.Touchee.Tasks.Task>)base.CreateFilteredQuery(input)
                .WhereIf(input.Searchkey.Length > 0, t => t.Title == input.Searchkey);
        }

        public void CreateTaskAndProduct(CreateProductDto input)
        {
//            var product = new Product { 
//                Name = input.Name, 
//                Quantity = input.Quantity 
//            };
            var task = new Task {
                Title="T2",
                Description="t2"
            }; 

            using (var unitOfWork = _unitOfWorkManager.Begin())
            {
                //_productRepository.Insert(product);
                //throw new Exception("loi"); Test Transaction
                _taskRepository.Insert(task);
                Logger.Info("GHI LOG -> CreateTaskAndProduct: " + input.Name);
                unitOfWork.Complete();
            }
        }

        //[UnitOfWork]
        //public SearchPeopleOutput SearchPeople(SearchPeopleInput input)
        //{
        //    // get IQueryable<Person>
        //    var query = _personRepository.GetAll();

        //    // add some filters if selected
        //    if (!string.IsNullOrEmpty(input.SearchedName))
        //    {
        //        query = query.Where(person => person.Name.StartsWith(input.SearchedName));
        //    }

        //    if (input.IsActive.HasValue)
        //    {
        //        query = query.Where(person => person.IsActive == input.IsActive.Value);
        //    }

        //    // get paged result list
        //    var people = query.Skip(input.SkipCount).Take(input.MaxResultCount).ToList();

        //    return new SearchPeopleOutput { People = Mapper.Map<List<PersonDto>>(people) };
        //}

        //public void CreateTask(CreateTaskInput input)
        //{
        //    var task = new Task { Description = input.Description };

        //    if (input.AssignedPersonId.HasValue)
        //    {
        //        task.AssignedPersonId = input.AssignedPersonId.Value;
        //        _unitOfWorkManager.Current.Completed += (sender, args) => { /* TODO: Send email to assigned person */ };
        //    }

        //    _taskRepository.Insert(task);
        //}

        //public class SimpleTaskSystemCoreModule : AbpModule
        //{
        //    public override void PreInitialize()
        //    {
        //        Configuration.UnitOfWork.IsolationLevel = IsolationLevel.ReadCommitted;
        //        Configuration.UnitOfWork.Timeout = TimeSpan.FromMinutes(30);
        //    }

        //    //...other module methods
        //}

        public string GetItem(string key)
        {
            //Try to get from cache
            return _cacheManager
                    .GetCache("MyCache")
                    .Get(key,()=>key);
        }

        public string SetItem(string key)
        {
            var value = key + new Random().Next(20);
            //Try to get from cache
            _cacheManager
                    .GetCache("MyCache").Set(key, value);
            return value;
        }

        public async Task<string> SendEmail()
        {
            try
            {
                var emailSender = new EmailSender();
                await emailSender.SendEmailAsync("minh.tran@medihub.com.vn","Test...","<p> Hoan Thanh...<br/> OK </p>");
                return await System.Threading.Tasks.Task.FromResult("OK");
            }
            catch (Exception ex) {
                return await System.Threading.Tasks.Task.FromResult(ex.Message);
            }
           
        }
    }
}
