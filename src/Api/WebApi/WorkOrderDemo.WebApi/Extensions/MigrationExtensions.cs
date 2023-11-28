using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WorkOrderDemo.Api.Infrastructure.Persistence.Context;

namespace WorkOrderDemo.WebApi.Extensions
{
    public static class MigrationExtensions
    {
        public static void MigrateAndSeed(this IConfiguration configuration)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WorkOrderDbContext>()
                .UseSqlServer(configuration.GetConnectionString("WorkOrderConnectionString"));

            var dbContext = new WorkOrderDbContext(optionsBuilder.Options);
            dbContext.Database.Migrate();
            WorkOrderDbContextSeed seeder = new WorkOrderDbContextSeed();
            seeder.SeedAsync(dbContext).Wait();
        }
    }
}
