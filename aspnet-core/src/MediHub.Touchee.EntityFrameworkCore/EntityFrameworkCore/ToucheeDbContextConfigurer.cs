using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MediHub.Touchee.EntityFrameworkCore
{
    public static class ToucheeDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ToucheeDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ToucheeDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
