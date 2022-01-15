using HR.Leavemanagament.Application.Responses;
using MediatR;

namespace HR.Leavemanagament.Application.Features
{
    public class DeleteLeaveTypeCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}
