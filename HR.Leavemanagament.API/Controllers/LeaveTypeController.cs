using HR.Leavemanagament.Application.DTOs;
using HR.Leavemanagament.Application.Features;
using HR.Leavemanagament.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR.Leavemanagament.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<LeaveTypeController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveTypeDto>>> Get()
        {
            return Ok( await _mediator.Send(new GetLeaveTypeListRequest()));
        }

        // GET api/<LeaveTypeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDto>> Get(int id)
        {
            return  Ok(await _mediator.Send(new GetLeaveTypeDetailRequest { Id = id} ));
        }

        // POST api/<LeaveTypeController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateLeaveTypeDto  createDto)
        {
            return Ok(await _mediator.Send(new CreateLeaveTypeCommand { LeaveTypeDto = createDto }));
        }

        // PUT api/<LeaveTypeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Put(int id, [FromBody] UpdateLeaveTypeDto updateDto)
        {
            return Ok(await _mediator.Send(new UpdateLeaveTypeCommand { UpdateLeaveTypeDto = updateDto }));
        }

        // DELETE api/<LeaveTypeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteLeaveTypeCommand { Id = id });

            return NoContent();
        }
    }
}
