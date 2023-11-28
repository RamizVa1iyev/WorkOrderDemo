using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace WorkOrderDemo.Api.Domain.Exceptions;

public class WorkOrderProblemDetails : ProblemDetails
{
    public override string ToString() => JsonConvert.SerializeObject(this);
}
