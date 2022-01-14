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
    public class LeaveRequestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LeaveRequestController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveRequestListDto>>> Get()
        {
            return Ok(await _mediator.Send(new GetLeaveRequestRequest()));
        }

        // GET api/<LeaveRequestController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequestDto>>  Get(int id)
        {
            return  Ok(await _mediator.Send(new GetLeaveRequestDetailRequest{ Id = id }));
        }

        // POST api/<LeaveRequestController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateLeaveRequestDto createDto)
        {
            return Ok(await _mediator.Send(new CreateLeaveRequestCommand { CreateLeaveRequestDto = createDto }));
        }

        // PUT api/<LeaveRequestController>/5
        [HttpPut]
        public async Task<ActionResult<BaseCommandResponse>> Put([FromBody] UpdateLeaveRequestDto   updateDto)
        {
            return Ok(await _mediator.Send(new UpdateLeaveRequestCommand { UpdateLeaveRequestDto = updateDto }));
        }

        // PUT api/<LeaveRequestController>/5
        [HttpPut("changeapproval")]
        public async Task<ActionResult<BaseCommandResponse>> ChangeApproval([FromBody] ChangeLeaveRequestApprovalDto approvalDto)
        {
            return Ok(await _mediator.Send(new ChangeLeaveRequestApprovalCommand { ChangeLeaveRequestApproval = approvalDto }));
        }

        // DELETE api/<LeaveRequestController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteLeaveRequestCommand { Id = id });
            return NoContent();
        }
    }
}
