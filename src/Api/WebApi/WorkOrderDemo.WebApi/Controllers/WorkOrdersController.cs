using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorkOrderDemo.Api.Application.Features.Commends.ChangeDatas;
using WorkOrderDemo.Api.Application.Features.Commends.CreateWorkOrder;
using WorkOrderDemo.Api.Application.Features.Commends.DeleteWorkOrder;
using WorkOrderDemo.Api.Application.Features.Commends.UpdateWorkOrder;
using WorkOrderDemo.Api.Application.Features.Queries.GetWorkOrderDetailById;
using WorkOrderDemo.Api.Application.Features.Queries.GetWorkOrderDetails;
using WorkOrderDemo.Api.Application.Features.Queries.ViewModels;
using WorkOrderDemo.Api.Domain.SeedWork.Paging;

namespace WorkOrderDemo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkOrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkOrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IPaginate<WorkOrderDetail>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync([FromQuery] int index, [FromQuery] int size)
        {
            var query = new GetWorkOrderDetailsQuery(index, size);

            var result = await _mediator.Send(query);

            return Ok(result);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(WorkOrderDetail), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var query = new GetWorkOrderDetailByIdQuery(id);

            var result = await _mediator.Send(query);

            return Ok(result);
        }


        [HttpPost]
        [ProducesResponseType(typeof(WorkOrderDetail), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddAsync([FromBody] CreateWorkOrderCommand createWorkOrder)
        {
            var result = await _mediator.Send(createWorkOrder);

            return Ok(result);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(typeof(WorkOrderDetail), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateWorkOrderCommand updateWorkOrder, [FromRoute] Guid id)
        {
            updateWorkOrder.Id = id;
            var result = await _mediator.Send(updateWorkOrder);

            return Ok(result);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var command = new DeleteWorkOrderCommand(id);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("ChangeDatasRandomly")]
        [ProducesResponseType(typeof(ChangingDataInformation), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ChangeDatasRandomly()
        {
            var command = new ChangeDatasCommand();

            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
