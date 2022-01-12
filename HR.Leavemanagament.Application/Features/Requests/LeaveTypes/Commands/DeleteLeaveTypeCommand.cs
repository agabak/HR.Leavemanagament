using HR.Leavemanagament.Application.Responses;
using MediatR;

namespace HR.Leavemanagament.Application.Features
{
    public class DeleteLeaveTypeCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
