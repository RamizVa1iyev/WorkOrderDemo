using Microsoft.AspNetCore.Mvc;
using WorkOrderDemo.Api.Domain.AggregateModels.WorkOrderAggregate;

namespace WorkOrderDemo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkOrderStatusController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = WorkOrderStatus.List();

            return Ok(result);
        }
    }
}
