using System.ComponentModel.DataAnnotations;

namespace WorkOrderDemo.WebApp.Models.WorkOrder;

public class WorkOrderDetail
{
    public Guid? Id { get; set; }

    public int OrderImportanceId { get; set; }

    public string OrderImportance { get; set; }

    public int OrderStatusId { get; set; }

    public string OrderStatus { get; set; }

    [Required]
    public DateTime Deadline { get; set; }

    [Required]
    public string OrderingCompanyName { get; set; }

    [Required]
    public string Description { get; set; }

    public int CountOfVisits { get; set; }

    public int CountOfParts { get; set; }
}
