using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace WorkOrderDemo.Api.Infrastructure.Persistence.Context;

public class WorkOrderDbContextDesignFactory : IDesignTimeDbContextFactory<WorkOrderDbContext>
{

    public WorkOrderDbContext CreateDbContext(string[] args)
    {
        var connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=WorkOrderDb; Trusted_Connection=True;";

        var optionsBuilder = new DbContextOptionsBuilder<WorkOrderDbContext>()
                                 .UseSqlServer(connectionString);

        return new WorkOrderDbContext(optionsBuilder.Options);
    }
}
