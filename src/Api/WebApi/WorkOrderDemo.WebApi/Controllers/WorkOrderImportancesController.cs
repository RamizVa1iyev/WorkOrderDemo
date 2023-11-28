using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkOrderDemo.Api.Domain.AggregateModels.WorkOrderAggregate;

namespace WorkOrderDemo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkOrderImportancesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = WorkOrderImportance.List();

            return Ok(result);
        }
    }
}
