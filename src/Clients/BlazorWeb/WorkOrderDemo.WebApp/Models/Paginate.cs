namespace WorkOrderDemo.WebApp.Models;

public class Paginate<T>
{
    public int Index { get; set; }

    public int Size { get; set; }

    public int Count { get; set; }

    public int Pages { get; set; }

    public int From { get; set; }

    public List<T> Items { get; set; }

    public bool HasPrevious { get; set; }

    public bool HasNext { get; set; }
}
