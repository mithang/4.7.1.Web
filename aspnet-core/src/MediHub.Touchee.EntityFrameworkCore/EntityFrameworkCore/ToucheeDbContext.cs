using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MediHub.Touchee.Authorization.Roles;
using MediHub.Touchee.Authorization.Users;
using MediHub.Touchee.MultiTenancy;

namespace MediHub.Touchee.EntityFrameworkCore
{
    public class ToucheeDbContext : AbpZeroDbContext<Tenant, Role, User, ToucheeDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public ToucheeDbContext(DbContextOptions<ToucheeDbContext> options)
            : base(options)
        {
        }
    }
}
