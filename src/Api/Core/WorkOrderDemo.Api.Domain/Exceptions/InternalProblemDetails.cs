using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WorkOrderDemo.Api.Domain.Exceptions;

public class InternalProblemDetails : ProblemDetails
{
    public override string ToString() => JsonConvert.SerializeObject(this);
}
