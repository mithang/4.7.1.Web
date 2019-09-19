using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MediHub.Touchee.Configuration;
using MediHub.Touchee.Web;

namespace MediHub.Touchee.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class ToucheeDbContextFactory : IDesignTimeDbContextFactory<ToucheeDbContext>
    {
        public ToucheeDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ToucheeDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            ToucheeDbContextConfigurer.Configure(builder, configuration.GetConnectionString(ToucheeConsts.ConnectionStringName));

            return new ToucheeDbContext(builder.Options);
        }
    }
}
