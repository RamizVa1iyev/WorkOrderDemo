using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorkOrderDemo.Api.Application.Features.Commends.CreateVisit;
using WorkOrderDemo.Api.Application.Features.Commends.DeleteVisit;
using WorkOrderDemo.Api.Application.Features.Commends.UpdateVisit;
using WorkOrderDemo.Api.Application.Features.Queries.GetVisitDetailById;
using WorkOrderDemo.Api.Application.Features.Queries.GetVisitDetails;
using WorkOrderDemo.Api.Application.Features.Queries.ViewModels;
using WorkOrderDemo.Api.Domain.SeedWork.Paging;

namespace WorkOrderDemo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VisitsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IPaginate<VisitDetail>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync([FromQuery] int index, [FromQuery] int size, [FromQuery] Guid? workOrderId)
        {
            var query = new GetVisitDetailsQuery(index, size, workOrderId);

            var result = await _mediator.Send(query);

            return Ok(result);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(VisitDetail), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var query = new GetVisitDetailByIdQuery(id);

            var result = await _mediator.Send(query);

            return Ok(result);
        }


        [HttpPost]
        [ProducesResponseType(typeof(VisitDetail), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddAsync([FromBody] CreateVisitCommand createVisit)
        {
            var result = await _mediator.Send(createVisit);

            return Ok(result);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(typeof(VisitDetail), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateVisitCommand updateVisit, [FromRoute] Guid id)
        {
            updateVisit.Id = id;
            var result = await _mediator.Send(updateVisit);

            return Ok(result);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var command = new DeleteVisitCommand(id);

            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
