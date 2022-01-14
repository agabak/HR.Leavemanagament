using HR.Leavemanagament.Application.DTOs;
using HR.Leavemanagament.Application.Features;
using HR.Leavemanagament.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HR.Leavemanagament.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveAllocationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveAllocationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<LeaveAllocationController>
        [HttpGet]
        public async Task<ActionResult<LeaveAllocationDto>>  Get()
        {
            return Ok(await _mediator.Send(new GetLeaveAllocationRequest()));
        }

        // GET api/<LeaveAllocationController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveAllocationDto>> Get(int id)
        {
            return Ok(await _mediator.Send(new GetLeaveAllocationDetailRequest { Id = id }));
        }

        // POST api/<LeaveAllocationController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateLeaveAllocationDto createDto)
        {
            return Ok(await _mediator.Send(new CreateLeaveAllocationCommand { createAllocationDto = createDto}));
        }

        // PUT api/<LeaveAllocationController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Put([FromBody] UpdateLeaveAllocationDto updateDto)
        {
            return Ok(await _mediator.Send(new UpdateLeaveAllocationCommand { UpdateLeaveAllocationDto = updateDto }));
        }

        // DELETE api/<LeaveAllocationController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteLeaveAllocationCommand { Id = id });
            return NoContent();
        }
    }
}
