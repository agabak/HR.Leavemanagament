using MediatR;

namespace HR.Leavemanagament.Application.Features
{
    public class DeleteLeaveAllocationCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
