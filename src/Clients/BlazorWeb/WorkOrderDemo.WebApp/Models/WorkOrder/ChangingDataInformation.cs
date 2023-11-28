namespace WorkOrderDemo.WebApp.Models.WorkOrder;


public class ChangingDataInformation
{
    public List<string> DeletedWorkOrdersMessages { get; set; }

    public List<string> DeletedVisitsMessages { get; set; }

    public List<string> DeletedPartsMessages { get; set; }

    public List<string> ChangedQuantitiesMessages { get; set; }

    public List<string> ChangedPricesMessages { get; set; }
}
