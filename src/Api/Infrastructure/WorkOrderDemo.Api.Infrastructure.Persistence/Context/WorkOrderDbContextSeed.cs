using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Polly;
using Polly.Retry;
using System.Globalization;
using System.Reflection;
using WorkOrderDemo.Api.Domain.AggregateModels.VisitAggregate;
using WorkOrderDemo.Api.Domain.AggregateModels.WorkOrderAggregate;

namespace WorkOrderDemo.Api.Infrastructure.Persistence.Context;

public class WorkOrderDbContextSeed
{
    private readonly string[] _visitors = { "John Smith", "Emily Johnson", "Michael Williams", "Sophia Brown", "James Miller",
                                            "Olivia Davis", "Daniel Wilson", "Ava Martinez", "William Garcia", "Grace Lopez"};

    private readonly string[] _parts = { "Component A", "Tool B", "Screwdriver", "Circuit Board", "Sensor Module", "Gear Wheel",
                                         "Microcontroller", "Battery Pack", "Actuator", "LED Display" };

    private readonly int[] _days = { -2, -3, -1, -12, -23, -21, -23, -4, -5, -6, -12, -32, -34, -21, -13, -19, -10, -16 };

    public async Task SeedAsync(WorkOrderDbContext dbContext)
    {
        var policy = CreatePolicy();

        await policy.ExecuteAsync(async () =>
        {
            if (!dbContext.WorkOrderStatus.Any())
            {
                dbContext.WorkOrderStatus.AddRange(WorkOrderStatus.List());

            }

            if (!dbContext.WorkOrderImportances.Any())
            {
                dbContext.WorkOrderImportances.AddRange(WorkOrderImportance.List());
            }

            if (!dbContext.WorkOrders.Any())
            {
                var workOrders = GetWorkOrdersSeedData();

                if (workOrders != null && workOrders.Count > 0)
                {
                    dbContext.WorkOrders.AddRange(workOrders);

                    foreach (var workOrder in workOrders)
                    {
                        List<Visit> visits = GenerateRandomVisits(workOrder.Id);

                        if (visits.Count > 0)
                        {
                            dbContext.Visits.AddRange(visits);
                        }
                    }
                }
            }

            await dbContext.SaveChangesAsync();
        });

    }

    private List<Visit> GenerateRandomVisits(Guid workOrderId)
    {
        List<Visit> visits = new List<Visit>();

        Random random = new Random();

        int count = random.Next(4);

        for (int i = 0; i < count; i++)
        {
            var visit = new Visit(workOrderId, _visitors[random.Next(_visitors.Length)], DateTime.Now.AddDays(_days[random.Next(_days.Length)]));

            int partCount = random.Next(1, 6);

            for (int j = 0; j < partCount; j++)
            {
                visit.AddVisitPart(_parts[random.Next(_parts.Length)], random.Next(1, 10), random.Next(150));
            }

            visits.Add(visit);
        }

        return visits;
    }

    private List<WorkOrder>? GetWorkOrdersSeedData()
    {
        string fileName = "Seeding/Setup/WorkOrder.txt";

        if (!File.Exists(fileName))
            return null;

        var fileContext = File.ReadAllLines(fileName);

        var result = new List<WorkOrder>();

        foreach (var line in fileContext)
        {
            var columns = line.Split(' ');
            var workOrder = new WorkOrder(Convert.ToInt32(columns[0]),
                                          DateTime.ParseExact(columns[1], "yyyy-MM-dd", CultureInfo.InvariantCulture),
                                          columns[2].Replace('_', ' '),
                                          columns[3].Replace('_', ' '));

            result.Add(workOrder);
        }

        return result;
    }

    private AsyncRetryPolicy CreatePolicy()
    {
        return Policy.Handle<SqlException>()
            .RetryAsync(retryCount: 3);
    }
}
